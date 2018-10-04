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
using Message = EVOFramework.Message;
using System.Windows.Forms;
using System.Collections.Generic;
using System;
using System.Data;
using System.ComponentModel;
using SystemMaintenance;
using System.Text;
using System.Drawing;

namespace Rubik.Transaction
{
    [Screen("TRN103", "FG Selection", eShowAction.Normal, eScreenType.Screen, "FG Selection")]
    public partial class TRN103_FGSelection : CustomizeForm
    {
        #region Enum
        public enum eColView
        {
            TRANS_ID,
            LOT_NO,
            EXTERNAL_LOT_NO,
            QTY
        } ;

        public enum eColCustomerOrderDetail
        {
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
        #endregion

        #region Constructor
        public TRN103_FGSelection()
        {
            InitializeComponent();
        }

        public TRN103_FGSelection(string strOrderNo, string strOrderDetailNo, string strLocation, string strItem_Cd, string strPartNo, decimal dRemainQty, NZString strSlipNo, SheetView shtLot, DataTable dtCust)
        {
            InitializeComponent();
            OrderNo = strOrderNo.ToNZString();
            OrderDetailNo = strOrderDetailNo.ToNZString();
            ItemCd = strItem_Cd.ToNZString();
            LocCd = strLocation.ToNZString();
            SlipNo = strSlipNo;
            PartNo = strPartNo.ToNZString();
            RemainQty = dRemainQty.ToNZDecimal();
            if (shtLot.RowCount != 0) shtPreviousLot = shtLot;
            if (dtCust.Rows.Count > 0)
            {
                m_Data = dtCust;
            }
        }
        #endregion

        #region Variable
        private Common.eScreenMode m_Mode = Common.eScreenMode.ADD;
        private ToolStripButton tsbOk = new System.Windows.Forms.ToolStripButton();
        private ToolStripButton tsbCancel = new System.Windows.Forms.ToolStripButton();
        private NZString ItemCd = new NZString();
        private NZString LocCd = new NZString();
        private NZString SlipNo = new NZString();
        private NZDecimal RemainQty = new NZDecimal();
        private NZString PartNo = new NZString();
        private NZString OrderDetailNo = new NZString();
        private NZString OrderNo = new NZString();
        private SheetView shtPreviousLot;
        private DataTable m_Data = new DataTable();
        private DataTable dt = new DataTable();
        private KeyboardSpread m_keyboardSpread = null;
        private bool m_bRowHasModified = false;

        const string CONST_COLUMN_NAME_CHECK_FLAG = "CHECK_FLAG";

        private List<string> ChoosePack = new List<string>();
        #endregion

        #region FormLoad
        private void TRN103_FGSelection_Load(object sender, EventArgs e)
        {
            InitializeMenuButton();
            InitialFormat();
            InitialSpread();
            InitialDefaultValue();
            InitialData();

            CtrlUtil.EnabledControl(false, txtItemNo, txtPartNo, txtRemainQty, txtQty);

            loadData();
            
            /* Atipan C. Modify 

            // Get all data
            DeliveryBIZ bizDelivery = new DeliveryBIZ();
            List<ActualOnhandViewDTO> listDTO = bizDelivery.Load_LotMaintenance(SlipNo, LocCd, ItemCd, false);
            m_Data = DTOUtility.ConvertListToDataTable<ActualOnhandViewDTO>(listDTO);
            m_Data.Columns.Add(CONST_COLUMN_NAME_CHECK_FLAG, typeof(int));


            m_Data = OrderData(m_Data);

            // Filter
            loadData();
            */
        }
        #endregion

        #region LoadData


