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
    [Screen("TRN010", "Receiving List", eShowAction.Normal, eScreenType.ScreenPane, "Receiving List")]
    public partial class TRN010 : SystemMaintenance.Forms.CustomizeListPaneBaseForm
    {
        #region Enum
        public enum eColView
        {
            TRANS_DATE,
            SLIP_NO,
            TRANS_CLS,
            DEALING_NO,
            ITEM_CD,
            ITEM_DESC,
            LOT_NO,
            //SUPP_LOT_NO,   Fixed bug by Pachara S. 20170908 : SUUPP_LOT_NO column is miss
            ORDER_QTY,
            PRICE,
            AMOUNT,
            ORDER_UM_CLS,
            QTY,
            INV_UM_CLS,
            LOC_CD,
            OTHER_DL_NO,
            REF_SLIP_NO,
            REF_SLIP_CLS,
            TRANS_ID,
            REMARK,
        }
        #endregion

        #region Variables
        private readonly ReceivingListController m_controller = new ReceivingListController();
        private readonly TransactionValidator m_transactionValidator = new TransactionValidator();


        #endregion

        #region Constructor
        public TRN010()
        {
            InitializeComponent();
        }
        #endregion

        #region InitializeScreen
        private void InitializeScreen()
        {
            InitializeSpread();

            //txt.KeyPress += CommonLib.CtrlUtil.SetRestrictKeyInput;
            //txtSearch.KeyPress += CommonLib.CtrlUtil.SetRestrictKeyInput;
            //txtSearch.TextChanged += CommonLib.CtrlUtil.FilterRestrictChar;

            dtPeriodBegin.KeyPress += CtrlUtil.SetNextControl;
            dtPeriodEnd.KeyPress += CtrlUtil.SetNextControl;

            dtPeriodBegin.Format = Common.CurrentUserInfomation.DateFormatString;
            dtPeriodEnd.Format = Common.CurrentUserInfomation.DateFormatString;
        }

        private void InitializeSpread()
        {
            shtView.ActiveSkin = Common.ACTIVE_SKIN;

            LookupDataBIZ biz = new LookupDataBIZ();
            NZString[] classInfos = {
                                        (NZString) DataDefine.Convert2ClassCode(DataDefine.eTRANS_TYPE.Receiving),
                                        (NZString) DataDefine.Convert2ClassCode(DataDefine.eTRANS_TYPE.Receive_Return)
                                    };

            LookupData receiveTypeLookupData = biz.LoadLookupClassType(DataDefine.TRANS_TYPE.ToNZString(), classInfos);
            shtView.Columns[(int)eColView.TRANS_CLS].CellType = CtrlUtil.CreateReadOnlyPairCellType(receiveTypeLookupData);

            LookupData locationLookupData = biz.LoadLookupLocation();
            shtView.Columns[(int)eColView.LOC_CD].CellType = CtrlUtil.CreateReadOnlyPairCellType(locationLookupData);
            shtView.Columns[(int)eColView.DEALING_NO].CellType = CtrlUtil.CreateReadOnlyPairCellType(locationLookupData);

            LookupData umClassLookupData = biz.LoadLookupClassType(DataDefine.UM_CLS.ToNZString());
            shtView.Columns[(int)eColView.ORDER_UM_CLS].CellType = CtrlUtil.CreateReadOnlyPairCellType(umClassLookupData);
            shtView.Columns[(int)eColView.INV_UM_CLS].CellType = CtrlUtil.CreateReadOnlyPairCellType(umClassLookupData);

            LookupData refTypeLookupData = biz.LoadLookupClassType(DataDefine.REF_SLIP_CLS.ToNZString());
            shtView.Columns[(int)eColView.REF_SLIP_CLS].CellType = CtrlUtil.CreateReadOnlyPairCellType(refTypeLookupData);

            shtView.Columns[(int)eColView.TRANS_DATE].CellType = CtrlUtil.CreateDateTimeCellType();
            CtrlUtil.MappingDataFieldWithEnum(shtView, typeof(eColView));

        }
        #endregion

        #region Private method
        private void LoadData(NZDateTime from, NZDateTime to)
        {
            List<InventoryTransactionViewDTO> list = m_controller.LoadReceivingList(from, to);
            //DataTable dt = DTOUtility.ConvertListToDataTable(list);
            m_dtAllData = DTOUtility.ConvertListToDataTable(list);
            shtView.RowCount = 0;
            shtView.DataSource = null;
            FindDataFromMemory();
            //shtView.DataSource = m_dtAllData;

            // CtrlUtil.SpreadUpdateColumnSorting(shtView);
        }
        #endregion

        #region Form event
        private void TRN010_Load(object sender, EventArgs e)
        {
            InitializeScreen();

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

                CellRange cellRange = fpView.GetCellFromPixel(0, 0, e.X, e.Y);
                if (cellRange.Column != -1 && cellRange.Row != -1)
                {
                    shtView.SetActiveCell(cellRange.Row, cellRange.Column);
                    shtView.AddSelection(cellRange.Row, cellRange.Column, 1, 1);
                    isClickOnCell = true;
                }

                if (isClickOnCell)
                {
                    NZString transID = new NZString(null, shtView.Cells[cellRange.Row, (int)eColView.TRANS_ID].Value);
                    bool canEditOrDelete = m_transactionValidator.TransactionCanEditOrDelete(transID);

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

                ctxMenu.Show(fpView, e.Location);
            }

        }
        private void fpView_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            OnEdit();
        }
        private void fpView_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
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
            TRN020 dialog = new TRN020();
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
            if (shtView.RowCount <= 0) return;
            NZString receiveNo = new NZString(null, shtView.GetValue(shtView.ActiveRowIndex, (int)eColView.SLIP_NO));
            TRN020 dialog = new TRN020(receiveNo);
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                LoadData(dtPeriodBegin.NZValue, dtPeriodEnd.NZValue);
            }
        }

        private void OnDelete()
        {
            try
            {
                NZString transID = new NZString(null, shtView.GetValue(shtView.ActiveRowIndex, (int)eColView.TRANS_ID));

                MessageDialogResult dr = MessageDialog.ShowConfirmation(this, new Message(Messages.eConfirm.CFM9002.ToString()), MessageDialogButtons.YesNo);
                if (dr == MessageDialogResult.No)
                    return;

                m_controller.DeleteItem(transID);
                //LoadData(dtPeriodBegin.NZValue, dtPeriodEnd.NZValue);
                shtView.RemoveRows(shtView.ActiveRowIndex, 1);

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
                NZString receiveNo = new NZString(null, shtView.GetValue(shtView.ActiveRowIndex, (int)eColView.SLIP_NO));

                MessageDialogResult dr = MessageDialog.ShowConfirmation(this, new Message(Messages.eConfirm.CFM9002.ToString()), MessageDialogButtons.YesNo);
                if (dr == MessageDialogResult.No)
                    return;

                m_controller.DeleteGroupTransaction(receiveNo);

                //ไล่ลบจากล่างขึ้นบน เพราะว่าไม่งั้นindex จะเลื่อนแล้วจะลบไม่ครบ
                for (int iRowIndex = shtView.RowCount - 1; iRowIndex >= 0; iRowIndex--)
                {
                    if (receiveNo.NVL("").Equals(shtView.GetValue(iRowIndex, (int)eColView.SLIP_NO)))
                    {
                        shtView.Rows.Remove(iRowIndex, 1);
                    }
                }

                //LoadData(dtPeriodBegin.NZValue, dtPeriodEnd.NZValue);

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
            shtView.DataSource = FilterData(m_dtAllData, txtSearch.Text);
            CtrlUtil.SpreadUpdateColumnSorting(shtView);
        }

        private DataTable FilterData(DataTable dtView, string filterText)
        {
            try
            {
                if (filterText.Trim() == String.Empty)
                    return dtView;

                string[] colNames = Enum.GetNames(typeof(eColView));
                string filterString = string.Empty;

                for (int i = 0; i < colNames.Length; i++)
                {
                    filterString += string.Format(@"CONVERT({0},'System.String') LIKE '%{1}%' ", colNames[i], filterText);
                    if (i != colNames.Length - 1)
                        filterString += " OR ";
                }

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

        private void fpView_KeyDown(object sender, KeyEventArgs e)
        {
            CtrlUtil.FilterShortCut(e);
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (DataDefine.ENABLED_AUTO_SEARCH_WHEN_PRESS_ENTER_KEY && e.KeyCode == Keys.Enter)
                FindDataFromMemory();
        }

    }
}
