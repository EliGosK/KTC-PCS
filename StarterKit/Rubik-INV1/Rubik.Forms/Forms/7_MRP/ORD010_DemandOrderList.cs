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
using System.Linq;

namespace Rubik.MRP {

    //[Screen("ORD010", "Demand Order List", eShowAction.Normal, eScreenType.ScreenPane, "Demand Order List")]
    public partial class ORD010_DemandOrderList : SystemMaintenance.Forms.CustomizeListPaneBaseForm {

        #region Enum


        public enum eColView
        {
            CRT_BY,
            CRT_DATE,
            CRT_MACHINE,
            UPD_BY,
            UPD_DATE,
            UPD_MACHINE,
            IS_ACTIVE,
            REVISION,
            YEAR_MONTH,
            CUSTOMER_CD,
            ORDER_ID,
            DUE_DATE,
            ITEM_CD,
            ITEM_DESC,
            ORDER_QTY,
            ORDER_TYPE,
            PRIORITY,
            Reserve
        }

        #endregion

        #region Variables


        private DataTable m_dtAllData;

        private DemandOrderBIZ m_BIZDemandOrder;

        #endregion

        #region Constructor


        public ORD010_DemandOrderList()
        {
            InitializeComponent();
            InitializeScreen();

            //InventoryPeriodBIZ biz = new InventoryPeriodBIZ();
            //InventoryPeriodDTO dto = biz.LoadCurrentPeriodWithQueryRange();
            //dtPeriodBegin.NZValue = dto.PERIOD_BEGIN_DATE;
            //dtPeriodEnd.NZValue = dto.PERIOD_END_DATE;

            

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

            LookupData locationLookupData = biz.LoadLookupLocation();
            shtView.Columns[(int)eColView.CUSTOMER_CD].CellType = CtrlUtil.CreateReadOnlyPairCellType(locationLookupData);            

            //LookupData umClassLookupData = biz.LoadLookupClassType(DataDefine.UM_CLS.ToNZString());
            //shtView.Columns[(int)eColView.ORDER_UM_CLS].CellType = CtrlUtil.CreateReadOnlyPairCellType(umClassLookupData);
            //shtView.Columns[(int)eColView.INV_UM_CLS].CellType = CtrlUtil.CreateReadOnlyPairCellType(umClassLookupData);

            //LookupData itemClassLookupData = biz.LoadLookupClassType(DataDefine.ITEM_CLS.ToNZString());
            //shtView.Columns[(int)eColView.ITEM_CLS].CellType = CtrlUtil.CreateReadOnlyPairCellType(itemClassLookupData);

            //LookupData ordClassLookupData = biz.LoadLookupClassType(DataDefine.ORDER_PROCESS_CLS.ToNZString());
            //shtView.Columns[(int)eColView.ORDER_PROCESS_CLS].CellType = CtrlUtil.CreateReadOnlyPairCellType(ordClassLookupData);

            //LookupData ordcClassLookupData = biz.LoadLookupClassType(DataDefine.ORDER_CONDITION.ToNZString());
            //shtView.Columns[(int)eColView.ORDER_CONDITION].CellType = CtrlUtil.CreateReadOnlyPairCellType(ordcClassLookupData);

            //LookupData ordpClassLookupData = biz.LoadLookupClassType(DataDefine.ORDER_PROCESS_CLS.ToNZString());
            //shtView.Columns[(int)eColView.ORDER_PROCESS_CLS].CellType = CtrlUtil.CreateReadOnlyPairCellType(ordpClassLookupData);

            //LookupData mrpClassLookupData = biz.LoadLookupClassType(DataDefine.MRP_FLAG.ToNZString());
            //shtView.Columns[(int)eColView.MRP_FLAG].CellType = CtrlUtil.CreateReadOnlyPairCellType(mrpClassLookupData);

            //shtView.Columns[(int)eColView.CRT_DATE].CellType = CtrlUtil.CreateDateTimeCellType();
            //shtView.Columns[(int)eColView.UPD_DATE].CellType = CtrlUtil.CreateDateTimeCellType();
            //shtView.Columns[(int)eColView.AT_DATE].CellType = CtrlUtil.CreateDateTimeCellType();

            //shtView.Columns[(int)eColView.IS_ACTIVE].CellType = CtrlUtil.CreateCheckboxCellType("","");

            int[] iHideColumn = { 
                                    (int)eColView.CRT_BY, 
                                    (int)eColView.CRT_DATE, 
                                    (int)eColView.CRT_MACHINE, 
                                    (int)eColView.UPD_BY, 
                                    (int)eColView.UPD_DATE, 
                                    (int)eColView.UPD_MACHINE, 
                                    (int)eColView.IS_ACTIVE, 
                                    (int)eColView.ORDER_TYPE,
                                    (int)eColView.PRIORITY,
                                    (int)eColView.Reserve,
                                    (int)eColView.REVISION,
                                    (int)eColView.ORDER_ID,
                                    (int)eColView.YEAR_MONTH
                                };
            for (int iColumn = 0; iColumn < iHideColumn.Length; iColumn++)
            {
                shtView.Columns[iHideColumn[iColumn]].Visible = false;
            }


            CtrlUtil.MappingDataFieldWithEnum(shtView, typeof(eColView));

            shtView.Columns[(int)eColView.DUE_DATE].CellType = CtrlUtil.CreateDateTimeCellType();
        }
        #endregion