        private void loadData()
        {
            try
            {
                dt = m_Data;

                if (dt.Rows.Count > 0)
                {
                    DataTable dd = new DataTable();
                    dd = dt.Clone();

                    for (int ind = 0; ind < dt.Rows.Count; ind++)
                    {
                        if (dt.Rows[ind]["REF_NO"].ToString() == OrderNo && dt.Rows[ind]["ITEM_CD"].ToString() == ItemCd)
                        {
                            dd.Rows.Add(dt.Rows[ind].ItemArray);
                        }
                    }

                    if (dd.Rows.Count > 0)
                    {
                        shtView.Rows.Count = 0;

                        DataTable data = new DataTable();
                        data.Columns.Add("TRANS_ID", typeof(String));
                        data.Columns.Add("LOT_NO", typeof(String));
                        data.Columns.Add("EXTERNAL_LOT_NO", typeof(String));
                        data.Columns.Add("QTY", typeof(Decimal));

                        for (int i = 0; i < dd.Rows.Count; i++)
                        {
                            DataRow row = data.NewRow();
                            row["TRANS_ID"] = dd.Rows[i]["REF_NO"];
                            row["LOT_NO"] = dd.Rows[i]["LOT_NO"];
                            row["EXTERNAL_LOT_NO"] = dd.Rows[i]["EXTERNAL_LOT_NO"];
                            row["QTY"] = dd.Rows[i]["QTY"];

                            data.Rows.Add(row);
                        }

                        PackingEntryUIDM model = new PackingEntryUIDM();
                        model.DATA_VIEW = data;

                        dmc.LoadData(model);
                        shtView.DataSource = model.DATA_VIEW;
                    }
                }
                else
                {
                    DataTable d = new DataTable();
                    for (int i = 0; i < 5; i++)
                    {
                        DataRow r = d.NewRow();
                        d.Rows.Add(r);
                    }

                    PackingEntryUIDM model = new PackingEntryUIDM();
                    model.DATA_VIEW = d;

                    dmc.LoadData(model);
                    shtView.DataSource = model.DATA_VIEW;
                }

                //for (int i = 0; i < m_Data.Rows.Count; i++)
                //{
                //    shtView.Rows.Count = i + 1;
                //    shtView.Cells[i, (int)eColView.LOT_NO].Value = m_Data.Rows[i][(int)eColCustomerOrderDetail.LOT_NO];
                //    shtView.Cells[i, (int)eColView.EXTERNAL_LOT_NO].Value = m_Data.Rows[i][(int)eColCustomerOrderDetail.EXTERNAL_LOT_NO];
                //    shtView.Cells[i, (int)eColView.QTY].Value = m_Data.Rows[i][(int)eColCustomerOrderDetail.QTY];
                //}

                //dt = m_Data;//.Copy();

                //fpView.DataSource = dt;
                CalTotatValue();
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusiness(this, ex.Message);
            }
        }

        private DataTable OrderData(DataTable dt)
        {
            return dt;
        }

        private void InitialData()
        {
            PackingEntryUIDM model = new PackingEntryUIDM();
            shtView.DataSource = model.DATA_VIEW;
            CtrlUtil.SpreadSetColumnsLocked(shtView, false, (int)eColView.LOT_NO);
            CtrlUtil.SpreadSetColumnsLocked(shtView, false, (int)eColView.EXTERNAL_LOT_NO);
            CtrlUtil.SpreadSetColumnsLocked(shtView, false, (int)eColView.QTY);
        }


        private void InitialFormat()
        {
            // Set Control Format
            CommonLib.FormatUtil.SetNumberFormat(this.txtRemainQty, FormatUtil.eNumberFormat.Total_Qty_PCS);
            CommonLib.FormatUtil.SetNumberFormat(this.txtQty, FormatUtil.eNumberFormat.Total_Qty_PCS);

            // Set Spread Format
            FormatUtil.SetNumberFormat(shtView.Columns[(int)eColView.QTY], FormatUtil.eNumberFormat.Qty_PCS);
        }
        private void InitialSpread()
        {
            shtView.ActiveSkin = Common.ACTIVE_SKIN;

            m_keyboardSpread = new KeyboardSpread(fpView);
            m_keyboardSpread.RowAdding += new KeyboardSpread.RowAddingHandler(m_keyboardSpread_RowAdding);
            m_keyboardSpread.RowAdded += new KeyboardSpread.RowAddedHandler(m_keyboardSpread_RowAdded);
            m_keyboardSpread.RowRemoving += new KeyboardSpread.RowRemovingHandler(m_keyboardSpread_RowRemoving);

            fpView.SubEditorOpening += CtrlUtil.SpreadDisableSubEditorOpening;
            CtrlUtil.MappingDataFieldWithEnum(shtView, typeof(eColView));

            m_keyboardSpread.StartBind();
            shtView.OperationMode = OperationMode.Normal;            
        }
        private void InitialDefaultValue()
        {
            txtItemNo.Text = ItemCd.StrongValue;
            txtPartNo.Text = PartNo.StrongValue;
            txtRemainQty.Decimal = RemainQty.StrongValue;
        }

        #endregion

