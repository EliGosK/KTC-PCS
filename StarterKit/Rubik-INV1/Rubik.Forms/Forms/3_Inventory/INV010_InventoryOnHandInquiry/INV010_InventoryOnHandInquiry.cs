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
    [Screen("INV010", "Inventory On Hand Inquiry", eShowAction.Normal, eScreenType.Screen, "Inventory On Hand Inquiry")]
    public partial class INV010_InventoryOnHandInquiry : CustomizeInquiryForm
    {
        #region Enum

        enum eColView
        {
            YEAR_MONTH,
            LOCATION,
            ITEM_CODE,
            SHORT_NAME,
            CUSTOMER_CD,
            PACK_NO,
            LOT_NO,
            EXTERNAL_LOT_NO,
            ONHAND_QTY,
            PREVIOUS_BAL,
            TOTAL_IN_QTY,
            TOTAL_OUT_QTY,
            TOTAL_ADJ_QTY,
            LAST_RECEIVE_DATE,
            QUERY_TYPE,
        }

        #endregion

        #region Variable
        private ToolStripButton tsbSearch;
        private ToolStripButton tsbExportCost;
        private bool m_bInitialize = true;
        private DataTable m_dtAllData;
        #endregion

        #region Constructor

        public INV010_InventoryOnHandInquiry()
        {
            InitializeComponent();
        }

        #endregion

        #region Overriden Method

        public override void OnExport()
        {
            base.OnExport();
            ExportDialog frmExport = new ExportDialog(fpView);

            frmExport.ShowDialog(this);
        }

        #endregion

        #region Private Method

        private void LoadData(NZDateTime FromPeriod, NZDateTime ToPeriod, string keyFilter, bool validate)
        {
            try
            {
                if (validate)
                {
                    if (chkToEndMonth.Checked)
                    {
                        // Validate period date before search data.
                        InventoryOnhandInquiryValidator validator = new InventoryOnhandInquiryValidator();
                        try
                        {
                            validator.ValidatePeriodDateRange(FromPeriod, ToPeriod);
                        }
                        catch (ValidateException err)
                        {
                            MessageDialog.ShowBusiness(this, err.ErrorResults[0].Message);
                            err.ErrorResults[0].FocusOnControl();
                            return;
                        }
                    }
                }

                //== Start to search data.
                InventoryOnhandController ctlInvent = new InventoryOnhandController();

                bool GroupByItem = rdoGroupItem.Checked;

                int iToEndOfMonth = 1;

                if (chkToEndMonth.Checked)
                {
                    iToEndOfMonth = 0;
                }
                else
                {
                    iToEndOfMonth = 1;
                }
                //== 20091203 Add by Teerayt S.                

                //NZString yearMonth = GetLatestYearMonthInInvOnhand();

                //InventoryPeriodBIZ biz = new InventoryPeriodBIZ();
                //InventoryPeriodDTO dtoPeriod = biz.LoadCurrentPeriod();
                NZString yearMonth = dtPeriodBegin.Value.Value.ToString("yyyyMM").ToNZString(); //dtoPeriod.YEAR_MONTH;
                //== 20091203 End Add by Teerayt S.

                List<InventoryOnhandInquiryViewDTO> dtoView = ctlInvent.LoadInventoryOnhand(yearMonth, FromPeriod, ToPeriod, GroupByItem, iToEndOfMonth);

                m_dtAllData = DTOUtility.ConvertListToDataTable(dtoView);

                DataTable dtView = m_dtAllData.Clone();

                if (keyFilter != string.Empty)
                {
                    string filterString = string.Format(@"
                                                (
                                                    LOCATION         LIKE '%{0}%' OR 
                                                    ITEM_CODE        LIKE '%{0}%' OR 
                                                    CUSTOMER_CD     LIKE '%{0}%' OR 
                                                    LOT_NO           LIKE '%{0}%' OR
                                                    PACK_NO           LIKE '%{0}%' OR
                                                    EXTERNAL_LOT_NO      LIKE '%{0}%' OR
                                                    SHORT_NAME       LIKE '%{0}%'   OR
                                                    LAST_RECEIVE_DATE = #{0:dd/MM/yyyy}#
                                                  )", keyFilter);

                    if (!chkZeroQty.Checked)
                    {
                        filterString = filterString + " AND ONHAND_QTY <> 0 ";
                    }

                    //get only the rows you want
                    DataRow[] results = m_dtAllData.Select(filterString, @"LOCATION,ITEM_CODE,LOT_NO,PACK_NO,EXTERNAL_LOT_NO");

                    //populate new destination table
                    foreach (DataRow dr in results)
                        dtView.ImportRow(dr);
                }
                else
                {
                    if (!chkZeroQty.Checked)
                    {
                        string filterString = " ONHAND_QTY <> 0 ";

                        //get only the rows you want
                        DataRow[] results = m_dtAllData.Select(filterString, @"LOCATION,ITEM_CODE,LOT_NO,PACK_NO,EXTERNAL_LOT_NO");

                        //populate new destination table
                        foreach (DataRow dr in results)
                            dtView.ImportRow(dr);
                    }
                    else
                    {
                        foreach (DataRow dr in m_dtAllData.Rows)
                            dtView.ImportRow(dr);
                    }
                }
                fpView.DataSource = dtView;
                CtrlUtil.SpreadUpdateColumnSorting(shtView);
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusiness(this, ex.Message);
            }
        }


        private void InitialScreen()
        {
            //txtFilter.KeyPress += CommonLib.CtrlUtil.SetRestrictKeyInput;
            //txtFilter.KeyUp += CommonLib.CtrlUtil.FilterRestrictChar;

            // add search button
            tsbSearch = new ToolStripButton("Refresh");
            tsbSearch.Image = Forms.Properties.Resources.REFRESH;
            tslControl.Items.Insert(0, tsbSearch);
            tsbSearch.Click += tsbSearch_Click;

            // add Export Cost button
            tsbExportCost = new ToolStripButton("Export Cost");
            tsbExportCost.Image = Forms.Properties.Resources.EXPORT;
            tslControl.Items.Add(tsbExportCost);
            tsbExportCost.Click += new EventHandler(tsbExportCost_Click);

            //Disable function
            tsbExportCost.Visible = false;

            chkToEndMonth.Checked = false;
            CtrlUtil.EnabledControl(false, dtPeriodEnd);

            shtView.ActiveSkin = Common.ACTIVE_SKIN;
            MapSpreadData();

            LookupDataBIZ bizLookup = new LookupDataBIZ();

            switch (Common.CurrentUserInfomation.DateFormat)
            {
                case eDateFormat.YMD:
                    dtPeriodBegin.Format = "yyyy/MM";
                    break;
                case eDateFormat.MDY:
                case eDateFormat.DMY:
                    dtPeriodBegin.Format = "MM/yyyy";
                    break;
            }

            dtPeriodEnd.Format = Common.CurrentUserInfomation.DateFormatString;

            rdoGroupItem.Checked = true;
            LoadDefaultPeriod();

            LookupDataBIZ biz = new LookupDataBIZ();

            LookupData locationLookupData = biz.LoadLookupLocation();
            shtView.Columns[(int)eColView.CUSTOMER_CD].CellType = CtrlUtil.CreateReadOnlyPairCellType(locationLookupData);


            LoadData(dtPeriodBegin.NZValue, dtPeriodEnd.NZValue, txtFilter.Text.Trim(), false);
        }

        void tsbExportCost_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            ExportCost();
        }

        private void ExportCost()
        {
            try
            {
                InventoryOnhandController ctlInvent = new InventoryOnhandController();
                if (shtView.Rows.Count == 0)
                {
                    return;
                }
                int row = shtView.Rows.Count;
                //int rowfilter= shtView.RowFilter.SheetView.Rows.Count;

                List<string> ItemCodes = new List<string>();
                for (int i = 0; i < row; i++)
                {
                    if (shtView.Cells[i, (int)eColView.ITEM_CODE].Value != null)
                        if (!ItemCodes.Contains(shtView.Cells[i, (int)eColView.ITEM_CODE].Value.ToString()))
                        {
                            ItemCodes.Add(shtView.Cells[i, (int)eColView.ITEM_CODE].Value.ToString());
                        }

                }

                DataTable dtCostView = ctlInvent.GetCostView(ItemCodes);
                if (dtCostView == null)
                {
                    return;
                }
                FarPoint.Win.Spread.FpSpread fpCost = new FarPoint.Win.Spread.FpSpread();
                FarPoint.Win.Spread.SheetView shtCost = new FarPoint.Win.Spread.SheetView();
                shtCost.DataSource = dtCostView;
                shtCost.Columns[0].CellType = CtrlUtil.CreateDateTimeCellType();

                fpCost.Sheets.Add(shtCost);
                ExportDialog frmExport = new ExportDialog(fpCost);
                frmExport.DefaultExcel_Filename = Environment.CurrentDirectory + "\\Cost View.xls";
                //frmExport.de
                frmExport.ShowDialog(this);

            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusiness(this, ex.Message);
            }

        }

        void tsbSearch_Click(object sender, EventArgs e)
        {
            LoadData(dtPeriodBegin.NZValue, dtPeriodEnd.NZValue, txtFilter.Text.Trim(), true);
        }

        private void MapSpreadData()
        {
            string[] names = Enum.GetNames(typeof(eColView));
            for (int i = 0; i < names.Length; i++)
            {
                shtView.Columns[i].DataField = names[i];
                shtView.Columns[i].Locked = true;
            }
        }

        private void LoadDefaultPeriod()
        {
            InventoryPeriodBIZ biz = new InventoryPeriodBIZ();
            InventoryPeriodDTO dto = biz.LoadCurrentPeriod();
            dtPeriodBegin.NZValue = dto.PERIOD_BEGIN_DATE;
            dtPeriodEnd.NZValue = dto.PERIOD_END_DATE;

        }

        private void FindDataFromMemory()
        {
            if (m_dtAllData == null)
                return;

            shtView.DataSource = FilterData(m_dtAllData, txtFilter.Text);
            CtrlUtil.SpreadUpdateColumnSorting(shtView);
        }

        private DataTable FilterData(DataTable dtView, string keyFilter)
        {
            //            if (keyFilter.Trim() == string.Empty)
            //            {
            //                return dtView;
            //            }

            //            string filterString = string.Format(@"
            //                                                LOCATION         LIKE '%{0}%' OR 
            //                                                ITEM_CODE        LIKE '%{0}%' OR 
            //                                                ITEM_DESCRIPTION LIKE '%{0}%' OR 
            //                                                FOR_CUSTOMER     LIKE '%{0}%' OR 
            //                                                MODEL            LIKE '%{0}%' OR 
            //                                                LOT_NO           LIKE '%{0}%' 
            //                                               ", keyFilter);


            //            //get only the rows you want
            //            DataRow[] results = dtView.Select(filterString);
            //            DataTable dtFilter = dtView.Clone();

            //            //populate new destination table
            //            foreach (DataRow dr in results)
            //                dtFilter.ImportRow(dr);

            //            return dtFilter;

            string filterString = "";
            DataTable dtFilter = dtView.Clone();
            if (keyFilter.Trim() == string.Empty)
            {
                //return dtView;

                //filter out qty=0
                if (!chkZeroQty.Checked)
                {
                    filterString = " ONHAND_QTY <> 0 ";
                }

                //get only the rows you want
                DataRow[] results = dtView.Select(filterString, "LOCATION,ITEM_CODE,LOT_NO,PACK_NO");


                //populate new destination table
                foreach (DataRow dr in results)
                    dtFilter.ImportRow(dr);
            }
            else
            {

                filterString = string.Format(@" ( 
                                                    LOCATION         LIKE '%{0}%' OR 
                                                    ITEM_CODE        LIKE '%{0}%' OR 
                                                    CUSTOMER_CD     LIKE '%{0}%' OR 
                                                    LOT_NO           LIKE '%{0}%' OR
                                                    PACK_NO           LIKE '%{0}%' OR
                                                    EXTERNAL_LOT_NO      LIKE '%{0}%' OR
                                                    SHORT_NAME       LIKE '%{0}%' 
                                               ", keyFilter);


                //  LAST_RECEIVE_DATE = #{0:dd/MM/yyyy}#
                DateTime dtKeyword = DateTime.Today;
                if (DateTime.TryParseExact(keyFilter, "dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"), System.Globalization.DateTimeStyles.None, out dtKeyword))
                {
                    filterString += string.Format(System.Globalization.CultureInfo.InvariantCulture, @" OR ( LAST_RECEIVE_DATE >= #{0}#", dtKeyword);
                    filterString += string.Format(System.Globalization.CultureInfo.InvariantCulture, @" AND LAST_RECEIVE_DATE < #{0}# ) ", dtKeyword.AddDays(1));
                }



                //filterString += string.Format(@" OR ONHAND_QTY = {0} ", keyFilter);     //Fixed bug by Pachara S. 20170908 : search string name can't use with ONHAND_QTY column.


                filterString += " )";

                //filter out qty=0
                if (!chkZeroQty.Checked)
                {
                    filterString = filterString + " AND ONHAND_QTY <> 0 ";
                }





                //get only the rows you want
                DataRow[] results = dtView.Select(filterString, "LOCATION,ITEM_CODE,LOT_NO,PACK_NO");


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
            m_bInitialize = true;
            InitialScreen();
            InitializeMenuButton();


            m_bInitialize = false;

        }

        #endregion

        #region Control Event

        private void rdoGroupItemLotNo_CheckedChanged(object sender, EventArgs e)
        {
            if (!m_bInitialize && rdoGroupItemLotNo.Checked)
            {
                LoadData(dtPeriodBegin.NZValue, dtPeriodEnd.NZValue, txtFilter.Text, true);
            }

        }

        private void rdoGroupItem_CheckedChanged(object sender, EventArgs e)
        {
            if (!m_bInitialize && rdoGroupItem.Checked)
            {
                LoadData(dtPeriodBegin.NZValue, dtPeriodEnd.NZValue, txtFilter.Text, true);
            }
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            FindDataFromMemory();
        }



        #endregion

        #region Spread Event

        private void fpView_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {

            if (shtView.Rows.Count == 0) return;
            if (shtView.ActiveRowIndex < 0) return;

            int ActiveRow = shtView.ActiveRowIndex;

            NZString YearMonth = new NZString(null, shtView.Cells[ActiveRow, (int)eColView.YEAR_MONTH].Value);
            NZString LocationCD = new NZString(null, shtView.Cells[ActiveRow, (int)eColView.LOCATION].Value);
            NZString ItemCD = new NZString(null, shtView.Cells[ActiveRow, (int)eColView.ITEM_CODE].Value);
            NZString LotNo = new NZString(null, shtView.Cells[ActiveRow, (int)eColView.LOT_NO].Value);
            NZString PackNo = new NZString(null, shtView.Cells[ActiveRow, (int)eColView.PACK_NO].Value);
            NZInt QueryType = new NZInt(null, shtView.Cells[ActiveRow, (int)eColView.QUERY_TYPE].Value);
            NZDateTime BeginDate = new NZDateTime(null, dtPeriodBegin.Value);
            NZDateTime EndDate = new NZDateTime(null, dtPeriodEnd.Value);

            // Validate period date before show inventory movement
            InventoryOnhandInquiryValidator validator = new InventoryOnhandInquiryValidator();
            try
            {
                if (chkToEndMonth.Checked)
                {
                    validator.ValidatePeriodDateRange(BeginDate, EndDate);
                }
            }
            catch (ValidateException err)
            {
                MessageDialog.ShowBusiness(this, err.ErrorResults[0].Message);
                err.ErrorResults[0].FocusOnControl();
                return;
            }

            INV020_InventoryMovementInquiry frmInventoryMovementInquiry = new INV020_InventoryMovementInquiry(
                YearMonth, LocationCD, ItemCD, LotNo, PackNo, BeginDate, EndDate, QueryType);
            frmInventoryMovementInquiry.ShowDialog();
        }

        #endregion

        private void dtPeriodBegin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != (char)Keys.Return) return;
            dtPeriodEnd.Focus();
        }

        private void dtPeriodEnd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != (char)Keys.Return) return;
            tslControl.Select();
            tsbSearch.Select();
        }

        private void chkZeroQty_CheckedChanged(object sender, EventArgs e)
        {
            FindDataFromMemory();
        }

        private void chkToEndMonth_CheckedChanged(object sender, EventArgs e)
        {
            if (chkToEndMonth.Checked)
            {
                CtrlUtil.EnabledControl(true, dtPeriodEnd);
            }
            else
            {
                CtrlUtil.EnabledControl(false, dtPeriodEnd);
            }
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

                if (this.dtPeriodBegin.Value.HasValue)
                {

                    objCriteria.YearMonth = this.dtPeriodBegin.Value.Value.ToString("yyyyMM");
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

        private void InitializeMenuButton()
        {
            ToolStripButton tsbExportForAccounting = new System.Windows.Forms.ToolStripButton();
            tsbExportForAccounting.Text = "Export Inventory For Accounting";
            tsbExportForAccounting.Image = global::Rubik.Forms.Properties.Resources.EXPORT;
            tslControl.Items.Insert(tslControl.Items.IndexOf(tslControl.Items[tsbExport.Name]) + 1, tsbExportForAccounting);

            tsbExportForAccounting.Click += new EventHandler(btnExportOnHandForAccounting_Click);

        }

        private void dtPeriodBegin_ValueChanged(object sender, EventArgs e)
        {
            if (this.dtPeriodBegin.Value.HasValue)
            {
                DateTime dtBegin = dtPeriodBegin.Value.Value;

                DateTime dtEndMonth = dtBegin.AddMonths(1).AddDays(-1);

                this.dtPeriodEnd.Value = dtEndMonth;
            }
        }

        private void fpView_KeyDown(object sender, KeyEventArgs e)
        {
            CtrlUtil.FilterShortCut(e);
        }

        private void txtFilter_KeyDown(object sender, KeyEventArgs e)
        {
            if (DataDefine.ENABLED_AUTO_SEARCH_WHEN_PRESS_ENTER_KEY && e.KeyCode == Keys.Enter)
                FindDataFromMemory();
        }
    }
}