        #region Private method


        private void ClearSpread() 
        {
            shtView.RowCount = 0;
            shtView.DataSource = null;
        }

        private void LoadData(NZDateTime dtmFrom, NZDateTime dtmTo)
        {
            DataTable dt = m_BIZDemandOrder.LoadDemandOrderInRange(dtPeriodBegin.NZValue, dtPeriodEnd.NZValue);
            m_dtAllData = dt;
            shtView.DataSource = m_dtAllData;

            ClearSpread();
            FindDataFromMemory();
            //shtView.DataSource = m_dtAllData;

            CtrlUtil.SpreadUpdateColumnSorting(shtView);               
        }

        private void FindDataFromMemory() {
            //CtrlUtil.FilterRestrictChar(txtSearch);
            shtView.DataSource = FilterData(m_dtAllData, txtSearch.Text);
            CtrlUtil.SpreadUpdateColumnSorting(shtView);

            if (shtView.DataSource == null)
                shtView.Rows.Count = 0;

            if (shtView.Rows.Count == 0)
                ctxMenu.Enabled = false;
            else
                ctxMenu.Enabled = true;
        }

        private DataTable FilterData(DataTable dtView, string filterText)
        {
            try
            {
                if (filterText.Trim() == String.Empty)
                    return dtView;

                string[] colNames = Enum.GetNames(typeof(eColView));
                string filterString = string.Empty;

                //for (int i = 0; i < colNames.Length; i++)
                for(int i = (int)eColView.CUSTOMER_CD; i<=  (int)eColView.ORDER_QTY;i++)
                {
                    filterString += string.Format(@"CONVERT({0},'System.String') LIKE '%{1}%' ", colNames[i], filterText);
                    //if (i != colNames.Length - 1)
                    if( i!= (int)eColView.ORDER_QTY)
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

        #endregion

        #region Form event

        private void MRP020_Shown(object sender, EventArgs e)
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

        //for generate PO
        public override void OnAddNew() {
            ORD020_DemandOrder ORD020 = new ORD020_DemandOrder();
            if (ORD020.ShowDialog() == System.Windows.Forms.DialogResult.OK) 
            {
                LoadData(dtPeriodBegin.NZValue, dtPeriodEnd.NZValue);
            }
        }
        
        #endregion

        private void txtSearch_KeyUp(object sender, KeyEventArgs e) {
            //if (DataDefine.ENABLED_AUTO_SEARCH_WHEN_TEXT_CHANGED)
            //{
            //    FindDataFromMemory();
            //}
        }

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
                    //NZString transID = new NZString(null, shtView.Cells[cellRange.Row, (int)eColView.TRANS_ID].Value);
                    //bool canEditOrDelete = m_transactionValidator.TransactionCanEditOrDelete(transID);

                    //miDelete.Enabled = canEditOrDelete && ActivePermission.Delete;
                    //miDeleteGroup.Enabled = canEditOrDelete && ActivePermission.Delete;
                    //miEdit.Enabled = canEditOrDelete && ActivePermission.Edit;
                }
                else
                {
                    //miDelete.Enabled = false;
                    //miDeleteGroup.Enabled = false;
                    //miEdit.Enabled = false;
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
    
        #endregion

        #region Operation
        
        private void OnEdit()
        {
            if (!ActivePermission.Edit) {
                return;
            }

            DemandOrderDTO dto = GenerateDemandOrderDTO();

            ORD020_DemandOrder ORD020 = new ORD020_DemandOrder(dto);
            if (ORD020.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                LoadData(dtPeriodBegin.NZValue, dtPeriodEnd.NZValue);
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

        private void mnuEdit_Click(object sender, EventArgs e)
        {
            OnEdit();
        }

        private void mnuDelete_Click(object sender, EventArgs e)
        {
            try
            {
                switch (MessageDialog.ShowConfirmation(this, new EVOFramework.Message(Messages.eConfirm.CFM9002.ToString()).MessageDescription))
                {
                    case MessageDialogResult.Cancel:
                        return;
                    case MessageDialogResult.No:
                        return;
                    case MessageDialogResult.Yes:
                        break;
                }

                m_BIZDemandOrder.DeleteTargetDemandOrder(GenerateDemandOrderDTO());
                LoadData(dtPeriodBegin.NZValue, dtPeriodEnd.NZValue);
                MessageDialog.ShowInformation(this, "Information", new EVOFramework.Message(Messages.eInformation.INF9003.ToString()).MessageDescription);
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusiness(this, ex.Message);
            }
        }

        private DemandOrderDTO GenerateDemandOrderDTO()
        {
            return new DemandOrderDTO()
            {
                ORDER_ID = new NZInt(null, shtView.Cells[shtView.ActiveRowIndex, (int)eColView.ORDER_ID].Value),
                CUSTOMER_CD =  new NZString(null,shtView.Cells[shtView.ActiveRowIndex, (int)eColView.CUSTOMER_CD].Value),
                YEAR_MONTH = new NZDateTime(null, shtView.Cells[shtView.ActiveRowIndex, (int)eColView.YEAR_MONTH].Value),
                CRT_BY = new NZString(null, shtView.Cells[shtView.ActiveRowIndex, (int)eColView.CRT_BY].Value),
                CRT_DATE = new NZDateTime(null, shtView.Cells[shtView.ActiveRowIndex, (int)eColView.CRT_DATE].Value),
                CRT_MACHINE = new NZString(null, shtView.Cells[shtView.ActiveRowIndex, (int)eColView.CRT_MACHINE].Value),
                UPD_BY = CommonLib.Common.CurrentUserInfomation.UserCD,
                UPD_DATE = (NZDateTime)DateTime.UtcNow,
                UPD_MACHINE = CommonLib.Common.CurrentUserInfomation.Machine,
            };
        }

        private void ORD010_DemandOrderList_Load(object sender, EventArgs e)
        {

            m_BIZDemandOrder = new DemandOrderBIZ();

            DateTime dtmDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            NZDateTime dtmDateFrom = (NZDateTime)dtmDate;
            NZDateTime dtmDateTo = (NZDateTime)(dtmDate.AddMonths(2).AddDays(-1));

            dtPeriodBegin.Value = dtmDateFrom;
            dtPeriodEnd.Value = dtmDateTo;
            LoadData(dtmDateFrom, dtmDateTo);
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

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
