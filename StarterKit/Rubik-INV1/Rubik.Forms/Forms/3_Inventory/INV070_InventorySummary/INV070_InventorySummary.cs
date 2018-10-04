using System;
using System.Collections.Generic;
using System.Data;
using SystemMaintenance.Forms;
using CommonLib;
using EVOFramework.Windows.Forms;
using Rubik.BIZ;
using Rubik.Controller;
using EVOFramework;
using Rubik.DTO;
using System.Windows.Forms;
using EVOFramework.Data;
using Rubik.Validators;
using System.IO;
using SystemMaintenance;

namespace Rubik.Inventory
{
    [Screen("INV070", "Inventory Summary", eShowAction.Normal, eScreenType.Screen, "Inventory Summary")]
    public partial class INV070_InventorySummary : CustomizeInquiryForm
    {
        #region Enum

        enum eColView
        {
            ItemLevel,
            ItemNo,
            ItemName,
            CustomerName,
            Header,
            Rolling,
            Cutting_I,
            Cutting_E,
            Plating_I,
            Plating_E,
            Heating_E,
            Others,
            QC,
            QC_Hold,
            Packing,
            WIP,
            FG
        }

        #endregion

        #region Variable
        private ToolStripButton tsbSearch;
        private DataTable m_dtAllData;
        #endregion

        #region Constructor

        public INV070_InventorySummary()
        {
            InitializeComponent();
        }

        #endregion

        #region Overriden Method

        public override void OnExport()
        {
            base.OnExport();
            ExportDialog frmExport = new ExportDialog(fpInventorySummary);

            frmExport.ShowDialog(this);
        }

        #endregion

        #region Private Method

        private void LoadData(NZDateTime dtPeriod, string keyFilter)
        {
            try
            {
                //== Start to search data.
                InventoryOnhandController ctlInvent = new InventoryOnhandController();

                //== 20091203 Add by Teerayt S.                

                //NZString yearMonth = GetLatestYearMonthInInvOnhand();

                NZString yearMonth = dtMonth.Value.Value.ToString("yyyyMM").ToNZString();
                //== 20091203 End Add by Teerayt S.


                //List<InventorySummaryViewDTO> dtoView = ctlInvent.LoadInventorySummary(yearMonth);
                //m_dtAllData = DTOUtility.ConvertListToDataTable(dtoView);

                m_dtAllData = ctlInvent.LoadInventorySummary(yearMonth);

                FindDataFromMemory(keyFilter);

                CtrlUtil.SpreadUpdateColumnSorting(shtInventorySummary);
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusiness(this, ex.Message);
            }
        }

        private void InitialScreen()
        {

            // add search button
            tsbSearch = new ToolStripButton("Refresh");
            tsbSearch.Image = Forms.Properties.Resources.REFRESH;
            tslControl.Items.Insert(0, tsbSearch);
            tsbSearch.Click += tsbSearch_Click;


            shtInventorySummary.ActiveSkin = Common.ACTIVE_SKIN;

            CtrlUtil.MappingDataFieldWithEnum(this.shtInventorySummary, typeof(eColView));

            for (int i = 0; i < shtInventorySummary.Columns.Count; i++)
            {
                CtrlUtil.SpreadSetColumnsLocked(shtInventorySummary, true, i);
            }

            CtrlUtil.SpreadUpdateColumnSorting(shtInventorySummary);

            //LookupDataBIZ bizLookup = new LookupDataBIZ();
            //LookupData umClsLookup = bizLookup.LoadLookupClassType((NZString)DataDefine.UM_CLS);
            //shtView.Columns[(int)eColView.INV_UM_CLS].CellType = CtrlUtil.CreateReadOnlyPairCellType(umClsLookup);

            //LookupData itemClsLookup = bizLookup.LoadLookupClassType((NZString)DataDefine.ITEM_CLS);
            //shtView.Columns[(int)eColView.ITEM_CLS].CellType = CtrlUtil.CreateReadOnlyPairCellType(itemClsLookup);

            //LookupData itemClsMinorLookup = bizLookup.LoadLookupClassType((NZString)DataDefine.ITEM_CLS_MINOR04);
            //shtView.Columns[(int)eColView.ITEM_CLS_MINOR].CellType = CtrlUtil.CreateReadOnlyPairCellType(itemClsMinorLookup);

            //LookupData locCustomer = bizLookup.LoadLookupLocation();
            //shtView.Columns[(int)eColView.FOR_CUSTOMER].CellType = CtrlUtil.CreateReadOnlyPairCellType(locCustomer);

            switch (Common.CurrentUserInfomation.DateFormat)
            {
                case eDateFormat.YMD:
                    dtMonth.Format = "yyyy/MM";
                    break;
                case eDateFormat.MDY:
                case eDateFormat.DMY:
                    dtMonth.Format = "MM/yyyy";
                    break;
            }

            LoadDefaultPeriod();


        }

