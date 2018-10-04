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
using Rubik.Data;
using System.Data;
using System.Linq;

namespace Rubik.MRP
{
    //[Screen("PUR020", "Purchase Order Entry", eShowAction.Normal, eScreenType.Screen, "Purchase Order Entry")]
    public partial class PUR020_PurchaseOrderEntry : SystemMaintenance.Forms.CustomizeBaseForm
    {

        private void PUR020_PurchaseOrderEntry_Load(object sender, EventArgs e)
        {
            dtmPODate.Format = Common.CurrentUserInfomation.DateFormatString;
            shtView.Columns[(int)eColumn.DUE_DATE].CellType = CtrlUtil.CreateDateTimeCellType();
            this.SetDefault(m_HDTOPurchaseOrder);
            m_bIsActived = true;
        }

        #region Enum


        /// <summary>
        /// enum of screenstate
        /// </summary>
        private enum eScreenState
        {
            View,
            Idle,
            Add,
            Edit,
        }

        /// <summary>
        /// enum of column in spredsheet.
        /// </summary>
        private enum eColumn
        {
            PO_LINE,
            CRT_BY,
            CRT_DATE,
            CRT_MACHINE,
            UPD_BY,
            UPD_DATE,
            UPD_MACHINE,
            IS_ACTIVE,
            PO_NO,
            ITEM_CD,
            BUTTON,
            ITEM_DESC,
            DUE_DATE,
            UNIT,
            PO_QTY,
            UNIT_PRICE,
            AMOUNT,
            INV_UM,
            INV_QTY,
            RECEIVE_QTY,
            BACK_ORDER_QTY,
            LAST_RECEIVE_ID,
            LAST_RECEIVE_DATE,
            STATUS,
            ModifyState,
            KeptStatus,
            RATE,
        }

        /// <summary>
        /// enum of modify state of a row
        /// </summary>
        private enum eModifyState
        {
            None,
            Add,
            Edit,
            Delete,
        }

        #endregion

        #region field


        private DialogResult m_dialogResult = DialogResult.Cancel;

        private PurchaseOrderBIZ m_BIZPurchaseOrder;

        private PurchaseOrderHDTO m_HDTOPurchaseOrder = null;

        private eScreenState m_ScreenStateEnum;

        int[] iUnLockedColumn = 
                    { 
                        (int)eColumn.ITEM_CD,
                        (int)eColumn.BUTTON, 
                        (int)eColumn.DUE_DATE, 
                        (int)eColumn.UNIT_PRICE, 
                        (int)eColumn.PO_QTY, 
                        (int)eColumn.STATUS 
                    };

        public delegate void OperationDelegate();

        private bool m_bIsActived;

        private List<PurchaseOrderDDTO> m_DDTOListForDelete;

        #endregion

        #region Constructor


        public PUR020_PurchaseOrderEntry() : this(null) { }

        public PUR020_PurchaseOrderEntry(PurchaseOrderHDTO hdtoPurchaseOrder)
        {
            InitializeComponent();

            #region Set Component
            shtView.ActiveSkin = Common.ACTIVE_SKIN;

            this.WindowState = FormWindowState.Maximized;

            CtrlUtil.MappingDataFieldWithEnum(shtView, typeof(eColumn));
            m_BIZPurchaseOrder = new PurchaseOrderBIZ();
            LookupDataBIZ BIZLookupData = new LookupDataBIZ();

            cboSupplierCode.Format += CommonLib.Common.ComboBox_Format;
            cboSupplierCode.LoadLookupData(BIZLookupData.LoadLookupLocation(new NZString[] { (NZString)"04", (NZString)"05" }));
            cboSupplierCode.SelectedIndex = -1;

            cboDelivery.Format += CommonLib.Common.ComboBox_Format;
            cboDelivery.LoadLookupData(BIZLookupData.LoadLookupLocation(new NZString[] 
                                {(NZString)DataDefine.Convert2ClassCode(DataDefine.eLOCATION_CLS.Customer),
                                 (NZString)DataDefine.Convert2ClassCode(DataDefine.eLOCATION_CLS.CustomerVendor)}));
            cboDelivery.SelectedIndex = -1;

            cboTermOfPayment.Format += CommonLib.Common.ComboBox_Format;
            cboTermOfPayment.LoadLookupData(BIZLookupData.LoadLookupClassType(DataDefine.TERM_OF_PAYMENT.ToNZString()));
            cboTermOfPayment.SelectedIndex = -1;

            cboCurrency.Format += CommonLib.Common.ComboBox_Format;
            cboCurrency.LoadLookupData(BIZLookupData.LoadLookupClassType(DataDefine.CURRENCY.ToNZString()));
            cboCurrency.SelectedIndex = -1;

            shtView.Columns[(int)eColumn.UNIT].CellType = CtrlUtil.CreateComboBoxCellType(BIZLookupData.LoadLookupClassType(DataDefine.UM_CLS.ToNZString()), true);
            shtView.Columns[(int)eColumn.INV_UM].CellType = CtrlUtil.CreateComboBoxCellType(BIZLookupData.LoadLookupClassType(DataDefine.UM_CLS.ToNZString()), true);
            //shtView.Columns[(int)eColumn.STATUS].CellType = CtrlUtil.CreateComboBoxCellType(BIZLookupData.LoadLookupClassType(DataDefine.PO_STATUS.ToNZString()), true);


            // ซ่อน column บางตัว
            for (eColumn column = eColumn.PO_LINE; column < eColumn.STATUS; column++)
            {
                FarPoint.Win.Spread.Column hiddenColumn = shtView.Columns[(int)column];
                hiddenColumn.Visible = false;
                hiddenColumn.Label = column.ToString();
                if (column == eColumn.PO_NO)
                    column = eColumn.BACK_ORDER_QTY;
            }
            shtView.Columns[(int)eColumn.ModifyState].Visible = false;
            shtView.Columns[(int)eColumn.KeptStatus].Visible = false;
            shtView.Columns[(int)eColumn.RATE].Visible = false;


            for (int iColumn = 0; iColumn < shtView.ColumnCount; iColumn++)
            {
                if (iColumn != (int)eColumn.BUTTON)
                {
                    shtView.Columns[iColumn].AllowAutoFilter = true;
                    shtView.Columns[iColumn].AllowAutoSort = true;
                }
            }
            #endregion

            this.m_HDTOPurchaseOrder = hdtoPurchaseOrder;
        }

