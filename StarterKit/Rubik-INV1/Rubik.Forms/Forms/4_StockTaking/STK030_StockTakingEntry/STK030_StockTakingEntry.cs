//Create Date 12 Oct 2010
//Author: Bunyapat L.
//Screen Name: Stock Taking Entry
//Description: To input stock taking data from manual count stock

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using EVOFramework.Windows.Forms;
using CommonLib;
using FarPoint.Win.Spread;
using EVOFramework.Data;
using EVOFramework;
using Message = EVOFramework.Message;
using SystemMaintenance;
using System.Data;
using FarPoint.Win.Spread.Model;
using Rubik.UIDataModel;
using Rubik.BIZ;
using Rubik.DTO;
using Rubik;
using Rubik.Validators;
using Rubik.Forms.FindDialog;
using Rubik.Controller;


namespace Rubik.StockTaking
{
    [Screen("STK030", "Stock Taking Entry", eShowAction.Normal, eScreenType.Screen, "Stock Taking Entry")]
    public partial class STK030_StockTakingEntry : SystemMaintenance.Forms.CustomizeForm
    {
        #region Enum
        public enum eScreenMode
        {
            IDLE,
            VIEW,
            ADD,
            EDIT,
        }

        public enum eRowStatus
        {
            NONE,
            ADD,
            UPDATE,
            DELETE
        }

        public enum eColView
        {
            STOCK_TAKING_ID,
            EFFECT_INVENTORY_FLAG,
            COUNTING_ID,
            ITEM_CD,
            BTN_ITEM_CD,
            SHORT_NAME,
            CUST_NAME,
            LOC_CD,
            LOT_NO,
            EXTERNAL_LOT_NO,
            PACK_NO,
            FG_NO,
            SYSTEM_QTY,
            COUNT_QTY,
            DIFF_QTY,
            ADJUSTED_FLAG,
            MANUAL_ADD_FLAG,
            TAG_NO,
            REMARK,
            ROW_STATUS,
        }

        public enum eColData
        {
            STOCK_TAKING_ID,
            COUNTING_ID,
            ITEM_CD,
            LOC_CD,
            LOT_NO,
            EXTERNAL_LOT_NO,
            PACK_NO,
            FG_NO,
            SYSTEM_QTY,
            COUNT_QTY,
            DIFF_QTY,
            EFFECT_INVENTORY_FLAG,
            ADJUSTED_FLAG,
            MANUAL_FLAG,
            TAG_NO,
            REMARK,
            SHORT_NAME,
            CUST_NAME,
        }
        #endregion

        #region Variables
        private eScreenMode m_screenMode = eScreenMode.ADD;
        private KeyboardSpread m_keyboardSpread = null;
        private DataTable dtSearchData = null;

        private int m_iRunUpdateProcess = 1;

        #endregion

        #region Constructor
        public STK030_StockTakingEntry()
        {
            InitializeComponent();
        }

        #endregion

        #region Initialize Screen
        private void InitializeScreen()
        {
            cboProcess.Format += Common.ComboBox_Format;

            //txtLocation.KeyPress += CtrlUtil.SetNextControl;
            cboProcess.KeyPress += CtrlUtil.SetNextControl;
            btnFind.KeyPress += CtrlUtil.SetNextControl;

            shtView.ActiveSkin = Common.ACTIVE_SKIN;

            SetScreenMode(eScreenMode.IDLE);

            LookupDataBIZ bizLookup = new LookupDataBIZ();

            //------------ Location --------------------//
            NZString[] locationtype = new NZString[1];
            locationtype[0] = DataDefine.Convert2ClassCode(DataDefine.eLOCATION_CLS.Production).ToNZString();
            LookupData dataProductionProcess = bizLookup.LoadLookupLocation(locationtype);
            cboProcess.LoadLookupData(dataProductionProcess);
            cboProcess.SelectedIndex = -1;
            //------------ Location --------------------//


            this.shtView.Columns[(int)eColView.STOCK_TAKING_ID].Visible = false;
            this.shtView.Columns[(int)eColView.LOC_CD].Visible = false;
            this.shtView.Columns[(int)eColView.ADJUSTED_FLAG].Visible = false;
            this.shtView.Columns[(int)eColView.MANUAL_ADD_FLAG].Visible = false;
            //this.shtView.Columns[(int)eColView.REMARK].Visible = false;
            this.shtView.Columns[(int)eColView.ROW_STATUS].Visible = false;
            // 14 Feb 2013: Hide Lot, FG No, Pack No
            this.shtView.Columns[(int)eColView.LOT_NO].Visible = false;
            this.shtView.Columns[(int)eColView.FG_NO].Visible = false;
            this.shtView.Columns[(int)eColView.PACK_NO].Visible = false;
            this.shtView.Columns[(int)eColView.EXTERNAL_LOT_NO].Visible = false;
            // end 14 Feb 2013

            dtStockTakingDate.Format = Common.CurrentUserInfomation.DateFormatString;

            m_keyboardSpread = new KeyboardSpread(fpView);
            m_keyboardSpread.RowAdding += new KeyboardSpread.RowAddingHandler(m_keyboardSpread_RowAdding);
            m_keyboardSpread.RowAdded += new KeyboardSpread.RowAddedHandler(m_keyboardSpread_RowAdded);
            //m_keyboardSpread.RowRemoving += new KeyboardSpread.RowRemovingHandler(m_keyboardSpread_RowRemoving);
            //m_keyboardSpread.RowRemoved += new KeyboardSpread.RowRemovedHandler(m_keyboardSpread_RowRemoved);
            //m_keyboardSpread.KeyPressF5 += new KeyboardSpread.KeyPressF5Handler(m_keyboardSpread_KeyPressF5);

            CtrlUtil.EnabledControl(false, dtStockTakingDate);

            FormatUtil.SetNumberFormat(shtView.Columns[(int)eColView.SYSTEM_QTY], FormatUtil.eNumberFormat.Qty_PCS);
            FormatUtil.SetNumberFormat(shtView.Columns[(int)eColView.COUNT_QTY], FormatUtil.eNumberFormat.Qty_PCS);
            FormatUtil.SetNumberFormat(shtView.Columns[(int)eColView.DIFF_QTY], FormatUtil.eNumberFormat.Qty_PCS);
            FormatUtil.SetNumberFormat(shtView.Columns[(int)eColView.ITEM_CD], FormatUtil.eNumberFormat.MasterNo);
            FormatUtil.SetNumberFormat(shtView.Columns[(int)eColView.TAG_NO], FormatUtil.eNumberFormat.TagNo);


            LoadCurrentStockTakingData();
        }

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
            // Unlock cells
            CtrlUtil.SpreadSetCellLocked(shtView, false, rowIndex, (int)eColView.BTN_ITEM_CD);
            //CtrlUtil.SpreadSetCellLocked(shtView, false, rowIndex, (int)eColView.LOT_NO);
            CtrlUtil.SpreadSetCellLocked(shtView, false, rowIndex, (int)eColView.COUNT_QTY);
            CtrlUtil.SpreadSetCellLocked(shtView, false, rowIndex, (int)eColView.EFFECT_INVENTORY_FLAG);