        void tsbExportCost_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            //ExportCost();
        }

        void tsbSearch_Click(object sender, EventArgs e)
        {
            LoadData(dtMonth.NZValue, txtFilter.Text.Trim());
        }

        private void MapSpreadData()
        {
            string[] names = Enum.GetNames(typeof(eColView));
            for (int i = 0; i < names.Length; i++)
            {
                shtInventorySummary.Columns[i].DataField = names[i];
                shtInventorySummary.Columns[i].Locked = true;
            }
        }

        private void LoadDefaultPeriod()
        {
            InventoryPeriodBIZ biz = new InventoryPeriodBIZ();
            InventoryPeriodDTO dto = biz.LoadCurrentPeriod();
            dtMonth.NZValue = dto.PERIOD_BEGIN_DATE;

        }

        private void FindDataFromMemory(string keyFilter)
        {
            DataTable dtView = m_dtAllData.Clone();

            if (keyFilter != string.Empty)
            {
                string filterString = FilterStringUtil.GetFilterstring(typeof(eColView), keyFilter);


                //get only the rows you want
                DataRow[] results = m_dtAllData.Select(filterString);

                //populate new destination table
                foreach (DataRow dr in results)
                    dtView.ImportRow(dr);
            }
            else
            {

                foreach (DataRow dr in m_dtAllData.Rows)
                    dtView.ImportRow(dr);

            }
            fpInventorySummary.DataSource = dtView;
        }

        private DataTable FilterData(DataTable dtView, string keyFilter)
        {
            string filterString = "";
            DataTable dtFilter = dtView.Clone();
            if (keyFilter.Trim() == string.Empty)
            {

                //get only the rows you want
                DataRow[] results = dtView.Select(filterString, "LOCATION,ITEM_CODE,LOT_NO,SUPP_LOT_NO");


                //populate new destination table
                foreach (DataRow dr in results)
                    dtFilter.ImportRow(dr);
            }
            else
            {

                filterString = string.Format(@" ( 
                                                    LOCATION         LIKE '%{0}%' OR 
                                                    ITEM_CODE        LIKE '%{0}%' OR 
                                                    ITEM_DESCRIPTION LIKE '%{0}%' OR 
                                                    FOR_CUSTOMER     LIKE '%{0}%' OR 
                                                    MODEL            LIKE '%{0}%' OR 
                                                    LOT_NO           LIKE '%{0}%' OR
                                                    SUPP_LOT_NO      LIKE '%{0}%' OR
                                                    SHORT_NAME       LIKE '%{0}%' 
                                               )", keyFilter);


                //get only the rows you want
                DataRow[] results = dtView.Select(filterString, "LOCATION,ITEM_CODE,LOT_NO,SUPP_LOT_NO");


                //populate new destination table
                foreach (DataRow dr in results)
                    dtFilter.ImportRow(dr);
            }
            return dtFilter;
        }
        #endregion

        #region Form Event

        private void INV010_InventoryOnHandInquiry_Load(object sender, EventArgs e)
        {
            InitialScreen();
            InitialFormat();

            LoadData(dtMonth.NZValue, txtFilter.Text.Trim());
        }


