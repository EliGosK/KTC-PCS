
using System;
using System.Collections.Generic;
using System.Drawing;
using EVOFramework.Data;
using Rubik.BIZ;
using EVOFramework;
using EVOFramework.Windows.Forms;
using Rubik.Controller;
using Rubik.UIDataModel;
using Rubik.Validators;
using System.Windows.Forms;
using Rubik.DTO;
using CommonLib;
using Rubik.Data;
using FarPoint.Win.Spread;
using SystemMaintenance;
using System.Data;

namespace Rubik.MRP {
    //[Screen("MRP030", "MRP Maintenance", eShowAction.Normal, eScreenType.Screen, "MRP Maintenance")]
    public class MRP030_MRPMaintenance : SystemMaintenance.Forms.CustomizeForm {

        #region Enum

        public enum eScreenMode {
            View,
            Idle,
            Add,
            Edit,
        }

        private enum eColumn {
            MRP_NO,
            ITEM_CD,
            ORDER_LOC_CD,
            AT_DATE,
            INCOMING_QTY,
            OUTGOING_QTY,
            REQ_QTY,
            ACT_REQ_QTY,
            ACT_REQ_LOT_QTY,
            ORDER_QTY,
            ON_HAND_QTY,
            BAL_QTY,
            BAL_LOT_QTY
        };

        private enum eModifyState {
            None,
            Add,
            Edit,
            Delete
        }



        #endregion

        #region Member

        private ContextMenuStrip ctxMenu;
        private System.ComponentModel.IContainer components;
        private ToolStripMenuItem tsmiAdd;

        private DialogResult m_dialogResult = DialogResult.No;
        private eScreenMode m_eScreenMode = eScreenMode.Idle;
        private KeyboardSpread m_keyboardSpread = null;

        /// <summary>
        /// เก็บสถานะว่าตอนนี้ Row นั้น มีบาง Cell ที่ถูกปรับเปลี่ยนค่า
        /// </summary>
        private bool m_bRowHasModified = false;
        private ToolStripMenuItem tsmiDelete;
        /// <summary>
        /// เก็บรายการของแถวที่กำลังแก้
        /// </summary>
        private readonly Map<eColumn, object> m_mapCellValue = new Map<eColumn, object>();
        private EVOIntegerTextBox txtReorderPoint;
        private EVOIntegerTextBox txtMinimumOrder;
        private EVOIntegerTextBox txtLotSize;
        private EVOIntegerTextBox txtLeadTime;
        private EVOIntegerTextBox txtSafetyStock;
        private Dictionary<string, string> m_dictDateList = null;        

        #endregion

        #region Constructor

        public MRP030_MRPMaintenance() {
            InitializeComponent();

            this.shtView.ActiveSkin = Common.ACTIVE_SKIN;
            this.WindowState = FormWindowState.Maximized;
            this.tsbSaveAndNew.Text = "Save And Refresh";
            CtrlUtil.ClearControlData(this.Controls);
            InitialCombobox();
            InitialSpread();
            
            dtpDateFrom.Format = Common.CurrentUserInfomation.DateFormatString;
            dtpDateTo.Format = Common.CurrentUserInfomation.DateFormatString;
        }


        public MRP030_MRPMaintenance(NZString MRP_NO, NZInt RevisionNo, NZString ITEM_CD, NZString LOC_CD, NZDateTime PERIOD_BEGIN, NZDateTime PERIOD_END)
            : this() {
            if (!(string.Empty.Equals(MRP_NO))) {
                txtMRPNo.Text = MRP_NO.Value.ToString();
                txtRevisionNo.Text = RevisionNo.Value.ToString();
                txtItemCode.Text = ITEM_CD.Value.ToString();
                txtLocCD.Text = LOC_CD.Value.ToString();
                dtpDateFrom.Value = (DateTime)PERIOD_BEGIN.Value;
                dtpDateTo.Value = (DateTime)PERIOD_END.Value;

                LoadData();
                SetScreenMode(eScreenMode.Edit);
            }
            else {
                SetScreenMode(eScreenMode.Idle);
            }
        }

        #endregion

        #region Override method

        public override void OnSaveAndClose() {
            fpView.StopCellEditing();
            if (m_bRowHasModified) { // ถ้า Row กำลังแก้ไขอยู่
                if (!ValidateRowSpread(shtView.ActiveRowIndex, false)) {
                    return;
                }
            }

            // ต้องเรียกก่อน Save เสมอ  เพื่อ Commit ข้อมูลการแก้ไขล่าสุดบน Grid
            // ใช้ได้เฉพาะกับ Sheet ที่ผูก DataSource
            CtrlUtil.SpreadSheetRowEndEdit(shtView, shtView.ActiveRowIndex);
            RemoveRowUnused(shtView);

            try {

                MessageDialogResult dr = MessageDialog.ShowConfirmation(this, EVOFramework.Message.LoadMessage(Messages.eConfirm.CFM9001.ToString()));
                if (dr == MessageDialogResult.Cancel || dr == MessageDialogResult.No) {
                    return;
                }
                if (dr == MessageDialogResult.Yes) {
                    SaveData();
                    MessageDialog.ShowInformation(this, null, EVOFramework.Message.LoadMessage(Messages.eInformation.INF9003.ToString()).MessageDescription);
                }

                m_dialogResult = DialogResult.OK;
                this.Close();
            }
            catch (ValidateException err) {
                MessageDialog.ShowBusiness(this, err.ErrorResults[0].Message);
                err.ErrorResults[0].FocusOnControl();
            }
            catch (BusinessException err) {
                MessageDialog.ShowBusiness(this, err.Error.Message);
                err.Error.FocusOnControl();
            }
            catch (Exception err) {
                MessageDialog.ShowBusiness(this, null, err.Message);
            }
        }

        public override void OnSaveAndNew() {
            fpView.StopCellEditing();
            if (m_bRowHasModified) { // ถ้า Row กำลังแก้ไขอยู่
                if (!ValidateRowSpread(shtView.ActiveRowIndex, false)) {
                    return;
                }
            }

            // ต้องเรียกก่อน Save เสมอ  เพื่อ Commit ข้อมูลการแก้ไขล่าสุดบน Grid
            // ใช้ได้เฉพาะกับ Sheet ที่ผูก DataSource
            CtrlUtil.SpreadSheetRowEndEdit(shtView, shtView.ActiveRowIndex);
            RemoveRowUnused(shtView);

            try {

                MessageDialogResult dr = MessageDialog.ShowConfirmation(this, EVOFramework.Message.LoadMessage(Messages.eConfirm.CFM9001.ToString()));
                if (dr == MessageDialogResult.Cancel || dr == MessageDialogResult.No) {
                    return;
                }
                if (dr == MessageDialogResult.Yes) {
                    SaveData();
                    MessageDialog.ShowInformation(this, null, EVOFramework.Message.LoadMessage(Messages.eInformation.INF9003.ToString()).MessageDescription);
                    
                    LoadData();
                    SetScreenMode(eScreenMode.Edit);                    
                }
            }
            catch (ValidateException err) {
                MessageDialog.ShowBusiness(this, err.ErrorResults[0].Message);
                err.ErrorResults[0].FocusOnControl();
            }
            catch (BusinessException err) {
                MessageDialog.ShowBusiness(this, err.Error.Message);
                err.Error.FocusOnControl();
            }
            catch (Exception err) {
                MessageDialog.ShowBusiness(this, null, err.Message);
            }
        }

        #endregion

        #region General Method

        private void SetScreenMode(eScreenMode eScreenMode) {
            m_eScreenMode = eScreenMode;
            switch (m_eScreenMode) {
                case eScreenMode.Edit:
                    CtrlUtil.EnabledControl(false, dtpDateFrom, dtpDateTo, txtMRPNo, txtRevisionNo, txtItemCode, txtLocCD);
                    CtrlUtil.EnabledControl(false, txtLotSize, txtMinimumOrder, txtReorderPoint, txtSafetyStock);
                    CtrlUtil.EnabledControl(false, txtLeadTime, txtSafetyLeadTime, cboOrderCondition);
                    //CtrlUtil.EnabledControl(true, tsbSaveAndClose);
                    //CtrlUtil.EnabledControl(false, tsbSaveAndNew);

                    CtrlUtil.SpreadSetColumnsLocked(shtView, false, (int)eColumn.ORDER_QTY);
                    LockCellAT_DATE();
                    m_keyboardSpread.StartBind();

                    break;
            }
        }

