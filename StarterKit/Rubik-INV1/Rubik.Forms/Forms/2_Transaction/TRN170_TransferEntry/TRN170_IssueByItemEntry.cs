using System;
using System.Collections.Generic;
using SystemMaintenance;
using CommonLib;
using EVOFramework;
using EVOFramework.Data;
using EVOFramework.Windows.Forms;
using FarPoint.Win.Spread;
using Rubik.BIZ;
using System.Windows.Forms;
using Rubik.Controller;
using Rubik.DTO;
using Rubik.Forms.FindDialog;
using Rubik.Validators;
using Rubik.UIDataModel;
using FarPoint.Win.Spread.CellType;
using System.Data;
using Message = EVOFramework.Message;

namespace Rubik.Transaction
{
    [Screen("TRN170", "Transfer Entry", eShowAction.Normal, eScreenType.Screen, "Transfer Entry")]
    public partial class TRN170_TransferEntry : SystemMaintenance.Forms.CustomizeForm
    {
        #region Enum

        private enum eColView
        {
            ITEM_CODE,
            ITEM_CD_BTN,
            SHORT_NAME,
            ITEM_DESC,
            LOT_NO,
            LOT_BTN,
            ISSUE_QTY,
            ONHAND_QTY,
            TRANS_ID,
            REF_NO,
        }
        public enum eColumns
        {
            EDIT_FLAG,
            LOT_NO,
            ON_HAND_QTY,
            Shipment,
            Location,
            Item_NO,
            Item_Name

        }
        private enum eSaveMode
        {
            ADD, UPDATE, VIEW
        }
        #endregion

        #region Variable

        private KeyboardSpread m_keyboardSpread;
        private eSaveMode m_Mode = eSaveMode.ADD;
        private IssueByOrderUIDM m_uidm = new IssueByOrderUIDM();
        private bool m_RowAdd = false;
        private string ItemNo;

        /// <summary>
        /// เก็บรายการของแถวที่กำลังแก้
        /// </summary>
        private readonly Map<eColView, object> m_mapCellValue = new Map<eColView, object>();
        /// <summary>
        /// เก็บสถานะว่าตอนนี้ Row นั้น มีบาง Cell ที่ถูกปรับเปลี่ยนค่า
        /// </summary>
        private bool m_bRowHasModified;

        #endregion

        #region Constructor

        public TRN170_TransferEntry()
        {
            InitializeComponent();
        }
        public TRN170_TransferEntry(IssueByOrderUIDM uidm, bool CanEdit)
        {
            InitializeComponent();
            if (CanEdit)
            {
                m_Mode = eSaveMode.UPDATE;
            }
            else
            {
                m_Mode = eSaveMode.VIEW;
            }
            m_uidm = uidm;
        }
        #endregion

        #region Overriden Method