            shtView.Cells[rowIndex, (int)eColView.ROW_STATUS].Value = (int)eRowStatus.ADD;


        }

        private void LoadCurrentStockTakingData()
        {
            StockTakingBIZ stkBiz = new StockTakingBIZ();
            StockTakingDTO stkDTO = stkBiz.LoadLastStockTaking();

            if (stkDTO != null)
            {
                this.dtStockTakingDate.DateValue = stkDTO.STOCK_TAKING_DATE;
                this.shtView.RowCount = 0;
                SetScreenMode(eScreenMode.VIEW);
            }
            else
            {
                MessageDialog.ShowBusiness(this
                    , new EVOFramework.Message(TKPMessages.eValidate.VLM0086.ToString()));
            }


        }

        #endregion

        #region Screen Mode
        private void SetScreenMode(eScreenMode mode)
        {
            switch (mode)
            {
                case eScreenMode.IDLE:
                    tsbSaveAndNew.Enabled = false;
                    tsbSaveAndClose.Enabled = false;
                    shtView.OperationMode = OperationMode.ReadOnly;
                    this.shtView.RowCount = 0;

                    //CtrlUtil.EnabledControl(false, btnFind, btnLocation, txtLocation);
                    CtrlUtil.EnabledControl(false, btnFind, cboProcess);
                    CtrlUtil.SpreadSetColumnsLocked(shtView, true, (int)eColView.BTN_ITEM_CD);
                    CtrlUtil.SpreadSetColumnsLocked(shtView, true, (int)eColView.LOT_NO);
                    CtrlUtil.SpreadSetColumnsLocked(shtView, true, (int)eColView.EXTERNAL_LOT_NO);

                    CtrlUtil.SpreadSetColumnsLocked(shtView, true, (int)eColView.EFFECT_INVENTORY_FLAG);
                    CtrlUtil.SpreadSetColumnsLocked(shtView, true, (int)eColView.COUNT_QTY);
                    CtrlUtil.SpreadSetColumnsLocked(shtView, true, (int)eColView.REMARK);
                    CtrlUtil.SpreadSetColumnsLocked(shtView, true, (int)eColView.TAG_NO);

                    fpView.ContextMenuStrip = null;


                    break;
                case eScreenMode.VIEW:

                    tsbSaveAndNew.Enabled = false;
                    tsbSaveAndClose.Enabled = false;
                    shtView.OperationMode = OperationMode.ReadOnly;

                    //CtrlUtil.EnabledControl(true, btnFind, btnLocation, txtLocation);
                    CtrlUtil.EnabledControl(true, btnFind, cboProcess);
                    CtrlUtil.SpreadSetColumnsLocked(shtView, true, (int)eColView.BTN_ITEM_CD);
                    CtrlUtil.SpreadSetColumnsLocked(shtView, true, (int)eColView.LOT_NO);
                    CtrlUtil.SpreadSetColumnsLocked(shtView, true, (int)eColView.EXTERNAL_LOT_NO);

                    CtrlUtil.SpreadSetColumnsLocked(shtView, true, (int)eColView.EFFECT_INVENTORY_FLAG);
                    CtrlUtil.SpreadSetColumnsLocked(shtView, true, (int)eColView.COUNT_QTY);
                    CtrlUtil.SpreadSetColumnsLocked(shtView, true, (int)eColView.REMARK);
                    CtrlUtil.SpreadSetColumnsLocked(shtView, true, (int)eColView.TAG_NO);


                    fpView.ContextMenuStrip = null;
                    break;
                case eScreenMode.ADD:
                    break;
                case eScreenMode.EDIT:
                    //CtrlUtil.EnabledControl(true, txtInvoiceNo, txtPONo, txtRemark, fpView);
                    //CtrlUtil.EnabledControl(false, dtReceiveDate, rdoReceive, rdoReceiveReturn);
                    //CtrlUtil.EnabledControl(false, txtInvoiceNo, txtPONo, txtRemark, cboStoredLoc);
                    tsbSaveAndNew.Enabled = true;
                    tsbSaveAndClose.Enabled = true;

                    fpView.ContextMenuStrip = ctxMenu;
                    shtView.OperationMode = OperationMode.Normal;
                    CtrlUtil.SpreadSetColumnsLocked(shtView, true, (int)eColView.BTN_ITEM_CD);
                    CtrlUtil.SpreadSetColumnsLocked(shtView, true, (int)eColView.LOT_NO);
                    CtrlUtil.SpreadSetColumnsLocked(shtView, true, (int)eColView.EXTERNAL_LOT_NO);

                    CtrlUtil.SpreadSetColumnsLocked(shtView, false, (int)eColView.EFFECT_INVENTORY_FLAG);
                    CtrlUtil.SpreadSetColumnsLocked(shtView, false, (int)eColView.COUNT_QTY);
                    CtrlUtil.SpreadSetColumnsLocked(shtView, false, (int)eColView.REMARK);
                    CtrlUtil.SpreadSetColumnsLocked(shtView, false, (int)eColView.TAG_NO);

                    m_keyboardSpread.StartBind();
                    break;
            }

            m_screenMode = mode;
        }

        #endregion