        private void InitialCombobox() {
            LookupDataBIZ BIZLookupData = new LookupDataBIZ();

            cboOrderCondition.Format += CommonLib.Common.ComboBox_Format;
            cboOrderCondition.LoadLookupData(BIZLookupData.LoadLookupClassType(DataDefine.ORDER_CONDITION.ToNZString()));
            cboOrderCondition.SelectedIndex = -1;
        }
        private void InitialSpread() {
            shtView.RowCount = 0;

            CtrlUtil.MappingDataFieldWithEnum(shtView, typeof(eColumn));

            shtView.Columns[(int)eColumn.AT_DATE].CellType = CtrlUtil.CreateDateTimeCellType(Common.CurrentUserInfomation.DateFormatString);
            shtView.Columns[(int)eColumn.AT_DATE].HorizontalAlignment = CellHorizontalAlignment.Center;
            shtView.Columns[(int)eColumn.MRP_NO].Visible = false;
            shtView.Columns[(int)eColumn.ITEM_CD].Visible = false;
            shtView.Columns[(int)eColumn.ORDER_LOC_CD].Visible = false;
            shtView.Columns[(int)eColumn.BAL_QTY].Visible = false;
            //shtView.Columns[(int)eColumn.REQ_QTY].Visible = false;

            //for (int i = 0; i < shtView.ColumnCount; i++) {
            //    shtView.Columns[i].AllowAutoFilter = true;
            //    shtView.Columns[i].AllowAutoSort = true;
            //}

            m_keyboardSpread = new KeyboardSpread(fpView);
            m_keyboardSpread.RowAdding += new KeyboardSpread.RowAddingHandler(m_keyboardSpread_RowAdding);
            m_keyboardSpread.RowAdded += new KeyboardSpread.RowAddedHandler(m_keyboardSpread_RowAdded);
            m_keyboardSpread.RowRemoving += new KeyboardSpread.RowRemovingHandler(m_keyboardSpread_RowRemoving);
            m_keyboardSpread.RowRemoved += new KeyboardSpread.RowRemovedHandler(m_keyboardSpread_RowRemoved);
        }
        private void LockCellAT_DATE() {
            bool bLock = true;
            for (int iRowIdx = 0; iRowIdx < shtView.RowCount; iRowIdx++) {
                bLock = !CanModifyDate(iRowIdx);
                CtrlUtil.SpreadSetCellLocked(shtView, bLock, iRowIdx, (int)eColumn.AT_DATE);
            }
        }

        private void RemoveRowUnused(SheetView sheet) {
            int lastRowNonEmpty = sheet.GetLastNonEmptyRow(NonEmptyItemFlag.Data);
            if (lastRowNonEmpty != sheet.RowCount - 1) {
                sheet.RemoveRows(sheet.RowCount - 1, 1);
            }
        }
        /// <summary>
        /// เก็บข้อมูลทุก Cell ของ Row ที่ระบุ
        /// </summary>
        /// <param name="rowIndex"></param>
        private void StoreCellValues(int rowIndex) {
            m_mapCellValue.RemoveAll();
            for (int i = 0; i < shtView.Columns.Count; i++) {
                m_mapCellValue.Put((eColumn)i, shtView.Cells[rowIndex, i].Value);
            }
        }

        /// <summary>
        /// คืนค่า Cell ที่เก็บไว้ กลับคืนไปยัง Row ที่ระบุ
        /// </summary>
        /// <param name="rowIndex"></param>
        private void RestoreCellValues(int rowIndex) {
            if (m_mapCellValue.Count > 0) {
                for (int i = 0; i < m_mapCellValue.Count; i++) {
                    shtView.Cells[rowIndex, (int)m_mapCellValue[i].Key].Value = m_mapCellValue[i].Value;
                }
            }
        }

        /// <summary>
        /// Validate เมื่อ Cell มีการแก้ไขเรียบร้อย  และค่าที่แก้ไขเป็นค่าใหม่
        /// </summary>
        /// <param name="row"></param>
        /// <param name="column"></param>
        private bool ValidateCellEdited(int row, int column) {

            //switch (column) {
            //    case (int)eColumn.AT_DATE:

            //        NZDateTime dtmAT_DATE = new NZDateTime(null, shtView.Cells[row, (int)eColumn.AT_DATE].Value);
            //        NZDateTime dtmDATE_FROM = new NZDateTime(null, dtpDateFrom.Value);
            //        NZDateTime dtmDATE_TO = new NZDateTime(null, dtpDateTo.Value);

            //        if (dtmAT_DATE.IsNull) {
            //            return true;
            //            //ErrorItem error = new ErrorItem(null, TKPMessages.eValidate.VLM0154.ToString());
            //            //MessageDialog.ShowBusiness(this, error.Message);
            //            //return false;
            //        }

            //        //Validate Date is in range date from-to                    
            //        if ((DateTime.Compare(dtmAT_DATE.StrongValue.Date, dtmDATE_FROM.StrongValue.Date) < 0)
            //            || (DateTime.Compare(dtmAT_DATE.StrongValue.Date, dtmDATE_TO.StrongValue.Date) > 0)) 
            //        {
            //            //shtView.Cells[row, (int)eColumn.AT_DATE].Value = null;
            //            ErrorItem error = new ErrorItem(null, TKPMessages.eValidate.VLM0155.ToString());
            //            MessageDialog.ShowBusiness(this, error.Message);
            //            return false;
            //        }

            //        if (CheckExistsDate(dtmAT_DATE)) 
            //        {
            //            //shtView.Cells[row, (int)eColumn.AT_DATE].Value = null;
            //            ErrorItem error = new ErrorItem(null, TKPMessages.eValidate.VLM0152.ToString());
            //            MessageDialog.ShowBusiness(this, error.Message);
            //            return false;
            //        }                    

            //        break;

            //    case (int)eColumn.ORDER_QTY:

            //        //// Check Order Qty row insert, qty cannot be tmpty or zero
            //        NZString strMRP_No = new NZString(null, shtView.Cells[row, (int)eColumn.MRP_NO].Value);
            //        NZDecimal qty = new NZDecimal(null, shtView.Cells[row, (int)eColumn.ORDER_QTY].Value);

            //        if ((!strMRP_No.IsNull) && (!string.Empty.Equals(strMRP_No.StrongValue)))
            //            return true;

            //        if (qty.IsNull || qty.StrongValue == decimal.Zero) {

            //            //order qty cannot be null
            //            ErrorItem error = new ErrorItem(null, TKPMessages.eValidate.VLM0153.ToString());
            //            MessageDialog.ShowBusiness(this, error.Message);
            //            return false;
            //        }
            //        break;
            //}

            return true;
        }
        private bool ValidateRowSpread(int row, bool forceValidate) {
            if (!forceValidate && !m_bRowHasModified)
                return true;

            NZString strMRP_No = new NZString(null, shtView.Cells[row, (int)eColumn.MRP_NO].Value);  
            if ((!strMRP_No.IsNull) && (!string.Empty.Equals(strMRP_No.StrongValue)))
                return true;

            if (!ValidateCell(row, (int)eColumn.AT_DATE))
                return false;

            if (!ValidateCell(row, (int)eColumn.ORDER_QTY))
                return false;

            // ถ้า Validate Row ผ่าน แสดงว่า แถวนั้นไม่จำเป็นต้องเช็คอีกรอบ
            m_bRowHasModified = false;
            return true;
        }

        private bool ValidateCell(int row, int column) {

            switch (column) {
                case (int)eColumn.AT_DATE:

                    NZDateTime dtmAT_DATE = new NZDateTime(null, shtView.Cells[row, (int)eColumn.AT_DATE].Value);
                    NZDateTime dtmDATE_FROM = new NZDateTime(null, dtpDateFrom.Value);
                    NZDateTime dtmDATE_TO = new NZDateTime(null, dtpDateTo.Value);

                    if (dtmAT_DATE.IsNull) {
                        ErrorItem error = new ErrorItem(null, TKPMessages.eValidate.VLM0154.ToString());
                        MessageDialog.ShowBusiness(this, error.Message);
                        return false;
                    }

                    //Validate Date is in range date from-to                    
                    if ((DateTime.Compare(dtmAT_DATE.StrongValue.Date, dtmDATE_FROM.StrongValue.Date) < 0)
                        || (DateTime.Compare(dtmAT_DATE.StrongValue.Date, dtmDATE_TO.StrongValue.Date) > 0)) {
                        //shtView.Cells[row, (int)eColumn.AT_DATE].Value = null;
                        ErrorItem error = new ErrorItem(null, TKPMessages.eValidate.VLM0155.ToString());
                        MessageDialog.ShowBusiness(this, error.Message);
                        return false;
                    }

                    if (CheckExistsDate(dtmAT_DATE)) {
                        //shtView.Cells[row, (int)eColumn.AT_DATE].Value = null;
                        ErrorItem error = new ErrorItem(null, TKPMessages.eValidate.VLM0152.ToString());
                        MessageDialog.ShowBusiness(this, error.Message);
                        return false;
                    }

                    break;

                case (int)eColumn.ORDER_QTY:

                    //// Check Order Qty row insert, qty cannot be tmpty or zero
                    NZString strMRP_No = new NZString(null, shtView.Cells[row, (int)eColumn.MRP_NO].Value);
                    NZDecimal qty = new NZDecimal(null, shtView.Cells[row, (int)eColumn.ORDER_QTY].Value);

                    if ((!strMRP_No.IsNull) && (!string.Empty.Equals(strMRP_No.StrongValue)))
                        return true;

                    if (qty.IsNull || qty.StrongValue == decimal.Zero) {

                        //order qty cannot be null
                        ErrorItem error = new ErrorItem(null, TKPMessages.eValidate.VLM0153.ToString());
                        MessageDialog.ShowBusiness(this, error.Message);
                        return false;
                    }
                    break;
            }

            return true;
        }