        #endregion

        #region Event Handler
        private void tsbSaveAndNew_Click(object sender, EventArgs e)
        {
            if (Save())
            {
                m_HDTOPurchaseOrder = null;
                this.SetDefault(null);
                this.SetScreenState(eScreenState.Add);
            }
        }
        private void tsbSaveAndClose_Click(object sender, EventArgs e)
        {
            if (Save())
            {
                this.Close();
            }
        }
        private void tsbCancel_Click(object sender, EventArgs e)
        {
            if (!IsDoOperation(Messages.eConfirm.CFM9003))
                return;
            SetDefault(this.m_HDTOPurchaseOrder);
        }
        private void tsbCancelPO_Click(object sender, EventArgs e)
        {
            if (!IsDoOperation(Messages.eConfirm.CFM9014))
                return;
            if (DoOperationComplete(CancelPO))
            {
                MessageDialog.ShowInformation(this, "Information", new EVOFramework.Message(Messages.eInformation.INF9003.ToString()).MessageDescription);
                this.Close();
            }
        }

        private void ctxAdd_Click(object sender, EventArgs e)
        {
            shtView.RowCount += 1;
            shtView.Cells[shtView.RowCount - 1, (int)eColumn.ITEM_CD].Locked = false;
            shtView.Cells[shtView.RowCount - 1, (int)eColumn.BUTTON].Locked = false;

            shtView.Cells[shtView.RowCount - 1, (int)eColumn.RECEIVE_QTY].Value = (Decimal)0;
            shtView.Cells[shtView.RowCount - 1, (int)eColumn.BACK_ORDER_QTY].Value = (Decimal)0;
            shtView.Cells[shtView.RowCount - 1, (int)eColumn.STATUS].Value = "00";
            shtView.Cells[shtView.RowCount - 1, (int)eColumn.ModifyState].Value = (int)eModifyState.Add;
            SetComboBoxInSpreadSheet(shtView.RowCount - 1);

            if (shtView.RowCount > 1)
                shtView.Cells[shtView.RowCount - 1, (int)eColumn.PO_LINE].Value = Convert.ToInt32(shtView.Cells[shtView.RowCount - 2, (int)eColumn.PO_LINE].Value) + 1;
            else
                shtView.Cells[shtView.RowCount - 1, (int)eColumn.PO_LINE].Value = 1;
            // ถ้าในตารางมี Record > 0 จะเพิ่มคำสั่ง Delete เข้าไป
            if (shtView.Rows.Count > 0 && ctxMenu.Items.Count < 2)
            {
                ctxMenu.Items.Add("Delete");
                ctxMenu.Items[1].Click += new EventHandler(ctxDelete_Click);
            }
        }
        private void ctxDelete_Click(object sender, EventArgs e)
        {
            DoOperationComplete(DeleteRecord);
        }

        private void fpView_ButtonClicked(object sender, EditorNotifyEventArgs e)
        {
            DoOperationComplete(SetItemCDandItemDesc);
        }
        private void fpView_EditModeOff(object sender, EventArgs e)
        {
            DoOperationComplete(CheckChangingInRecord);
        }
        private void fpView_EditModeOn(object sender, EventArgs e)
        {
            // if user change item code, remove item description.
            if (shtView.ActiveColumnIndex == (int)eColumn.ITEM_CD && shtView.RowCount > 0
                && Convert.ToInt32(shtView.Cells[shtView.ActiveRowIndex, (int)eColumn.ModifyState].Value) == (int)eModifyState.Add)
                shtView.Cells[shtView.ActiveRowIndex, (int)eColumn.ITEM_DESC].Value = string.Empty;
        }
        private void fpView_KeyUp(object sender, KeyEventArgs e)
        {
            CtrlUtil.FilterShortCut(e);

            if ((e.KeyData == Keys.Enter && shtView.ActiveColumnIndex == (int)eColumn.ITEM_CD)
                && (shtView.RowCount > 0))
            {
                LoadItem(shtView.ActiveRowIndex);
            }
        }

        private void chkOurFactory_CheckedChanged(object sender, EventArgs e)
        {
            cboDelivery.Enabled = !chkOurFactory.Checked;
            if (chkOurFactory.Checked)
            {
                cboDelivery.Text = (new SysConfigBIZ().LoadByPK((NZString)"DELIVERY_TO", (NZString)"PUR010")).CHAR_DATA;
            }
            else
            {
                cboDelivery.LoadLookupData(new LookupDataBIZ().LoadLookupLocation(new NZString[] 
                                {(NZString)DataDefine.Convert2ClassCode(DataDefine.eLOCATION_CLS.Customer),
                                 (NZString)DataDefine.Convert2ClassCode(DataDefine.eLOCATION_CLS.CustomerVendor)}));
                cboDelivery.SelectedIndex = 0;
            }
        }

        private void PUR020_PurchaseOrderEntry_FormClosed(object sender, FormClosedEventArgs e)
        {
            DialogResult = m_dialogResult;
        }
        #endregion

        #region Private Method


        /// <summary>
        /// Method that get a Method to execute. If error, will catch Exception.
        /// </summary>
        /// <param name="Operation">Method that want to execute without parameter(s).</param>
        /// <returns>Result of Execution</returns>
        public bool DoOperationComplete(OperationDelegate Operation)
        {
            bool bOperationPass = true;
            try
            {
                Operation();
            }
            catch (BusinessException err)
            {
                MessageDialog.ShowBusiness(this, err.Error.Message);
                err.Error.FocusOnControl();
                bOperationPass = false;
            }
            catch (ValidateException err)
            {
                MessageDialog.ShowBusiness(this, err.ErrorResults[0].Message);
                err.ErrorResults[0].FocusOnControl();
                bOperationPass = false;
            }
            return bOperationPass;
        }