        #region Private method
        private void RemoveRowUnused(SheetView sheet)
        {
            if (shtView.RowCount <= 0) return;

            int lastRowNonEmpty = shtView.GetLastNonEmptyRow(NonEmptyItemFlag.Data);
            if (lastRowNonEmpty != shtView.RowCount - 1)
            {
                shtView.RemoveRows(shtView.RowCount - 1, 1);
            }

            int iRow = shtView.RowCount - 1;
            if ("".Equals(shtView.Cells[iRow, (int)eColView.ITEM_CD].Text.Trim())
                && "".Equals(shtView.Cells[iRow, (int)eColView.LOT_NO].Text.Trim())
                && "".Equals(shtView.Cells[iRow, (int)eColView.EXTERNAL_LOT_NO].Text.Trim())
                && "".Equals(shtView.Cells[iRow, (int)eColView.COUNT_QTY].Text.Trim())
                && "1".Equals(shtView.Cells[iRow, (int)eColView.ROW_STATUS].Text.Trim())
                )
            {
                shtView.RemoveRows(shtView.RowCount - 1, 1);
            }

        }

        private void GoToNextRow()
        {
            int iCurrentRow = shtView.ActiveRowIndex;
            int iCurrentColumn = shtView.ActiveColumnIndex;

            if (iCurrentColumn == (int)eColView.COUNT_QTY)
            {
                if (iCurrentRow < shtView.RowCount)
                {
                    shtView.SetActiveCell(iCurrentRow + 1, iCurrentColumn, false);

                }
            }

        }

        private bool LoadItemIntoRow(int row, NZString ITEM_CD, ItemUIDM SelectedItem)
        {
            ItemValidator itemValidator = new ItemValidator();

            if (ITEM_CD != null)
            {
                BusinessException error = itemValidator.CheckItemNotExist(ITEM_CD);
                if (error != null)
                {
                    shtView.Cells[row, (int)eColView.SHORT_NAME].Value = null;
                    shtView.Cells[row, (int)eColView.CUST_NAME].Value = null;
                    return false;
                }

                ItemBIZ itemBIZ = new ItemBIZ();
                ItemDTO itemDTO = itemBIZ.LoadItem(ITEM_CD);
                DealingBIZ custBIZ = new DealingBIZ();
                DealingDTO custDTO = custBIZ.LoadLocation(itemDTO.CUSTOMER_CD);

                shtView.Cells[row, (int)eColView.ITEM_CD].Value = itemDTO.ITEM_CD.Value;
                shtView.Cells[row, (int)eColView.SHORT_NAME].Value = itemDTO.SHORT_NAME.Value;
                shtView.Cells[row, (int)eColView.CUST_NAME].Value = custDTO.LOC_DESC.Value; //itemDTO.ITEM_DESC.Value;
                shtView.Cells[row, (int)eColView.LOC_CD].Value = cboProcess.SelectedValue.ToString();//this.txtLocation.Text;
                shtView.Cells[row, (int)eColView.SYSTEM_QTY].Value = 0;
                shtView.Cells[row, (int)eColView.EFFECT_INVENTORY_FLAG].Value = 0;
                shtView.Cells[row, (int)eColView.MANUAL_ADD_FLAG].Value = 1;

                if (Convert.ToInt32(shtView.Cells[row, (int)eColView.ROW_STATUS].Value) == (int)eRowStatus.NONE)
                {
                    shtView.Cells[row, (int)eColView.ROW_STATUS].Value = (int)eRowStatus.UPDATE;
                }

                //if ("00".Equals(SelectedItem.LOT_CONTROL_CLS))
                //{
                //    CtrlUtil.SpreadSetCellLocked(shtView, true, row, (int)eColView.LOT_NO);
                //    shtView.Cells[row, (int)eColView.LOT_NO].Value = null;
                //}
                //else
                //{
                //    CtrlUtil.SpreadSetCellLocked(shtView, false, row, (int)eColView.LOT_NO);
                //}

            }

            return true;
        }

        private void SelectAllData(bool IsSelect)
        {
            for (int iRow = 0; iRow < shtView.RowCount; iRow++)
            {
                shtView.Cells[iRow, (int)eColView.EFFECT_INVENTORY_FLAG].Value = IsSelect ? 1 : 0;
                UpdateRowStatus(iRow);
            }
        }
        #endregion

