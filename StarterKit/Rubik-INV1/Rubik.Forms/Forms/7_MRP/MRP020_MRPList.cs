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

namespace Rubik.MRP {

    //[Screen("MRP020", "MRP Result List", eShowAction.Normal, eScreenType.ScreenPane, "MRP Result List")]
    public partial class MRP020_MRPList : SystemMaintenance.Forms.CustomizeListPaneBaseForm {

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
            MRP_NO,
            REVISION_NO,
            ITEM_CD,
            ITEM_DESC,
            ITEM_CLS,
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
            BAL_LOT_QTY,

            ORDER_PROCESS_CLS,
            LOT_SIZE,
            REORDER_POINT,
            SAFETY_STOCK,
            MINIMUM_ORDER,
            INV_UM_RATE,
            INV_UM_CLS,
            ORDER_UM_RATE,
            ORDER_UM_CLS,            
            MAX_CAPACITY,
            LEADTIME,
            SAFETY_LEADTIME,
            MRP_FLAG,
            ORDER_CONDITION,

            //AT_DATE,
            //INCOMING_QTY,
            //OUTGOING_QTY,
            //REQ_QTY,
            //ACT_REQ_QTY,
            //ACT_REQ_LOT_QTY,
            //ORDER_QTY,
            //ON_HAND_QTY,
            //BAL_QTY,
            //BAL_LOT_QTY
        }
        #endregion

        #region Variables

        private DataTable m_dtAllData;

        #endregion

        #region Constructor
        public MRP020_MRPList()
        {
            InitializeComponent();
            InitializeScreen();

            //InventoryPeriodBIZ biz = new InventoryPeriodBIZ();
            //InventoryPeriodDTO dto = biz.LoadCurrentPeriodWithQueryRange();
            //dtPeriodBegin.NZValue = dto.PERIOD_BEGIN_DATE;
            //dtPeriodEnd.NZValue = dto.PERIOD_END_DATE;

            DateTime dtmDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            NZDateTime dtmDateFrom = (NZDateTime)dtmDate;
            MRPBIZ biz = new MRPBIZ();
            NZDateTime dtmDateTo = biz.GetMaxMRPDate();

            dtPeriodBegin.Value = dtmDateFrom;
            dtPeriodEnd.Value = dtmDateTo;
            LoadData(dtmDateFrom, dtmDateTo);

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

            tsbNew.Enabled = false;
            tsbNew.Text = "Generate PO";
        }