        /// <summary>
        /// Show Comfirmation Box to do Operation.
        /// </summary>
        /// <param name="msgCD">Message that want to ask.</param>
        /// <returns>Confirmation to do Operation.</returns>
        private bool IsDoOperation(Messages.eConfirm msgCD)
        {
            bool bDoOperation = false;
            switch (MessageDialog.ShowConfirmation(this, new EVOFramework.Message(msgCD.ToString()).MessageDescription))
            {
                case MessageDialogResult.Cancel:
                    break;
                case MessageDialogResult.No:
                    break;
                case MessageDialogResult.Yes:
                    bDoOperation = true;
                    break;
            }
            return bDoOperation;
        }

        /// <summary>
        /// Save PO, will check to add or edit by ScreenState.
        /// </summary>
        /// <returns>Result of Execution.</returns>
        private bool Save()
        {
            if (!IsDoOperation(Messages.eConfirm.CFM9001))
                return false;
            bool bIsSaved = false;
            switch (m_ScreenStateEnum)
            {
                case eScreenState.Add:
                    bIsSaved = DoOperationComplete(new OperationDelegate(Add));
                    break;
                case eScreenState.Edit:
                    bIsSaved = DoOperationComplete(new OperationDelegate(Edit));
                    break;
            }
            if (bIsSaved)
            {
                MessageDialog.ShowInformation(this, "Information", new EVOFramework.Message(Messages.eInformation.INF9003.ToString()).MessageDescription);
                m_dialogResult = DialogResult.OK;
            }
            return bIsSaved;
        }


        private void Add()
        {
            ValidateAllRows();
            RunningNumberBIZ bizRunning = new RunningNumberBIZ();
            NZString strPONo = bizRunning.GetCompleteRunningNo(new NZString(null, "PO_NO"), new NZString(null, "TB_PURCHASE_ORDER_H_TR"));

            PurchaseOrderHDTO hDTOPurchaseOrder = GeneratePurchaseOrderHDTO(strPONo);
            List<PurchaseOrderDDTO> dDTOPurchaseOrder = GeneratePurchaseOrderDDTO(strPONo, eModifyState.Add);
            m_BIZPurchaseOrder.AddPO(hDTOPurchaseOrder, dDTOPurchaseOrder);
        }
        private void Edit()
        {
            ValidateAllRows();
            NZString strPONo = m_HDTOPurchaseOrder.PO_NO;
            PurchaseOrderHDTO hDTOPurchaseOrder = GeneratePurchaseOrderHDTO(strPONo);

            // เก็บ dto แยก list สำหรับ add , edit , delete
            List<PurchaseOrderDDTO> dDTOPurchaseOrderAdd = GeneratePurchaseOrderDDTO(strPONo, eModifyState.Add);
            List<PurchaseOrderDDTO> dDTOPurchaseOrderEdit = GeneratePurchaseOrderDDTO(strPONo, eModifyState.Edit);
            List<PurchaseOrderDDTO> dDTOPurchaseOrderDelete = m_DDTOListForDelete;
            // update ทีเดียว
            m_BIZPurchaseOrder.UpdatePO(hDTOPurchaseOrder, dDTOPurchaseOrderEdit, dDTOPurchaseOrderAdd, dDTOPurchaseOrderDelete);

            m_DDTOListForDelete.Clear();
        }
        private void CancelPO()
        {
            m_BIZPurchaseOrder.CancelPO(m_HDTOPurchaseOrder);
        }
        private void DeleteRecord()
        {
            // ถ้าไม่ได้เพิ่ง add เข้ามาจะเก็บไว้รอ delete ออกจาก database 
            // ถ้า delete ข้อมูลที่มีอยู่แล้ว จะเก็บข้อมูลไว้ใน List รอการ delete เมื่อ save
            int iModifyStatus = Convert.ToInt32(shtView.Cells[shtView.ActiveRowIndex, (int)eColumn.ModifyState].Value);
            if (shtView.Cells[shtView.ActiveRowIndex, (int)eColumn.ModifyState].Value == null || iModifyStatus != (int)eModifyState.Add)
            {
                m_DDTOListForDelete.Add(new PurchaseOrderDDTO
                {
                    UPD_BY = CommonLib.Common.CurrentUserInfomation.UserCD,
                    UPD_DATE = (NZDateTime)DateTime.UtcNow,
                    UPD_MACHINE = CommonLib.Common.CurrentUserInfomation.Machine,
                    PO_LINE = (NZDecimal)Convert.ToDecimal(shtView.Cells[shtView.ActiveRowIndex, (int)eColumn.PO_LINE].Value),
                    PO_NO = m_HDTOPurchaseOrder.PO_NO,
                    RECEIVE_QTY = (NZDecimal)Convert.ToDecimal(shtView.Cells[shtView.ActiveRowIndex, (int)eColumn.RECEIVE_QTY].Value),
                    ITEM_CD = (NZString)Convert.ToString(shtView.Cells[shtView.ActiveRowIndex, (int)eColumn.ITEM_CD].Value),
                    DUE_DATE = (NZDateTime)Convert.ToDateTime(shtView.Cells[shtView.ActiveRowIndex, (int)eColumn.DUE_DATE].Value)
                });
            }
            shtView.Rows[shtView.ActiveRowIndex].Remove();

            // เช็คว่าถ้าในตารางไม่มี Record อยู่เลย จะเอาคำสั่ง Delete ออก
            if (shtView.Rows.Count == 0)
                ctxMenu.Items.RemoveAt(1);
        }