        public override void OnSaveAndClose()
        {
            try
            {
                fpIssueList.StopCellEditing();
                // ต้องเรียกก่อน Save เสมอ  เพื่อ Commit ข้อมูลการแก้ไขล่าสุดบน Grid
                // ใช้ได้เฉพาะกับ Sheet ที่ผูก DataSource
                CtrlUtil.SpreadSheetRowEndEdit(shtIssueList, shtIssueList.ActiveRowIndex);
                RemoveRowUnused();

                // Validate Data before Save
                IssueEntryValidator valIssue = new IssueEntryValidator();

                ErrorItem errorItem;

                errorItem = valIssue.CheckIssueDate(new NZDateTime(dtIssueDate, dtIssueDate.Value));
                if (null != errorItem) ValidateException.ThrowErrorItem(errorItem);

                errorItem = valIssue.CheckEmptySubType(new NZString(cboSubType, cboSubType.SelectedValue));
                if (null != errorItem) ValidateException.ThrowErrorItem(errorItem);

                //errorItem = valIssue.CheckEmptyItemCode(new NZString(txtItemCode, txtItemCode.Text));
                //if (null != errorItem) ValidateException.ThrowErrorItem(errorItem);

                errorItem = valIssue.CheckEmptyLocFrom(new NZString(cboFromLoc, cboFromLoc.SelectedValue));
                if (null != errorItem) ValidateException.ThrowErrorItem(errorItem);

                errorItem = valIssue.CheckEmptyLocTo(new NZString(cboToLoc, cboToLoc.SelectedValue));
                if (null != errorItem) ValidateException.ThrowErrorItem(errorItem);

                errorItem = valIssue.CheckFromToLocation(new NZString(cboFromLoc, cboFromLoc.SelectedValue), new NZString(cboToLoc, cboToLoc.SelectedValue));
                if (null != errorItem) ValidateException.ThrowErrorItem(errorItem);

                for (int i = 0; i < shtIssueList.Rows.Count; i++)
                {

                    if (!ValidateRowSpread(i, true))
                    {
                        return;
                    }

                }

                MessageDialogResult dr = MessageDialog.ShowConfirmation(this, new EVOFramework.Message(Messages.eConfirm.CFM9001.ToString()).MessageDescription);
                switch (dr)
                {
                    case MessageDialogResult.Cancel:
                        return;

                    case MessageDialogResult.No:
                        // this.Close();
                        return;

                    case MessageDialogResult.Yes:
                        break;

                }
                if (m_Mode == eSaveMode.ADD)
                //|| (m_Mode == eSaveMode.UPDATE))
                {
                    if (SaveData())
                    {
                        MessageDialog.ShowInformation(this, "Information", new EVOFramework.Message(Messages.eInformation.INF9003.ToString()).MessageDescription);
                        Close();
                    }
                }
                else
                {
                    if (SaveDataEditMode())
                    {
                        MessageDialog.ShowInformation(this, "Information", new EVOFramework.Message(Messages.eInformation.INF9003.ToString()).MessageDescription);
                        Close();
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

        private bool SaveDataEditMode()
        {
            RemoveRowUnused();
            // ต้องเรียกก่อน Save เสมอ  เพื่อ Commit ข้อมูลการแก้ไขล่าสุดบน Grid
            // ใช้ได้เฉพาะกับ Sheet ที่ผูก DataSource
            //int row = shtIssueList.Rows.Count;
            for (int i = 0; i < shtIssueList.Rows.Count; i++)
            {
                CtrlUtil.SpreadSheetRowEndEdit(shtIssueList, shtIssueList.ActiveRowIndex);

            }

            IssueByOrderUIDM newModel = dmcIssue.SaveData(new IssueByOrderUIDM());
            newModel.DATA_VIEW = m_uidm.DATA_VIEW;


            //== Save Process
            IssueByEntryController ctl = new IssueByEntryController();
            ctl.SaveDataEditMode(newModel);
            return true;
        }
        public override void OnSaveAndNew()
        {
            try
            {
                fpIssueList.StopCellEditing();
                // ต้องเรียกก่อน Save เสมอ  เพื่อ Commit ข้อมูลการแก้ไขล่าสุดบน Grid
                // ใช้ได้เฉพาะกับ Sheet ที่ผูก DataSource
                CtrlUtil.SpreadSheetRowEndEdit(shtIssueList, shtIssueList.ActiveRowIndex);
                RemoveRowUnused();

                // Validate Data before Save
                IssueEntryValidator valIssue = new IssueEntryValidator();

                ErrorItem errorItem;

                errorItem = valIssue.CheckIssueDate(new NZDateTime(dtIssueDate, dtIssueDate.Value));
                if (null != errorItem) ValidateException.ThrowErrorItem(errorItem);

                errorItem = valIssue.CheckEmptySubType(new NZString(cboSubType, cboSubType.SelectedValue));
                if (null != errorItem) ValidateException.ThrowErrorItem(errorItem);

                errorItem = valIssue.CheckEmptyLocFrom(new NZString(cboFromLoc, cboFromLoc.SelectedValue));
                if (null != errorItem) ValidateException.ThrowErrorItem(errorItem);

                errorItem = valIssue.CheckEmptyLocTo(new NZString(cboToLoc, cboToLoc.SelectedValue));
                if (null != errorItem) ValidateException.ThrowErrorItem(errorItem);

                errorItem = valIssue.CheckFromToLocation(new NZString(cboFromLoc, cboFromLoc.SelectedValue), new NZString(cboToLoc, cboToLoc.SelectedValue));
                if (null != errorItem) ValidateException.ThrowErrorItem(errorItem);

                for (int i = 0; i < shtIssueList.Rows.Count; i++)
                {
                    if (!ValidateRowSpread(i, true))
                    {
                        return;

                    }

                }

                MessageDialogResult dr = MessageDialog.ShowConfirmation(this, new EVOFramework.Message(Messages.eConfirm.CFM9001.ToString()).MessageDescription);
                switch (dr)
                {
                    case MessageDialogResult.Cancel:
                        return;

                    case MessageDialogResult.No:
                        return;

                    case MessageDialogResult.Yes:
                        break;

                }

                if (m_Mode == eSaveMode.ADD)
                {
                    if (SaveData())
                    {
                        MessageDialog.ShowInformation(this, "Information", new EVOFramework.Message(Messages.eInformation.INF9003.ToString()).MessageDescription);
                        ClearAllControlExceptDefault();
                    }
                }
                else
                {
                    if (SaveDataEditMode())
                    {
                        MessageDialog.ShowInformation(this, "Information", new EVOFramework.Message(Messages.eInformation.INF9003.ToString()).MessageDescription);
                        CtrlUtil.EnabledControl(true, cboFromLoc, cboToLoc, txtRemark, dtIssueDate);
                        ClearAllControl();
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

        #endregion

        #region Private Method

        private void InitialScreen()
        {
            CheckCurrentInvPeriod();
            InitialSpread();
            InitialComboBox();

            CtrlUtil.EnabledControl(false, txtIssueNo);

            dmcIssue.AddControl(txtIssueNo);
            dmcIssue.AddControl(dtIssueDate);
            dmcIssue.AddControl(cboToLoc);
            dmcIssue.AddControl(cboFromLoc);
            dmcIssue.AddControl(txtRemark);
            dmcIssue.AddControl(cboSubType);
            dmcIssue.AddControl(txtRefDocNo);
            dmcIssue.AddControl(txtJobOrderNo);
            dmcIssue.AddControl(cboForCustomer);


            dtIssueDate.Format = Common.CurrentUserInfomation.DateFormatString;


            cboFromLoc.KeyPress += CtrlUtil.SetNextControl;
            cboToLoc.KeyPress += CtrlUtil.SetNextControl;

            cboSubType.KeyPress += CommonLib.CtrlUtil.SetNextControl;
            txtRefDocNo.KeyPress += CommonLib.CtrlUtil.SetNextControl;
            txtJobOrderNo.KeyPress += CommonLib.CtrlUtil.SetNextControl;
            //txtForMachine.KeyPress += CommonLib.CtrlUtil.SetNextControl;
            cboForCustomer.KeyPress += CommonLib.CtrlUtil.SetNextControl;
            dtIssueDate.KeyPress += CommonLib.CtrlUtil.SetNextControl;

            ClearAllControl();


            SysConfigBIZ sysBiz = new SysConfigBIZ();
            SysConfigDTO argScreenInfo = new SysConfigDTO();
            argScreenInfo.SYS_GROUP_ID = DataDefine.eSYSTEM_CONFIG.TRN080.SYS_GROUP_ID;
            argScreenInfo.SYS_KEY = (NZString)DataDefine.eSYSTEM_CONFIG.TRN080.SYS_KEY.DEFAULT_DATE.ToString();
            dtIssueDate.Value = sysBiz.GetDefaultDateForScreen(argScreenInfo);

            if (m_Mode == eSaveMode.UPDATE)
            {
                if (m_uidm != null)
                {
                    dmcIssue.LoadData(m_uidm);
                    NZString TranId = (NZString)Convert.ToString(m_uidm.TRANS_ID.Value);
                    GetShipNo(TranId);
                }
                CtrlUtil.EnabledControl(false
                    , cboFromLoc, cboToLoc
                    , dtIssueDate);

            }
            else if (m_Mode == eSaveMode.VIEW)
            {
                if (m_uidm != null)
                {
                    dmcIssue.LoadData(m_uidm);

                    LoadIssueListForEdit(m_uidm.SLIP_NO);
                }
                CtrlUtil.EnabledControl(true
                    , cboFromLoc, cboToLoc, txtRemark
                    , dtIssueDate);
                CtrlUtil.EnabledControl(false, tsbSaveAndClose, tsbSaveAndNew);
            }
        }
        private void GetShipNo(NZString TranId)
        {
            InventoryTransBIZ bizInv = new InventoryTransBIZ();
            InventoryTransactionDTO dto =
                bizInv.LoadShip(TranId);
            NZString shipno = (NZString)dto.SLIP_NO.ToString();
            LoadIssueListForEdit(shipno);
        }
        private void LoadIssueListForEdit(NZString SLIP_NO)
        {
            if (SLIP_NO.IsNull) return;
            shtIssueList.Rows.Count = 0;
            IssueByEntryController ctlIssue = new IssueByEntryController();
            m_uidm.DATA_VIEW = ctlIssue.LoadIssueListForEdit(SLIP_NO);

            m_uidm.DATA_VIEW.AcceptChanges();
            shtIssueList.DataSource = m_uidm.DATA_VIEW;

            // load lot no
            int row = shtIssueList.Rows.Count;
            for (int i = 0; i < row; i++)
            {
                shtIssueList.Cells[i, (int)eColView.LOT_NO].Value =
                     m_uidm.DATA_VIEW.Rows[i][eColView.LOT_NO.ToString()].ToString();
            }
        }

        private void InitialComboBox()
        {
            cboToLoc.Format += Common.ComboBox_Format;
            cboFromLoc.Format += Common.ComboBox_Format;
            cboForCustomer.Format += CommonLib.Common.ComboBox_Format;
            cboSubType.Format += CommonLib.Common.ComboBox_Format;

            LookupDataBIZ bizLookup = new LookupDataBIZ();
            // Lookup From Loc
            LookupData lookupLocationFrom = bizLookup.LoadLookupLocation();
            cboFromLoc.LoadLookupData(lookupLocationFrom);
            // Lookup To Loc
            LookupData lookupLocationTo = bizLookup.LoadLookupLocation();
            cboToLoc.LoadLookupData(lookupLocationTo);

            // Lookup To CustomerLocation
            LookupData lookupCustomer = bizLookup.LoadLookupLocation(new NZString[]{(NZString)DataDefine.Convert2ClassCode(DataDefine.eLOCATION_CLS.Customer)
            ,(NZString)DataDefine.Convert2ClassCode(DataDefine.eLOCATION_CLS.CustomerVendor)});
            cboForCustomer.LoadLookupData(lookupCustomer);

            // Lookup SubType
            LookupData lookupSubType = bizLookup.LoadLookupClassType(new NZString(null, "ISSUE_SUBTYPE"));
            cboSubType.LoadLookupData(lookupSubType);
        }


        private void InitialSpread()
        {
            shtIssueList.ActiveSkin = Common.ACTIVE_SKIN;

            m_keyboardSpread = new KeyboardSpread(fpIssueList);
            m_keyboardSpread.RowAdding += m_keyboardSpread_RowAdding;
            m_keyboardSpread.RowAdded += m_keyboardSpread_RowAdded;
            m_keyboardSpread.RowRemoved += m_keyboardSpread_RowRemoved;
            if (m_Mode != eSaveMode.VIEW)
                m_keyboardSpread.StartBind();

            fpIssueList.SubEditorOpening += CtrlUtil.SpreadDisableSubEditorOpening;

            string[] names = Enum.GetNames(typeof(eColView));
            for (int i = 0; i < names.Length; i++)
            {
                shtIssueList.Columns[i].DataField = names[i];
                CtrlUtil.SpreadSetColumnsLocked(shtIssueList, true, i);
            }
            if (m_Mode == eSaveMode.ADD || m_Mode == eSaveMode.UPDATE)
            {
                CtrlUtil.SpreadSetColumnsLocked(shtIssueList, false, (int)eColView.ISSUE_QTY);
            }
            if (m_Mode == eSaveMode.ADD)
            {
                CtrlUtil.SpreadSetColumnsLocked(shtIssueList, false, (int)eColView.LOT_NO);
                CtrlUtil.SpreadSetColumnsLocked(shtIssueList, false, (int)eColView.LOT_BTN);
            }
        }

        private void ClearAllControl()
        {
            CtrlUtil.ClearControlData(txtIssueNo, cboFromLoc, cboToLoc, txtRemark
                                      , cboForCustomer, cboSubType, txtRefDocNo, txtJobOrderNo);
            shtIssueList.Rows.Count = 0;
            if (m_uidm.DATA_VIEW != null)
                m_uidm.DATA_VIEW.Rows.Clear();
        }

        private void ClearAllControlExceptDefault()
        {
            CtrlUtil.ClearControlData(txtIssueNo, cboFromLoc, cboToLoc, txtRemark
                                      , cboForCustomer, cboSubType, txtRefDocNo, txtJobOrderNo);
            shtIssueList.Rows.Count = 0;
            if (m_uidm.DATA_VIEW != null)
                m_uidm.DATA_VIEW.Rows.Clear();
        }


        private bool SaveData()
        {
            IssueByEntryController ctlIssue = new IssueByEntryController();
            List<IssueByOrderUIDM> uidmIssueList = new List<IssueByOrderUIDM>();


            NZString FromLocCD = new NZString(cboFromLoc, cboFromLoc.SelectedValue);
            NZString ToLocCD = new NZString(cboToLoc, cboToLoc.SelectedValue);
            NZString TranSubCls = new NZString(cboSubType, cboSubType.SelectedValue);
            NZString RefSlipNo = new NZString(txtRefDocNo, txtRefDocNo.Text);
            NZString RefSlipNo2 = new NZString(txtJobOrderNo, txtJobOrderNo.Text);
            NZString ForCustomer = new NZString(cboForCustomer, cboForCustomer.SelectedValue);

            int row = shtIssueList.Rows.Count;
            for (int i = 0; i < row; i++)
            {
                IssueByOrderUIDM uidm = new IssueByOrderUIDM();
                NZString ItemCD = new NZString(null,
                                               shtIssueList.Cells[i, (int)eColView.ITEM_CODE].
                                                   Text);
                NZString LotNo = new NZString(null, shtIssueList.Cells[i, (int)eColView.LOT_NO].Value);
                NZDecimal Qty = new NZDecimal(null, shtIssueList.Cells[i, (int)eColView.ISSUE_QTY].Value);
                NZString Remark = new NZString(txtRemark, txtRemark.Text.Trim());
                NZDateTime TransDate = new NZDateTime(dtIssueDate, dtIssueDate.Value);
                uidm.ITEM_CD = ItemCD;
                uidm.FROM_LOC_CD = FromLocCD;
                uidm.TO_LOC_CD = ToLocCD;
                uidm.LOT_NO = LotNo;
                uidm.QTY = Qty;
                uidm.REMARK = Remark;
                uidm.TRANS_DATE = TransDate;
                uidm.TRANS_CLS = DataDefine.Convert2ClassCode(DataDefine.eTRANS_TYPE.Issuing).ToNZString();//TransCls;
                uidm.TRAN_SUB_CLS = TranSubCls;
                uidm.REF_SLIP_NO = RefSlipNo;
                uidm.REF_SLIP_NO2 = RefSlipNo2;
                uidm.FOR_CUSTOMER = ForCustomer;

                uidmIssueList.Add(uidm);
            }

            ctlIssue.SaveAddIssue(uidmIssueList);

            return true;
        }

        private decimal GetOnhandQty(NZString ItemCD, NZString LocCD, NZString LotNo)
        {
            // get Onhand Qty

            InventoryBIZ bizInv = new InventoryBIZ();
            ActualOnhandViewDTO dto =
                bizInv.LoadActualInventoryOnHand(ItemCD, LocCD, LotNo);
            if (dto != null)
                return dto.ONHAND_QTY.StrongValue;
            return 0;
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            m_keyboardSpread.OnActionAddNewRow();
            m_RowAdd = true;

        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (shtIssueList.Rows.Count < 0) return;
            // show confirm message
            MessageDialogResult dr = MessageDialog.ShowConfirmation(this, new EVOFramework.Message(Messages.eConfirm.CFM9002.ToString()), MessageDialogButtons.YesNo);
            if (dr != MessageDialogResult.Yes)
                return;
            m_keyboardSpread.OnActionRemoveRow();
        }

        ComboBoxCellType CreateLotNoCellType(LookupData data)
        {
            ComboBoxCellType cell = new ComboBoxCellType();
            cell.Editable = true;
            cell.EditorValue = EditorValue.ItemData;

            if ((data.DataSource) != null)
            {
                DataTable dt = data.DataSource;

                string[] strItems = new string[dt.Rows.Count];
                string[] strItemData = new string[dt.Rows.Count];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    strItemData[i] = dt.Rows[i][data.ValueMember] as string;
                    strItems[i] = strItemData[i];

                }

                cell.Items = strItems;
                cell.ItemData = strItemData;
            }

            return cell;
        }
        #endregion

        #region Keyboard Spread
        void m_keyboardSpread_RowAdded(object sender, int rowIndex)
        {
            // Unlock cells
            CtrlUtil.SpreadSetCellLocked(shtIssueList, false, rowIndex, (int)eColView.ITEM_CODE);
            CtrlUtil.SpreadSetCellLocked(shtIssueList, false, rowIndex, (int)eColView.ITEM_CD_BTN);
            CtrlUtil.SpreadSetCellLocked(shtIssueList, false, rowIndex, (int)eColView.ISSUE_QTY);
            CtrlUtil.SpreadSetCellLocked(shtIssueList, false, rowIndex, (int)eColView.LOT_NO);
            CtrlUtil.SpreadSetCellLocked(shtIssueList, false, rowIndex, (int)eColView.LOT_BTN);
        }

        void m_keyboardSpread_RowAdding(object sender, EventRowAdding e)
        {
            if (m_bRowHasModified)
            { // ถ้า Row กำลังแก้ไขอยู่
                if (!ValidateRowSpread(shtIssueList.ActiveRowIndex, false))
                {
                    e.Cancel = true;
                    return;
                }
            }
            else
            {
                // ถ้าไม่มีการแก้ไข Row  แต่ก่อนที่จะเพิ่มแถวใหม่ จะต้อง Validate แถวล่าสุด (ล่างสุด) ก่อน
                if (shtIssueList.RowCount > 0 && shtIssueList.ActiveRowIndex >= 0)
                {
                    if (!ValidateRowSpread(shtIssueList.RowCount - 1, true))
                    {
                        e.Cancel = true;
                        return;
                    }
                }
            }
        }

        void m_keyboardSpread_RowRemoved(object sender)
        {
            m_bRowHasModified = false;
        }
        #endregion

        #region Form Event

        private void TRN170_Load(object sender, EventArgs e)
        {
            InitialScreen();
        }

        #endregion

        #region Spread Event

        private void fpIssueList_EditModeOff(object sender, EventArgs e)
        {
            eColView eActiveCol = (eColView)shtIssueList.ActiveColumnIndex;
            int ActiveRow = shtIssueList.ActiveRowIndex;

            NZString ItemCD = new NZString(null, shtIssueList.Cells[ActiveRow, (int)eColView.ITEM_CODE].Value);
            NZString LotNo = new NZString(null, shtIssueList.Cells[ActiveRow, (int)eColView.LOT_NO].Value);
            NZString LocCD = new NZString(cboFromLoc, cboFromLoc.SelectedValue);

            switch (eActiveCol)
            {
                case eColView.ITEM_CODE:
                    shtIssueList.Cells[ActiveRow, (int)eColView.ONHAND_QTY].Value = GetOnhandQty(ItemCD, LocCD, LotNo);
                    break;
                case eColView.LOT_NO:
                    // Load Onhand qty
                    shtIssueList.Cells[ActiveRow, (int)eColView.ONHAND_QTY].Value = GetOnhandQty(ItemCD, LocCD, LotNo);
                    break;
            }
        }

        #endregion

        #region Control Event

        private void txtIssueQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                txtRemark.Focus();
                txtRemark.SelectAll();
            }
        }

        void txtItemCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != (char)Keys.Return)
                return;
            // NZString ItemCD = new NZString(txtItemCode, txtItemCode.Text.Trim());
            // LoadIssueList(ItemCD);


            cboFromLoc.Focus();
        }

        private void txtIssueQty_TextChanged(object sender, EventArgs e)
        {
            //CalChildQty(txtIssueQty.Double);
        }

        private void btnItemCode_Click(object sender, EventArgs e)
        {
            //txtItemCode_KeyPress(txtItemCode, new KeyPressEventArgs((char)Keys.Return));
        }

        private void cboFromLoc_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cboFromLoc.SelectedValue != null)
            {

                int rows = shtIssueList.Rows.Count;
                if (rows > 0)
                {
                    NZString LocCD = new NZString(cboFromLoc, cboFromLoc.SelectedValue);
                    for (int i = 0; i < rows; i++)
                    {
                        NZString ItemCD = new NZString(null, shtIssueList.Cells[i, (int)eColView.ITEM_CODE].Value);
                        NZString LotNo = new NZString(null, shtIssueList.Cells[i, (int)eColView.LOT_NO].Value);
                        shtIssueList.Cells[i, (int)eColView.ONHAND_QTY].Value = GetOnhandQty(ItemCD, LocCD, LotNo);

                        //LookupLotNo(i, ItemCD, LocCD);
                    }
                }
            }
        }

        private void dtIssueDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                //txtItemCode.Focus();
                //txtItemCode.SelectAll();
                //rdoIssueType_issue.Select();
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

        #endregion

        #region Spread Validate
        private bool ValidateQTY(int row)
        {
            //Check item
            string itemCode = shtIssueList.Cells[row, (int)eColView.ITEM_CODE].Text;
            NZString LocCD = new NZString(cboFromLoc, cboFromLoc.SelectedValue);
            NZString LotNo = new NZString(null, shtIssueList.Cells[row, (int)eColView.LOT_NO].Value);

            // check lot no
            IssueEntryValidator valIssue = new IssueEntryValidator();
            CommonBizValidator commonVal = new CommonBizValidator();
            ErrorItem err = commonVal.CheckInputLot((NZString)itemCode, LocCD, LotNo, true);
            if (err != null)
            {
                MessageDialog.ShowBusiness(this, err.Message);
                return false;
            }
            // Check ReceiveQty
            NZDecimal qty = GetIssueQtyFromSpread(itemCode);// new NZDecimal(null, shtIssueList.Cells[row, (int)eColView.ISSUE_QTY].Value);

            if (qty.IsNull || qty.StrongValue == decimal.Zero)
            {
                ErrorItem error = new ErrorItem(null, TKPMessages.eValidate.VLM0027.ToString());
                MessageDialog.ShowBusiness(this, error.Message);
                return false;
            }

            return true;
        }

        private NZDecimal GetIssueQtyFromSpread(string itemCode)
        {
            int row = shtIssueList.Rows.Count;
            decimal sumQTY = 0;
            for (int i = 0; i < row; i++)
            {
                if (shtIssueList.Cells[i, (int)eColView.ITEM_CODE].Text.Trim() == itemCode)
                {
                    sumQTY += Convert.ToDecimal(shtIssueList.Cells[i, (int)eColView.ISSUE_QTY].Value);
                }
            }
            return (NZDecimal)sumQTY;
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
            string itemCode = shtIssueList.Cells[row, (int)eColView.ITEM_CODE].Text;
            NZString LocCD = new NZString(cboFromLoc, cboFromLoc.SelectedValue);
            NZString LotNo = new NZString(null, shtIssueList.Cells[row, (int)eColView.LOT_NO].Value);

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

            // ถ้า Validate Row ผ่าน แสดงว่า แถวนั้นไม่จำเป็นต้องเช็คอีกรอบ
            m_bRowHasModified = false;
            return true;
        }

        private decimal GetIssueQtyFromTransID(NZString TransID)
        {
            InventoryTransBIZ biz = new InventoryTransBIZ();
            InventoryTransactionDTO dto = biz.LoadByTransactionID(TransID);
            if (dto != null) return dto.QTY.StrongValue;
            return 0;
        }
        #endregion

        #region Utility method
        /// <summary>
        /// เก็บข้อมูลทุก Cell ของ Row ที่ระบุ
        /// </summary>
        /// <param name="rowIndex"></param>
        private void StoreCellValues(int rowIndex)
        {
            m_mapCellValue.RemoveAll();
            for (int i = 0; i < shtIssueList.Columns.Count; i++)
            {
                m_mapCellValue.Put((eColView)i, shtIssueList.Cells[rowIndex, i].Value);
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
                    shtIssueList.Cells[rowIndex, (int)m_mapCellValue[i].Key].Value = m_mapCellValue[i].Value;
                }
            }
        }
        #endregion