        private void InitialFormat()
        {
            FormatUtil.SetNumberFormat(this.shtInventorySummary.Columns[(int)eColView.Header], FormatUtil.eNumberFormat.Qty_PCS);
            FormatUtil.SetNumberFormat(this.shtInventorySummary.Columns[(int)eColView.Rolling], FormatUtil.eNumberFormat.Qty_PCS);
            FormatUtil.SetNumberFormat(this.shtInventorySummary.Columns[(int)eColView.Cutting_I], FormatUtil.eNumberFormat.Qty_PCS);
            FormatUtil.SetNumberFormat(this.shtInventorySummary.Columns[(int)eColView.Cutting_E], FormatUtil.eNumberFormat.Qty_PCS);
            FormatUtil.SetNumberFormat(this.shtInventorySummary.Columns[(int)eColView.Plating_I], FormatUtil.eNumberFormat.Qty_PCS);
            FormatUtil.SetNumberFormat(this.shtInventorySummary.Columns[(int)eColView.Plating_E], FormatUtil.eNumberFormat.Qty_PCS);
            FormatUtil.SetNumberFormat(this.shtInventorySummary.Columns[(int)eColView.Heating_E], FormatUtil.eNumberFormat.Qty_PCS);
            FormatUtil.SetNumberFormat(this.shtInventorySummary.Columns[(int)eColView.Others], FormatUtil.eNumberFormat.Qty_PCS);
            FormatUtil.SetNumberFormat(this.shtInventorySummary.Columns[(int)eColView.QC], FormatUtil.eNumberFormat.Qty_PCS);
            FormatUtil.SetNumberFormat(this.shtInventorySummary.Columns[(int)eColView.QC_Hold], FormatUtil.eNumberFormat.Qty_PCS);
            FormatUtil.SetNumberFormat(this.shtInventorySummary.Columns[(int)eColView.Packing], FormatUtil.eNumberFormat.Qty_PCS);
            FormatUtil.SetNumberFormat(this.shtInventorySummary.Columns[(int)eColView.WIP], FormatUtil.eNumberFormat.Qty_PCS);
            FormatUtil.SetNumberFormat(this.shtInventorySummary.Columns[(int)eColView.FG], FormatUtil.eNumberFormat.Qty_PCS);

            FormatUtil.SetNumberFormat(this.shtInventorySummary.Columns[(int)eColView.ItemNo], FormatUtil.eNumberFormat.MasterNo);

        }

        #endregion

