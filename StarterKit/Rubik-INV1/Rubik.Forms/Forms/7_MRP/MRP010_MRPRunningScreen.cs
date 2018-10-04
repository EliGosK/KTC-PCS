using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SystemMaintenance.Forms;
using EVOFramework;
using EVOFramework.Data;
using EVOFramework.Windows.Forms;
using Cube.AFD.Windows.Controls.CalendarControls;
using Rubik.BIZ;
using Rubik.DTO;
using System.Runtime.InteropServices;
using SystemMaintenance;
using CommonLib;
using Rubik.Data;
using SystemMaintenance.BIZ;
using Rubik.Forms.FindDialog;

namespace Rubik.MRP
{
    /// <summary>
    /// สถานะของหน้าจอ สำหรับกำหนดการ Edit
    /// </summary>
    //[Screen("MRP010", "MRP Running Screen", eShowAction.Normal, eScreenType.Screen, "MRP Running Screen")]

    public partial class MRP010_MRPRunningScreen : CustomizeBaseForm {
               
        #region enum

        private enum eScreenMode {
            Idle,
            View,
            Simulate
        }

        private enum eHeader 
        {
            MRPNo,
            Revision,
            ItemCD,
            ItemDesc,
            OrderLocCD,
            ItemCLS,
            OrderProcessCLS,
            LotSize,
            ReOrderPoint,
            SafetyStock,
            MinimumOrder,
            InvUMRate,
            InvUMCLS,
            OrderUMRate,
            OrderUMCLS,  
            MaxCapacity,
            LeadTime,
            SafetyLeadTime,
            MRPFlag,
            OrderCondition,
            InventoryQty
        }

        private enum eDetail 
        {
            RecordNo,
            Description,
            ItemCD,
            OrderLocCD,
            StartDate
        }

        #endregion

        #region Constant

        private const string CONST_STR_PROCESS_NAME = "MRP";
        private const string CONST_STR_MRP_NO = "MRP_NO";

        #endregion

        #region Member

        private eScreenMode m_eScreenMode = eScreenMode.Idle;
        private string m_strMRPNo = string.Empty;

        #endregion

        #region constructor

        public MRP010_MRPRunningScreen() {

            InitializeComponent();
            
            shtViewHeader.ActiveSkin = Common.ACTIVE_SKIN;
            shtViewDetail.ActiveSkin = Common.ACTIVE_SKIN;

            CtrlUtil.MappingDataFieldWithEnum(shtViewHeader, typeof(eHeader));
            for (int i = 0; i < shtViewHeader.ColumnCount; i++) {
                shtViewHeader.Columns[i].AllowAutoFilter = true;
                shtViewHeader.Columns[i].AllowAutoSort = true;
            }
            shtViewDetail.Columns.Count = 0;
            this.SetScreenMode(eScreenMode.Idle);            
        }
        #endregion

        #region Screen Mode

        private void SetScreenMode(eScreenMode mode) 
        {
            m_eScreenMode = mode;
            switch (mode) 
            {
                case eScreenMode.Idle:
                    CtrlUtil.ClearControlData(this.Controls);    
                    CtrlUtil.EnabledControl(false, this.Controls);                    
                    CtrlUtil.EnabledControl(true, chkItemFlag, txtRemark, btnSourceOrder, btnRun);                    
                    CtrlUtil.VisibleControl(false, picWaiting);
                    this.ClearSpread(shtViewHeader, shtViewDetail);
                    SetDefaultControl();
                    InitialSpread();
                    break;
                case eScreenMode.View:
                    CtrlUtil.EnabledControl(false, this.Controls);                    
                    CtrlUtil.EnabledControl(true, chkItemFlag, txtRemark, btnSourceOrder, btnRun);                    
                    CtrlUtil.VisibleControl(false, picWaiting);
                    CtrlUtil.EnabledControl(chkItemFlag.Checked, txtItemCodeFrom, txtItemCodeTo, btnSearchItemFrom, btnSearchItemTo);

                    //if (shtViewHeader.Columns.Count > 0) 
                    //{
                    //    SpreadVisibleColumn(false, shtViewHeader, (int)eHeader.ItemCLS,
                    //                                              (int)eHeader.OrderProcessCLS,
                    //                                              (int)eHeader.InvUMCLS,
                    //                                              (int)eHeader.OrderUMCLS,
                    //                                              (int)eHeader.MaxCapacity,
                    //                                              (int)eHeader.InventoryQty
                    //        );
                    //}
                    //if (shtViewDetail.Columns.Count > 0) 
                    //{                        
                    //    SpreadVisibleColumn(false, shtViewDetail, (int)eDetail.ItemCD, (int)eDetail.OrderLocCD, (int)eDetail.RecordNo);
                    //}
                    break;
                case eScreenMode.Simulate:
                    CtrlUtil.EnabledControl(false, this.Controls); 
                    break;

            }
        }

