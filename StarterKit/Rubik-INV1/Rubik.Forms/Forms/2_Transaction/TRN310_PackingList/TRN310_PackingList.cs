using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using EVOFramework;
using EVOFramework.Data;
using EVOFramework.Windows.Forms;
using FarPoint.Win.Spread.Model;
using Rubik.BIZ;
using CommonLib;
using Rubik.Controller;
using Rubik.DTO;
using SystemMaintenance;
using Message = EVOFramework.Message;
using Rubik.Validators;

namespace Rubik.Transaction
{
    [Screen("TRN310", "Packing List", eShowAction.Normal, eScreenType.ScreenPane, "Packing List")]
    public partial class TRN310_PackingList : SystemMaintenance.Forms.CustomizeListPaneBaseForm
    {
        #region Enum
        public enum eColView
        {
            TRANS_ID,
            GROUP_TRANS_ID,
            TRANS_DATE,
            PACKING,
            ITEM_CD,
            SHORT_NAME,
            CUSTOMER_NAME,
            SHIFT_CLS,
            SHIFT_CLS_NAME,
            PACKING_NO,
            PERSON_IN_CHARGE,
            PERSON_IN_CHARGE_NAME,
            PACK_NO,
            FG_NO,
            LOT_NO,
            EXTERNAL_LOT_NO,
            QTY,
            REMARK
        }
        #endregion

        #region Variables
        private readonly PackingController m_controller = new PackingController();
        private readonly TransactionValidator m_transactionValidator = new TransactionValidator();


        #endregion

        #region Constructor
        public TRN310_PackingList()
        {
            InitializeComponent();
        }
        #endregion

        #region InitializeScreen
        private void InitializeScreen()
        {
            InitializeSpread();
            InitialFormat();
            //txt.KeyPress += CommonLib.CtrlUtil.SetRestrictKeyInput;
            //txtSearch.KeyPress += CommonLib.CtrlUtil.SetRestrictKeyInput;
            //txtSearch.TextChanged += CommonLib.CtrlUtil.FilterRestrictChar;

            dtPeriodBegin.KeyPress += CtrlUtil.SetNextControl;
            dtPeriodEnd.KeyPress += CtrlUtil.SetNextControl;

            //dtPeriodBegin.Format = Common.CurrentUserInfomation.DateFormatString;
            //dtPeriodEnd.Format = Common.CurrentUserInfomation.DateFormatString;
        }
        private void InitializeSpread()
        {
            shtPackingList.ActiveSkin = Common.ACTIVE_SKIN;

            #region Initial Cell Type

            LookupDataBIZ biz = new LookupDataBIZ();

            LookupData shiftCls = biz.LoadLookupClassType(DataDefine.SHIFT_CLS.ToNZString());
            shtPackingList.Columns[(int)eColView.SHIFT_CLS].CellType = CtrlUtil.CreateReadOnlyPairCellType(shiftCls);

            LookupData PersonInCharge = biz.LoadPersonInCharge();
            shtPackingList.Columns[(int)eColView.PERSON_IN_CHARGE].CellType = CtrlUtil.CreateReadOnlyPairCellType(PersonInCharge);

            shtPackingList.Columns[(int)eColView.TRANS_DATE].CellType = CtrlUtil.CreateDateTimeCellType();

            #endregion

            #region Initial export column

            shtPackingList.Columns[(int)eColView.TRANS_ID].StyleName = DataDefine.EXPORT_LAST.ToString();
            shtPackingList.Columns[(int)eColView.GROUP_TRANS_ID].StyleName = DataDefine.EXPORT_LAST.ToString();

            shtPackingList.Columns[(int)eColView.TRANS_ID].Visible = false;
            shtPackingList.Columns[(int)eColView.GROUP_TRANS_ID].Visible = false;
            shtPackingList.Columns[(int)eColView.SHIFT_CLS_NAME].Visible = false;
            shtPackingList.Columns[(int)eColView.PERSON_IN_CHARGE_NAME].Visible = false;

            #endregion

            CtrlUtil.MappingDataFieldWithEnum(shtPackingList, typeof(eColView));
        }
        private void InitialFormat()
        {
            FormatUtil.SetNumberFormat(shtPackingList.Columns[(int)eColView.QTY], FormatUtil.eNumberFormat.Qty_PCS);
            CommonLib.FormatUtil.SetDateFormat(shtPackingList.Columns[(int)eColView.TRANS_DATE]);
            CommonLib.FormatUtil.SetDateFormat(dtPeriodBegin);
            CommonLib.FormatUtil.SetDateFormat(dtPeriodEnd);
        }
        #endregion