        #region Overriden method
        public override void OnSaveAndNew()
        {
            try
            {
                if (shtView.RowCount == 0)
                {

                    MessageDialog.ShowBusiness(this, Message.LoadMessage(TKPMessages.eValidate.VLM0105.ToString(), new object[] { "Stock Taking" }));
                    return;

                }

                fpView.StopCellEditing();

                RemoveRowUnused(shtView);

                if (!ValidateRowSpread(shtView.ActiveRowIndex, false))
                {
                    return;
                }


                // ต้องเรียกก่อน Save เสมอ  เพื่อ Commit ข้อมูลการแก้ไขล่าสุดบน Grid
                // ใช้ได้เฉพาะกับ Sheet ที่ผูก DataSource
                CtrlUtil.SpreadSheetRowEndEdit(shtView, shtView.ActiveRowIndex);



                try
                {
                    MessageDialogResult dr = UpdateStockTakingData();
                    if (dr == MessageDialogResult.Yes)
                    {
                        //== return to Add new data screen mode.
                        SetScreenMode(eScreenMode.IDLE);
                        LoadCurrentStockTakingData();
                    }
                    else
                    {
                        //do nothing (keep previous state)
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
                    Console.WriteLine(err.StackTrace);
                }
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
                fpView.StopCellEditing();

                RemoveRowUnused(shtView);

                if (!ValidateRowSpread(shtView.ActiveRowIndex, false))
                {
                    return;
                }


                // ต้องเรียกก่อน Save เสมอ  เพื่อ Commit ข้อมูลการแก้ไขล่าสุดบน Grid
                // ใช้ได้เฉพาะกับ Sheet ที่ผูก DataSource
                CtrlUtil.SpreadSheetRowEndEdit(shtView, shtView.ActiveRowIndex); ;


                try
                {
                    MessageDialogResult dr = UpdateStockTakingData();
                    if (dr == MessageDialogResult.Yes)
                    {
                        //== Exit form.
                        this.Close();
                    }
                    else
                    {
                        //do nothing (keep previous state)
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
                    Console.WriteLine(err.StackTrace);
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

        #endregion

        #region Form Event
        private void STK030_StockTakingEntry_Load(object sender, EventArgs e)
        {
            try
            {
                InitializeScreen();
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusiness(this, ex.Message);
            }
        }

        private void STK030_StockTakingEntry_Shown(object sender, EventArgs e)
        {
            try
            {
                if (m_screenMode == eScreenMode.ADD)
                {

                }
                else
                {
                    CtrlUtil.FocusControl(fpView);
                }
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusiness(this, ex.Message);
            }
        }

        private void STK030_StockTakingEntry_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusiness(this, ex.Message);
            }
        }

        #endregion

        #region Control event
        private void miAdd_Click(object sender, EventArgs e)
        {
            try
            {
                m_keyboardSpread.OnActionAddNewRow();
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusiness(this, ex.Message);
            }
        }
        private void miAddPack_Click(object sender, EventArgs e)
        {
            if (cboProcess.SelectedValue == null)
                return;

            //STK050_StockTakingPackEntry dialog = new STK050_StockTakingPackEntry(txtLocation.Text.Trim(), shtView);
            STK050_StockTakingPackEntry dialog = new STK050_StockTakingPackEntry(cboProcess.SelectedValue.ToString(), shtView);
            DialogResult dr = dialog.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {

            }
        }
        private void miDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (shtView.ActiveRowIndex > -1 && shtView.RowCount > 0)
                {
                    int iManualFlag = Convert.ToInt32(shtView.Cells[shtView.ActiveRowIndex, (int)eColView.MANUAL_ADD_FLAG].Value);

                    if (iManualFlag == 0)
                    {
                        // if it's not a manual row , do nothing
                    }
                    else
                    {

                        DealingConstraintBIZ bizConstraint = new DealingConstraintBIZ();
                        DealingConstraintDTO constriant = bizConstraint.LoadDealingConstraint(cboProcess.SelectedValue.ToString().ToNZString());
                        if (constriant != null && constriant.LOT_CONTROL_FLAG.StrongValue == 1)
                        {
                            string MasterNo = shtView.Cells[shtView.ActiveRowIndex, (int)eColView.ITEM_CD].Text;
                            string PackNo = shtView.Cells[shtView.ActiveRowIndex, (int)eColView.PACK_NO].Text;

                            for (int iRow = 0; iRow < shtView.RowCount; iRow++)
                            {
                                if (!(MasterNo.Equals(shtView.Cells[iRow, (int)eColView.ITEM_CD].Text) &&
                                    PackNo.Equals(shtView.Cells[iRow, (int)eColView.PACK_NO].Text)))
                                    continue;

                                if (((int)eRowStatus.ADD).Equals(shtView.Cells[shtView.ActiveRowIndex, (int)eColView.ROW_STATUS].Value))
                                {
                                    shtView.Rows[iRow].Remove();
                                }
                                else
                                {
                                    shtView.Cells[iRow, (int)eColView.ROW_STATUS].Value = (int)eRowStatus.DELETE;
                                    shtView.Rows[iRow].Visible = false;
                                }
                            }
                        }
                        else
                        {
                            if (((int)eRowStatus.ADD).Equals(shtView.Cells[shtView.ActiveRowIndex, (int)eColView.ROW_STATUS].Value))
                            {
                                shtView.Rows[shtView.ActiveRowIndex].Remove();
                            }
                            else
                            {
                                shtView.Cells[shtView.ActiveRowIndex, (int)eColView.ROW_STATUS].Value = (int)eRowStatus.DELETE;
                                shtView.Rows[shtView.ActiveRowIndex].Visible = false;
                            }

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusiness(this, ex.Message);
            }
        }
        #endregion

        #region Spread event



        #region Spread trigger.

        private void fpView_LeaveCell(object sender, LeaveCellEventArgs e)
        {
            try
            {
                if (e.Row != e.NewRow)
                {  // ถ้าเป็นการเปลี่ยนแถว ต้องเช็คก่อนว่า Validate แถวผ่านหรือไม่?
                    if (!ValidateRowSpread(e.Row, false))
                    {
                        e.Cancel = true;
                    }
                    else
                    {
                        //if (e.Column == (int)eColView.COUNT_QTY)
                        //{
                        //    CalculateDiffQty(e.Row);
                        //}

                        //if (e.Column == (int)eColView.ITEM_CD
                        //    || e.Column == (int)eColView.LOT_NO
                        //    || e.Column == (int)eColView.EFFECT_INVENTORY_FLAG
                        //    || e.Column == (int)eColView.COUNT_QTY
                        //    )
                        //{
                        //    UpdateRowStatus(e.Row);
                        //}
                    }
                }
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusiness(this, ex.Message);
            }
        }

        private void CalculateDiffQty(int iRow)
        {
            decimal decSystemQty = 0;
            decimal decCountQty = 0;

            decSystemQty = Convert.ToDecimal(shtView.Cells[iRow, (int)eColView.SYSTEM_QTY].Value);

            decCountQty = Convert.ToDecimal(shtView.Cells[iRow, (int)eColView.COUNT_QTY].Value);

            shtView.Cells[iRow, (int)eColView.COUNT_QTY].Value = decCountQty;

            shtView.Cells[iRow, (int)eColView.DIFF_QTY].Value = decCountQty - decSystemQty;

        }

        private void UpdateRowStatus(int iRow)
        {
            int CurrentStatus = Convert.ToInt32(shtView.Cells[iRow, (int)eColView.ROW_STATUS].Value);

            if (CurrentStatus == (int)eRowStatus.NONE)
            {
                shtView.Cells[iRow, (int)eColView.ROW_STATUS].Value = (int)eRowStatus.UPDATE;
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
            //if (e.KeyData == Keys.Enter)
            //{

            //    int iCol = this.shtView.ActiveColumnIndex;
            //    int iRow = this.shtView.ActiveRowIndex;

            //    if (iCol == (int)eColView.COUNT_QTY)
            //    {
            //        CalculateDiffQty(iRow);
            //    }

            //    if (iCol == (int)eColView.ITEM_CD
            //        || iCol == (int)eColView.LOT_NO
            //        || iCol == (int)eColView.EFFECT_INVENTORY_FLAG
            //        || iCol == (int)eColView.COUNT_QTY
            //        )
            //    {
            //        UpdateRowStatus(iRow);
            //    }
            //}
        }

        private void fpView_ButtonClicked(object sender, EditorNotifyEventArgs e)
        {
            try
            {
                if (e.Column == (int)eColView.BTN_ITEM_CD)
                {
                    ItemFindDialog dialog = new ItemFindDialog(eSqlOperator.In, null);
                    dialog.ShowDialog(this);

                    if (dialog.IsSelected)
                    {
                        LoadItemIntoRow(e.Row, dialog.SelectedItem.ITEM_CD, dialog.SelectedItem);


                    }
                }
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusiness(this, ex.Message);
            }
        }
        #endregion

        #region Spread Validate
        /// <summary>
        /// Validate spread row.
        /// </summary>
        /// <param name="row"></param>
        /// <param name="forceValidate">force to validate.</param>
        /// <returns></returns>
        private bool ValidateRowSpread(int row, bool forceValidate)
        {
            int rowStatus = Convert.ToInt32(shtView.Cells[row, (int)eColView.ROW_STATUS].Value);

            if (rowStatus == (int)eRowStatus.ADD)
            {
                string CountQty = shtView.Cells[row, (int)eColView.COUNT_QTY].Text;
                if (String.IsNullOrEmpty(CountQty))
                {
                    ErrorItem error = new ErrorItem(null, TKPMessages.eValidate.VLM0088.ToString());
                    MessageDialog.ShowBusiness(this, error.Message);
                    return false;
                }
            }

            if (rowStatus != (int)eRowStatus.DELETE)
            {
                //Check item
                string strItemCode = shtView.Cells[row, (int)eColView.ITEM_CD].Text;                

                if (String.IsNullOrEmpty(strItemCode))
                {
                    ErrorItem error = new ErrorItem(null, TKPMessages.eValidate.VLM0006.ToString());
                    MessageDialog.ShowBusiness(this, error.Message);
                    return false;
                }
                else
                {
                    ItemValidator itemValidator = new ItemValidator();
                    BusinessException error = itemValidator.CheckItemNotExist(strItemCode.ToNZString());

                    //modify 30 oct 2010
                    // check ว่า item ต้องอยู่ใน master
                    // ไม่งั้นต้องใส่จำนวน = 0
                    object objCountQty = shtView.Cells[row, (int)eColView.COUNT_QTY].Value;
                    decimal decCountQty = 0;

                    if (objCountQty == DBNull.Value || objCountQty == null)
                    {
                        decCountQty = 0;
                    }
                    else
                    {
                        decCountQty = Convert.ToDecimal(objCountQty);
                    }

                    if (decCountQty != 0)
                    {

                        if (error != null)
                        {
                            MessageDialog.ShowBusiness(this, error.Error.Message);
                            return false;
                        }
                    }
                    else
                    {
                        //ปล่อยมันไป ถึง part หาไม่เจอ แต่ใส่เป็น 0 แสดงว่า ยอมรับ เผื่อกรณีเอาไป clear inventory
                    }
                }

                //Check Tag No
                string strTagNo = shtView.Cells[row, (int)eColView.TAG_NO].Text;
                if (!(string.Empty.Equals(strTagNo))) 
                {
                    int iTag = Convert.ToInt32(strTagNo);
                    if (iTag < 1 || iTag > 99999) 
                    {
                        MessageDialog.ShowBusiness(this, new Message(TKPMessages.eValidate.VLM0228.ToString()));

                        return false;
                    }
                }


                //modify 5 nov 2010
                // Check Lot ต้องยังไม่มีข้อมูล ใน list ทั้งหมด กรณีเป็น manual add


                int iManualFlag = Convert.ToInt32(shtView.Cells[row, (int)eColView.MANUAL_ADD_FLAG].Value);
                if (iManualFlag == 1)
                {
                    // check ส่วนที่เคย save ใน db แล้ว
                    string strLotNo = shtView.Cells[row, (int)eColView.LOT_NO].Text;
                    string strPackNo = shtView.Cells[row, (int)eColView.PACK_NO].Text;

                    //string strFilterStatement = "ITEM_CD='{0}' and ISNULL(LOT_NO,'')='{1}' and ISNULL(PACK_NO,'')='{2}' ";

                    //string strCurrentCountingID = shtView.Cells[row, (int)eColView.COUNTING_ID].Text;
                    //if (strCurrentCountingID != "")
                    //{
                    //    strFilterStatement = strFilterStatement + " AND COUNTING_ID <> " + strCurrentCountingID;
                    //}

                    //DataRow[] drFilterData = dtSearchData.Select(string.Format(strFilterStatement, strItemCode, strLotNo));
                    //if (drFilterData.Length > 0)
                    //{
                    //    string strCountingID = "";
                    //    try
                    //    {
                    //        if (drFilterData[0][(int)eColData.COUNTING_ID] != null
                    //            && drFilterData[0][(int)eColData.COUNTING_ID] != DBNull.Value
                    //            )
                    //        {
                    //            strCountingID = drFilterData[0][(int)eColData.COUNTING_ID].ToString();
                    //        }
                    //    }
                    //    catch
                    //    {
                    //        strCountingID = "";
                    //    }
                    //    MessageDialog.ShowBusiness(this, new Message(TKPMessages.eValidate.VLM0215.ToString(), new object[] { strItemCode, strLotNo, }));

                    //    return false;
                    //}


                    //check ส่วนของ ข้อมูลที่ add มาใหม่
                    //for (int iRowIndex = shtView.RowCount - 1; iRowIndex >= 0; iRowIndex--)
                    for (int iRowIndex = 0; iRowIndex < shtView.RowCount; iRowIndex++)
                    {
                        //if (shtView.Cells[iRowIndex, (int)eColView.COUNTING_ID].Value != null
                        //    && shtView.Cells[iRowIndex, (int)eColView.COUNTING_ID].Value != DBNull.Value
                        //    )
                        //{
                        //    break;
                        //}

                        if (iRowIndex != row)
                        {
                            int iRowStatus = Convert.ToInt32(shtView.Cells[iRowIndex, (int)eColView.ROW_STATUS].Value);

                            if (iRowStatus != (int)eRowStatus.DELETE)
                            {

                                string strRowPartNo = shtView.Cells[iRowIndex, (int)eColView.ITEM_CD].Text;
                                string strRowLotNo = shtView.Cells[iRowIndex, (int)eColView.LOT_NO].Text;
                                string strRowPackNo = shtView.Cells[iRowIndex, (int)eColView.PACK_NO].Text;

                                if (strRowPartNo.Equals(strItemCode)
                                    && strRowLotNo.Equals(strLotNo)
                                    && strRowPackNo.Equals(strPackNo)
                                    )
                                {
                                    MessageDialog.ShowBusiness(this, new Message(TKPMessages.eValidate.VLM0215.ToString(), new object[] { strItemCode, strLotNo, strPackNo, iRowIndex }));

                                    return false;
                                }
                            }
                        }
                    }
                }


            }

            return true;
        }
        #endregion

        #endregion


        private void btnFind_Click(object sender, EventArgs e)
        {
            try
            {
                ErrorItem err = CheckCanFindData();
                if (err != null)
                {
                    MessageDialog.ShowBusiness(this, err.Message);
                    return;
                }

                StockTakingBIZ biz = new StockTakingBIZ();
                StockTakingDTO dto = new StockTakingDTO();
                dto.STOCK_TAKING_DATE = Convert.ToDateTime(dtStockTakingDate.DateValue);
                dto.LOCATION_CODE = cboProcess.SelectedValue.ToString();//txtLocation.Text;

                if (chkIncomplete.Checked)
                {
                    dto.SEARCH_INCOMPLETE = 1;
                }
                else
                {
                    dto.SEARCH_INCOMPLETE = 0;
                }


                dtSearchData = biz.LoadStockTakingEntryData(dto);

                m_iRunUpdateProcess = biz.GetFlagRunUpdateProcess(dto);

                if (dtSearchData != null && dtSearchData.Rows.Count > 0)
                {
                    BindData(dtSearchData);

                    //int iRunUpdateProcess = 0;

                    ////หาว่ามีตัวที่ถูก adjust หรือไม่
                    //for (int iRow = 0; iRow < dtSearchData.Rows.Count; iRow++)
                    //{
                    //    iRunUpdateProcess = Convert.ToInt32(dtSearchData.Rows[iRow][(int)eColData.ADJUSTED_FLAG]);

                    //    if (iRunUpdateProcess == 1) break;
                    //}


                    if (m_iRunUpdateProcess == 1)
                    {
                        SetScreenMode(eScreenMode.VIEW);
                        //Run Update Process 
                        MessageDialog.ShowBusiness(this
                            , new EVOFramework.Message(TKPMessages.eValidate.VLM0090.ToString()
                                , new object[] { cboProcess.SelectedValue.ToString() }
                            //, new object[] { this.txtLocation.Text }
                            ));
                    }
                    else
                    {
                        bool bPermission = CtrlUtil.GetPermissionControl(this.ScreenCode, CtrlUtil.ePermissionMode.Edit);

                        if (bPermission)
                        {

                            SetScreenMode(eScreenMode.EDIT);
                        }
                        else
                        {
                            SetScreenMode(eScreenMode.VIEW);
                        }
                    }
                }
                else
                {
                    ////search ไม่เจอ ต้อง check location ว่ามีจริงหรือเปล่า ถ้ามีจริง
                    //// ก็ enable ให้ edit
                    //LocationBIZ bizLoc = new LocationBIZ();
                    //LocationDTO dtoLoc = bizLoc.LoadLocation(new NZString(txtLocation, this.txtLocation.Text.Trim()));

                    //if (dtoLoc != null)
                    //{
                    //    BindData(dt);

                    //    int iRunUpdateProcess = 0;
                    //    iRunUpdateProcess = Convert.ToInt32(dt.Rows[0][(int)eColData.ADJUSTED_FLAG]);

                    //    if (iRunUpdateProcess == 1)
                    //    {
                    //        SetScreenMode(eScreenMode.VIEW);
                    //        //Run Update Process 
                    //        MessageDialog.ShowBusiness(this
                    //            , new EVOFramework.Message(TKPMessages.eValidate.VLM0081.ToString()
                    //                    , new object[] { this.txtLocation.Text }
                    //            ));
                    //    }
                    //    else
                    //    {
                    //        SetScreenMode(eScreenMode.EDIT);
                    //    }
                    //}
                    //else
                    //{

                    shtView.RowCount = 0;

                    if (m_iRunUpdateProcess == 1)
                    {
                        SetScreenMode(eScreenMode.VIEW);
                        //Run Update Process 
                        MessageDialog.ShowBusiness(this
                            , new EVOFramework.Message(TKPMessages.eValidate.VLM0090.ToString()
                                , new object[] { cboProcess.SelectedValue.ToString() }
                            //, new object[] { this.txtLocation.Text }
                            ));
                    }
                    else
                    {


                        MessageDialog.ShowInformation(this, null, Message.LoadMessage(TKPMessages.eInformation.INF0001.ToString()).MessageDescription);
                        LoadCurrentStockTakingData();

                        bool bPermission = CtrlUtil.GetPermissionControl(this.ScreenCode, CtrlUtil.ePermissionMode.Edit);

                        if (bPermission)
                        {

                            SetScreenMode(eScreenMode.EDIT);
                        }
                        else
                        {
                            SetScreenMode(eScreenMode.VIEW);
                        }
                        //}

                    }
                }


                SheetWidthController ctrl = new SheetWidthController();
                ctrl.SetSheetWidth(shtView, this.ScreenCode);
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusiness(this, ex.Message);
            }

        }

        private void BindData(DataTable dt)
        {
            DefaultSheetDataModel dataModel;
            dataModel = new DefaultSheetDataModel(0, shtView.ColumnCount);
            dataModel.RowCount = 0;
            shtView.RowCount = 0;

            for (int iRow = 0; iRow <= dt.Rows.Count - 1; iRow++)
            {

                dataModel.RowCount++;

                dataModel.SetValue(iRow, (int)eColView.ADJUSTED_FLAG, dt.Rows[iRow][(int)eColData.ADJUSTED_FLAG]);
                dataModel.SetValue(iRow, (int)eColView.COUNT_QTY, dt.Rows[iRow][(int)eColData.COUNT_QTY]);
                dataModel.SetValue(iRow, (int)eColView.COUNTING_ID, dt.Rows[iRow][(int)eColData.COUNTING_ID]);
                dataModel.SetValue(iRow, (int)eColView.CUST_NAME, dt.Rows[iRow][(int)eColData.CUST_NAME]);
                dataModel.SetValue(iRow, (int)eColView.DIFF_QTY, dt.Rows[iRow][(int)eColData.DIFF_QTY]);
                dataModel.SetValue(iRow, (int)eColView.EFFECT_INVENTORY_FLAG, dt.Rows[iRow][(int)eColData.EFFECT_INVENTORY_FLAG]);
                dataModel.SetValue(iRow, (int)eColView.STOCK_TAKING_ID, dt.Rows[iRow][(int)eColData.STOCK_TAKING_ID]);
                dataModel.SetValue(iRow, (int)eColView.ITEM_CD, dt.Rows[iRow][(int)eColData.ITEM_CD]);
                dataModel.SetValue(iRow, (int)eColView.LOC_CD, dt.Rows[iRow][(int)eColData.LOC_CD]);
                dataModel.SetValue(iRow, (int)eColView.LOT_NO, dt.Rows[iRow][(int)eColData.LOT_NO]);
                dataModel.SetValue(iRow, (int)eColView.EXTERNAL_LOT_NO, dt.Rows[iRow][(int)eColData.EXTERNAL_LOT_NO]);
                dataModel.SetValue(iRow, (int)eColView.MANUAL_ADD_FLAG, dt.Rows[iRow][(int)eColData.MANUAL_FLAG]);
                dataModel.SetValue(iRow, (int)eColView.PACK_NO, dt.Rows[iRow][(int)eColData.PACK_NO]);
                dataModel.SetValue(iRow, (int)eColView.FG_NO, dt.Rows[iRow][(int)eColData.FG_NO]);
                dataModel.SetValue(iRow, (int)eColView.REMARK, dt.Rows[iRow][(int)eColData.REMARK]);
                dataModel.SetValue(iRow, (int)eColView.ROW_STATUS, (int)eRowStatus.NONE);
                dataModel.SetValue(iRow, (int)eColView.SHORT_NAME, dt.Rows[iRow][(int)eColData.SHORT_NAME]);
                dataModel.SetValue(iRow, (int)eColView.SYSTEM_QTY, dt.Rows[iRow][(int)eColData.SYSTEM_QTY]);
                dataModel.SetValue(iRow, (int)eColView.TAG_NO, dt.Rows[iRow][(int)eColData.TAG_NO]);


            }

            dataModel.Name = shtView.SheetName;
            shtView.Models.Data = dataModel;
        }

        private void CopyData()
        {
            for (int iRow = 0; iRow < shtView.Rows.Count; iRow++)
            {
                if (string.Empty.Equals(shtView.Cells[iRow, (int)eColView.COUNT_QTY].Text))
                {
                    shtView.Cells[iRow, (int)eColView.COUNT_QTY].Value = shtView.Cells[iRow, (int)eColView.SYSTEM_QTY].Value;
                    CalculateDiffQty(iRow);
                    UpdateRowStatus(iRow);
                }
            }
        }

        private ErrorItem CheckCanFindData()
        {
            try
            {
                //if ("".Equals(txtLocation.Text.Trim()))
                if (cboProcess.SelectedValue == null)
                {
                    return new ErrorItem(null, TKPMessages.eValidate.VLM0087.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusiness(this, ex.Message);
            }

            return null;
        }

        private void fpView_Change(object sender, ChangeEventArgs e)
        {
            try
            {
                if (e.Column == (int)eColView.COUNT_QTY)
                {
                    CalculateDiffQty(e.Row);
                }

                if (e.Column == (int)eColView.ITEM_CD
                    || e.Column == (int)eColView.LOT_NO
                    || e.Column == (int)eColView.EXTERNAL_LOT_NO
                    || e.Column == (int)eColView.EFFECT_INVENTORY_FLAG
                    || e.Column == (int)eColView.COUNT_QTY
                    || e.Column == (int)eColView.REMARK
                    || e.Column == (int)eColView.TAG_NO
                    || e.Column == (int)eColView.FG_NO
                    )
                {
                    UpdateRowStatus(e.Row);
                }
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusiness(this, ex.Message);
            }
        }

        private MessageDialogResult UpdateStockTakingData()
        {
            MessageDialogResult dr = MessageDialog.ShowConfirmation(this, new Message(SystemMaintenance.Messages.eConfirm.CFM9001.ToString()).MessageDescription);

            if (dr == MessageDialogResult.Yes)
            {
                List<StockTakingDetailDTO> listDataUpdate = new List<StockTakingDetailDTO>();
                List<StockTakingDetailDTO> listDataDelete = new List<StockTakingDetailDTO>();
                List<StockTakingDetailDTO> listDataInsert = new List<StockTakingDetailDTO>();

                for (int iRow = 0; iRow < shtView.RowCount; iRow++)
                {
                    int RowStatus = Convert.ToInt32(shtView.Cells[iRow, (int)eColView.ROW_STATUS].Value);

                    if ((int)eRowStatus.NONE != RowStatus)
                    {
                        //ไม่ใช้  none ก็  new dto ไว้รอได้เลย

                        StockTakingDetailDTO dto = new StockTakingDetailDTO();

                        //dto.ADJUSTED_FLAG=;

                        if (shtView.Cells[iRow, (int)eColView.COUNT_QTY].Value == DBNull.Value
                            || shtView.Cells[iRow, (int)eColView.COUNT_QTY].Text == ""
                            )
                        {

                            dto.COUNT_QTY = null;
                        }
                        else
                        {
                            dto.COUNT_QTY = Convert.ToDecimal(shtView.Cells[iRow, (int)eColView.COUNT_QTY].Value);
                        }
                        dto.COUNTING_ID = Convert.ToInt64(shtView.Cells[iRow, (int)eColView.COUNTING_ID].Value);


                        if (shtView.Cells[iRow, (int)eColView.DIFF_QTY].Value == DBNull.Value
                          || shtView.Cells[iRow, (int)eColView.DIFF_QTY].Text == ""
                        )
                        {

                            dto.DIFF_QTY = null;
                        }
                        else
                        {
                            dto.DIFF_QTY = Convert.ToDecimal(shtView.Cells[iRow, (int)eColView.DIFF_QTY].Value);
                        }




                        dto.EFFECT_INVENTORY_FLAG = Convert.ToInt32(shtView.Cells[iRow, (int)eColView.EFFECT_INVENTORY_FLAG].Value);
                        dto.ID = Convert.ToInt64(shtView.Cells[iRow, (int)eColView.STOCK_TAKING_ID].Value);
                        dto.ITEM_CD = Convert.ToString(shtView.Cells[iRow, (int)eColView.ITEM_CD].Value);
                        dto.LOC_CD = Convert.ToString(shtView.Cells[iRow, (int)eColView.LOC_CD].Value);
                        dto.LOT_NO = Convert.ToString(shtView.Cells[iRow, (int)eColView.LOT_NO].Value);
                        dto.EXTERNAL_LOT_NO = Convert.ToString(shtView.Cells[iRow, (int)eColView.EXTERNAL_LOT_NO].Value);
                        dto.PACK_NO = Convert.ToString(shtView.Cells[iRow, (int)eColView.PACK_NO].Value);
                        dto.FG_NO = Convert.ToString(shtView.Cells[iRow, (int)eColView.FG_NO].Value);
                        dto.TAG_NO = Convert.ToString(shtView.Cells[iRow, (int)eColView.TAG_NO].Value);

                        dto.MANUAL_ADD_FLAG = Convert.ToInt32(shtView.Cells[iRow, (int)eColView.MANUAL_ADD_FLAG].Value);
                        dto.REMARK = Convert.ToString(shtView.Cells[iRow, (int)eColView.REMARK].Value);
                        dto.ROW_STATUS = Convert.ToInt32(shtView.Cells[iRow, (int)eColView.ROW_STATUS].Value);
                        dto.STOCK_TAKING_DATE = Convert.ToDateTime(this.dtStockTakingDate.DateValue);
                        dto.SYSTEM_QTY = Convert.ToDecimal(shtView.Cells[iRow, (int)eColView.SYSTEM_QTY].Value); ;

                        dto.UPD_BY = CommonLib.Common.CurrentUserInfomation.UserCD;
                        dto.UPD_MACHINE = CommonLib.Common.CurrentUserInfomation.Machine;



                        if ((int)eRowStatus.ADD == RowStatus)
                        {
                            listDataInsert.Add(dto);
                        }
                        else if ((int)eRowStatus.UPDATE == RowStatus)
                        {
                            listDataUpdate.Add(dto);
                        }
                        else if ((int)eRowStatus.DELETE == RowStatus)
                        {
                            listDataDelete.Add(dto);
                        }


                    }

                }

                //Call update biz
                StockTakingBIZ biz = new StockTakingBIZ();
                biz.UpdateStockTakingData(listDataInsert, listDataUpdate, listDataDelete);

                MessageDialog.ShowInformation(this, null, Message.LoadMessage(Messages.eInformation.INF9003.ToString()).MessageDescription);

            }


            return dr;
        }


        private void ctxMenu_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                if (shtView.RowCount > 0 && shtView.ActiveRowIndex > -1)
                {
                    int iManualFlag = Convert.ToInt32(shtView.Cells[shtView.ActiveRowIndex, (int)eColView.MANUAL_ADD_FLAG].Value);

                    if (iManualFlag == 0)
                    {
                        //cannot delete stock taking item which was generated from pre-process
                        miDelete.Enabled = false;
                    }
                    else
                    {
                        //allow user to delete manual stock taking item
                        miDelete.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusiness(this, ex.Message);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            STK020_PrintStockCheckingList frmStockCheckingList = new STK020_PrintStockCheckingList();

            frmStockCheckingList.LocationCode = cboProcess.SelectedValue.ToString(); //this.txtLocation.Text;
            frmStockCheckingList.IncompleteData = chkIncomplete.Checked;

            frmStockCheckingList.ShowInTaskbar = true;
            frmStockCheckingList.Show();


        }

        private void btnCopyData_Click(object sender, EventArgs e)
        {
            try
            {
                CopyData();
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusiness(this, ex.Message);
            }
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            try
            {
                SelectAllData(true);
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusiness(this, ex.Message);
            }
        }

        private void btnUnSelectAll_Click(object sender, EventArgs e)
        {
            try
            {
                SelectAllData(false);
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusiness(this, ex.Message);
            }
        }

        private void fpView_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (m_screenMode == eScreenMode.VIEW)
                {
                    miAdd.Enabled = false;
                    miAddPack.Enabled = false;
                    miDelete.Enabled = false;
                    return;

                }

                ErrorItem err = CheckCanFindData();
                if (err != null)
                {
                    MessageDialog.ShowBusiness(this, err.Message);
                    return;
                }

                //bool isClickOnCell = false;

                //CellRange cellRange = fpView.GetCellFromPixel(0, 0, e.X, e.Y);
                //if (cellRange.Column != -1 && cellRange.Row != -1) {
                //    shtView.SetActiveCell(cellRange.Row, cellRange.Column);
                //    shtView.AddSelection(cellRange.Row, cellRange.Column, 1, 1);
                //    isClickOnCell = true;
                //}

                //if (isClickOnCell) 
                //{
                DealingConstraintBIZ bizConstraint = new DealingConstraintBIZ();
                DealingConstraintDTO constriant = bizConstraint.LoadDealingConstraint(cboProcess.SelectedValue.ToString().ToNZString());
                if (constriant != null && constriant.LOT_CONTROL_FLAG.StrongValue == 1)
                {
                    miAdd.Enabled = false;
                    miAddPack.Enabled = true;
                }
                else
                {
                    miAdd.Enabled = true;
                    miAddPack.Enabled = false;
                }
                //}
                //else 
                //{
                //    miAdd.Enabled = false;
                //    miAddPack.Enabled = false;
                //}

                ctxMenu.Show(fpView, e.Location);
            }
        }

        private void fpView_KeyDown(object sender, KeyEventArgs e)
        {
            CtrlUtil.FilterShortCut(e);
        }

        private void txtLotNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                FindLotNoRecord();
            }
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            FindLotNoRecord();
        }

        private void FindLotNoRecord()
        {
            if (shtView.RowCount == 0)
                return;

            if (shtView.ActiveRowIndex < 0)
                return;

            string strFindLotText = txtLotNo.Text.Trim();
            if (string.Empty.Equals(strFindLotText))
                return;

            for (int row = shtView.ActiveRowIndex + 1; row < shtView.RowCount; row++)
            {
                if (shtView.Cells[row, (int)eColView.LOT_NO].Text.Trim().IndexOf(strFindLotText) >= 0)
                {
                    shtView.ActiveRowIndex = row;
                    shtView.SetActiveCell(row, (int)eColView.COUNT_QTY);
                    shtView.AddSelection(row, (int)eColView.STOCK_TAKING_ID, 1, shtView.ColumnCount);
                    return;
                }
            }

            for (int row = 0; row < shtView.ActiveRowIndex + 1; row++)
            {
                if (shtView.Cells[row, (int)eColView.LOT_NO].Text.Trim().IndexOf(strFindLotText) >= 0)
                {
                    shtView.ActiveRowIndex = row;
                    shtView.SetActiveCell(row, (int)eColView.COUNT_QTY);
                    shtView.AddSelection(row, (int)eColView.STOCK_TAKING_ID, 1, shtView.ColumnCount);
                    return;
                }
            }
        }



    }
}