        private void LoadData() {

            MRPHDTO dtoMRPH = new MRPHDTO();

            MRPBIZ biz = new MRPBIZ();
            dtoMRPH = biz.LoadMRPHByPK(txtMRPNo.Text.Trim(), txtItemCode.Text.Trim(), txtLocCD.Text.Trim());
            if (dtoMRPH != null) {

                txtMRPNo.Text = dtoMRPH.MRP_NO.Value.ToString();
                txtRevisionNo.Text = dtoMRPH.REVISION_NO.Value.ToString();
                txtItemCode.Text = dtoMRPH.ITEM_CD.Value.ToString();
                txtLocCD.Text = dtoMRPH.ORDER_LOC_CD.Value.ToString();
                txtLotSize.Text = dtoMRPH.LOT_SIZE.Value.ToString();
                txtMinimumOrder.Text = dtoMRPH.MINIMUM_ORDER.Value.ToString();
                txtReorderPoint.Text = dtoMRPH.REORDER_POINT.Value.ToString();
                txtSafetyStock.Text = dtoMRPH.SAFETY_STOCK.Value.ToString();
                txtLeadTime.Text = dtoMRPH.LEADTIME.Value.ToString();
                txtSafetyLeadTime.Text = dtoMRPH.SAFETY_LEADTIME.Value.ToString();
                cboOrderCondition.SelectedValue = dtoMRPH.ORDER_CONDITION.Value.ToString();

                //Load Detail
                DataTable dt = biz.LoadMRPDByItem((NZString)txtMRPNo.Text.Trim(),
                                       (NZString)txtItemCode.Text.Trim(),
                                       (NZString)txtLocCD.Text.Trim(),
                                       (NZDateTime)dtpDateFrom.Value,
                                       (NZDateTime)dtpDateTo.Value);

                shtView.DataSource = dt;
                KeepDataList(dt);
            }
        }
        private void SaveData() {
            DataTable dtData = (DataTable)shtView.DataSource;
            if (dtData == null || dtData.Rows.Count == 0)
                return;

            DataTable dtInsert = dtData.GetChanges(DataRowState.Added);
            DataTable dtUpdate = dtData.GetChanges(DataRowState.Modified);
            DataTable dtDelete = dtData.GetChanges(DataRowState.Deleted);

            if (dtInsert == null && dtUpdate == null && dtDelete == null)
                return;

            MRPHDTO dtoHeader = new MRPHDTO();
            dtoHeader.MRP_NO = (NZString)txtMRPNo.Text.Trim();
            dtoHeader.ITEM_CD = (NZString)txtItemCode.Text.Trim();
            dtoHeader.ORDER_LOC_CD = (NZString)txtLocCD.Text.Trim();
            dtoHeader.REVISION_NO = (NZDecimal)(Convert.ToInt32(txtRevisionNo.Text.Trim()) + 1);
            dtoHeader.UPD_BY = Common.CurrentUserInfomation.UserCD;
            dtoHeader.UPD_MACHINE = Common.CurrentUserInfomation.Machine;

            List<MRPDDTO> dtoInsert = null;
            List<MRPDDTO> dtoUpdate = null;
            List<MRPDDTO> dtoDelete = null;

            //Insert Item 
            if (dtInsert != null && dtInsert.Rows.Count > 0) {
                foreach (DataRow dr in dtInsert.Rows) {
                    dr[(int)eColumn.MRP_NO] = txtMRPNo.Text.Trim();
                    dr[(int)eColumn.ITEM_CD] = txtItemCode.Text.Trim();
                    dr[(int)eColumn.ORDER_LOC_CD] = txtLocCD.Text.Trim();                    
                }
                dtoInsert = DTOUtility.ConvertDataTableToList<MRPDDTO>(dtInsert);
            }
            //Update Item
            if (dtUpdate != null && dtUpdate.Rows.Count > 0)
                dtoUpdate = DTOUtility.ConvertDataTableToList<MRPDDTO>(dtUpdate);

            //Delete Item
            if (dtDelete != null && dtDelete.Rows.Count > 0)
                dtoDelete = DTOUtility.ConvertDataTableToList<MRPDDTO>(dtDelete);

            MRPBIZ biz = new MRPBIZ();
            biz.SaveData(dtoHeader, dtoInsert, dtoUpdate, dtoDelete);

        }
        private void KeepDataList(DataTable dt) {            
            m_dictDateList = new Dictionary<string, string>();
            if (dt == null)
                return;

            MRPDDTO dto = null;
            string strDate = string.Empty;
            foreach (DataRow dr in dt.Rows) {
                dto = DTOUtility.ConvertDataRowToDTO<MRPDDTO>(dr);
                strDate = dto.AT_DATE.StrongValue.ToString(Common.CurrentUserInfomation.DateFormatString);
                m_dictDateList.Add(strDate, strDate);
            }
        }
        private bool CheckExistsDate(NZDateTime dtmDate) {
            if (m_dictDateList.ContainsKey(dtmDate.StrongValue.ToString(Common.CurrentUserInfomation.DateFormatString)))
                return true;

            return false;
        }

        private bool CanDeleteRecord(int iRowIdx) {            
            if (shtView.Rows.Count == 0)
                return false;

            MRPDDTO dtoDetail = GetCurrentDTO(iRowIdx); 
  
            MRPBIZ biz = new MRPBIZ();
            return biz.CheckCanDelete(dtoDetail);
        }
        private bool CanModifyDate(int iRowIdx) {
            if (shtView.Rows.Count == 0)
                return false;

            MRPDDTO dtoDetail = GetCurrentDTO(iRowIdx);             

            MRPBIZ biz = new MRPBIZ();
            return biz.CheckCanModifyDate(dtoDetail);
        }
        private MRPDDTO GetCurrentDTO(int iRowIdx) 
        {
            MRPDDTO dtoDetail = new MRPDDTO();
            dtoDetail.MRP_NO = new NZString(null, shtView.GetValue(iRowIdx, (int)eColumn.MRP_NO));
            dtoDetail.ITEM_CD = new NZString(null, shtView.GetValue(iRowIdx, (int)eColumn.ITEM_CD));
            dtoDetail.ORDER_LOC_CD = new NZString(null, shtView.GetValue(iRowIdx, (int)eColumn.ORDER_LOC_CD));
            dtoDetail.AT_DATE = new NZDateTime(null, shtView.GetValue(iRowIdx, (int)eColumn.AT_DATE));
            dtoDetail.INCOMING_QTY = new NZDecimal(null, shtView.GetValue(iRowIdx, (int)eColumn.INCOMING_QTY));
            dtoDetail.OUTGOING_QTY = new NZDecimal(null, shtView.GetValue(iRowIdx, (int)eColumn.OUTGOING_QTY));
            dtoDetail.REQ_QTY = new NZDecimal(null, shtView.GetValue(iRowIdx, (int)eColumn.REQ_QTY));
            dtoDetail.ACT_REQ_QTY = new NZDecimal(null, shtView.GetValue(iRowIdx, (int)eColumn.ACT_REQ_QTY));
            dtoDetail.ACT_REQ_LOT_QTY = new NZDecimal(null, shtView.GetValue(iRowIdx, (int)eColumn.ACT_REQ_LOT_QTY));
            dtoDetail.ON_HAND_QTY = new NZDecimal(null, shtView.GetValue(iRowIdx, (int)eColumn.ON_HAND_QTY));

            return dtoDetail;
        }

        #endregion

        #region Event

        private void MRP021_MRPMaintenance_Load(object sender, EventArgs e) {

        }
        private void MRP021_MRPMaintenance_FormClosed(object sender, FormClosedEventArgs e) { 
            
            this.DialogResult = DialogResult.OK;
        }