        #region Spread trigger.
        private void fpIssueList_EditModeOn(object sender, EventArgs e)
        {
            // ถ้าเป็นการแก้ไข Cell ใน Row เดียวกัน เป็นครั้งแรก
            if (!m_bRowHasModified)
            {
                m_bRowHasModified = true;
                StoreCellValues(shtIssueList.ActiveRowIndex);

            }
        }

        //private void fpIssueList_EditModeOff(object sender, EventArgs e)
        //{

        //    int rowIndex = shtIssueList.ActiveRowIndex;
        //    int colIndex = shtIssueList.ActiveColumnIndex;

        //    bool bValidateCellPass = ValidateCellEdited(rowIndex, colIndex);
        //    if (!bValidateCellPass)
        //    {
        //        shtIssueList.SetActiveCell(rowIndex, colIndex);
        //    }
        //}

        private void fpIssueList_LeaveCell(object sender, LeaveCellEventArgs e)
        {
            if (m_bRowHasModified)
            {  // เช็คว่า Cell ในแถวนั้น มีการแก้ไขค่าหรือไม่
                if (e.Row != e.NewRow)
                {  // ถ้าเป็นการเปลี่ยนแถว ต้องเช็คก่อนว่า Validate แถวผ่านหรือไม่?
                    if (!ValidateRowSpread(e.Row, false))
                    {
                        e.Cancel = true;
                    }
                    //else
                    //{
                    //    if (m_RowAdd)
                    //    {
                    //        // re sort spread by item code
                    //        shtIssueList.SortRows((int)eColView.ITEM_CODE, true, true);
                    //        m_RowAdd = false;
                    //    }
                    //}
                }
            }
        }

