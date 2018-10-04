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

namespace Rubik.StockTaking
{


    [Screen("STK050", "Stock Taking Pack Entry", eShowAction.Normal, eScreenType.Screen, "Stock Taking Pack Entry")]
    public partial class STK050_StockTakingPackEntry : CustomizeForm
    {
        #region Enum

        private enum eScreenMode
        {
            ADD
        } ;

        public enum eColView
        {
            LOT_NO,
            EXTERNAL_LOT_NO,
            QTY
        } ;
        #endregion

        #region Variables

        private readonly ItemBIZ m_bizItem = new ItemBIZ();

        private eScreenMode m_screenMode = eScreenMode.ADD;
        private DialogResult m_dialogResult = DialogResult.Cancel;
        private KeyboardSpread m_keyboardSpread = null;

        private string m_Location = null;
        private FarPoint.Win.Spread.SheetView m_ParentSheet;

        #endregion

        #region Constructor

        public STK050_StockTakingPackEntry()
        {
            InitializeComponent();
        }

        public STK050_StockTakingPackEntry(string Location, FarPoint.Win.Spread.SheetView sheet)
        {
            InitializeComponent();
            m_Location = Location;
            m_ParentSheet = sheet;
        }
        #endregion

        #region Initialize Screen

        private void InitializeScreen()
        {
            FormatUtil.SetNumberFormat(txtTotalQty, FormatUtil.eNumberFormat.Qty_PCS);
            FormatUtil.SetNumberFormat(txtNumberOfBox, FormatUtil.eNumberFormat.Qty_Box);
            FormatUtil.SetNumberFormat(shtView.Columns[(int)eColView.QTY], FormatUtil.eNumberFormat.Qty_PCS);

            txtMasterNo.KeyPress += CtrlUtil.SetNextControl;
            txtTagNo.KeyPress += CtrlUtil.SetNextControl;
            txtPackNo.KeyPress += CtrlUtil.SetNextControl;
            txtFGNo.KeyPress += CtrlUtil.SetNextControl;
            txtNumberOfBox.KeyPress += CtrlUtil.SetNextControl;


            InitializeSpread();

        }
        private void InitializeSpread()
        {
            shtView.ActiveSkin = Common.ACTIVE_SKIN;

            m_keyboardSpread = new KeyboardSpread(fpView);
            m_keyboardSpread.RowAdding += new KeyboardSpread.RowAddingHandler(m_keyboardSpread_RowAdding);
            m_keyboardSpread.RowAdded += new KeyboardSpread.RowAddedHandler(m_keyboardSpread_RowAdded);
            m_keyboardSpread.RowRemoving += new KeyboardSpread.RowRemovingHandler(m_keyboardSpread_RowRemoving);
            m_keyboardSpread.RowRemoved += new KeyboardSpread.RowRemovedHandler(m_keyboardSpread_RowRemoved);
            fpView.SubEditorOpening += CtrlUtil.SpreadDisableSubEditorOpening;
            //LookupDataBIZ biz = new LookupDataBIZ();

            //shtView.Columns[(int)eColView.INV_UM_CLS].CellType = CtrlUtil.CreateReadOnlyPairCellType(biz.LoadLookupClassType(DataDefine.UM_CLS.ToNZString()));
            CtrlUtil.MappingDataFieldWithEnum(shtView, typeof(eColView));
        }

        #endregion