        #region Private method
        private void LoadData(NZDateTime from, NZDateTime to)
        {
            //List<InventoryTransactionViewDTO> list = m_controller.LoadReceivingList(from, to);
            //DataTable dt = DTOUtility.ConvertListToDataTable(list);
            //m_dtAllData = DTOUtility.ConvertListToDataTable(list);
            m_dtAllData = m_controller.LoadPackingList(from, to);
            shtPackingList.RowCount = 0;
            shtPackingList.DataSource = null;
            FindDataFromMemory();
            //shtView.DataSource = m_dtAllData;

            // CtrlUtil.SpreadUpdateColumnSorting(shtView);
        }

        private bool CheckCanEditOrDelete(int row)
        {
            if (shtPackingList.RowCount <= 0) return false;
            NZString transID = new NZString(null, shtPackingList.Cells[row, (int)eColView.TRANS_ID].Value);
            bool canEditOrDelete = m_transactionValidator.TransactionCanEditOrDelete(transID);
            if (canEditOrDelete)
            {
                //Unpack Cannot Delete and Modify
                InventoryTransBIZ biz = new InventoryTransBIZ();
                InventoryTransactionDTO dto = biz.LoadByTransactionID(transID);
                if (dto != null)
                {
                    if (DataDefine.Convert2ClassCode(DataDefine.eTRANS_TYPE.Unpack).Equals(dto.TRANS_CLS.StrongValue) ||
                       DataDefine.Convert2ClassCode(DataDefine.eTRANS_TYPE.Unpack_Consumption).Equals(dto.TRANS_CLS.StrongValue)
                        )
                        canEditOrDelete = false;
                }
            }

            return canEditOrDelete;
        }
        #endregion

        #region Form event
        private void TRN010_Load(object sender, EventArgs e)
        {
            InitializeScreen();
            InitializeMenuButton();

            InventoryPeriodBIZ biz = new InventoryPeriodBIZ();
            InventoryPeriodDTO dto = biz.LoadCurrentPeriodWithQueryRange();
            dtPeriodBegin.NZValue = dto.PERIOD_BEGIN_DATE;
            dtPeriodEnd.NZValue = dto.PERIOD_END_DATE;

            LoadData(dto.PERIOD_BEGIN_DATE, dto.PERIOD_END_DATE);
        }

        private void TRN010_Shown(object sender, EventArgs e)
        {
            CtrlUtil.FocusControl(txtSearch);
        }

        public void tsbUnpack_Click(object sender, EventArgs e)
        {
            TRN330_UnpackEntry dialog = new TRN330_UnpackEntry();
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                LoadData(dtPeriodBegin.NZValue, dtPeriodEnd.NZValue);
            }
        }
        #endregion

        #region Control event
        #region Screen control
        //private void tsbRefresh_Click(object sender, EventArgs e)
        //{
        //    LoadData(dtPeriodBegin.NZValue, dtPeriodEnd.NZValue);
        //}
        public override void OnRefresh()
        {
            base.OnRefresh();
            LoadData(dtPeriodBegin.NZValue, dtPeriodEnd.NZValue);
        }
        //private void tsbNew_Click(object sender, EventArgs e)
        //{
        //    OnNew();
        //}
        //public override void OnExit()
        //{
        //    base.OnExit();
        //}
        //private void tsbExit_Click(object sender, EventArgs e)
        //{
        //    this.HidePane();
        //}
        #endregion