        private void fpIssueList_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
            {
                if (m_bRowHasModified)
                {
                    int lastRowNonEmpty = shtIssueList.GetLastNonEmptyRow(NonEmptyItemFlag.Data);
                    if (lastRowNonEmpty != shtIssueList.RowCount - 1)
                    {
                        shtIssueList.RemoveRows(shtIssueList.RowCount - 1, 1);
                    }
                    else
                    {
                        RestoreCellValues(shtIssueList.ActiveRowIndex);
                    }

                    m_bRowHasModified = false;
                }
                else
                {
                    RemoveRowUnused();
                }
            }
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

        private void RemoveRowUnused()
        {
            int lastRowNonEmpty = shtIssueList.GetLastNonEmptyRow(NonEmptyItemFlag.Data);
            if (lastRowNonEmpty != shtIssueList.RowCount - 1)
            {
                shtIssueList.RemoveRows(shtIssueList.RowCount - 1, 1);
            }

            if (lastRowNonEmpty != -1)
            {
                object o = shtIssueList.Cells[lastRowNonEmpty, (int)eColView.ITEM_CODE].Value;

                if (o == null || o == DBNull.Value)
                {
                    shtIssueList.RemoveRows(lastRowNonEmpty, 1);
                }
            }
        }

        private void fpIssueList_ButtonClicked(object sender, EditorNotifyEventArgs e)
        {
            NZString ItemCD = new NZString(null, shtIssueList.Cells[e.Row, (int)eColView.ITEM_CODE].Value);
            NZString LotNo = new NZString(null, shtIssueList.Cells[e.Row, (int)eColView.LOT_NO].Value);
            NZString LocCD = new NZString(cboFromLoc, cboFromLoc.SelectedValue);

            if (e.Column == (int)eColView.ITEM_CD_BTN)
            {

                ItemFindDialog dialog = new ItemFindDialog(eSqlOperator.In, null);

                dialog.ShowDialog(this);

                if (dialog.IsSelected)
                {
                    shtIssueList.Cells[e.Row, (int)eColView.ITEM_CODE].Value = dialog.SelectedItem.ITEM_CD.Value;
                    shtIssueList.Cells[e.Row, (int)eColView.ITEM_DESC].Value = dialog.SelectedItem.ITEM_DESC.Value;
                    shtIssueList.Cells[e.Row, (int)eColView.LOT_NO].Value = null;
                    shtIssueList.Cells[e.Row, (int)eColView.ISSUE_QTY].Value = null;
                }
            }
            else if (e.Column == (int)eColView.LOT_BTN)
            {
                NZString locCD = new NZString(null, cboFromLoc.SelectedValue);
                LotNoFindDialog dialog = new LotNoFindDialog(ItemCD, locCD);

                dialog.ShowDialog(this);
                if (dialog.IsSelected)
                {
                    shtIssueList.Cells[e.Row, (int)eColView.LOT_NO].Value = dialog.SelectedLotNo.NVL(string.Empty);
                    LotNo = new NZString(null, shtIssueList.Cells[e.Row, (int)eColView.LOT_NO].Value);
                    shtIssueList.Cells[e.Row, (int)eColView.ONHAND_QTY].Value = GetOnhandQty(ItemCD, LocCD, LotNo);
                    shtIssueList.Cells[e.Row, (int)eColView.ISSUE_QTY].Value = shtIssueList.Cells[e.Row, (int)eColView.ONHAND_QTY].Value;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cboFromLoc.SelectedValue == null)
            {
                MessageDialog.ShowBusiness(this,
                    Message.LoadMessage(TKPMessages.eValidate.VLM0103.ToString()));
                return;
            }
            else
            {
                //ถ้าไม่มี row ให้ add ได้ แต่ถ้ามี row ให้ check ว่า row สุดท้ายไม่ใช่ blank
                if ((shtIssueList.RowCount == 0) || (shtIssueList.RowCount > 0 && ValidateRowSpread(shtIssueList.RowCount - 1, true)))
                {
                    string loc = Convert.ToString(cboFromLoc.SelectedValue);
                    TRN171_LotMaintenance trn171 = new TRN171_LotMaintenance(loc);
                    if (DialogResult.OK == trn171.ShowDialog())
                    {
                        ItemNo = trn171.ItemNo.ToString();
                        for (int i = 0; i < trn171.shtData.Rows.Count; i++)
                        {
                            if (Convert.ToBoolean(trn171.shtData.Cells[i, (int)eColumns.EDIT_FLAG].Value) == true)
                            {
                                int j = shtIssueList.RowCount;
                                m_keyboardSpread.OnActionAddNewRow();
                                shtIssueList.Cells[j, (int)eColView.ITEM_CODE].Value = trn171.ItemNo.ToString();
                                shtIssueList.Cells[j, (int)eColView.ITEM_DESC].Value = trn171.ItemName.ToString();
                                shtIssueList.Cells[j, (int)eColView.LOT_NO].Value = trn171.shtData.Cells[i, (int)eColumns.LOT_NO].Value;
                                // shtIssueList.Cells[j, (int)eColView.REQUEST_QTY].Value = trn171.shtData.Cells[i, (int)eColumns.ON_HAND_QTY].Value;
                                shtIssueList.Cells[j, (int)eColView.ISSUE_QTY].Value = trn171.shtData.Cells[i, (int)eColumns.Shipment].Value;
                                shtIssueList.Cells[j, (int)eColView.ONHAND_QTY].Value = trn171.shtData.Cells[i, (int)eColumns.ON_HAND_QTY].Value;
                            }
                        }
                    }
                }
            }
        }

        private void fpIssueList_KeyDown(object sender, KeyEventArgs e)
        {
            CtrlUtil.FilterShortCut(e);
        }
    }