        #region Keyboard Spread
        void m_keyboardSpread_RowAdding(object sender, EventRowAdding e)
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
        void m_keyboardSpread_RowAdded(object sender, int rowIndex)
        {
            CtrlUtil.SpreadSetCellLocked(shtView, false, rowIndex, (int)eColView.LOT_NO);
            CtrlUtil.SpreadSetCellLocked(shtView, false, rowIndex, (int)eColView.EXTERNAL_LOT_NO);
            CtrlUtil.SpreadSetCellLocked(shtView, false, rowIndex, (int)eColView.QTY);

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
        void m_keyboardSpread_RowRemoved(object sender)
        {
            CalculateTotalQty();
        }
        #endregion

        #region Screen mode
        private void SetScreenMode(eScreenMode mode)
        {
            switch (mode)
            {
                case eScreenMode.ADD:

                    txtNumberOfBox.Int = 1;
                    CtrlUtil.ClearControlData(txtMasterNo, txtPartNo, txtPackNo, txtItemDesc, txtTotalQty, txtFGNo, txtTagNo);
                    CtrlUtil.ClearControlData(shtView);

                    CtrlUtil.EnabledControl(true, txtMasterNo, txtFGNo, txtNumberOfBox, txtTagNo);
                    CtrlUtil.EnabledControl(false, txtPartNo, txtItemDesc, txtTotalQty, txtPackNo);

                    m_keyboardSpread.StartBind();
                    shtView.OperationMode = OperationMode.Normal;

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
            RemoveRowUnused(shtView);

            if (txtNumberOfBox.Int <= 0)
                txtNumberOfBox.Int = 1; 

            try
            {
                ValidateBeforeSave();

                MessageDialogResult dr = MessageDialog.ShowConfirmation(this, Message.LoadMessage(Messages.eConfirm.CFM9001.ToString()));
                if (dr == MessageDialogResult.Cancel)
                {
                    return;
                }
                if (dr == MessageDialogResult.Yes)
                {
                    SaveData();
                    SetScreenMode(eScreenMode.ADD);

                    CtrlUtil.FocusControl(txtMasterNo);
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
            ////if (txtItemCode.SelectedItemData != null)
            ////    numWorkResultQty_KeyPress(numWorkResultQty, new KeyPressEventArgs((char)Keys.Return));

            if (txtNumberOfBox.Int <= 0)
                txtNumberOfBox.Int = 1; 

            try
            {
                ValidateBeforeSave();

                MessageDialogResult dr = MessageDialog.ShowConfirmation(this, Message.LoadMessage(Messages.eConfirm.CFM9001.ToString()));
                if (dr == MessageDialogResult.Cancel)
                {
                    return;
                }
                if (dr == MessageDialogResult.Yes)
                {
                    SaveData();
                }

                m_dialogResult = DialogResult.OK;
                this.Close();
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

        #region Private method

        private void RemoveRowUnused(SheetView sheet)
        {
            int lastRowNonEmpty = sheet.GetLastNonEmptyRow(NonEmptyItemFlag.Data);
            if (lastRowNonEmpty != sheet.RowCount - 1)
            {
                sheet.RemoveRows(sheet.RowCount - 1, 1);
            }
        }
        private void GoToNextRow()
        {
            int iCurrentRow = shtView.ActiveRowIndex;
            int iCurrentColumn = shtView.ActiveColumnIndex;

            if (iCurrentColumn == (int)eColView.QTY)
            {
                if (iCurrentRow < shtView.RowCount)
                {
                    shtView.SetActiveCell(iCurrentRow + 1, iCurrentColumn, false);

                }
            }

        }

        private void CalculateTotalQty()
        {
            decimal decTotalQty = 0;
            for (int iRow = 0; iRow < shtView.RowCount; iRow++)
            {
                string Qty = shtView.Cells[iRow, (int)eColView.QTY].Text;
                if (String.IsNullOrEmpty(Qty))
                    continue;

                decTotalQty = decTotalQty + Convert.ToDecimal(Qty);
            }
            txtTotalQty.Text = decTotalQty.ToString();
        }

        private void ValidateBeforeSave()
        {
            ItemValidator itemValidator = new ItemValidator();            
            ValidateException.ThrowErrorItem(itemValidator.CheckEmptyItemCode(txtMasterNo.Text.ToNZString()));

            //PackingValidator validator = new PackingValidator();
            //ValidateException.ThrowErrorItem(validator.CheckEmptyFGNo(txtFGNo.Text.ToNZString()));
        }
        private void SaveData()
        {
            if (m_ParentSheet == null)
                return;

            int iBox = txtNumberOfBox.Int == 0 ? 1 : txtNumberOfBox.Int;

            for (int box = 0; box < iBox; box++)
            {
                NZString strPackNo = new NZString();
                if (string.Empty.Equals(txtPackNo.Text.Trim()))
                {
                    StockTakingBIZ biz = new StockTakingBIZ();
                    strPackNo = biz.GeneratePackNo();
                }
                else
                {
                    strPackNo = new NZString(txtPackNo, txtPackNo.Text);
                }

                for (int i = 0; i < shtView.RowCount; i++)
                {
                    m_ParentSheet.RowCount = m_ParentSheet.RowCount + 1;

                    //m_ParentSheet.Cells[m_ParentSheet.RowCount - 1, (int)STK030_StockTakingEntry.eColView.STOCK_TAKING_ID].Value = string.Empty;
                    //m_ParentSheet.Cells[m_ParentSheet.RowCount - 1, (int)STK030_StockTakingEntry.eColView.EFFECT_INVENTORY_FLAG].Value = false;
                    //m_ParentSheet.Cells[m_ParentSheet.RowCount - 1, (int)STK030_StockTakingEntry.eColView.COUNTING_ID].Value = string.Empty;
                    m_ParentSheet.Cells[m_ParentSheet.RowCount - 1, (int)STK030_StockTakingEntry.eColView.ITEM_CD].Value = txtMasterNo.Text.Trim();
                    //m_ParentSheet.Cells[m_ParentSheet.RowCount - 1, (int)STK030_StockTakingEntry.eColView.BTN_ITEM_CD].Value = null;
                    m_ParentSheet.Cells[m_ParentSheet.RowCount - 1, (int)STK030_StockTakingEntry.eColView.SHORT_NAME].Value = txtPartNo.Text.Trim();
                    m_ParentSheet.Cells[m_ParentSheet.RowCount - 1, (int)STK030_StockTakingEntry.eColView.CUST_NAME].Value = txtItemDesc.Text.Trim();
                    m_ParentSheet.Cells[m_ParentSheet.RowCount - 1, (int)STK030_StockTakingEntry.eColView.LOC_CD].Value = m_Location;
                    m_ParentSheet.Cells[m_ParentSheet.RowCount - 1, (int)STK030_StockTakingEntry.eColView.LOT_NO].Value = shtView.Cells[i, (int)eColView.LOT_NO].Value;
                    m_ParentSheet.Cells[m_ParentSheet.RowCount - 1, (int)STK030_StockTakingEntry.eColView.EXTERNAL_LOT_NO].Value = shtView.Cells[i, (int)eColView.EXTERNAL_LOT_NO].Value;
                    m_ParentSheet.Cells[m_ParentSheet.RowCount - 1, (int)STK030_StockTakingEntry.eColView.PACK_NO].Value = strPackNo.StrongValue;//txtPackNo.Text.Trim();
                    m_ParentSheet.Cells[m_ParentSheet.RowCount - 1, (int)STK030_StockTakingEntry.eColView.FG_NO].Value = txtFGNo.Text.Trim();//txtPackNo.Text.Trim();
                    m_ParentSheet.Cells[m_ParentSheet.RowCount - 1, (int)STK030_StockTakingEntry.eColView.SYSTEM_QTY].Value = 0;
                    m_ParentSheet.Cells[m_ParentSheet.RowCount - 1, (int)STK030_StockTakingEntry.eColView.COUNT_QTY].Value = shtView.Cells[i, (int)eColView.QTY].Value;
                    m_ParentSheet.Cells[m_ParentSheet.RowCount - 1, (int)STK030_StockTakingEntry.eColView.DIFF_QTY].Value = shtView.Cells[i, (int)eColView.QTY].Value;
                    //m_ParentSheet.Cells[m_ParentSheet.RowCount - 1, (int)STK030_StockTakingEntry.eColView.ADJUSTED_FLAG].Value = 0;
                    m_ParentSheet.Cells[m_ParentSheet.RowCount - 1, (int)STK030_StockTakingEntry.eColView.MANUAL_ADD_FLAG].Value = 1;
                    //m_ParentSheet.Cells[m_ParentSheet.RowCount - 1, (int)STK030_StockTakingEntry.eColView.TAG_NO].Value = string.Empty;
                    //m_ParentSheet.Cells[m_ParentSheet.RowCount - 1, (int)STK030_StockTakingEntry.eColView.REMARK].Value = string.Empty;
                    m_ParentSheet.Cells[m_ParentSheet.RowCount - 1, (int)STK030_StockTakingEntry.eColView.ROW_STATUS].Value = (int)STK030_StockTakingEntry.eRowStatus.ADD;
                    m_ParentSheet.Cells[m_ParentSheet.RowCount - 1, (int)STK030_StockTakingEntry.eColView.TAG_NO].Value = this.txtTagNo.Text.Trim();
                }
            }
        }

        #endregion

        #region Form event

        private void TRN080_Load(object sender, EventArgs e)
        {
            InitializeScreen();

            if (m_ParentSheet == null)
                return;

            SetScreenMode(eScreenMode.ADD);
        }
        private void TRN080_Shown(object sender, EventArgs e)
        {
            CtrlUtil.FocusControl(txtMasterNo);
        }
        private void TRN080_FormClosed(object sender, FormClosedEventArgs e)
        {
            DialogResult = m_dialogResult;
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
            try
            {
                int rowIndex = shtView.ActiveRowIndex;
                int colIndex = shtView.ActiveColumnIndex;

                bool bValidateCellPass = ValidateCellEdited(rowIndex, colIndex);
                if (!bValidateCellPass)
                {
                    shtView.SetActiveCell(rowIndex, colIndex);
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
        private void fpView_LeaveCell(object sender, LeaveCellEventArgs e)
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
        private void fpView_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyData == Keys.Escape)
                {
                    RemoveRowUnused(shtView);
                }

                if (e.KeyData == Keys.Enter)
                {

                    GoToNextRow();
                }

            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusiness(this, ex.Message);
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
            switch (column)
            {
                case (int)eColView.LOT_NO:

                    string LotNo = shtView.Cells[row, (int)eColView.LOT_NO].Text;
                    FormatUtil.CheckFormatLotNo(LotNo.ToNZString());

                    break;
                case (int)eColView.QTY:

                    string Qty = shtView.Cells[row, (int)eColView.QTY].Text;
                    if (String.IsNullOrEmpty(Qty))
                    {
                        ErrorItem error = new ErrorItem(null, TKPMessages.eValidate.VLM0175.ToString());
                        throw new BusinessException(error);
                    }

                    CalculateTotalQty();
                    break;
            }

            return true;
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
            string LotNo = shtView.Cells[row, (int)eColView.LOT_NO].Text;

            if (String.IsNullOrEmpty(LotNo))
            {
                ErrorItem error = new ErrorItem(null, TKPMessages.eValidate.VLM0011.ToString());
                MessageDialog.ShowBusiness(this, error.Message);
                return false;
            }

            string Qty = shtView.Cells[row, (int)eColView.QTY].Text;
            if (String.IsNullOrEmpty(Qty))
            {
                ErrorItem error = new ErrorItem(null, TKPMessages.eValidate.VLM0175.ToString());
                MessageDialog.ShowBusiness(this, error.Message);
                return false;
            }

            //check format lotno
            if (!(string.Empty.Equals(shtView.Cells[row, (int)eColView.LOT_NO].Text)))
            {
                try
                {
                    FormatUtil.CheckFormatLotNo(new NZString(null, shtView.Cells[row, (int)eColView.LOT_NO].Text));
                }
                catch (ValidateException ex)
                {
                    MessageDialog.ShowBusiness(this, ex.ErrorResults[0].Message);
                    return false;
                }
            }

            //Check dupllicate lot
            for (int iRow = 0; iRow < shtView.Rows.Count; iRow++)
            {
                if (iRow == row)
                    continue;

                // Check key duplidate.
                string lot_no = shtView.Cells[iRow, (int)eColView.LOT_NO].Text;

                if (Equals(LotNo, lot_no))
                {
                    MessageDialog.ShowBusiness(this, Message.LoadMessage(TKPMessages.eValidate.VLM0189.ToString()));
                    return false;
                }
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
        }

        private void btnItemCode_Click(object sender, EventArgs e)
        {
            txtItemCode_KeyPressResult(txtMasterNo, (txtMasterNo.SelectedItemData != null), (NZString)txtMasterNo.Text);

        }

        private void txtPartNo_Validating(object sender, CancelEventArgs e)
        {
            if (string.Empty.Equals(txtPartNo.Text.Trim()))
            {
                txtMasterNo.Text = string.Empty;
                txtItemDesc.Text = string.Empty;
                return;
            }

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
                txtItemDesc.Text = dto.CUSTOMER_NAME;
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

        private void fpView_KeyDown(object sender, KeyEventArgs e)
        {
            CtrlUtil.FilterShortCut(e);
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

        private void txtNumberOfBox_Validating(object sender, CancelEventArgs e)
        {
            if (txtNumberOfBox.Int <= 0)
                txtNumberOfBox.Int = 1; 
        }
    }


}