        #region Spread
        private void fpView_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {

                bool isClickOnCell = false;

                CellRange cellRange = fpPackingList.GetCellFromPixel(0, 0, e.X, e.Y);
                if (cellRange.Column != -1 && cellRange.Row != -1)
                {
                    shtPackingList.SetActiveCell(cellRange.Row, cellRange.Column);
                    shtPackingList.AddSelection(cellRange.Row, cellRange.Column, 1, 1);
                    isClickOnCell = true;
                }

                if (isClickOnCell)
                {
                    bool canEditOrDelete = CheckCanEditOrDelete(cellRange.Row);

                    //NZString transID = new NZString(null, shtPackingList.Cells[cellRange.Row, (int)eColView.TRANS_ID].Value);                    
                    //bool canEditOrDelete = m_transactionValidator.TransactionCanEditOrDelete(transID);
                    //if (canEditOrDelete) 
                    //{
                    //    //Unpack Cannot Delete and Modify
                    //    InventoryTransBIZ biz = new InventoryTransBIZ();
                    //    InventoryTransactionDTO dto = biz.LoadByTransactionID(transID);
                    //    if (dto != null)
                    //    {
                    //        if (DataDefine.Convert2ClassCode(DataDefine.eTRANS_TYPE.Unpack).Equals(dto.TRANS_CLS.StrongValue) ||
                    //           DataDefine.Convert2ClassCode(DataDefine.eTRANS_TYPE.Unpack_Consumption).Equals(dto.TRANS_CLS.StrongValue)
                    //            )
                    //            canEditOrDelete = false;
                    //    }

                    //}

                    miDelete.Enabled = canEditOrDelete && ActivePermission.Delete;
                    miDeleteGroup.Enabled = canEditOrDelete && ActivePermission.Delete;
                    miEdit.Enabled = canEditOrDelete && ActivePermission.Edit;
                }
                else
                {
                    miDelete.Enabled = false;
                    miDeleteGroup.Enabled = false;
                    miEdit.Enabled = false;
                }

                ctxMenu.Show(fpPackingList, e.Location);
            }

        }
        private void fpView_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            if (CheckCanEditOrDelete(e.Row))
                OnEdit();
        }
        private void fpView_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                if (CheckCanEditOrDelete(shtPackingList.ActiveRowIndex))
                    OnEdit();
            }
        }
        #endregion

        #region Context Menu
        private void miEdit_Click(object sender, EventArgs e)
        {
            OnEdit();
        }

        private void miDelete_Click(object sender, EventArgs e)
        {
            OnDelete();
        }
        #endregion
        #endregion

        #region Operation
        public override void OnAddNew()
        {
            base.OnAddNew();
            TRN320_PackingEntry dialog = new TRN320_PackingEntry();
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                LoadData(dtPeriodBegin.NZValue, dtPeriodEnd.NZValue);
            }
        }
        //private void OnNew()
        //{
        //    TRN020 dialog = new TRN020();
        //    if (dialog.ShowDialog(this) == DialogResult.OK)
        //    {
        //        LoadData(dtPeriodBegin.NZValue, dtPeriodEnd.NZValue);
        //    }
        //}

        private void OnEdit()
        {
            if (!ActivePermission.Edit)
            {
                return;
            }
            if (shtPackingList.RowCount <= 0) return;

            NZString groupTransID = new NZString(null, shtPackingList.GetValue(shtPackingList.ActiveRowIndex, (int)eColView.GROUP_TRANS_ID));

            if (!CanEditDeletePacking(groupTransID))
            {
                MessageDialog.ShowInformation(this, null, new Message(TKPMessages.eValidate.VLM0221.ToString()).MessageDescription);

                return;
            }

            NZString packingNo = new NZString(null, shtPackingList.GetValue(shtPackingList.ActiveRowIndex, (int)eColView.PACKING_NO));
            TRN320_PackingEntry dialog = new TRN320_PackingEntry(packingNo);
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                LoadData(dtPeriodBegin.NZValue, dtPeriodEnd.NZValue);
            }
        }

        private void OnDelete()
        {
            try
            {
                NZString transID = new NZString(null, shtPackingList.GetValue(shtPackingList.ActiveRowIndex, (int)eColView.TRANS_ID));
                NZString groupTransID = new NZString(null, shtPackingList.GetValue(shtPackingList.ActiveRowIndex, (int)eColView.GROUP_TRANS_ID));


                if (!CanEditDeletePacking(groupTransID))
                {
                    MessageDialog.ShowInformation(this, null, new Message(TKPMessages.eValidate.VLM0221.ToString()).MessageDescription);
                    return;
                }


                MessageDialogResult dr = MessageDialog.ShowConfirmation(this, new Message(Messages.eConfirm.CFM9002.ToString()), MessageDialogButtons.YesNo);
                if (dr == MessageDialogResult.No)
                    return;

                m_controller.DeleteTransaction(transID, groupTransID);
                LoadData(dtPeriodBegin.NZValue, dtPeriodEnd.NZValue);
                //shtPackingList.RemoveRows(shtPackingList.ActiveRowIndex, 1);

                MessageDialog.ShowInformation(this, null, new Message(Messages.eInformation.INF9003.ToString()).MessageDescription);
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
            catch (Exception err)
            {
                MessageDialog.ShowBusiness(this, err.Message);
            }
        }

        private void OnDeleteGroup()
        {
            try
            {
                NZString groupID = new NZString(null, shtPackingList.GetValue(shtPackingList.ActiveRowIndex, (int)eColView.GROUP_TRANS_ID));

                if (!CanEditDeletePacking(groupID))
                {
                    MessageDialog.ShowInformation(this, null, new Message(TKPMessages.eValidate.VLM0221.ToString()).MessageDescription);
                    return;
                }


                MessageDialogResult dr = MessageDialog.ShowConfirmation(this, new Message(Messages.eConfirm.CFM9002.ToString()), MessageDialogButtons.YesNo);
                if (dr == MessageDialogResult.No)
                    return;

                m_controller.DeleteGroupTransaction(groupID);

                ////ไล่ลบจากล่างขึ้นบน เพราะว่าไม่งั้นindex จะเลื่อนแล้วจะลบไม่ครบ
                //for (int iRowIndex = shtPackingList.RowCount - 1; iRowIndex >= 0; iRowIndex--)
                //{
                //    if (receiveNo.NVL("").Equals(shtPackingList.GetValue(iRowIndex, (int)eColView.SLIP_NO)))
                //    {
                //        shtPackingList.Rows.Remove(iRowIndex, 1);
                //    }
                //}

                LoadData(dtPeriodBegin.NZValue, dtPeriodEnd.NZValue);

                MessageDialog.ShowInformation(this, null, new Message(Messages.eInformation.INF9003.ToString()).MessageDescription);
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
            catch (Exception err)
            {
                MessageDialog.ShowBusiness(this, err.Message);
            }
        }
        #endregion

        private void InitializeMenuButton()
        {
            ToolStripButton tsbUnpack = new System.Windows.Forms.ToolStripButton();
            tsbUnpack.Text = "Unpack";
            tsbUnpack.Image = global::Rubik.Forms.Properties.Resources.CLEAR;
            tsControl.Items.Insert(tsControl.Items.IndexOf(tsControl.Items[this.tsbNew.Name]) + 1, tsbUnpack);

            tsbUnpack.Click += new EventHandler(tsbUnpack_Click);

        }

        public override void PermissionControl()
        {
            base.PermissionControl();

            if (ActivePermission.View)
            {
                ctxMenu.Items[0].Enabled = ActivePermission.Edit;
                ctxMenu.Items[1].Enabled = ActivePermission.Delete;
            }
        }

        private DataTable m_dtAllData;
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (DataDefine.ENABLED_AUTO_SEARCH_WHEN_TEXT_CHANGED)
            {
                FindDataFromMemory();
            }
        }
        private void FindDataFromMemory()
        {
            //CtrlUtil.FilterRestrictChar(txtSearch);
            shtPackingList.DataSource = FilterData(m_dtAllData, txtSearch.Text);
            CtrlUtil.SpreadUpdateColumnSorting(shtPackingList);
        }

        private DataTable FilterData(DataTable dtView, string filterText)
        {
            try
            {
                if (filterText.Trim() == String.Empty)
                    return dtView;

                //string[] colNames = Enum.GetNames(typeof(eColView));
                //string filterString = string.Empty;

                //for (int i = 0; i < colNames.Length; i++) {
                //    filterString += string.Format(@"CONVERT({0},'System.String') LIKE '%{1}%' ", colNames[i], filterText);
                //    if (i != colNames.Length - 1)
                //        filterString += " OR ";
                //}

                string filterString = FilterStringUtil.GetFilterstring(typeof(eColView), filterText);

                //get only the rows you want
                DataRow[] results = m_dtAllData.Select(filterString);
                DataTable dtFilter = dtView.Clone();

                //populate new destination table
                foreach (DataRow dr in results)
                    dtFilter.ImportRow(dr);

                return dtFilter;
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusiness(this, ex.Message);
            }
            return null;
        }

        private void miDeleteGroup_Click(object sender, EventArgs e)
        {
            OnDeleteGroup();
        }

        public override void OnSorting()
        {
            ShowMultiSortDialog(shtPackingList);
        }

        public override void OnSaveFormat()
        {
            base.OnSaveFormat();

            SheetWidthController ctrl = new SheetWidthController();
            ctrl.SaveSheetWidth(shtPackingList, this.ScreenCode);
        }

        public override void OnResetFormat()
        {
            base.OnResetFormat();

            SheetWidthController ctrl = new SheetWidthController();
            ctrl.ResetSheetWidth(shtPackingList);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (Common.UserGroupShowFormatButton.ToUpper().Equals(Common.CurrentUserInfomation.GroupCode.NVL("").ToUpper()))
            {
                tsbDefaultSize.Visible = true;
                tsbSaveFormat.Visible = true;
                tsbAdvanceSearch.Visible = true;
            }

            SheetWidthController ctrl = new SheetWidthController();
            ctrl.SetSheetWidth(shtPackingList, this.ScreenCode);
        }

        private void fpPackingList_KeyDown(object sender, KeyEventArgs e)
        {
            CtrlUtil.FilterShortCut(e);
        }

        private bool CanEditDeletePacking(NZString groupTransactionID)
        {
            InventoryBIZ biz = new InventoryBIZ();
            DataTable dt = biz.CheckUnpackInventory(groupTransactionID);

            if (dt != null && dt.Rows.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public override void OnAdvanceSearch()
        {
            base.OnAdvanceSearch();

            ShowAdvanceSearchDialog(shtPackingList, typeof(eColView), m_dtAllData);
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (DataDefine.ENABLED_AUTO_SEARCH_WHEN_PRESS_ENTER_KEY && e.KeyCode == Keys.Enter)
                FindDataFromMemory();
        }
    }
}