    //internal class SelectedDataRow
    //{
    //    private NZString m_ITEM_CODE = new NZString();
    //    private NZString m_ITEM_DESC = new NZString();
    //    private NZDecimal m_REQUEST_QTY = new NZDecimal();
    //    private NZDecimal m_ISSUE_QTY = new NZDecimal();
    //    private NZDecimal m_ON_HAND_QTY = new NZDecimal();
    //    private NZString m_LOT_NO = new NZString();

    //    public NZString ITEM_CODE { get { return m_ITEM_CODE; } set { m_ITEM_CODE.Value = value; } }
    //    public NZString ITEM_DESC { get { return m_ITEM_DESC; } set { m_ITEM_DESC.Value = value; } }
    //    public NZString LOT_NO { get { return m_LOT_NO; } set { m_LOT_NO.Value = value; } }
    //    public NZDecimal REQUEST_QTY { get { return m_REQUEST_QTY; } set { m_REQUEST_QTY.Value = value; } }
    //    public NZDecimal ISSUE_QTY { get { return m_ISSUE_QTY; } set { m_ISSUE_QTY.Value = value; } }
    //    public NZDecimal ON_HAND_QTY { get { return m_ON_HAND_QTY; } set { m_ON_HAND_QTY.Value = value; } }
    //}
}
