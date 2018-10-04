using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using SystemMaintenance;
using CommonLib;
using EVOFramework;
using EVOFramework.Data;
using EVOFramework.Windows.Forms;
using FarPoint.Win.Spread.Model;
using Rubik.BIZ;
using Rubik.Controller;
using Rubik.DTO;
using System.Windows.Forms;
using Rubik.Validators;
using Message = EVOFramework.Message;

namespace Rubik.Transaction
{
    //[Screen("TRN070", "Work Result List", eShowAction.Normal, eScreenType.ScreenPane, "Work Result List")]
    public partial class TRN070 : SystemMaintenance.Forms.CustomizeListPaneBaseForm
    {


        #region Enum
        public enum eColView
        {
            TRANS_DATE,
            SLIP_NO, // Work result no
            GROUP_TRANS_ID,
            REF_SLIP_NO, // Work order no
            SHIFT_CLS,
            FOR_MACHINE,
            ITEM_CD,
            ITEM_DESC,
            QTY,
            RESERVE_QTY,
            NG_QTY,
            LOC_CD,
            LOT_NO,
            TRANS_ID,
            REMARK,
        }
        #endregion

        #region Variables
        private readonly WorkResultController m_controller = new WorkResultController();
        private readonly TransactionValidator m_transactionValidator = new TransactionValidator();
        #endregion

        #region Constructor
        public TRN070()
        {
            InitializeComponent();
        }
        #endregion

        #region InitializeScreen

        private void InitializeMenuButton()
        {
            tsControl.Items[tsbNew.Name].Text = "Work Result";


            ToolStripButton tsbNewMultiWorkResult = new System.Windows.Forms.ToolStripButton();
            tsbNewMultiWorkResult.Text = "Work Result (Multi)";
            tsbNewMultiWorkResult.Image = global::Rubik.Forms.Properties.Resources.ADD_TO_LIST;
            tsControl.Items.Insert(tsControl.Items.IndexOf(tsControl.Items[tsbNew.Name]) + 1, tsbNewMultiWorkResult);

            tsbNewMultiWorkResult.Click += new EventHandler(tsbNewMultiWorkResult_Click);

        }

        private void tsbNewMultiWorkResult_Click(object sender, EventArgs e)
        {
            TRN160_MultiWorkResultEntry dialog = new TRN160_MultiWorkResultEntry();
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                LoadData(dtPeriodBegin.NZValue, dtPeriodEnd.NZValue);
            }
        }


        private void InitializeScreen()
        {
            InitializeSpread();

            //txtSearch.KeyPress += CommonLib.CtrlUtil.SetRestrictKeyInput;
            //txtSearch.KeyUp += CommonLib.CtrlUtil.FilterRestrictChar;

            dtPeriodBegin.KeyPress += CtrlUtil.SetNextControl;
            dtPeriodEnd.KeyPress += CtrlUtil.SetNextControl;

            dtPeriodBegin.Format = Common.CurrentUserInfomation.DateFormatString;
            dtPeriodEnd.Format = Common.CurrentUserInfomation.DateFormatString;

            InventoryPeriodBIZ biz = new InventoryPeriodBIZ();
            InventoryPeriodDTO dto = biz.LoadCurrentPeriodWithQueryRange();
            dtPeriodBegin.NZValue = dto.PERIOD_BEGIN_DATE;
            dtPeriodEnd.NZValue = dto.PERIOD_END_DATE;
            LoadData(dto.PERIOD_BEGIN_DATE, dto.PERIOD_END_DATE);
        }

        private void InitializeSpread()
        {
            shtView.ActiveSkin = Common.ACTIVE_SKIN;

            LookupDataBIZ biz = new LookupDataBIZ();


            LookupData locationLookupData = biz.LoadLookupLocation();
            shtView.Columns[(int)eColView.LOC_CD].CellType = CtrlUtil.CreateReadOnlyPairCellType(locationLookupData);

            LookupData shiftLookupData = biz.LoadLookupClassType(DataDefine.SHIFT_CLS.ToNZString());
            shtView.Columns[(int)eColView.SHIFT_CLS].CellType = CtrlUtil.CreateReadOnlyPairCellType(shiftLookupData);


            shtView.Columns[(int)eColView.TRANS_DATE].CellType = CtrlUtil.CreateDateTimeCellType();

            CtrlUtil.MappingDataFieldWithEnum(shtView, typeof(eColView));

        }
        #endregion