        #endregion

        #region General Method

        private void SetDefaultControl() 
        {
            MRPBIZ bizMRP = new MRPBIZ();
            ProcessBIZ bizProcess = new ProcessBIZ();
 
            //set start date
            dtpStartDate.Format = Common.CurrentUserInfomation.DateFormatString;
            dtpLastSimulateDate.Format = Common.CurrentUserInfomation.DateFormatString;

            dtpStartDate.Value = bizMRP.GetDefaultStartDate();
            //txtRecoverDay.Text = bizMRP.GetDefaultRecoverDuration().ToString();

            //Load last simulate time
            ProcessDTO dtoProcess = bizProcess.LoadLastProcess(CONST_STR_PROCESS_NAME);
            if (dtoProcess != null) {
                txtLastMRPNo.Text = dtoProcess.PROCESS_NO.ToString();
                dtpLastSimulateDate.Value = (DateTime)dtoProcess.PROCESS_DATE.Value;
            }         
            
        }
        private void InitialSpread() 
        {
            LookupDataBIZ biz = new LookupDataBIZ();
            LookupData locationLookupData = biz.LoadLookupLocation();
            shtViewHeader.Columns[(int)eHeader.OrderLocCD].CellType = CtrlUtil.CreateReadOnlyPairCellType(locationLookupData);

            if (shtViewHeader.Columns.Count > 0) {
                SpreadVisibleColumn(false, shtViewHeader, (int)eHeader.ItemCLS,
                                                          (int)eHeader.OrderProcessCLS,
                                                          (int)eHeader.InvUMCLS,
                                                          (int)eHeader.OrderUMCLS,
                                                          (int)eHeader.MaxCapacity,
                                                          (int)eHeader.InventoryQty
                    );
            }
            if (shtViewDetail.Columns.Count > 0) {
                SpreadVisibleColumn(false, shtViewDetail, (int)eDetail.ItemCD, (int)eDetail.OrderLocCD, (int)eDetail.RecordNo);
            }
        }

        private void ClearSpread(params FarPoint.Win.Spread.SheetView [] sheets) 
        {
            foreach (FarPoint.Win.Spread.SheetView sht in sheets) 
            {
                sht.RowCount = 0;
            }
        }
                
        private bool RunProcess() 
        {
            MRPBIZ bizMRP = new MRPBIZ();

            ProcessDTO dtoProcess = new ProcessDTO();
            dtoProcess.PROCESS_NO = (NZString)m_strMRPNo;
			dtoProcess.PROCESS_TYPE = (NZString)CONST_STR_PROCESS_NAME;
			dtoProcess.STATUS = (NZString)"S";
			dtoProcess.DESCRIPTION = (NZString)txtRemark.Text.Trim();
            dtoProcess.START_PRCS_TIME = (NZDateTime)DateTime.Now;
			dtoProcess.END_PRCS_TIME = null;
            dtoProcess.FILTER_TIMESTAMP = (NZDateTime)DateTime.Now;
			dtoProcess.FILE_NAME = null;
			dtoProcess.MD5SUM = null;
			dtoProcess.IS_CANCEL = (NZDecimal)0;
			dtoProcess.CANCEL_DATE = null;
			dtoProcess.CANCEL_BY = null;
			dtoProcess.CANCEL_MACHINE = null;
            dtoProcess.PROCESS_DATE = (NZDateTime)DateTime.Now.Date;
            dtoProcess.PROCESS_BY = (NZString)Common.CurrentUserInfomation.UserCD;
            dtoProcess.PROCESS_MACHINE = (NZString)Common.CurrentUserInfomation.Machine;
			dtoProcess.RESERVE1 = null;
			dtoProcess.RESERVE2 = null;                

            GenerateMRPDTO dtoMRP = new GenerateMRPDTO();
            dtoMRP.START_DATE = (NZDateTime)dtpStartDate.Value;
            dtoMRP.RECOVER_DURATION = (NZInt)bizMRP.GetDefaultRecoverDuration();
            dtoMRP.ITEM_FLAG = (NZBoolean)chkItemFlag.Checked;
            dtoMRP.ITEM_CD_FROM = (NZString)txtItemCodeFrom.Text.Trim();
            dtoMRP.ITEM_CD_TO = (NZString)txtItemCodeTo.Text.Trim();
            dtoMRP.USER_CD = Common.CurrentUserInfomation.UserCD;
            dtoMRP.MACHINE = Common.CurrentUserInfomation.Machine;
            
            bizMRP.SimulateMRP(dtoProcess, dtoMRP);

            return true;
        }