        /// <summary>
        /// Set Default Value into selected cell, will be used when select Item Code.
        /// </summary>
        private void SetItemCDandItemDesc()
        {
            eItemType[] itemTypeEnum = { eItemType.All };
            ItemFindDialog dialog = new ItemFindDialog(eSqlOperator.Equal, itemTypeEnum);
            dialog.ShowDialog(this);
            if (dialog.IsSelected)
            {
                shtView.Cells[shtView.ActiveRowIndex, (int)eColumn.ITEM_CD].Value = dialog.SelectedItem.ITEM_CD.StrongValue;

                // set default into ItemCode, ItemDesc, Unit, InventoryU/M and Rate of unit.
                ErrorItem errItem = ValidateDupplicateItem();
                if (errItem != null)
                {
                    shtView.Cells[shtView.ActiveRowIndex, (int)eColumn.ITEM_CD].Value = string.Empty;
                    shtView.Cells[shtView.ActiveRowIndex, (int)eColumn.ITEM_DESC].Value = string.Empty;
                    ValidateException.ThrowErrorItem(errItem);
                }
                ValidateException.ThrowErrorItem(errItem);

                shtView.Cells[shtView.ActiveRowIndex, (int)eColumn.ITEM_DESC].Value = dialog.SelectedItem.ITEM_DESC.StrongValue;
                //shtView.Cells[shtView.ActiveRowIndex, (int)eColumn.UNIT].Value = dialog.SelectedItem.ORDER_UM_CLS.StrongValue;
                //shtView.Cells[shtView.ActiveRowIndex, (int)eColumn.INV_UM].Value = dialog.SelectedItem.INV_UM_CLS.StrongValue;
                //shtView.Cells[shtView.ActiveRowIndex, (int)eColumn.RATE].Value = dialog.SelectedItem.INV_UM_RATE.StrongValue / dialog.SelectedItem.ORDER_UM_RATE.StrongValue;
            }
        }

        /// <summary>
        /// Do action after change record , such as set default and validate data.
        /// </summary>
        private void CheckChangingInRecord()
        {
            if (shtView.Rows.Count > 0)
            {
                // ตรวจว่าข้อมูลใน PO ซ้ำหรือไม่
                ValidateException.ThrowErrorItem(ValidateDupplicateItem());

                int iRow = shtView.ActiveRowIndex;
                int iCol = shtView.ActiveColumnIndex;

                NZDecimal decQty = new NZDecimal(null, shtView.GetValue(iRow, (int)eColumn.PO_QTY));
                NZDecimal decUnitPrice = new NZDecimal(null, shtView.GetValue(iRow, (int)eColumn.UNIT_PRICE));
                NZDecimal decReceiveQty = new NZDecimal(null, shtView.GetValue(iRow, (int)eColumn.RECEIVE_QTY));
                NZDecimal decRate = new NZDecimal(null, shtView.GetValue(iRow, (int)eColumn.RATE));

                // เซ็ต Amount
                if ((iCol == (int)eColumn.PO_QTY || iCol == (int)eColumn.UNIT_PRICE))
                    shtView.Cells[iRow, (int)eColumn.AMOUNT].Value = (decQty.IsNull ? 0 : decQty.StrongValue) *
                                                                        (decUnitPrice.IsNull ? 0 : decUnitPrice.StrongValue);

                // กำหนด Formula + value ให้ Inventory Qty
                shtView.Cells[iRow, (int)eColumn.INV_QTY].Formula = shtView.Cells[iRow, (int)eColumn.PO_QTY].ToString() + "*" + shtView.Cells[iRow, (int)eColumn.RATE].ToString();
                shtView.Cells[iRow, (int)eColumn.INV_QTY].Value = (decQty.IsNull ? 0 : decQty.StrongValue) *
                                                                    (decRate.IsNull ? 0 : decRate.StrongValue);

                // กำหนด modifystate = edit (กรณีที่ไม่ใช่ record ที่เพิ่ง add มาใหม่)
                if (Convert.ToInt32(shtView.Cells[iRow, (int)eColumn.ModifyState].Value) != (int)eModifyState.Add)
                    shtView.Cells[iRow, (int)eColumn.ModifyState].Value = (int)eModifyState.Edit;
            }
        }

        /// <summary>
        /// Set Default for each control in screen.
        /// </summary>
        /// <param name="hDTO">DTO for set default.</param>
        private void SetDefault(PurchaseOrderHDTO hDTO)
        {
            if (hDTO != null)
            {
                // แสดง header
                PurchaseOrderHDTO hDTOSearch = m_BIZPurchaseOrder.LoadByPK(hDTO);

                this.lblPoNo.Text = hDTOSearch.PO_NO.ToString();
                this.dtmPODate.Value = hDTOSearch.PO_DATE;

                this.cboSupplierCode.SelectedValue = hDTOSearch.SUPPLIER_CD;

                string strDeliveryTo = Convert.ToString((new SysConfigBIZ().LoadByPK((NZString)"DELIVERY_TO", (NZString)"PUR010")).CHAR_DATA.Value);
                if (hDTOSearch.DELIVERY_TO.Value.Equals(strDeliveryTo))
                {
                    chkOurFactory.Checked = true;
                    chkOurFactory_CheckedChanged(this, null);
                }
                else
                    this.cboDelivery.SelectedValue = hDTOSearch.DELIVERY_TO;

                this.cboTermOfPayment.SelectedValue = hDTOSearch.TERM_OF_PAYMENT;

                m_bIsActived = hDTO.IS_ACTIVE.StrongValue;
                lblPoStatus.Text = m_bIsActived ? "Active" : "Cancel";


                this.txtVatRate.Text = hDTOSearch.VAT_RATE.ToString();
                this.cboCurrency.SelectedValue = hDTOSearch.CURRENCY;

                this.txtRemark.Text = hDTOSearch.REMARK;

                m_HDTOPurchaseOrder = hDTOSearch;

                // แสดง detail
                shtView.RowCount = 0;
                List<PurchaseOrderDDTO> dDTOPurchaseOrderList = m_BIZPurchaseOrder.LoadDetailByPO(m_HDTOPurchaseOrder);
                shtView.DataSource = DTOUtility.ConvertListToDataTable<PurchaseOrderDDTO>(dDTOPurchaseOrderList);

                for (int iRow = 0; iRow < shtView.RowCount; iRow++)
                {
                    LoadItem(iRow);
                    SetComboBoxInSpreadSheet(iRow);
                }

                if (hDTOSearch.IS_ACTIVE.StrongValue)
                    SetScreenState(eScreenState.Edit);
                else
                    SetScreenState(eScreenState.View);
            }
            else
            {
                // set default into Controls.
                var bizSysConfig = new SysConfigBIZ();

                string strVatRate = (bizSysConfig.LoadByPK((NZString)"VAT_RATE", (NZString)"PUR010")).CHAR_DATA; ;
                this.txtVatRate.Text = strVatRate;

                string strCurrency = (bizSysConfig.LoadByPK((NZString)"CURRENCY", (NZString)"PUR010")).CHAR_DATA; ;
                cboCurrency.SelectedValue = strCurrency;

                chkOurFactory.Checked = true;
                chkOurFactory_CheckedChanged(this, null);

                this.lblPoNo.Text = string.Empty;
                this.dtmPODate.Value = DateTime.Now;

                this.cboSupplierCode.SelectedIndex = -1;
                this.cboTermOfPayment.SelectedIndex = -1;

                lblPoStatus.Text = "Actived";

                this.txtRemark.Text = string.Empty;

                shtView.Rows.Count = 0;
                SetScreenState(eScreenState.Add);
            }
            m_DDTOListForDelete = new List<PurchaseOrderDDTO>();
        }