        #region Control Event



        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            if (DataDefine.ENABLED_AUTO_SEARCH_WHEN_TEXT_CHANGED)
            {
                FindDataFromMemory(this.txtFilter.Text);
            }
        }



        #endregion

        #region Spread Event

        private void fpView_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {

            if (shtInventorySummary.Rows.Count == 0) return;
            if (shtInventorySummary.ActiveRowIndex < 0) return;

            int ActiveRow = shtInventorySummary.ActiveRowIndex;

            //NZString YearMonth = new NZString(null, shtView.Cells[ActiveRow, (int)eColView.YEAR_MONTH].Value);
            //NZString LocationCD = new NZString(null, shtView.Cells[ActiveRow, (int)eColView.LOCATION].Value);
            //NZString ItemCD = new NZString(null, shtView.Cells[ActiveRow, (int)eColView.ITEM_CODE].Value);
            //NZString LotNo = new NZString(null, shtView.Cells[ActiveRow, (int)eColView.LOT_NO].Value);
            //NZString ItemType = new NZString(null, shtView.Cells[ActiveRow, (int)eColView.ITEM_CLS].Value);
            //NZInt QueryType = new NZInt(null, shtView.Cells[ActiveRow, (int)eColView.QUERY_TYPE].Value);
            NZDateTime BeginDate = new NZDateTime(null, dtMonth.Value);

            // Validate period date before show inventory movement
            //InventoryOnhandInquiryValidator validator = new InventoryOnhandInquiryValidator();

            //INV020_InventoryMovementInquiry frmInventoryMovementInquiry = new INV020_InventoryMovementInquiry(
            //    YearMonth, LocationCD, ItemCD, LotNo, BeginDate, EndDate, ItemType, QueryType);
            //frmInventoryMovementInquiry.ShowDialog();
        }

        #endregion

        private void dtPeriodBegin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != (char)Keys.Return) return;
        }

        private void dtPeriodEnd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != (char)Keys.Return) return;
            tslControl.Select();
            tsbSearch.Select();
        }

        private void chkZeroQty_CheckedChanged(object sender, EventArgs e)
        {
            FindDataFromMemory(this.txtFilter.Text);
        }


        private void btnExportOnHandForAccounting_Click(object sender, EventArgs e)
        {
            ExportOnHandForAccounting();
        }

        private void ExportOnHandForAccounting()
        {
            string strFileName = GenerateFileName("IVR010");

            string strTemplateFileName = @"Report\IVR010_InventorySheet.xls";
            string strTemplatePath = Path.Combine(Application.StartupPath, strTemplateFileName);

            string strExportPath = SaveDialogUtil.GetBrowseFileDialogForExport(strFileName);

            if (!"".Equals(strExportPath))
            {
                ReportBIZ bizReport = new ReportBIZ();
                ReportCriteriaDTO.IVR010 objCriteria = new ReportCriteriaDTO.IVR010();

                if (this.dtMonth.Value.HasValue)
                {

                    objCriteria.YearMonth = this.dtMonth.Value.Value.ToString("yyyyMM");
                }
                else
                {
                    objCriteria.YearMonth = DateTime.Today.ToString("yyyyMM");
                }


                DataSet dsIVR010 = bizReport.LoadIVR010_InventorySheet(objCriteria);

                ExportUtil.Export(dsIVR010, strTemplatePath, strExportPath);


                MessageDialog.ShowInformation(this, null, new EVOFramework.Message(Messages.eInformation.INF9003.ToString()).MessageDescription);


                if (File.Exists(strExportPath))
                {
                    System.Diagnostics.Process.Start(strExportPath);
                }


            }
        }

        private string GenerateFileName(string strReportID)
        {
            string strFilename = "";

            strFilename = "MFC-INV1-" + strReportID + "_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".xls";

            return strFilename;
        }

        private void dtPeriodBegin_ValueChanged(object sender, EventArgs e)
        {
            if (this.dtMonth.Value.HasValue)
            {
                DateTime dtBegin = dtMonth.Value.Value;

                DateTime dtEndMonth = dtBegin.AddMonths(1).AddDays(-1);

            }
        }

        public override void OnSaveFormat()
        {
            base.OnSaveFormat();

            SheetWidthController ctrl = new SheetWidthController();
            ctrl.SaveSheetWidth(shtInventorySummary, this.ScreenCode);
        }

        public override void OnResetFormat()
        {
            base.OnResetFormat();

            SheetWidthController ctrl = new SheetWidthController();
            ctrl.ResetSheetWidth(shtInventorySummary);
        }

        public override void OnAdvanceSearch()
        {
            base.OnAdvanceSearch();

            ShowAdvanceSearchDialog(shtInventorySummary, typeof(eColView), m_dtAllData);
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
            ctrl.SetSheetWidth(shtInventorySummary, this.ScreenCode);
        }

        private void fpInventorySummary_KeyDown(object sender, KeyEventArgs e)
        {
            CtrlUtil.FilterShortCut(e);
        }

        private void INV070_InventorySummary_Shown(object sender, EventArgs e)
        {
            CtrlUtil.FocusControl(txtFilter);
        }

        private void txtFilter_KeyDown(object sender, KeyEventArgs e)
        {
            if (DataDefine.ENABLED_AUTO_SEARCH_WHEN_PRESS_ENTER_KEY && e.KeyCode == Keys.Enter)
                FindDataFromMemory(this.txtFilter.Text);
        }

    }
}