        private void LoadData(string strMRP_NO) 
        {
            txtMRPNo.Text = strMRP_NO;

            MRPBIZ biz = new MRPBIZ();
            DataTable dt = biz.LoadSimalateMRPHeader(strMRP_NO);            
            shtViewHeader.DataSource = dt;

            if (dt.Rows.Count > 0) 
            {
                shtViewHeader.ActiveRowIndex = 0;
                LoadDetailSummary(strMRP_NO, shtViewHeader.Cells[shtViewHeader.ActiveRowIndex, (int)eHeader.ItemCD].Value.ToString(), shtViewHeader.Cells[shtViewHeader.ActiveRowIndex, (int)eHeader.OrderLocCD].Value.ToString());
            }
        }

        private void LoadDetailSummary(string strMRP_NO, string strITEM_CD, string strLOC_CD)
        {
            MRPBIZ biz = new MRPBIZ();
            DataTable dt = biz.LoadMRPDetailSummaryByMonth(strMRP_NO, strITEM_CD, strLOC_CD);

            ClearSpread(shtViewDetail);
            shtViewDetail.ColumnCount = 0;            
            shtViewDetail.DataSource = dt;

            if (shtViewDetail.Columns.Count > 0) {
                SpreadVisibleColumn(false, shtViewDetail, (int)eDetail.ItemCD, (int)eDetail.OrderLocCD, (int)eDetail.RecordNo);
            }
        }

        private string SearchItem() {
            eItemType[] eType = { eItemType.All };
            ItemFindDialog dialog = new ItemFindDialog(eSqlOperator.Equal, eType);
            dialog.ShowDialog(this);            
            if (dialog.IsSelected)
                return dialog.SelectedItem.ITEM_CD.ToString();
            
            return string.Empty;
        }

        private void SpreadVisibleColumn(bool bVisible,FarPoint.Win.Spread.SheetView sht, params int[] columns) 
        {
            foreach (int iCol in columns) 
            {
                sht.Columns[iCol].Visible = bVisible;
            }
        }

        #endregion

        #region Event

        private void MRP010_MRPRunningScreen_Load(object sender, EventArgs e) {
            this.WindowState = FormWindowState.Maximized;
        }

        private void tsbExit_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void chkItemFlag_CheckedChanged(object sender, EventArgs e) {
            CtrlUtil.EnabledControl(chkItemFlag.Checked, txtItemCodeFrom, txtItemCodeTo, btnSearchItemFrom, btnSearchItemTo);
        }

        private void btnRun_Click(object sender, EventArgs e) {

            //eScreenMode ePreviousMode = m_eScreenMode;

            try {

                this.Cursor = Cursors.WaitCursor;

                //if (string.Empty.Equals(txtRecoverDay.Text)) 
                //{
                //    ErrorItem err = new ErrorItem(null, TKPMessages.eValidate.VLM0143.ToString());
                //    throw new BusinessException(err);
                //}

                MessageDialogResult dr = MessageDialog.ShowConfirmation(this, new EVOFramework.Message(TKPMessages.eConfirm.CFM0005.ToString()).MessageDescription);
                if (dr == MessageDialogResult.Yes) {

                    picWaiting.Visible = true;

                    SetScreenMode(eScreenMode.Simulate);

                    RunningNumberBIZ bizRunning = new RunningNumberBIZ();
                    NZString strMRPNo = bizRunning.GetCompleteRunningNo(new NZString(null, CONST_STR_MRP_NO), new NZString(null, "TB_MRP_H_TR"));
                    m_strMRPNo = strMRPNo;

                    if (RunProcess()) {

                        MessageDialog.ShowInformation(this, "Information", new EVOFramework.Message(Messages.eInformation.INF9003.ToString()).MessageDescription);

                        LoadData(m_strMRPNo);
                        SetDefaultControl();
                    }
                    else 
                    {
                        txtMRPNo.Clear();
                        ClearSpread(shtViewHeader, shtViewDetail);
                    }
                }
            }
            catch (ValidateException ex) {
                MessageDialog.ShowBusiness(this, ex.ErrorResults[0].Message);
            }
            catch (BusinessException ex) {
                MessageDialog.ShowBusiness(this, ex.Error.Message);
            }
            catch (Exception ex) {
                MessageDialog.ShowBusiness(this, ex.Message);
            }
            finally {
                picWaiting.Visible = false;
                SetScreenMode(eScreenMode.View);
                this.Cursor = Cursors.Default;
            }
        }