        /// <summary>
        /// Set ScreenState and enable Controls.
        /// </summary>
        /// <param name="screenState">ScreenState that want to add.</param>
        private void SetScreenState(eScreenState screenState)
        {
            m_ScreenStateEnum = screenState;

            ctxMenu.Items.Clear();

            tsbSaveAndNew.Enabled = true;
            tsbSaveAndClose.Enabled = true;
            tsbCancelPO.Visible = false;
            gbPOH.Enabled = true;
            pnlPO.Enabled = true;
            ctxMenu.Items.Add("Add");
            ctxMenu.Items[0].Click += ctxAdd_Click;
            shtView.OperationMode = OperationMode.Normal;

            switch (m_ScreenStateEnum)
            {
                case eScreenState.View:
                    tsbSaveAndNew.Enabled = false;
                    tsbSaveAndClose.Enabled = false;
                    gbPOH.Enabled = false;
                    pnlPO.Enabled = false;
                    ctxMenu.Items.Clear();
                    shtView.OperationMode = OperationMode.SingleSelect;
                    break;
                case eScreenState.Edit:
                    tsbCancelPO.Visible = true;
                    if (shtView.Rows.Count > 0)
                    {
                        ctxMenu.Items.Add("Delete");
                        ctxMenu.Items[1].Click += new EventHandler(ctxDelete_Click);
                    }
                    break;
            }
            if (m_ScreenStateEnum == eScreenState.Edit || m_ScreenStateEnum == eScreenState.Add)
            {
                for (int iColumn = 0; iColumn < iUnLockedColumn.Length; iColumn++)
                {
                    if (m_ScreenStateEnum == eScreenState.Edit && iColumn > 1 || m_ScreenStateEnum == eScreenState.Add)
                        shtView.Columns[iUnLockedColumn[iColumn]].Locked = false;
                    shtView.Columns[iUnLockedColumn[iColumn]].ForeColor = Color.Blue;
                }
            }
        }

        /// <summary>
        /// Set Status Combobox (if status is '0' or '2' hide '1' , if status is '2' hide others)
        /// </summary>
        /// <param name="iRow">Row in SpreadSheet that want to set.</param>
        private void SetComboBoxInSpreadSheet(int iRow)
        {
            DataTable dt = (new LookupDataBIZ().LoadLookupClassType(DataDefine.PO_STATUS.ToNZString())).DataSource;

            if (dt != null && dt.Rows.Count > 0)
            {
                FarPoint.Win.Spread.CellType.ComboBoxCellType cboCellType = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
                FarPoint.Win.Spread.Cell fpCell; // declare variable cell

                int iNoofRow = 0;
                switch (Convert.ToString(shtView.Cells[iRow, (int)eColumn.KeptStatus].Value))
                {
                    case "":
                    case "00": iNoofRow = 2; break;
                    case "01": iNoofRow = 3; break;
                    case "02": iNoofRow = 1; break;
                }

                string[] strValue = new string[iNoofRow];
                string[] strItem = new string[iNoofRow];

                int j = 0;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string str = Convert.ToString(shtView.Cells[iRow, (int)eColumn.KeptStatus].Value);
                    bool bCase00 = (str == "00" || str == "");
                    bool bCase01 = (str == "01");
                    bool bCase02 = (str == "02");
                    if ((bCase00 && dt.Rows[i]["CLS_CD"].ToString() != "01")
                        || (bCase01)
                        || (bCase02 && dt.Rows[i]["CLS_CD"].ToString() == "02"))
                    {
                        strValue[j] = dt.Rows[i]["CLS_CD"].ToString().Trim() == string.Empty ? "" : dt.Rows[i]["CLS_CD"].ToString().Trim();
                        strItem[j] = strValue[j] + " : " + dt.Rows[i]["CLS_DESC"].ToString();
                        j++;
                    }
                }

                cboCellType.ItemData = strValue;
                cboCellType.Items = strItem; // add item to cbo cell
                cboCellType.EditorValue = FarPoint.Win.Spread.CellType.EditorValue.ItemData;

                // set cell of ComboBox
                fpCell = shtView.Cells[iRow, (int)eColumn.STATUS];
                fpCell.CellType = cboCellType;
            }
            shtView.Cells[iRow, (int)eColumn.STATUS].Value = shtView.Cells[iRow, (int)eColumn.STATUS].Value == null ? "00" : shtView.Cells[iRow, (int)eColumn.STATUS].Value;
        }