        #region SentData
        public SheetView shtData
        { get { return shtView; } set { shtView = value; } }
        //public string ItemNo
        //{ get { return txtItemNo.Text; } set { txtItemNo.Text = value; } }
        //public string ItemName
        //{ get { return txtItemDesc.Text; } set { txtItemDesc.Text = value; } }
        #endregion

        #region MenuBotton
        private void InitializeMenuButton()
        {
            tsbSaveAndClose.Visible = false;
            tsbSaveAndNew.Visible = false;            

            tsbCancel.Text = "Cancel";
            tsbCancel.Image = global::Rubik.Forms.Properties.Resources.CANCEL_ICON;
            tslControl.Items.Insert(tslControl.Items.IndexOf(tslControl.Items[tsbSaveAndClose.Name]) + 1, tsbCancel);
            tsbCancel.Click += new EventHandler(tsbCancel_Click);

            tsbOk.Text = "Ok";
            tsbOk.Image = global::Rubik.Forms.Properties.Resources.ADD_ICON;
            tslControl.Items.Insert(tslControl.Items.IndexOf(tslControl.Items[tsbSaveAndClose.Name]) + 1, tsbOk);
            tsbOk.Click += new EventHandler(tsbOk_Click); 
        }
        private void tsbOk_Click(object sender, EventArgs e)
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
                if (txtRemainQty.Decimal < txtQty.Decimal)
                {
                    MessageDialog.ShowInformation(this, "Information", new Message(TKPMessages.eValidate.VLM0214.ToString()).MessageDescription);
                    return;
                }

                PackingEntryUIDM model = dmc.SaveData(new PackingEntryUIDM());
                model.DATA_VIEW = (DataTable)shtView.DataSource;
                model.DATA_VIEW.AcceptChanges();


                UpdateRecord(model.DATA_VIEW);

                if (!ValidateBeforeSave(model))
                    return;

                DialogResult = DialogResult.OK;
                //this.Close();
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

        private void tsbCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            loadData();
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

                        if (string.Empty.Equals(shtView.Cells[row, column].Text))
                            return true;

                        CalTotatValue();
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

            if (shtView.RowCount <= 0)
                return true;

            object src_lot_no = shtView.Cells[row, (int)eColView.LOT_NO].Value;
            object src_cust_lot_no = shtView.Cells[row, (int)eColView.EXTERNAL_LOT_NO].Value;
            object src_qty = shtView.Cells[row, (int)eColView.QTY].Value;

            if (src_lot_no == null && src_cust_lot_no == null && src_qty == null)
                return false;

            if (string.Empty.Equals(shtView.Cells[row, (int)eColView.LOT_NO].Text.Trim()))
            {
                MessageDialog.ShowBusiness(this, Message.LoadMessage(TKPMessages.eValidate.VLM0011.ToString()));
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
            //for (int iRow = 0; iRow < shtView.Rows.Count; iRow++)
            //{
            //    if (iRow == row)
            //        continue;

            //    // Check key duplidate.
            //    object lot_no = shtView.Cells[iRow, (int)eColView.LOT_NO].Value;

            //    if (Equals(src_lot_no, lot_no))
            //    {
            //        MessageDialog.ShowBusiness(this, Message.LoadMessage(TKPMessages.eValidate.VLM0189.ToString()));
            //        return false;
            //    }
            //}

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

        #region Keyboard Spread
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
            shtView.SetActiveCell(shtView.RowCount - 1, (int)eColView.LOT_NO);

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
        #endregion

        #region Spread trigger.

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

        }

        private void MoveNextCell()
        {
            //if (shtLotNoList.ActiveRowIndex == shtLotNoList.RowCount - 1 && shtLotNoList.ActiveColumnIndex == (int)eColView.QTY)
            //{
            //    m_keyboardSpread.OnActionAddNewRow();
            //    return;
            //}

            int iNextRow = shtView.ActiveRowIndex;
            int iNextCol = shtView.ActiveColumnIndex;

            if (iNextCol == (int)eColView.QTY)
            {
                iNextRow = iNextRow + 1;
                iNextCol = 0;
            }
            else
            {
                iNextCol = iNextCol + 1;
            }

            for (int iRow = iNextRow; iRow < shtView.RowCount; iRow++)
            {
                for (int iCol = iNextCol; iCol < shtView.ColumnCount; iCol++)
                {
                    shtView.SetActiveCell(iRow, iCol);
                    fpView.ShowActiveCell(VerticalPosition.Nearest, HorizontalPosition.Nearest);

                    if (!shtView.Cells[iRow, iCol].Locked)
                        return;
                }
            }
        }