        #region Private method
        private void LoadData(NZDateTime from, NZDateTime to)
        {
            List<InventoryTransactionViewDTO> list = m_controller.LoadWorkResultList(from, to);
            m_dtAllData = DTOUtility.ConvertListToDataTable(list);

            shtView.RowCount = 0;
            shtView.DataSource = null;
            //shtView.DataSource = m_dtAllData;

            FindDataFromMemory();
            //CtrlUtil.SpreadUpdateColumnSorting(shtView);
        }
        #endregion

        #region Form event
        private void TRN070_Load(object sender, EventArgs e)
        {
            InitializeMenuButton();
            InitializeScreen();
        }

        private void TRN070_Shown(object sender, EventArgs e)
        {
            CtrlUtil.FocusControl(dtPeriodBegin);
        }
        #endregion

        #region Control event
        #region Screen control
        public override void OnRefresh()
        {
            base.OnRefresh();
            LoadData(dtPeriodBegin.NZValue, dtPeriodEnd.NZValue);
        }
        //private void tsbRefresh_Click(object sender, EventArgs e)
        //{
        //    LoadData(dtPeriodBegin.NZValue, dtPeriodEnd.NZValue);
        //}

        //private void tsbNew_Click(object sender, EventArgs e)
        //{
        //    OnNew();
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
                    NZString groupTransID = new NZString(null, shtView.Cells[cellRange.Row, (int)eColView.GROUP_TRANS_ID].Value);

                    bool canEditOrDelete = m_transactionValidator.TransactionCanEditOrDelete(transID);

                    miDelete.Enabled = canEditOrDelete && ActivePermission.Delete;
                    miEdit.Enabled = canEditOrDelete && ActivePermission.Edit;
                    miDeleteGroup.Enabled = canEditOrDelete && ActivePermission.Edit && (!groupTransID.IsNull);
                }
                else
                {
                    miDelete.Enabled = false;
                    miEdit.Enabled = false;
                    miDeleteGroup.Enabled = false;
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
            TRN080 dialog = new TRN080();
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                LoadData(dtPeriodBegin.NZValue, dtPeriodEnd.NZValue);
            }
        }

        private void OnEdit()
        {
            if (!ActivePermission.Edit)
            {
                return;
            }
            if (shtView.RowCount <= 0) return;
            NZString transID = new NZString(null, shtView.GetValue(shtView.ActiveRowIndex, (int)eColView.TRANS_ID));
            NZString GroupTransID = new NZString(null, shtView.GetValue(shtView.ActiveRowIndex, (int)eColView.GROUP_TRANS_ID));

            //ถ้าไม่มี group ก็แสดงหน้าเดี่ยว 
            //ถ้ามี group ก็แสดงหน้า group
            if (GroupTransID.IsNull)
            {
                TRN080 dialog = new TRN080(transID);
                if (dialog.ShowDialog(this) == DialogResult.OK)
                {
                    LoadData(dtPeriodBegin.NZValue, dtPeriodEnd.NZValue);
                }
            }
            else
            {
                TRN160_MultiWorkResultEntry dialog = new TRN160_MultiWorkResultEntry(transID);
                if (dialog.ShowDialog(this) == DialogResult.OK)
                {
                    LoadData(dtPeriodBegin.NZValue, dtPeriodEnd.NZValue);
                }
            }
        }

        private void OnDelete()
        {
            try
            {
                NZString workResultID = new NZString(null, shtView.GetValue(shtView.ActiveRowIndex, (int)eColView.SLIP_NO));

                MessageDialogResult dr = MessageDialog.ShowConfirmation(this, new Message(Messages.eConfirm.CFM9002.ToString()), MessageDialogButtons.YesNo);
                if (dr == MessageDialogResult.No)
                    return;

                m_controller.DeleteWorkResult(workResultID);
                shtView.RemoveRows(shtView.ActiveRowIndex, 1);
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

        private void OnDeleteGroup()
        {
            try
            {
                NZString groupTransId = new NZString(null, shtView.GetValue(shtView.ActiveRowIndex, (int)eColView.GROUP_TRANS_ID));

                MessageDialogResult dr = MessageDialog.ShowConfirmation(this, new Message(Messages.eConfirm.CFM9002.ToString()), MessageDialogButtons.YesNo);
                if (dr == MessageDialogResult.No)
                    return;

                m_controller.DeleteGroupTransaction(groupTransId);

                //ไล่ลบจากล่างขึ้นบน เพราะว่าไม่งั้นindex จะเลื่อนแล้วจะลบไม่ครบ
                for (int iRowIndex = shtView.RowCount - 1; iRowIndex >= 0; iRowIndex--)
                {
                    if (groupTransId.NVL("").Equals(shtView.GetValue(iRowIndex, (int)eColView.GROUP_TRANS_ID)))
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