        private void btnSourceOrder_Click(object sender, EventArgs e) {

            MRPBIZ bizMRP = new MRPBIZ();
            GenerateMRPDTO dtoMRP = new GenerateMRPDTO();

            dtoMRP.START_DATE = (NZDateTime)dtpStartDate.Value;
            dtoMRP.RECOVER_DURATION = (NZInt)bizMRP.GetDefaultRecoverDuration();
            dtoMRP.ITEM_FLAG = (NZBoolean)chkItemFlag.Checked;
            dtoMRP.ITEM_CD_FROM = (NZString)txtItemCodeFrom.Text.Trim();
            dtoMRP.ITEM_CD_TO = (NZString)txtItemCodeTo.Text.Trim();

            MRP011_SourceOrder MRP011 = new MRP011_SourceOrder(dtoMRP);
            MRP011.ShowDialog(this);
        }

        private void btnSearchItemFrom_Click(object sender, EventArgs e) {
            txtItemCodeFrom.Text = SearchItem();
        }

        private void btnSearchItemTo_Click(object sender, EventArgs e) {
            txtItemCodeTo.Text = SearchItem();
        }

        private void fpView_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e) {
            if (!e.ColumnHeader && e.Row >= 0) {
                string strMRPNo = shtViewHeader.Cells[e.Row, (int)eHeader.MRPNo].Value.ToString();
                string strItemCD = shtViewHeader.Cells[e.Row, (int)eHeader.ItemCD].Value.ToString();
                string strLocCD = shtViewHeader.Cells[e.Row, (int)eHeader.OrderLocCD].Value.ToString();

                LoadDetailSummary(strMRPNo, strItemCD, strLocCD);
                SetScreenMode(eScreenMode.View);
            }
        }

        #endregion

        private void fpView_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e) {
            if (shtViewHeader.RowCount <= 0) return;
            NZString strMRPNo = new NZString(null, shtViewHeader.Cells[shtViewHeader.ActiveRowIndex, (int)eHeader.MRPNo].Value);
            NZString strItemCD = new NZString(null, shtViewHeader.Cells[shtViewHeader.ActiveRowIndex, (int)eHeader.ItemCD].Value);
            NZString strLocCD = new NZString(null, shtViewHeader.Cells[shtViewHeader.ActiveRowIndex, (int)eHeader.OrderLocCD].Value);
            NZInt iRevision = new NZInt(null, shtViewHeader.Cells[shtViewHeader.ActiveRowIndex, (int)eHeader.Revision].Value);
            DateTime dtm = new DateTime(dtpStartDate.Value.Value.Year, dtpStartDate.Value.Value.Month, 1);
            NZDateTime dtmPeriodFrom = new NZDateTime(null, (dtm));
            MRPBIZ biz = new MRPBIZ();            
            NZDateTime dtmPeriodTo = biz.GetMaxMRPDate();

            MRP030_MRPMaintenance MRP030 = new MRP030_MRPMaintenance(strMRPNo, iRevision, strItemCD, strLocCD, dtmPeriodFrom, dtmPeriodTo);
            if (MRP030.ShowDialog(null) == DialogResult.OK) {
                //Load New Data
                if (!(string.Empty.Equals(txtMRPNo.Text)))
                    LoadData(txtMRPNo.Text.Trim());
            }
        }

        private void fpView_KeyDown(object sender, KeyEventArgs e)
        {
            CtrlUtil.FilterShortCut(e);
        }

       

        
    }
    
}