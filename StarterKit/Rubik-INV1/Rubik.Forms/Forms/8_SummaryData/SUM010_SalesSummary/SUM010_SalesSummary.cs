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

namespace Rubik.SummaryData
{
    [Screen("SUM010", "Sales Summary", eShowAction.Normal, eScreenType.Screen, "Sales Summary")]
    public partial class SUM010_SalesSummary : CustomizeInquiryForm
    {
        #region Enum

        enum eColView
        {
            ItemNo,
            ItemName,
            CustomerName,
            ItemLevel,
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
            FG,
            OrderQty,
            RemainQty,
            DeliveryQty
        }

        #endregion

        #region Variable
        private ToolStripButton tsbSearch;
        private DataTable m_dtAllData;
        #endregion

        #region Constructor

        public SUM010_SalesSummary()
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



            LoadDefaultPeriod();


        }

        void tsbExportCost_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            //ExportCost();
        }

        void tsbSearch_Click(object sender, EventArgs e)
        {
            LoadData(dtDateBegin.NZValue, dtDateEnd.NZValue, this.txtFilter.Text);
        }



        private void LoadDefaultPeriod()
        {
            this.dtDateBegin.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            this.dtDateEnd.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1).AddMonths(1).AddDays(-1);
        }

        private void FindDataFromMemory(string keyFilter)
        {
            DataTable dtView = m_dtAllData.Clone();

            if (keyFilter != string.Empty)
            {
                string filterString = FilterStringUtil.GetFilterstring(typeof(eColView), keyFilter);

                DataView dv = m_dtAllData.DefaultView;
                dv.RowFilter = filterString;
                dtView = dv.ToTable();

                ////get only the rows you want
                //DataRow[] results = m_dtAllData.Select(filterString);

                ////populate new destination table
                //foreach (DataRow dr in results)
                //    dtView.ImportRow(dr);
            }
            else
            {

                dtView = m_dtAllData.Copy();
                //foreach (DataRow dr in m_dtAllData.Rows)
                //    dtView.ImportRow(dr);

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


        private void LoadData(NZDateTime dtDateFrom, NZDateTime dtDateTo, string keyFilter)
        {
            try
            {
                //== Start to search data.
                SalesSummaryController ctlInvent = new SalesSummaryController();

                //== 20091203 Add by Teerayt S.                

                //NZString yearMonth = GetLatestYearMonthInInvOnhand();

                //== 20091203 End Add by Teerayt S.


                //List<InventorySummaryViewDTO> dtoView = ctlInvent.LoadInventorySummary(yearMonth);
                //m_dtAllData = DTOUtility.ConvertListToDataTable(dtoView);

                m_dtAllData = ctlInvent.LoadSalesSummary(dtDateBegin.NZValue, dtDateEnd.NZValue);

                FindDataFromMemory(keyFilter);
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusiness(this, ex.Message);
            }
        }


        #endregion

        #region Form Event

        private void INV010_InventoryOnHandInquiry_Load(object sender, EventArgs e)
        {
            InitialScreen();
            InitialFormat();

            LoadData(this.dtDateBegin.NZValue, this.dtDateEnd.NZValue, txtFilter.Text.Trim());
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

        #endregion


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

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (Common.UserGroupShowFormatButton.ToUpper().Equals(Common.CurrentUserInfomation.GroupCode.NVL("").ToUpper()))
            {
                tsbDefaultSize.Visible = true;
                tsbSaveFormat.Visible = true;
            }

            SheetWidthController ctrl = new SheetWidthController();
            ctrl.SetSheetWidth(shtInventorySummary, this.ScreenCode);
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


            FormatUtil.SetDateFormat(dtDateBegin);
            FormatUtil.SetDateFormat(dtDateEnd);

        }

        private void fpInventorySummary_KeyDown(object sender, KeyEventArgs e)
        {
            CtrlUtil.FilterShortCut(e);
        }

    }
}