        /// <summary>
        /// Load Item Description and other description into SpreadSheet require ItemCode from SpreadSheet for do operation.
        /// </summary>
        /// <param name="iRow">Selected row , load description for this row.</param>
        private void LoadItem(int iRow)
        {
            try
            {
                if (shtView.Cells[iRow, (int)eColumn.ITEM_CD].Value != null)
                {

                    #region validateion
                    List<string> strItemCDList = new List<string>();
                    for (int i = 0; i < shtView.Rows.Count; i++)
                    {
                        if (i != iRow)
                            strItemCDList.Add(Convert.ToString(shtView.Cells[i, (int)eColumn.ITEM_CD].Value));
                    }
                    ErrorItem errItem = ValidateDupplicateItem();
                    if (errItem != null)
                    {
                        shtView.Cells[shtView.ActiveRowIndex, (int)eColumn.ITEM_CD].Value = string.Empty;
                        shtView.Cells[shtView.ActiveRowIndex, (int)eColumn.ITEM_DESC].Value = string.Empty;
                        ValidateException.ThrowErrorItem(errItem);
                    }
                    #endregion

                    shtView.Cells[iRow, (int)eColumn.KeptStatus].Value = shtView.Cells[iRow, (int)eColumn.STATUS].Value;
                    ItemBIZ bizItem = new ItemBIZ();
                    ItemDTO dtoItem = bizItem.LoadItem((NZString)Convert.ToString(shtView.Cells[shtView.ActiveRowIndex, (int)eColumn.ITEM_CD].Value));

                    if (dtoItem != null)
                    {
                        shtView.Cells[iRow, (int)eColumn.ITEM_DESC].Value = dtoItem.ITEM_DESC.StrongValue;
                        //shtView.Cells[iRow, (int)eColumn.UNIT].Value = dtoItem.ORDER_UM_CLS.StrongValue;
                        //shtView.Cells[iRow, (int)eColumn.INV_UM].Value = dtoItem.INV_UM_CLS.StrongValue;
                        //shtView.Cells[iRow, (int)eColumn.RATE].Value = dtoItem.INV_UM_RATE.StrongValue / dtoItem.ORDER_UM_RATE.StrongValue;
                        shtView.Cells[iRow, (int)eColumn.INV_QTY].Value = Convert.ToDecimal(shtView.Cells[iRow, (int)eColumn.PO_QTY].Value) * Convert.ToDecimal(shtView.Cells[iRow, (int)eColumn.RATE].Value);
                    }
                    else
                    {
                        shtView.Cells[iRow, (int)eColumn.ITEM_DESC].Value = null;
                        shtView.Cells[iRow, (int)eColumn.UNIT].Value = null;
                        shtView.Cells[iRow, (int)eColumn.INV_UM].Value = null;
                        shtView.Cells[iRow, (int)eColumn.RATE].Value = null;
                        shtView.Cells[iRow, (int)eColumn.INV_QTY].Value = null;
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
        }

        /// <summary>
        /// Generate PO Header.
        /// </summary>
        /// <param name="strPONo">PO No of PO Header.</param>
        /// <returns>PO Header</returns>
        private PurchaseOrderHDTO GeneratePurchaseOrderHDTO(NZString strPONo)
        {
            NZDateTime dtmPO = new NZDateTime(dtmPODate, dtmPODate.Value);
            NZString strSupplierCD = new NZString(cboSupplierCode, cboSupplierCode.SelectedValue);
            NZString strDeliveryTo = chkOurFactory.Checked ? new NZString(cboDelivery, cboDelivery.Text) : new NZString(cboDelivery, cboDelivery.SelectedValue);
            NZString strCurrency = new NZString(cboCurrency, cboCurrency.SelectedValue);
            NZString strVatRate = new NZString(txtVatRate, txtVatRate.Text);
            string strVatType = (Convert.ToInt32(strVatRate) > 0) ? "02" : "01";

            #region validation

            ValidateException.ThrowErrorItem(PurchaseOrderEntryValidation.CheckDateTimeValue(dtmPO, Messages.eValidate.VLM0116));
            ValidateException.ThrowErrorItem(PurchaseOrderEntryValidation.CheckEmptyString(strSupplierCD, Messages.eValidate.VLM0118));
            if (!chkOurFactory.Checked)
                ValidateException.ThrowErrorItem(PurchaseOrderEntryValidation.CheckEmptyString((NZString)strDeliveryTo, Messages.eValidate.VLM0119));
            ValidateException.ThrowErrorItem(PurchaseOrderEntryValidation.CheckEmptyString((NZString)strCurrency, Messages.eValidate.VLM0121));
            if (this.m_ScreenStateEnum == eScreenState.Add)
                ValidateException.ThrowErrorItem(PurchaseOrderEntryValidation.CheckPurchaseOrderItem((NZInt)shtView.Rows.Count));

            #endregion


            PurchaseOrderHDTO hDTO = new PurchaseOrderHDTO
            {
                CRT_BY = CommonLib.Common.CurrentUserInfomation.UserCD,
                CRT_DATE = (NZDateTime)DateTime.UtcNow,
                CRT_MACHINE = CommonLib.Common.CurrentUserInfomation.Machine,
                UPD_BY = CommonLib.Common.CurrentUserInfomation.UserCD,
                UPD_DATE = (NZDateTime)DateTime.UtcNow,
                UPD_MACHINE = CommonLib.Common.CurrentUserInfomation.Machine,

                PO_NO = strPONo,
                PO_DATE = (NZDateTime)dtmPO,
                IS_ACTIVE = (NZBoolean)m_bIsActived,//(NZBoolean)((m_iPOStatus == 1) ? true : false),
                PO_TYPE = (NZString)"01",//(NZString)(cboPOType.SelectedValue.ToString()), 

                IS_EXPORT = (NZBoolean)false,//(NZBoolean)chkExport.Checked,               
                ADDRESS = (NZString)"",// (NZString)txtAddress.Text,

                SUPPLIER_CD = (NZString)strSupplierCD,
                DELIVERY_TO = (NZString)strDeliveryTo,
                TERM_OF_PAYMENT = (NZString)(Convert.ToString(cboTermOfPayment.SelectedValue)),

                STATUS = (NZString)"0",
                VAT_TYPE = (NZString)strVatType,
                VAT_RATE = (NZDecimal)Convert.ToDecimal(strVatRate),
                CURRENCY = (NZString)(cboCurrency.SelectedValue.ToString()),

                REMARK = (NZString)txtRemark.Text,
            };

            return hDTO;
        }

        /// <summary>
        /// Generate PO Detail List with selected status.
        /// </summary>
        /// <param name="strPONo">PO No of PO Details.</param>
        /// <param name="modifyState">status that want to selected.</param>
        /// <returns>List of PO Detail with selected status.</returns>
        private List<PurchaseOrderDDTO> GeneratePurchaseOrderDDTO(NZString strPONo, eModifyState modifyState)
        {
            if (modifyState == eModifyState.Delete)
                return m_DDTOListForDelete;
            else
            {
                List<PurchaseOrderDDTO> dDTOPurchaseOrderList = new List<PurchaseOrderDDTO>();
                for (int iRow = 0; iRow < shtView.Rows.Count; iRow++)
                {
                    if (Convert.ToInt32(shtView.Cells[iRow, (int)eColumn.ModifyState].Value) == (int)modifyState)
                    {
                        NZString strItemCD = new NZString(null, shtView.Cells[iRow, (int)eColumn.ITEM_CD].Value, null);
                        NZString strItemDesc = new NZString(null, shtView.Cells[iRow, (int)eColumn.ITEM_DESC].Value, null);
                        NZDateTime dtmRequireDate = new NZDateTime(null, shtView.Cells[iRow, (int)eColumn.DUE_DATE].Value, null);
                        NZDecimal decUnitPrice = new NZDecimal(null, shtView.Cells[iRow, (int)eColumn.UNIT_PRICE].Value, null);
                        NZDecimal decQty = new NZDecimal(null, shtView.Cells[iRow, (int)eColumn.PO_QTY].Value, null);
                        NZString strUnit = new NZString(null, shtView.Cells[iRow, (int)eColumn.UNIT].Value, null);
                        NZDecimal decAmount = new NZDecimal(null, shtView.Cells[iRow, (int)eColumn.AMOUNT].Value, null);
                        NZDecimal decReceiveQty = new NZDecimal(null, shtView.Cells[iRow, (int)eColumn.RECEIVE_QTY].Value, 0);
                        NZString strStatus = new NZString(null, shtView.Cells[iRow, (int)eColumn.STATUS].Value, null);

                        PurchaseOrderDDTO dDTO = new PurchaseOrderDDTO
                        {
                            #region tmp data
                            CRT_BY = CommonLib.Common.CurrentUserInfomation.UserCD,
                            CRT_DATE = (NZDateTime)DateTime.UtcNow,
                            CRT_MACHINE = CommonLib.Common.CurrentUserInfomation.Machine,
                            UPD_BY = CommonLib.Common.CurrentUserInfomation.UserCD,
                            UPD_DATE = (NZDateTime)DateTime.UtcNow,
                            UPD_MACHINE = CommonLib.Common.CurrentUserInfomation.Machine,
                            IS_ACTIVE = (NZBoolean)true,
                            PO_NO = strPONo,
                            #endregion

                            PO_LINE = new NZDecimal(null, shtView.Cells[iRow, (int)eColumn.PO_LINE].Value, 0),
                            ITEM_CD = strItemCD,
                            ITEM_DESC = strItemDesc,
                            DUE_DATE = dtmRequireDate,
                            UNIT_PRICE = decUnitPrice,
                            PO_QTY = decQty,
                            UNIT = strUnit,
                            AMOUNT = decAmount,
                            RECEIVE_QTY = (decReceiveQty.IsNull ? new NZDecimal(null, 0) : decReceiveQty),
                            //BACK_ORDER_QTY = (NZDecimal)0,
                            //LAST_RECEIVE_ID = (NZString)string.Empty,
                            //LAST_RECEIVE_DATE = (NZDateTime)DateTime.UtcNow,
                            STATUS = strStatus
                        };
                        dDTOPurchaseOrderList.Add(dDTO);
                    }
                }
                return dDTOPurchaseOrderList;
            }
        }

        /// <summary>
        /// Validate Value of rows in SpreadSheet.
        /// </summary>
        private void ValidateAllRows()
        {
            for (int iRow = 0; iRow < shtView.RowCount; iRow++)
            {
                NZString strItemCD = new NZString(null, shtView.Cells[iRow, (int)eColumn.ITEM_CD].Value, null);
                NZString strItemDesc = new NZString(null, shtView.Cells[iRow, (int)eColumn.ITEM_DESC].Value, null);
                NZDateTime dtmRequireDate = new NZDateTime(null, shtView.Cells[iRow, (int)eColumn.DUE_DATE].Value, null);
                NZDecimal decUnitPrice = new NZDecimal(null, shtView.Cells[iRow, (int)eColumn.UNIT_PRICE].Value, null);
                NZDecimal decQty = new NZDecimal(null, shtView.Cells[iRow, (int)eColumn.PO_QTY].Value, null);
                NZString strUnit = new NZString(null, shtView.Cells[iRow, (int)eColumn.UNIT].Value, null);
                NZDecimal decAmount = new NZDecimal(null, shtView.Cells[iRow, (int)eColumn.AMOUNT].Value, null);
                NZDecimal decReceiveQty = new NZDecimal(null, shtView.Cells[iRow, (int)eColumn.RECEIVE_QTY].Value, 0);
                NZString strStatus = new NZString(null, shtView.Cells[iRow, (int)eColumn.STATUS].Value, null);

                #region Validateion before Generate DDTO
                ValidateException.ThrowErrorItem(PurchaseOrderEntryValidation.CheckEmptyString(strItemDesc, Messages.eValidate.VLM0129));
                ValidateException.ThrowErrorItem(PurchaseOrderEntryValidation.CheckDateTimeValue(dtmRequireDate, Messages.eValidate.VLM0130));
                ValidateException.ThrowErrorItem(PurchaseOrderEntryValidation.CheckDecimalValue(decUnitPrice, Messages.eValidate.VLM0131));
                ValidateException.ThrowErrorItem(PurchaseOrderEntryValidation.CheckEmptyString(strUnit, Messages.eValidate.VLM0133));
                ValidateException.ThrowErrorItem(PurchaseOrderEntryValidation.CheckDecimalValue(decQty, Messages.eValidate.VLM0132));
                ValidateException.ThrowErrorItem(PurchaseOrderEntryValidation.CheckEmptyString(strStatus, Messages.eValidate.VLM0137));
                #endregion
            }
        }

        /// <summary>
        /// Check PO Details, there cannot has the same ItemCode, DueDate and UnitPrice.
        /// </summary>
        /// <returns>ErrorItem if Has Dupplication.</returns>
        private ErrorItem ValidateDupplicateItem()
        {
            int iRow = shtView.ActiveRowIndex;
            if (shtView.Cells[iRow, (int)eColumn.ITEM_CD].Value == null ||
                shtView.Cells[iRow, (int)eColumn.DUE_DATE].Value == null ||
                shtView.Cells[iRow, (int)eColumn.UNIT_PRICE].Value == null)
                return null;

            PurchaseOrderDDTO dDTOChk = new PurchaseOrderDDTO
            {
                ITEM_CD = (NZString)Convert.ToString(shtView.Cells[iRow, (int)eColumn.ITEM_CD].Value),
                DUE_DATE = (NZDateTime)Convert.ToDateTime(shtView.Cells[iRow, (int)eColumn.DUE_DATE].Value),
                UNIT_PRICE = (NZDecimal)Convert.ToDecimal(shtView.Cells[iRow, (int)eColumn.UNIT_PRICE].Value)
            };

            List<PurchaseOrderDDTO> dDTOPOList = new List<PurchaseOrderDDTO>();

            for (int i = 0; i < shtView.Rows.Count; i++)
            {
                if (shtView.Cells[i, (int)eColumn.ITEM_CD].Value == null ||
                shtView.Cells[i, (int)eColumn.DUE_DATE].Value == null ||
                shtView.Cells[i, (int)eColumn.UNIT_PRICE].Value == null)
                    continue;

                if (i != iRow)
                {
                    PurchaseOrderDDTO dDTOTmp = new PurchaseOrderDDTO
                    {
                        ITEM_CD = (NZString)Convert.ToString(shtView.Cells[i, (int)eColumn.ITEM_CD].Value),
                        DUE_DATE = (NZDateTime)Convert.ToDateTime(shtView.Cells[i, (int)eColumn.DUE_DATE].Value),
                        UNIT_PRICE = (NZDecimal)Convert.ToDecimal(shtView.Cells[i, (int)eColumn.UNIT_PRICE].Value)
                    };
                    dDTOPOList.Add(dDTOTmp);
                }
            }
            ErrorItem errItem = PurchaseOrderEntryValidation.CheckDupItemByDTO(dDTOChk, dDTOPOList);
            if (errItem != null)
                shtView.Cells[shtView.ActiveRowIndex, shtView.ActiveColumnIndex].Value = null;
            return errItem;
        }
        #endregion

        private void fpView_LeaveCell(object sender, LeaveCellEventArgs e)
        {
            if (e.Column == (int)eColumn.ITEM_CD)
                LoadItem(e.Row);
        }
    }

    public static class PurchaseOrderEntryValidation
    {
        #region validate before generate dto
        public static ErrorItem CheckEmptyString(NZString strCheck, Messages.eValidate eValidateMsg)
        {
            if (strCheck.StrongValue == string.Empty)
                return new ErrorItem(strCheck.Owner, eValidateMsg.ToString());
            else
                return null;
        }
        public static ErrorItem CheckVatRate(NZString strVatType, NZString strVatRate)
        {
            if (strVatType.StrongValue == string.Empty)
                return new ErrorItem(strVatType.Owner, Messages.eValidate.VLM0122.ToString());
            else if (strVatType.ToString().ToLower() == "02" && strVatRate == "0")
                return new ErrorItem(strVatRate.Owner, Messages.eValidate.VLM0123.ToString());
            else
                return null;
        }
        public static ErrorItem CheckDateTimeValue(NZDateTime demCheckedValue, Messages.eValidate eValidateMsg)
        {
            if (demCheckedValue.IsNull)
                return new ErrorItem(demCheckedValue.Owner, eValidateMsg.ToString());
            else
                return null;
        }
        public static ErrorItem CheckDecimalValue(NZDecimal decCheckedValue, Messages.eValidate eValidateMsg)
        {
            if (decCheckedValue.IsNull)
                return new ErrorItem(decCheckedValue.Owner, eValidateMsg.ToString());
            else
                return null;
        }
        public static ErrorItem CheckPurchaseOrderItem(NZInt iCheck)
        {
            if (iCheck == 0)
                return new ErrorItem(iCheck.Owner, Messages.eValidate.VLM0125.ToString());
            else
                return null;
        }
        #endregion
        #region simple validateion
        public static ErrorItem CheckZeroQty(NZDecimal dCheck)
        {
            if (dCheck > 0)
                return new ErrorItem(dCheck.Owner, Messages.eValidate.VLM0124.ToString());
            else
                return null;
        }
        public static ErrorItem CheckQty(NZDecimal nzdQty, decimal iRecieveQty)
        {
            decimal dQty = Convert.ToInt32(nzdQty);
            if (dQty <= 0)
                return new ErrorItem(nzdQty.Owner, Messages.eValidate.VLM0126.ToString());
            else if (dQty > 0 && dQty < iRecieveQty)
                return new ErrorItem(nzdQty.Owner, Messages.eValidate.VLM0127.ToString());
            else
                return null;
        }
        public static ErrorItem CheckDupItemByDTO(PurchaseOrderDDTO dDTOchk, List<PurchaseOrderDDTO> dDTOList)
        {
            foreach (PurchaseOrderDDTO dto in dDTOList)
            {
                bool b1 = dDTOchk.ITEM_CD.Value.Equals(dto.ITEM_CD.Value);
                bool b2 = dDTOchk.DUE_DATE.Value.Equals(dto.DUE_DATE.Value);
                bool b3 = dDTOchk.UNIT_PRICE.Value.Equals(dto.UNIT_PRICE.Value);
                if (b1 && b2 && b3)
                    return new ErrorItem(dDTOchk.ITEM_CD.Owner, Messages.eValidate.VLM0128.ToString());
            }
            return null;
        }
        public static ErrorItem CheckDupItem(NZString strCheck, List<string> strList)
        {
            if (strCheck.StrongValue != string.Empty)
            {
                foreach (string s in strList)
                {
                    if (Convert.ToString(strCheck.Value) == s)
                        return new ErrorItem(strCheck.Owner, Messages.eValidate.VLM0128.ToString());
                }
            }
            return null;
        }

        public static ErrorItem CheckStatus(NZString strStatus)
        {
            if (strStatus.StrongValue != "0")
                return new ErrorItem(strStatus.Owner, Messages.eValidate.VLM0141.ToString());
            else
                return null;
        }
        #endregion
    }
}