        private void m_keyboardSpread_RowAdded(object sender, int rowIndex) {
            CtrlUtil.SpreadSetCellLocked(shtView, false, rowIndex, (int)eColumn.AT_DATE);
            CtrlUtil.SpreadSetCellLocked(shtView, false, rowIndex, (int)eColumn.ORDER_QTY);
        }
        private void m_keyboardSpread_RowAdding(object sender, EventRowAdding e) {
            if (m_bRowHasModified) { // ถ้า Row กำลังแก้ไขอยู่
                if (!ValidateRowSpread(shtView.ActiveRowIndex, false)) {
                    e.Cancel = true;
                    return;
                }
            }
            else {
                // ถ้าไม่มีการแก้ไข Row  แต่ก่อนที่จะเพิ่มแถวใหม่ จะต้อง Validate แถวล่าสุด (ล่างสุด) ก่อน
                if (shtView.RowCount > 0 && shtView.ActiveRowIndex >= 0) {
                    if (!ValidateRowSpread(shtView.RowCount - 1, true)) {
                        e.Cancel = true;
                        return;
                    }
                }
            }

            int rowIdx = shtView.RowCount - 1;
            NZString strMRP_NO = new NZString(null, shtView.GetValue(rowIdx, (int)eColumn.MRP_NO));
            if (strMRP_NO.IsNull || string.Empty.Equals(strMRP_NO.StrongValue)) 
            {
                string strDate = Convert.ToDateTime(shtView.GetValue(rowIdx, (int)eColumn.AT_DATE)).ToString(Common.CurrentUserInfomation.DateFormatString);
                if (m_dictDateList.ContainsKey(strDate))
                    return;

                m_dictDateList.Add(strDate, strDate);
            }
        }
        private void m_keyboardSpread_RowRemoving(object sender, EventRowRemoving e) {

            //MessageDialogResult dr = MessageDialog.ShowConfirmation(this, EVOFramework.Message.LoadMessage(Messages.eConfirm.CFM9002.ToString()), MessageDialogButtons.YesNo);
            //if (dr == MessageDialogResult.No) {
            //    e.Cancel = true;
            //}

            CanDeleteRecord(shtView.ActiveRowIndex);

            int rowIndex = shtView.ActiveRowIndex;
            int colIndex = (int)eColumn.AT_DATE;
            NZDateTime dtmDate = new NZDateTime(null, shtView.GetValue(rowIndex, colIndex));
            if (dtmDate.IsNull)
                return;
            string strDate = Convert.ToDateTime(dtmDate).ToString(Common.CurrentUserInfomation.DateFormatString);
            if (m_dictDateList.ContainsKey(strDate))
                m_dictDateList.Remove(strDate);
        }
        private void m_keyboardSpread_RowRemoved(object sender) {
            m_bRowHasModified = false;            
        }

        private void fpView_EditModeOn(object sender, EventArgs e) {

            // ถ้าเป็นการแก้ไข Cell ใน Row เดียวกัน เป็นครั้งแรก
            if (!m_bRowHasModified) {
                m_bRowHasModified = true;
                StoreCellValues(shtView.ActiveRowIndex);
            }
        }
        private void fpView_EditModeOff(object sender, EventArgs e) {
            int rowIndex = shtView.ActiveRowIndex;
            int colIndex = shtView.ActiveColumnIndex;

            bool bValidateCellPass = ValidateCellEdited(rowIndex, colIndex);
            if (!bValidateCellPass) {
                shtView.SetActiveCell(rowIndex, colIndex);
                return;
            }                                  
        }

        private void tsmiAdd_Click(object sender, EventArgs e) {
            m_keyboardSpread.OnActionAddNewRow();
        }
        private void tsmiDelete_Click(object sender, EventArgs e) {
            m_keyboardSpread.OnActionRemoveRow();
        }


        #endregion