        private void fpView_Validating(object sender, CancelEventArgs e)
        {
            if (!ValidateRowSpread(shtView.ActiveRowIndex, false))
            {
                e.Cancel = true;
            }
        }

        private void fpView_KeyDown(object sender, KeyEventArgs e)
        {
            CtrlUtil.FilterShortCut(e);
        }
        #endregion

        private void RemoveRowUnused(SheetView sheet)
        {
            for (int i = 0; i < sheet.RowCount; i++)
            {
                if (string.Empty.Equals(shtView.Cells[i, (int)eColView.TRANS_ID].Text.Trim()) &&
                    string.Empty.Equals(shtView.Cells[i, (int)eColView.LOT_NO].Text.Trim()) &&
                    string.Empty.Equals(shtView.Cells[i, (int)eColView.EXTERNAL_LOT_NO].Text.Trim()) &&
                    string.Empty.Equals(shtView.Cells[i, (int)eColView.QTY].Text.Trim()))
                {
                    sheet.RemoveRows(i, 1);
                    i--;
                }
            }
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

        private bool ValidateBeforeSave(PackingEntryUIDM model)
        {
            if (shtView.RowCount == 0)
                ValidateException.ThrowErrorItem(new ErrorItem(null, TKPMessages.eValidate.VLM0186.ToString()));

            for (int iRow = 0; iRow < shtView.RowCount; iRow++)
            {
                if (!ValidateRowSpread(iRow, true))
                    return false;
            }

            return true;
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            m_keyboardSpread.OnActionAddNewRow();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            m_keyboardSpread.OnActionRemoveRow();
            CalTotatValue();
        }

        private void btnItemNo_Click(object sender, EventArgs e)
        {
            //if (chkFilterItem.Checked && !"".Equals(txtCustomer.Text.Trim()))
            //{
            //    txtItemNo.CustomerCode = txtCustomer.Text;
            //}
            //else
            //{
            //    txtItemNo.CustomerCode = "";
            //}
        }

        private void txtItemNo_KeyPressResult(object sender, bool isFound, NZString ItemCD)
        {
            if (!isFound)
            {
                //this.txtItemNo.Text = "";
                //this.txtItemDesc.Text = "";

                return;
            }

        }

        #region Private Method
        private void AutoCheckFromMainScreen()
        {
            /* Atipan C. Modify
            if (shtPreviousLot == null || shtPreviousLot.RowCount <= 0 || shtView.RowCount <= 0) return;

            for (int i = 0; i < shtPreviousLot.RowCount; i++)
            {
                string pOrderDetailNo = Convert.ToString(shtPreviousLot.GetValue(i, (int)eColPreviousLot.REF_SLIP_NO));
                string pItemCd = Convert.ToString(shtPreviousLot.GetValue(i, (int)eColPreviousLot.ITEM_CD));
                string pPackNo = Convert.ToString(shtPreviousLot.GetValue(i, (int)eColPreviousLot.PACK_NO));
                string pLotNo = Convert.ToString(shtPreviousLot.GetValue(i, (int)eColPreviousLot.LOT_NO));

                if (pItemCd != ItemCd) continue;

                for (int j = 0; j < shtView.RowCount; j++)
                {
                    if (Convert.ToString(shtView.GetValue(j, (int)eColumns.PACK_NO)) == pPackNo
                        && Convert.ToString(shtView.GetValue(j, (int)eColumns.LOT_NO)) == pLotNo)
                    {
                        if (OrderDetailNo.StrongValue != pOrderDetailNo)
                        {
                            shtView.Rows[j].BackColor = Color.DarkSlateGray;
                            CtrlUtil.SpreadSetCellLocked(shtView, true, j, (int)eColumns.CHECK_FLAG);
                        }
                        else shtView.Cells[j, (int)eColumns.CHECK_FLAG].Value = true;
                        break;
                    }
                }
            }
             */
        }
        private void CalTotatValue()
        {
            decimal TotalQTY = 0;
            for (int i = 0; i < shtView.RowCount; i++)
            {
                    TotalQTY += Convert.ToDecimal(shtView.GetValue(i, (int)eColView.QTY));
            }
            txtQty.Decimal = TotalQTY;
        }
        #endregion

        private void txtLotNo_TextChanged(object sender, EventArgs e)
        {
            loadData();
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


    }
}