        private void InitializeSpread()
        {
            shtView.ActiveSkin = Common.ACTIVE_SKIN;

            LookupDataBIZ biz = new LookupDataBIZ();
           
            LookupData locationLookupData = biz.LoadLookupLocation();
            shtView.Columns[(int)eColView.ORDER_LOC_CD].CellType = CtrlUtil.CreateReadOnlyPairCellType(locationLookupData);            

            LookupData umClassLookupData = biz.LoadLookupClassType(DataDefine.UM_CLS.ToNZString());
            shtView.Columns[(int)eColView.ORDER_UM_CLS].CellType = CtrlUtil.CreateReadOnlyPairCellType(umClassLookupData);
            shtView.Columns[(int)eColView.INV_UM_CLS].CellType = CtrlUtil.CreateReadOnlyPairCellType(umClassLookupData);

            LookupData itemClassLookupData = biz.LoadLookupClassType(DataDefine.ITEM_CLS.ToNZString());
            shtView.Columns[(int)eColView.ITEM_CLS].CellType = CtrlUtil.CreateReadOnlyPairCellType(itemClassLookupData);

            LookupData ordClassLookupData = biz.LoadLookupClassType(DataDefine.ORDER_PROCESS_CLS.ToNZString());
            shtView.Columns[(int)eColView.ORDER_PROCESS_CLS].CellType = CtrlUtil.CreateReadOnlyPairCellType(ordClassLookupData);

            LookupData ordcClassLookupData = biz.LoadLookupClassType(DataDefine.ORDER_CONDITION.ToNZString());
            shtView.Columns[(int)eColView.ORDER_CONDITION].CellType = CtrlUtil.CreateReadOnlyPairCellType(ordcClassLookupData);

            LookupData ordpClassLookupData = biz.LoadLookupClassType(DataDefine.ORDER_PROCESS_CLS.ToNZString());
            shtView.Columns[(int)eColView.ORDER_PROCESS_CLS].CellType = CtrlUtil.CreateReadOnlyPairCellType(ordpClassLookupData);

            LookupData mrpClassLookupData = biz.LoadLookupClassType(DataDefine.MRP_FLAG.ToNZString());
            shtView.Columns[(int)eColView.MRP_FLAG].CellType = CtrlUtil.CreateReadOnlyPairCellType(mrpClassLookupData);

            shtView.Columns[(int)eColView.CRT_DATE].CellType = CtrlUtil.CreateDateTimeCellType(Common.CurrentUserInfomation.DateFormatString);
            shtView.Columns[(int)eColView.CRT_DATE].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            shtView.Columns[(int)eColView.UPD_DATE].CellType = CtrlUtil.CreateDateTimeCellType(Common.CurrentUserInfomation.DateFormatString);
            shtView.Columns[(int)eColView.UPD_DATE].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            shtView.Columns[(int)eColView.AT_DATE].CellType = CtrlUtil.CreateDateTimeCellType(Common.CurrentUserInfomation.DateFormatString);
            shtView.Columns[(int)eColView.AT_DATE].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;

            shtView.Columns[(int)eColView.IS_ACTIVE].CellType = CtrlUtil.CreateCheckboxCellType("","");

            shtView.Columns[(int)eColView.CRT_BY].Visible = false;
            shtView.Columns[(int)eColView.CRT_DATE].Visible = false;
            shtView.Columns[(int)eColView.CRT_MACHINE].Visible = false;
            shtView.Columns[(int)eColView.UPD_BY].Visible = false;
            shtView.Columns[(int)eColView.UPD_DATE].Visible = false;
            shtView.Columns[(int)eColView.UPD_MACHINE].Visible = false;
            shtView.Columns[(int)eColView.IS_ACTIVE].Visible = false;
            shtView.Columns[(int)eColView.BAL_QTY].Visible = false;
            shtView.Columns[(int)eColView.ITEM_CLS].Visible = false;
            shtView.Columns[(int)eColView.MAX_CAPACITY].Visible = false;  

            CtrlUtil.MappingDataFieldWithEnum(shtView, typeof(eColView));
            for (int i = 0; i < shtView.ColumnCount; i++) {
                shtView.Columns[i].AllowAutoFilter = true;
                shtView.Columns[i].AllowAutoSort = true;
            }
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
            MRPBIZ biz = new MRPBIZ();
            DataTable dt = biz.LoadMRPList(dtmFrom, dtmTo);
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
        }
        private DataTable FilterData(DataTable dtView, string filterText) {
            try {
                if (filterText.Trim() == String.Empty)
                    return dtView;

                string[] colNames = Enum.GetNames(typeof(eColView));
                string filterString = string.Empty;

                for (int i = 0; i < colNames.Length; i++) {
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
            catch (Exception ex) {
                MessageDialog.ShowBusiness(this, ex.Message);
            }
            return null;
        }

        #endregion

        #region Form event
        private void MRP020_Load(object sender, EventArgs e)
        {
            
        }

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
            MRP040_GeneratePO MRP040 = new MRP040_GeneratePO();
            if (MRP040.ShowDialog() == System.Windows.Forms.DialogResult.OK) 
            {
                LoadData(dtPeriodBegin.NZValue, dtPeriodEnd.NZValue);
            }
        }
        
        #endregion

        private void txtSearch_TextChanged(object sender, EventArgs e) {
            if (DataDefine.ENABLED_AUTO_SEARCH_WHEN_TEXT_CHANGED)
            {
                FindDataFromMemory();
            }
        }
        private void txtSearch_KeyUp(object sender, KeyEventArgs e) {
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

            NZString strMRPNo = new NZString(null,shtView.Cells[shtView.ActiveRowIndex, (int)eColView.MRP_NO].Value);
            NZString strItemCD = new NZString(null,shtView.Cells[shtView.ActiveRowIndex, (int)eColView.ITEM_CD].Value);
            NZString strLocCD = new NZString(null,shtView.Cells[shtView.ActiveRowIndex, (int)eColView.ORDER_LOC_CD].Value);
            NZInt iRevision = new NZInt(null, shtView.Cells[shtView.ActiveRowIndex, (int)eColView.REVISION_NO].Value);
            NZDateTime dtmPeriodFrom = new NZDateTime(null,dtPeriodBegin.Value);
            NZDateTime dtmPeriodTo = new NZDateTime(null,dtPeriodEnd.Value);

            MRP030_MRPMaintenance MRP020 = new MRP030_MRPMaintenance(strMRPNo, iRevision, strItemCD, strLocCD, dtmPeriodFrom,dtmPeriodTo);
            if (MRP020.ShowDialog(null) == DialogResult.OK) {
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
            }
        }

        private void mnuEdit_Click(object sender, EventArgs e) {
            OnEdit();
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