        #region Control
        private EVOLabel evoLabel3;
        private EVOLabel evoLabel1;
        private EVOLabel stdReceiveDate;
        private EVOTextBox txtMRPNo;
        private EVOTextBox txtLocCD;
        private EVOTextBox txtItemCode;
        private EVOLabel evoLabel8;
        private EVOLabel evoLabel7;
        private EVOLabel evoLabel6;
        private EVOLabel evoLabel4;
        private EVOLabel evoLabel2;
        private EVOLabel evoLabel11;
        private EVOLabel evoLabel9;
        private EVOIntegerTextBox txtSafetyLeadTime;
        private FarPoint.Win.Spread.FpSpread fpView;
        private FarPoint.Win.Spread.SheetView shtView;
        private EVOTextBox txtRevisionNo;
        private EVOLabel evoLabel10;
        private EVOLabel evoLabel13;
        private EVOLabel evoLabel12;
        private EVODateTextBoxWithCalendar dtpDateFrom;
        private EVODateTextBoxWithCalendar dtpDateTo;
        private EVOComboBox cboOrderCondition;
        private EVOLabel evoLabel5;

        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            FarPoint.Win.Spread.CellType.TextCellType textCellType1 = new FarPoint.Win.Spread.CellType.TextCellType();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MRP030_MRPMaintenance));
            this.evoLabel5 = new EVOFramework.Windows.Forms.EVOLabel();
            this.stdReceiveDate = new EVOFramework.Windows.Forms.EVOLabel();
            this.evoLabel1 = new EVOFramework.Windows.Forms.EVOLabel();
            this.evoLabel3 = new EVOFramework.Windows.Forms.EVOLabel();
            this.txtItemCode = new EVOFramework.Windows.Forms.EVOTextBox();
            this.txtLocCD = new EVOFramework.Windows.Forms.EVOTextBox();
            this.txtMRPNo = new EVOFramework.Windows.Forms.EVOTextBox();
            this.evoLabel2 = new EVOFramework.Windows.Forms.EVOLabel();
            this.evoLabel4 = new EVOFramework.Windows.Forms.EVOLabel();
            this.evoLabel6 = new EVOFramework.Windows.Forms.EVOLabel();
            this.evoLabel7 = new EVOFramework.Windows.Forms.EVOLabel();
            this.evoLabel8 = new EVOFramework.Windows.Forms.EVOLabel();
            this.evoLabel9 = new EVOFramework.Windows.Forms.EVOLabel();
            this.evoLabel11 = new EVOFramework.Windows.Forms.EVOLabel();
            this.txtSafetyLeadTime = new EVOFramework.Windows.Forms.EVOIntegerTextBox();
            this.fpView = new FarPoint.Win.Spread.FpSpread();
            this.ctxMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.shtView = new FarPoint.Win.Spread.SheetView();
            this.evoLabel10 = new EVOFramework.Windows.Forms.EVOLabel();
            this.txtRevisionNo = new EVOFramework.Windows.Forms.EVOTextBox();
            this.dtpDateTo = new EVOFramework.Windows.Forms.EVODateTextBoxWithCalendar();
            this.dtpDateFrom = new EVOFramework.Windows.Forms.EVODateTextBoxWithCalendar();
            this.evoLabel12 = new EVOFramework.Windows.Forms.EVOLabel();
            this.evoLabel13 = new EVOFramework.Windows.Forms.EVOLabel();
            this.cboOrderCondition = new EVOFramework.Windows.Forms.EVOComboBox();
            this.txtLeadTime = new EVOFramework.Windows.Forms.EVOIntegerTextBox();
            this.txtLotSize = new EVOFramework.Windows.Forms.EVOIntegerTextBox();
            this.txtMinimumOrder = new EVOFramework.Windows.Forms.EVOIntegerTextBox();
            this.txtReorderPoint = new EVOFramework.Windows.Forms.EVOIntegerTextBox();
            this.txtSafetyStock = new EVOFramework.Windows.Forms.EVOIntegerTextBox();
            this.pnlContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fpView)).BeginInit();
            this.ctxMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.shtView)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlContainer
            // 
            this.pnlContainer.Controls.Add(this.txtSafetyStock);
            this.pnlContainer.Controls.Add(this.txtReorderPoint);
            this.pnlContainer.Controls.Add(this.txtMinimumOrder);
            this.pnlContainer.Controls.Add(this.txtLotSize);
            this.pnlContainer.Controls.Add(this.txtLeadTime);
            this.pnlContainer.Controls.Add(this.cboOrderCondition);
            this.pnlContainer.Controls.Add(this.evoLabel13);
            this.pnlContainer.Controls.Add(this.evoLabel12);
            this.pnlContainer.Controls.Add(this.dtpDateFrom);
            this.pnlContainer.Controls.Add(this.dtpDateTo);
            this.pnlContainer.Controls.Add(this.txtRevisionNo);
            this.pnlContainer.Controls.Add(this.evoLabel10);
            this.pnlContainer.Controls.Add(this.fpView);
            this.pnlContainer.Controls.Add(this.txtSafetyLeadTime);
            this.pnlContainer.Controls.Add(this.txtMRPNo);
            this.pnlContainer.Controls.Add(this.txtLocCD);
            this.pnlContainer.Controls.Add(this.txtItemCode);
            this.pnlContainer.Controls.Add(this.evoLabel3);
            this.pnlContainer.Controls.Add(this.evoLabel1);
            this.pnlContainer.Controls.Add(this.stdReceiveDate);
            this.pnlContainer.Controls.Add(this.evoLabel5);
            this.pnlContainer.Controls.Add(this.evoLabel8);
            this.pnlContainer.Controls.Add(this.evoLabel7);
            this.pnlContainer.Controls.Add(this.evoLabel6);
            this.pnlContainer.Controls.Add(this.evoLabel2);
            this.pnlContainer.Controls.Add(this.evoLabel11);
            this.pnlContainer.Controls.Add(this.evoLabel9);
            this.pnlContainer.Controls.Add(this.evoLabel4);
            this.pnlContainer.Font = new System.Drawing.Font("Tahoma", 12F);
            this.pnlContainer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pnlContainer.Size = new System.Drawing.Size(1041, 615);
            // 
            // evoLabel5
            // 
            this.evoLabel5.AppearanceName = "Title";
            this.evoLabel5.AutoSize = true;
            this.evoLabel5.ControlID = "";
            this.evoLabel5.Font = new System.Drawing.Font("Tahoma", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.evoLabel5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.evoLabel5.Location = new System.Drawing.Point(3, 1);
            this.evoLabel5.Name = "evoLabel5";
            this.evoLabel5.PathString = null;
            this.evoLabel5.PathValue = "MRP Maintenance";
            this.evoLabel5.Size = new System.Drawing.Size(304, 39);
            this.evoLabel5.TabIndex = 10004;
            this.evoLabel5.Text = "MRP Maintenance";
            // 
            // stdReceiveDate
            // 
            this.stdReceiveDate.AppearanceName = "";
            this.stdReceiveDate.AutoSize = true;
            this.stdReceiveDate.ControlID = "";
            this.stdReceiveDate.Font = new System.Drawing.Font("Tahoma", 12F);
            this.stdReceiveDate.Location = new System.Drawing.Point(25, 79);
            this.stdReceiveDate.Name = "stdReceiveDate";
            this.stdReceiveDate.PathString = null;
            this.stdReceiveDate.PathValue = "MRP No.";
            this.stdReceiveDate.Size = new System.Drawing.Size(70, 19);
            this.stdReceiveDate.TabIndex = 10005;
            this.stdReceiveDate.Text = "MRP No.";
            // 
            // evoLabel1
            // 
            this.evoLabel1.AppearanceName = "";
            this.evoLabel1.AutoSize = true;
            this.evoLabel1.ControlID = "";
            this.evoLabel1.Font = new System.Drawing.Font("Tahoma", 12F);
            this.evoLabel1.Location = new System.Drawing.Point(25, 113);
            this.evoLabel1.Name = "evoLabel1";
            this.evoLabel1.PathString = null;
            this.evoLabel1.PathValue = "Part No.";
            this.evoLabel1.Size = new System.Drawing.Size(67, 19);
            this.evoLabel1.TabIndex = 10006;
            this.evoLabel1.Text = "Part No.";
            // 
            // evoLabel3
            // 
            this.evoLabel3.AppearanceName = "";
            this.evoLabel3.AutoSize = true;
            this.evoLabel3.ControlID = "";
            this.evoLabel3.Font = new System.Drawing.Font("Tahoma", 12F);
            this.evoLabel3.Location = new System.Drawing.Point(25, 148);
            this.evoLabel3.Name = "evoLabel3";
            this.evoLabel3.PathString = null;
            this.evoLabel3.PathValue = "Supplier LOC";
            this.evoLabel3.Size = new System.Drawing.Size(102, 19);
            this.evoLabel3.TabIndex = 10008;
            this.evoLabel3.Text = "Supplier LOC";
            // 
            // txtItemCode
            // 
            this.txtItemCode.AppearanceName = "";
            this.txtItemCode.AppearanceReadOnlyName = "";
            this.txtItemCode.ControlID = "";
            this.txtItemCode.DisableRestrictChar = false;
            this.txtItemCode.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtItemCode.HelpButton = null;
            this.txtItemCode.Location = new System.Drawing.Point(122, 110);
            this.txtItemCode.MaxLength = 50;
            this.txtItemCode.Name = "txtItemCode";
            this.txtItemCode.PathString = null;
            this.txtItemCode.PathValue = "";
            this.txtItemCode.ReadOnly = true;
            this.txtItemCode.Size = new System.Drawing.Size(364, 27);
            this.txtItemCode.TabIndex = 10010;
            // 
            // txtLocCD
            // 
            this.txtLocCD.AppearanceName = "";
            this.txtLocCD.AppearanceReadOnlyName = "";
            this.txtLocCD.ControlID = "";
            this.txtLocCD.DisableRestrictChar = false;
            this.txtLocCD.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtLocCD.HelpButton = null;
            this.txtLocCD.Location = new System.Drawing.Point(122, 145);
            this.txtLocCD.MaxLength = 50;
            this.txtLocCD.Name = "txtLocCD";
            this.txtLocCD.PathString = null;
            this.txtLocCD.PathValue = "";
            this.txtLocCD.ReadOnly = true;
            this.txtLocCD.Size = new System.Drawing.Size(364, 27);
            this.txtLocCD.TabIndex = 10011;
            // 
            // txtMRPNo
            // 
            this.txtMRPNo.AppearanceName = "";
            this.txtMRPNo.AppearanceReadOnlyName = "";
            this.txtMRPNo.ControlID = "";
            this.txtMRPNo.DisableRestrictChar = false;
            this.txtMRPNo.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtMRPNo.HelpButton = null;
            this.txtMRPNo.Location = new System.Drawing.Point(122, 76);
            this.txtMRPNo.Name = "txtMRPNo";
            this.txtMRPNo.PathString = null;
            this.txtMRPNo.PathValue = "MRP110600001";
            this.txtMRPNo.ReadOnly = true;
            this.txtMRPNo.Size = new System.Drawing.Size(170, 27);
            this.txtMRPNo.TabIndex = 10012;
            this.txtMRPNo.Text = "MRP110600001";
            // 
            // evoLabel2
            // 
            this.evoLabel2.AppearanceName = "";
            this.evoLabel2.AutoSize = true;
            this.evoLabel2.ControlID = "";
            this.evoLabel2.Font = new System.Drawing.Font("Tahoma", 12F);
            this.evoLabel2.Location = new System.Drawing.Point(501, 45);
            this.evoLabel2.Name = "evoLabel2";
            this.evoLabel2.PathString = null;
            this.evoLabel2.PathValue = "Lot Size";
            this.evoLabel2.Size = new System.Drawing.Size(64, 19);
            this.evoLabel2.TabIndex = 10014;
            this.evoLabel2.Text = "Lot Size";
            // 
            // evoLabel4
            // 
            this.evoLabel4.AppearanceName = "";
            this.evoLabel4.AutoSize = true;
            this.evoLabel4.ControlID = "";
            this.evoLabel4.Font = new System.Drawing.Font("Tahoma", 12F);
            this.evoLabel4.Location = new System.Drawing.Point(761, 45);
            this.evoLabel4.Name = "evoLabel4";
            this.evoLabel4.PathString = null;
            this.evoLabel4.PathValue = "Leadtime";
            this.evoLabel4.Size = new System.Drawing.Size(73, 19);
            this.evoLabel4.TabIndex = 10015;
            this.evoLabel4.Text = "Leadtime";
            // 
            // evoLabel6
            // 
            this.evoLabel6.AppearanceName = "";
            this.evoLabel6.AutoSize = true;
            this.evoLabel6.ControlID = "";
            this.evoLabel6.Font = new System.Drawing.Font("Tahoma", 12F);
            this.evoLabel6.Location = new System.Drawing.Point(501, 113);
            this.evoLabel6.Name = "evoLabel6";
            this.evoLabel6.PathString = null;
            this.evoLabel6.PathValue = "Re-order Point";
            this.evoLabel6.Size = new System.Drawing.Size(112, 19);
            this.evoLabel6.TabIndex = 10016;
            this.evoLabel6.Text = "Re-order Point";
            // 
            // evoLabel7
            // 
            this.evoLabel7.AppearanceName = "";
            this.evoLabel7.AutoSize = true;
            this.evoLabel7.ControlID = "";
            this.evoLabel7.Font = new System.Drawing.Font("Tahoma", 12F);
            this.evoLabel7.Location = new System.Drawing.Point(501, 148);
            this.evoLabel7.Name = "evoLabel7";
            this.evoLabel7.PathString = null;
            this.evoLabel7.PathValue = "Safety Stock";
            this.evoLabel7.Size = new System.Drawing.Size(95, 19);
            this.evoLabel7.TabIndex = 10017;
            this.evoLabel7.Text = "Safety Stock";
            // 
            // evoLabel8
            // 
            this.evoLabel8.AppearanceName = "";
            this.evoLabel8.AutoSize = true;
            this.evoLabel8.ControlID = "";
            this.evoLabel8.Font = new System.Drawing.Font("Tahoma", 12F);
            this.evoLabel8.Location = new System.Drawing.Point(501, 79);
            this.evoLabel8.Name = "evoLabel8";
            this.evoLabel8.PathString = null;
            this.evoLabel8.PathValue = "Minimum Order";
            this.evoLabel8.Size = new System.Drawing.Size(121, 19);
            this.evoLabel8.TabIndex = 10018;
            this.evoLabel8.Text = "Minimum Order";
            // 
            // evoLabel9
            // 
            this.evoLabel9.AppearanceName = "";
            this.evoLabel9.AutoSize = true;
            this.evoLabel9.ControlID = "";
            this.evoLabel9.Font = new System.Drawing.Font("Tahoma", 12F);
            this.evoLabel9.Location = new System.Drawing.Point(761, 79);
            this.evoLabel9.Name = "evoLabel9";
            this.evoLabel9.PathString = null;
            this.evoLabel9.PathValue = "Safety Leadtime";
            this.evoLabel9.Size = new System.Drawing.Size(121, 19);
            this.evoLabel9.TabIndex = 10019;
            this.evoLabel9.Text = "Safety Leadtime";
            // 
            // evoLabel11
            // 
            this.evoLabel11.AppearanceName = "";
            this.evoLabel11.AutoSize = true;
            this.evoLabel11.ControlID = "";
            this.evoLabel11.Font = new System.Drawing.Font("Tahoma", 12F);
            this.evoLabel11.Location = new System.Drawing.Point(761, 113);
            this.evoLabel11.Name = "evoLabel11";
            this.evoLabel11.PathString = null;
            this.evoLabel11.PathValue = "Order Condition";
            this.evoLabel11.Size = new System.Drawing.Size(123, 19);
            this.evoLabel11.TabIndex = 10021;
            this.evoLabel11.Text = "Order Condition";
            // 
            // txtSafetyLeadTime
            // 
            this.txtSafetyLeadTime.AllowNegative = false;
            this.txtSafetyLeadTime.AppearanceName = "";
            this.txtSafetyLeadTime.AppearanceReadOnlyName = "";
            this.txtSafetyLeadTime.ControlID = "";
            this.txtSafetyLeadTime.Decimal = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtSafetyLeadTime.DecimalPoint = '\0';
            this.txtSafetyLeadTime.DigitsInGroup = 3;
            this.txtSafetyLeadTime.Double = 0D;
            this.txtSafetyLeadTime.FixDecimalPosition = false;
            this.txtSafetyLeadTime.Flags = 65536;
            this.txtSafetyLeadTime.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtSafetyLeadTime.GroupSeparator = ',';
            this.txtSafetyLeadTime.Int = 0;
            this.txtSafetyLeadTime.Location = new System.Drawing.Point(881, 76);
            this.txtSafetyLeadTime.Long = ((long)(0));
            this.txtSafetyLeadTime.MaxDecimalPlaces = 0;
            this.txtSafetyLeadTime.MaxWholeDigits = 12;
            this.txtSafetyLeadTime.Name = "txtSafetyLeadTime";
            this.txtSafetyLeadTime.NegativeSign = '\0';
            this.txtSafetyLeadTime.PathString = null;
            this.txtSafetyLeadTime.PathValue = 0;
            this.txtSafetyLeadTime.Prefix = "";
            this.txtSafetyLeadTime.RangeMax = 120D;
            this.txtSafetyLeadTime.RangeMin = 1D;
            this.txtSafetyLeadTime.ReadOnly = true;
            this.txtSafetyLeadTime.Size = new System.Drawing.Size(148, 27);
            this.txtSafetyLeadTime.TabIndex = 10028;
            this.txtSafetyLeadTime.Text = "0";
            this.txtSafetyLeadTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // fpView
            // 
            this.fpView.About = "2.5.2015.2005";
            this.fpView.AccessibleDescription = "fpView, Sheet1, Row 0, Column 0, ";
            this.fpView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fpView.BackColor = System.Drawing.Color.AliceBlue;
            this.fpView.ContextMenuStrip = this.ctxMenu;
            this.fpView.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.fpView.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpView.Location = new System.Drawing.Point(9, 186);
            this.fpView.Name = "fpView";
            this.fpView.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.fpView.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.fpView.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.shtView});
            this.fpView.Size = new System.Drawing.Size(1022, 422);
            this.fpView.TabIndex = 10029;
            this.fpView.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpView.EditModeOn += new System.EventHandler(this.fpView_EditModeOn);
            this.fpView.EditModeOff += new System.EventHandler(this.fpView_EditModeOff);
            this.fpView.LeaveCell += new FarPoint.Win.Spread.LeaveCellEventHandler(this.fpView_LeaveCell);
            this.fpView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fpView_KeyDown);
            this.fpView.KeyUp += new System.Windows.Forms.KeyEventHandler(this.fpView_KeyUp);
            // 
            // ctxMenu
            // 
            this.ctxMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiAdd,
            this.tsmiDelete});
            this.ctxMenu.Name = "ctxMenu";
            this.ctxMenu.Size = new System.Drawing.Size(106, 48);
            this.ctxMenu.Opening += new System.ComponentModel.CancelEventHandler(this.ctxMenu_Opening);
            // 
            // tsmiAdd
            // 
            this.tsmiAdd.Name = "tsmiAdd";
            this.tsmiAdd.Size = new System.Drawing.Size(105, 22);
            this.tsmiAdd.Text = "Add";
            this.tsmiAdd.Click += new System.EventHandler(this.tsmiAdd_Click);
            // 
            // tsmiDelete
            // 
            this.tsmiDelete.Name = "tsmiDelete";
            this.tsmiDelete.Size = new System.Drawing.Size(105, 22);
            this.tsmiDelete.Text = "Delete";
            this.tsmiDelete.Click += new System.EventHandler(this.tsmiDelete_Click);
            // 
            // shtView
            // 
            this.shtView.Reset();
            this.shtView.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.shtView.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.shtView.ColumnCount = 13;
            this.shtView.RowCount = 15;
            this.shtView.AutoCalculation = false;
            this.shtView.ColumnHeader.AutoText = FarPoint.Win.Spread.HeaderAutoText.Blank;
            this.shtView.ColumnHeader.Cells.Get(0, 0).Value = "MRP No.";
            this.shtView.ColumnHeader.Cells.Get(0, 1).Value = "Part No.";
            this.shtView.ColumnHeader.Cells.Get(0, 2).Value = "Supplier LOC";
            this.shtView.ColumnHeader.Cells.Get(0, 3).Value = "Due Date";
            this.shtView.ColumnHeader.Cells.Get(0, 4).Value = "Incoming Qty";
            this.shtView.ColumnHeader.Cells.Get(0, 5).Value = "Outgoing Qty";
            this.shtView.ColumnHeader.Cells.Get(0, 6).Value = "Request Qty";
            this.shtView.ColumnHeader.Cells.Get(0, 7).Value = "Actual Request Qty";
            this.shtView.ColumnHeader.Cells.Get(0, 8).Value = "Actual Request By Lot";
            this.shtView.ColumnHeader.Cells.Get(0, 9).Value = "Purchase Order Qty";
            this.shtView.ColumnHeader.Cells.Get(0, 10).Value = "On Hand Qty";
            this.shtView.ColumnHeader.Cells.Get(0, 11).Value = "Balance Qty";
            this.shtView.ColumnHeader.Cells.Get(0, 12).Value = "Balance By Lot Qty";
            this.shtView.ColumnHeader.Rows.Get(0).Height = 40F;
            this.shtView.Columns.Get(0).CellType = textCellType1;
            this.shtView.Columns.Get(0).Label = "MRP No.";
            this.shtView.Columns.Get(0).Tag = "MRP No.";
            this.shtView.Columns.Get(0).Width = 152F;
            this.shtView.Columns.Get(1).Label = "Part No.";
            this.shtView.Columns.Get(1).Tag = "Part No.";
            this.shtView.Columns.Get(1).Width = 175F;
            this.shtView.Columns.Get(2).Label = "Supplier LOC";
            this.shtView.Columns.Get(2).Tag = "Supplier LOC";
            this.shtView.Columns.Get(2).Width = 185F;
            this.shtView.Columns.Get(3).Label = "Due Date";
            this.shtView.Columns.Get(3).Tag = "Due Date";
            this.shtView.Columns.Get(3).Width = 114F;
            this.shtView.Columns.Get(4).Label = "Incoming Qty";
            this.shtView.Columns.Get(4).Tag = "Incoming Qty";
            this.shtView.Columns.Get(4).Width = 120F;
            this.shtView.Columns.Get(5).Label = "Outgoing Qty";
            this.shtView.Columns.Get(5).Tag = "Outgoing Qty";
            this.shtView.Columns.Get(5).Width = 120F;
            this.shtView.Columns.Get(6).Label = "Request Qty";
            this.shtView.Columns.Get(6).Tag = "Request Qty";
            this.shtView.Columns.Get(6).Width = 144F;
            this.shtView.Columns.Get(7).Label = "Actual Request Qty";
            this.shtView.Columns.Get(7).Tag = "Actual Request Qty";
            this.shtView.Columns.Get(7).Width = 156F;
            this.shtView.Columns.Get(8).Label = "Actual Request By Lot";
            this.shtView.Columns.Get(8).Tag = "Actual Request By Lot";
            this.shtView.Columns.Get(8).Width = 188F;
            this.shtView.Columns.Get(9).Label = "Purchase Order Qty";
            this.shtView.Columns.Get(9).Tag = "Purchase Order Qty";
            this.shtView.Columns.Get(9).Width = 126F;
            this.shtView.Columns.Get(10).Label = "On Hand Qty";
            this.shtView.Columns.Get(10).Tag = "On Hand Qty";
            this.shtView.Columns.Get(10).Width = 120F;
            this.shtView.Columns.Get(11).Label = "Balance Qty";
            this.shtView.Columns.Get(11).Tag = "Balance Qty";
            this.shtView.Columns.Get(11).Width = 120F;
            this.shtView.Columns.Get(12).Label = "Balance By Lot Qty";
            this.shtView.Columns.Get(12).Tag = "Balance By Lot Qty";
            this.shtView.Columns.Get(12).Width = 120F;
            this.shtView.DataAutoCellTypes = false;
            this.shtView.DataAutoHeadings = false;
            this.shtView.DataAutoSizeColumns = false;
            this.shtView.DefaultStyle.ForeColor = System.Drawing.Color.Blue;
            this.shtView.DefaultStyle.Locked = true;
            this.shtView.DefaultStyle.Parent = "DataAreaDefault";
            this.shtView.LockForeColor = System.Drawing.Color.Black;
            this.shtView.RowHeader.Columns.Default.Resizable = true;
            this.shtView.RowHeader.Columns.Get(0).Width = 50F;
            this.shtView.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // evoLabel10
            // 
            this.evoLabel10.AppearanceName = "";
            this.evoLabel10.AutoSize = true;
            this.evoLabel10.ControlID = "";
            this.evoLabel10.Font = new System.Drawing.Font("Tahoma", 12F);
            this.evoLabel10.Location = new System.Drawing.Point(312, 79);
            this.evoLabel10.Name = "evoLabel10";
            this.evoLabel10.PathString = null;
            this.evoLabel10.PathValue = "Revision";
            this.evoLabel10.Size = new System.Drawing.Size(68, 19);
            this.evoLabel10.TabIndex = 10030;
            this.evoLabel10.Text = "Revision";
            // 
            // txtRevisionNo
            // 
            this.txtRevisionNo.AppearanceName = "";
            this.txtRevisionNo.AppearanceReadOnlyName = "";
            this.txtRevisionNo.ControlID = "";
            this.txtRevisionNo.DisableRestrictChar = false;
            this.txtRevisionNo.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtRevisionNo.HelpButton = null;
            this.txtRevisionNo.Location = new System.Drawing.Point(386, 76);
            this.txtRevisionNo.Name = "txtRevisionNo";
            this.txtRevisionNo.PathString = null;
            this.txtRevisionNo.PathValue = "1";
            this.txtRevisionNo.ReadOnly = true;
            this.txtRevisionNo.Size = new System.Drawing.Size(100, 27);
            this.txtRevisionNo.TabIndex = 10031;
            this.txtRevisionNo.Text = "1";
            this.txtRevisionNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // dtpDateTo
            // 
            this.dtpDateTo.AppearanceName = "";
            this.dtpDateTo.AppearanceReadOnlyName = "";
            this.dtpDateTo.BackColor = System.Drawing.Color.Transparent;
            this.dtpDateTo.ControlID = "";
            this.dtpDateTo.Enabled = false;
            this.dtpDateTo.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.dtpDateTo.Format = "dd/MM/yyyy";
            this.dtpDateTo.Location = new System.Drawing.Point(316, 43);
            this.dtpDateTo.MinimumSize = new System.Drawing.Size(100, 0);
            this.dtpDateTo.Name = "dtpDateTo";
            this.dtpDateTo.NZValue = ((EVOFramework.NZDateTime)(resources.GetObject("dtpDateTo.NZValue")));
            this.dtpDateTo.PathString = null;
            this.dtpDateTo.PathValue = ((object)(resources.GetObject("dtpDateTo.PathValue")));
            this.dtpDateTo.ReadOnly = true;
            this.dtpDateTo.ShowButton = true;
            this.dtpDateTo.Size = new System.Drawing.Size(170, 27);
            this.dtpDateTo.TabIndex = 10033;
            this.dtpDateTo.Value = null;
            // 
            // dtpDateFrom
            // 
            this.dtpDateFrom.AppearanceName = "";
            this.dtpDateFrom.AppearanceReadOnlyName = "";
            this.dtpDateFrom.BackColor = System.Drawing.Color.Transparent;
            this.dtpDateFrom.ControlID = "";
            this.dtpDateFrom.Enabled = false;
            this.dtpDateFrom.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.dtpDateFrom.Format = "dd/MM/yyyy";
            this.dtpDateFrom.Location = new System.Drawing.Point(122, 43);
            this.dtpDateFrom.MinimumSize = new System.Drawing.Size(100, 0);
            this.dtpDateFrom.Name = "dtpDateFrom";
            this.dtpDateFrom.NZValue = ((EVOFramework.NZDateTime)(resources.GetObject("dtpDateFrom.NZValue")));
            this.dtpDateFrom.PathString = null;
            this.dtpDateFrom.PathValue = ((object)(resources.GetObject("dtpDateFrom.PathValue")));
            this.dtpDateFrom.ReadOnly = true;
            this.dtpDateFrom.ShowButton = true;
            this.dtpDateFrom.Size = new System.Drawing.Size(170, 27);
            this.dtpDateFrom.TabIndex = 10034;
            this.dtpDateFrom.Value = null;
            // 
            // evoLabel12
            // 
            this.evoLabel12.AppearanceName = "";
            this.evoLabel12.AutoSize = true;
            this.evoLabel12.ControlID = "";
            this.evoLabel12.Font = new System.Drawing.Font("Tahoma", 12F);
            this.evoLabel12.Location = new System.Drawing.Point(25, 45);
            this.evoLabel12.Name = "evoLabel12";
            this.evoLabel12.PathString = null;
            this.evoLabel12.PathValue = "Date";
            this.evoLabel12.Size = new System.Drawing.Size(41, 19);
            this.evoLabel12.TabIndex = 10035;
            this.evoLabel12.Text = "Date";
            // 
            // evoLabel13
            // 
            this.evoLabel13.AppearanceName = "";
            this.evoLabel13.AutoSize = true;
            this.evoLabel13.ControlID = "";
            this.evoLabel13.Font = new System.Drawing.Font("Tahoma", 12F);
            this.evoLabel13.Location = new System.Drawing.Point(298, 45);
            this.evoLabel13.Name = "evoLabel13";
            this.evoLabel13.PathString = null;
            this.evoLabel13.PathValue = "-";
            this.evoLabel13.Size = new System.Drawing.Size(15, 19);
            this.evoLabel13.TabIndex = 10036;
            this.evoLabel13.Text = "-";
            // 
            // cboOrderCondition
            // 
            this.cboOrderCondition.AppearanceName = "";
            this.cboOrderCondition.AppearanceReadOnlyName = "";
            this.cboOrderCondition.BackColor = System.Drawing.Color.White;
            this.cboOrderCondition.ControlID = null;
            this.cboOrderCondition.DropDownHeight = 100;
            this.cboOrderCondition.Enabled = false;
            this.cboOrderCondition.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.cboOrderCondition.ForeColor = System.Drawing.Color.Black;
            this.cboOrderCondition.FormattingEnabled = true;
            this.cboOrderCondition.IntegralHeight = false;
            this.cboOrderCondition.Location = new System.Drawing.Point(881, 110);
            this.cboOrderCondition.Name = "cboOrderCondition";
            this.cboOrderCondition.PathString = "ORDER_CONDITION.Value";
            this.cboOrderCondition.PathValue = null;
            this.cboOrderCondition.ReadOnly = true;
            this.cboOrderCondition.Size = new System.Drawing.Size(148, 28);
            this.cboOrderCondition.TabIndex = 10037;
            // 
            // txtLeadTime
            // 
            this.txtLeadTime.AllowNegative = false;
            this.txtLeadTime.AppearanceName = "";
            this.txtLeadTime.AppearanceReadOnlyName = "";
            this.txtLeadTime.ControlID = "";
            this.txtLeadTime.Decimal = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtLeadTime.DecimalPoint = '.';
            this.txtLeadTime.DigitsInGroup = 3;
            this.txtLeadTime.Double = 0D;
            this.txtLeadTime.FixDecimalPosition = false;
            this.txtLeadTime.Flags = 65536;
            this.txtLeadTime.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtLeadTime.GroupSeparator = ',';
            this.txtLeadTime.Int = 0;
            this.txtLeadTime.Location = new System.Drawing.Point(881, 43);
            this.txtLeadTime.Long = ((long)(0));
            this.txtLeadTime.MaxDecimalPlaces = 0;
            this.txtLeadTime.MaxWholeDigits = 12;
            this.txtLeadTime.Name = "txtLeadTime";
            this.txtLeadTime.NegativeSign = '\0';
            this.txtLeadTime.PathString = null;
            this.txtLeadTime.PathValue = 0;
            this.txtLeadTime.Prefix = "";
            this.txtLeadTime.RangeMax = 120D;
            this.txtLeadTime.RangeMin = 1D;
            this.txtLeadTime.ReadOnly = true;
            this.txtLeadTime.Size = new System.Drawing.Size(148, 27);
            this.txtLeadTime.TabIndex = 10038;
            this.txtLeadTime.Text = "0";
            this.txtLeadTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtLotSize
            // 
            this.txtLotSize.AllowNegative = false;
            this.txtLotSize.AppearanceName = "";
            this.txtLotSize.AppearanceReadOnlyName = "";
            this.txtLotSize.ControlID = "";
            this.txtLotSize.Decimal = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtLotSize.DecimalPoint = '.';
            this.txtLotSize.DigitsInGroup = 3;
            this.txtLotSize.Double = 0D;
            this.txtLotSize.FixDecimalPosition = false;
            this.txtLotSize.Flags = 65536;
            this.txtLotSize.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtLotSize.GroupSeparator = ',';
            this.txtLotSize.Int = 0;
            this.txtLotSize.Location = new System.Drawing.Point(619, 43);
            this.txtLotSize.Long = ((long)(0));
            this.txtLotSize.MaxDecimalPlaces = 4;
            this.txtLotSize.MaxWholeDigits = 12;
            this.txtLotSize.Name = "txtLotSize";
            this.txtLotSize.NegativeSign = '\0';
            this.txtLotSize.PathString = null;
            this.txtLotSize.PathValue = 0;
            this.txtLotSize.Prefix = "";
            this.txtLotSize.RangeMax = 120D;
            this.txtLotSize.RangeMin = 1D;
            this.txtLotSize.ReadOnly = true;
            this.txtLotSize.Size = new System.Drawing.Size(129, 27);
            this.txtLotSize.TabIndex = 10039;
            this.txtLotSize.Text = "0";
            this.txtLotSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtMinimumOrder
            // 
            this.txtMinimumOrder.AllowNegative = false;
            this.txtMinimumOrder.AppearanceName = "";
            this.txtMinimumOrder.AppearanceReadOnlyName = "";
            this.txtMinimumOrder.ControlID = "";
            this.txtMinimumOrder.Decimal = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtMinimumOrder.DecimalPoint = '.';
            this.txtMinimumOrder.DigitsInGroup = 3;
            this.txtMinimumOrder.Double = 0D;
            this.txtMinimumOrder.FixDecimalPosition = false;
            this.txtMinimumOrder.Flags = 65536;
            this.txtMinimumOrder.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtMinimumOrder.GroupSeparator = ',';
            this.txtMinimumOrder.Int = 0;
            this.txtMinimumOrder.Location = new System.Drawing.Point(619, 76);
            this.txtMinimumOrder.Long = ((long)(0));
            this.txtMinimumOrder.MaxDecimalPlaces = 4;
            this.txtMinimumOrder.MaxWholeDigits = 12;
            this.txtMinimumOrder.Name = "txtMinimumOrder";
            this.txtMinimumOrder.NegativeSign = '\0';
            this.txtMinimumOrder.PathString = null;
            this.txtMinimumOrder.PathValue = 0;
            this.txtMinimumOrder.Prefix = "";
            this.txtMinimumOrder.RangeMax = 120D;
            this.txtMinimumOrder.RangeMin = 1D;
            this.txtMinimumOrder.ReadOnly = true;
            this.txtMinimumOrder.Size = new System.Drawing.Size(129, 27);
            this.txtMinimumOrder.TabIndex = 10040;
            this.txtMinimumOrder.Text = "0";
            this.txtMinimumOrder.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtReorderPoint
            // 
            this.txtReorderPoint.AllowNegative = false;
            this.txtReorderPoint.AppearanceName = "";
            this.txtReorderPoint.AppearanceReadOnlyName = "";
            this.txtReorderPoint.ControlID = "";
            this.txtReorderPoint.Decimal = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtReorderPoint.DecimalPoint = '.';
            this.txtReorderPoint.DigitsInGroup = 3;
            this.txtReorderPoint.Double = 0D;
            this.txtReorderPoint.FixDecimalPosition = false;
            this.txtReorderPoint.Flags = 65536;
            this.txtReorderPoint.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtReorderPoint.GroupSeparator = ',';
            this.txtReorderPoint.Int = 0;
            this.txtReorderPoint.Location = new System.Drawing.Point(619, 109);
            this.txtReorderPoint.Long = ((long)(0));
            this.txtReorderPoint.MaxDecimalPlaces = 4;
            this.txtReorderPoint.MaxWholeDigits = 12;
            this.txtReorderPoint.Name = "txtReorderPoint";
            this.txtReorderPoint.NegativeSign = '\0';
            this.txtReorderPoint.PathString = null;
            this.txtReorderPoint.PathValue = 0;
            this.txtReorderPoint.Prefix = "";
            this.txtReorderPoint.RangeMax = 120D;
            this.txtReorderPoint.RangeMin = 1D;
            this.txtReorderPoint.ReadOnly = true;
            this.txtReorderPoint.Size = new System.Drawing.Size(129, 27);
            this.txtReorderPoint.TabIndex = 10041;
            this.txtReorderPoint.Text = "0";
            this.txtReorderPoint.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtSafetyStock
            // 
            this.txtSafetyStock.AllowNegative = false;
            this.txtSafetyStock.AppearanceName = "";
            this.txtSafetyStock.AppearanceReadOnlyName = "";
            this.txtSafetyStock.ControlID = "";
            this.txtSafetyStock.Decimal = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtSafetyStock.DecimalPoint = '.';
            this.txtSafetyStock.DigitsInGroup = 3;
            this.txtSafetyStock.Double = 0D;
            this.txtSafetyStock.FixDecimalPosition = false;
            this.txtSafetyStock.Flags = 65536;
            this.txtSafetyStock.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtSafetyStock.GroupSeparator = ',';
            this.txtSafetyStock.Int = 0;
            this.txtSafetyStock.Location = new System.Drawing.Point(619, 145);
            this.txtSafetyStock.Long = ((long)(0));
            this.txtSafetyStock.MaxDecimalPlaces = 4;
            this.txtSafetyStock.MaxWholeDigits = 12;
            this.txtSafetyStock.Name = "txtSafetyStock";
            this.txtSafetyStock.NegativeSign = '\0';
            this.txtSafetyStock.PathString = null;
            this.txtSafetyStock.PathValue = 0;
            this.txtSafetyStock.Prefix = "";
            this.txtSafetyStock.RangeMax = 120D;
            this.txtSafetyStock.RangeMin = 1D;
            this.txtSafetyStock.ReadOnly = true;
            this.txtSafetyStock.Size = new System.Drawing.Size(129, 27);
            this.txtSafetyStock.TabIndex = 10042;
            this.txtSafetyStock.Text = "0";
            this.txtSafetyStock.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // MRP030_MRPMaintenance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1041, 665);
            this.MinimumSize = new System.Drawing.Size(1049, 699);
            this.Name = "MRP030_MRPMaintenance";
            this.Text = "MRP030 - MRP Maintenance";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MRP021_MRPMaintenance_FormClosed);
            this.Load += new System.EventHandler(this.MRP021_MRPMaintenance_Load);
            this.Controls.SetChildIndex(this.pnlContainer, 0);
            this.pnlContainer.ResumeLayout(false);
            this.pnlContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fpView)).EndInit();
            this.ctxMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.shtView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private void ctxMenu_Opening(object sender, System.ComponentModel.CancelEventArgs e) {
            int iRowIdx = shtView.ActiveRowIndex;
            bool bCanDelete = true;
            if (iRowIdx >= 0) {
                bCanDelete = CanDeleteRecord(iRowIdx);
                tsmiDelete.Enabled = bCanDelete;
            }
        }

        private void fpView_KeyUp(object sender, KeyEventArgs e) {
            if (e.KeyData == Keys.Escape) {
                if (m_bRowHasModified) {
                    int lastRowNonEmpty = shtView.GetLastNonEmptyRow(NonEmptyItemFlag.Data);
                    if (lastRowNonEmpty != shtView.RowCount - 1) {
                        shtView.RemoveRows(shtView.RowCount - 1, 1);
                    }
                    else {
                        RestoreCellValues(shtView.ActiveRowIndex);
                    }

                    m_bRowHasModified = false;
                }
                else {
                    RemoveRowUnused(shtView);
                }
            }
        }

        private void fpView_LeaveCell(object sender, LeaveCellEventArgs e) {
            if (m_bRowHasModified) {  // เช็คว่า Cell ในแถวนั้น มีการแก้ไขค่าหรือไม่
                if (e.Row != e.NewRow) {  // ถ้าเป็นการเปลี่ยนแถว ต้องเช็คก่อนว่า Validate แถวผ่านหรือไม่?
                    if (!ValidateRowSpread(e.Row, false)) {
                        e.Cancel = true;
                    }
                }
            }
        }

        private void fpView_KeyDown(object sender, KeyEventArgs e)
        {
            CtrlUtil.FilterShortCut(e);
        }


    }

}
