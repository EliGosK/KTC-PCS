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
using System.Text;

namespace Rubik.SummaryData
{
    [Screen("SUM020", "Sales Summary", eShowAction.Normal, eScreenType.Screen, "Sales Summary")]
    public partial class SUM020_SalesSummary : CustomizeInquiryForm
    {
        #region Enum

        enum eColView
        {
            //HideRowNo,
            //HideCustomer,
            //HideItemCd,
            //HideShortName,
            //HideMatName,
            //HideMatSize,
            //HideWeight,

            RowNo,
            Customer,
            ItemCd,
            ShortName,

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

            StartBalanceMonth,
            Stock,
            Previous,
            CurrMonth,
            CurrMonth1,
            CurrMonth2,
            CurrMonth3,
            Later,

            StartBalanceDay,
            FirstMonthDay1,
            FirstMonthDay2,
            FirstMonthDay3,
            FirstMonthDay4,
            FirstMonthDay5,
            FirstMonthDay6,
            FirstMonthDay7,
            FirstMonthDay8,
            FirstMonthDay9,
            FirstMonthDay10,
            FirstMonthDay11,
            FirstMonthDay12,
            FirstMonthDay13,
            FirstMonthDay14,
            FirstMonthDay15,
            FirstMonthDay16,
            FirstMonthDay17,
            FirstMonthDay18,
            FirstMonthDay19,
            FirstMonthDay20,
            FirstMonthDay21,
            FirstMonthDay22,
            FirstMonthDay23,
            FirstMonthDay24,
            FirstMonthDay25,
            FirstMonthDay26,
            FirstMonthDay27,
            FirstMonthDay28,
            FirstMonthDay29,
            FirstMonthDay30,
            FirstMonthDay31,
            FirstMonthTotal,
            FirstMonthAmount,
            LastMonthDay1,
            LastMonthDay2,
            LastMonthDay3,
            LastMonthDay4,
            LastMonthDay5,
            LastMonthDay6,
            LastMonthDay7,
            LastMonthDay8,
            LastMonthDay9,
            LastMonthDay10,
            LastMonthDay11,
            LastMonthDay12,
            LastMonthDay13,
            LastMonthDay14,
            LastMonthDay15,
            LastMonthDay16,
            LastMonthDay17,
            LastMonthDay18,
            LastMonthDay19,
            LastMonthDay20,
            LastMonthDay21,
            LastMonthDay22,
            LastMonthDay23,
            LastMonthDay24,
            LastMonthDay25,
            LastMonthDay26,
            LastMonthDay27,
            LastMonthDay28,
            LastMonthDay29,
            LastMonthDay30,
            LastMonthDay31,
            LastMonthTotal,
            LastMonthAmount,

            THB,
            MatName,
            MatSize,
            Weight
        }

        //enum eColView
        //{
        //    //RowNo,
        //    //Customer,
        //    //ItemCd,
        //    //ShortName,

        //    //Header,
        //    //Rolling,
        //    //Cutting_I,
        //    //Cutting_E,
        //    //Plating_I,
        //    //Plating_E,
        //    //Heating_E,
        //    //Others,
        //    //QC,
        //    //QC_Hold,
        //    //Packing,
        //    //WIP,
        //    //FG,

        //    //MonthText,
        //    //Stock,
        //    //Previous,
        //    //Current,
        //    //Current_1,
        //    //Current_2,
        //    //Current_3,
        //    //Later,

        //    //ItemNo,
        //    //ItemName,
        //    //CustomerName,
        //    //ItemLevel,
        //    //Header,
        //    //Rolling,
        //    //Cutting_I,
        //    //Cutting_E,
        //    //Plating_I,
        //    //Plating_E,
        //    //Heating_E,
        //    //Others,
        //    //QC,
        //    //QC_Hold,
        //    //Packing,
        //    //WIP,
        //    //FG,
        //    //OrderQty,
        //    //RemainQty,
        //    //DeliveryQty
        //}

        #endregion

        #region Variable
        private ToolStripButton tsbSearch;
        private DataTable m_dtAllData;
        #endregion

        #region Constructor

        public SUM020_SalesSummary()
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
            //CtrlUtil.MappingDataFieldWithEnum(this.shtInventorySummary, typeof(eColView));

            //for (int i = 0; i < shtInventorySummary.Columns.Count; i++)
            //{
            //    CtrlUtil.SpreadSetColumnsLocked(shtInventorySummary, true, i);
            //}

            //CtrlUtil.SpreadUpdateColumnSorting(shtInventorySummary);

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
            LoadData(dtDateBegin.NZValue, this.txtFilter.Text);
        }



        private void LoadDefaultPeriod()
        {
            this.dtDateBegin.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            //this.dtDateEnd.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1).AddMonths(1).AddDays(-1);
        }

        private void FindDataFromMemory(string keyFilter)
        {
            DataTable dtView = m_dtAllData.Clone();

            if (keyFilter != string.Empty)
            {
                string filterString = FilterStringUtil.GetFilterstring(dtView, keyFilter);

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

            //RenameColumn(dtView, dtDateBegin.Value.Value);
            //fpInventorySummary.DataSource = dtView;
            fpInventorySummary.DataSource = RenameColumn(dtView, dtDateBegin.Value.Value);

            if (shtInventorySummary.Columns.Count == ((int)eColView.Weight) + 1)
                SetFormatData();
        }

        private DataTable RenameColumn(DataTable data, DateTime dtmYearMonth)
        {
            if (data == null)
                return null;

            DateTime dtmStartDate = new DateTime(dtmYearMonth.Year, dtmYearMonth.Month, 1);
            StringBuilder strEmptyDay = new StringBuilder(" ");

            data.Columns[(int)eColView.RowNo].ColumnName = "No.";
            data.Columns[(int)eColView.Customer].ColumnName = "Customer";
            data.Columns[(int)eColView.ItemCd].ColumnName = "M/N";
            data.Columns[(int)eColView.ShortName].ColumnName = "Part No";

            //Process
            data.Columns[(int)eColView.Header].ColumnName = "Header";
            data.Columns[(int)eColView.Rolling].ColumnName = "Rolling";
            data.Columns[(int)eColView.Cutting_I].ColumnName = "Cutting\n(KTC)";
            data.Columns[(int)eColView.Cutting_E].ColumnName = "Cutting\n(Sub)";
            data.Columns[(int)eColView.Plating_I].ColumnName = "Plating\n(KTC)";
            data.Columns[(int)eColView.Plating_E].ColumnName = "Plating\n(Sub)";
            data.Columns[(int)eColView.Heating_E].ColumnName = "Heat Treatment\n(Sub)";
            data.Columns[(int)eColView.Others].ColumnName = "Others";
            data.Columns[(int)eColView.QC].ColumnName = "QC";
            data.Columns[(int)eColView.QC_Hold].ColumnName = "QC Hold";
            data.Columns[(int)eColView.Packing].ColumnName = "Packing";
            data.Columns[(int)eColView.WIP].ColumnName = "WIP";
            data.Columns[(int)eColView.FG].ColumnName = "FG";

            //Month
            data.Columns[(int)eColView.StartBalanceMonth].ColumnName = " ";
            data.Columns[(int)eColView.Stock].ColumnName = "Stock";
            data.Columns[(int)eColView.Previous].ColumnName = "Previous";
            data.Columns[(int)eColView.CurrMonth].ColumnName = dtmStartDate.ToString("MMM");
            data.Columns[(int)eColView.CurrMonth1].ColumnName = dtmStartDate.AddMonths(1).ToString("MMM");
            data.Columns[(int)eColView.CurrMonth2].ColumnName = dtmStartDate.AddMonths(2).ToString("MMM");
            data.Columns[(int)eColView.CurrMonth3].ColumnName = dtmStartDate.AddMonths(3).ToString("MMM");
            data.Columns[(int)eColView.Later].ColumnName = "Later";

            //Day
            data.Columns[(int)eColView.StartBalanceDay].ColumnName = "This Month";

            int iTotalColOfMonth = 31;
            int iRemainCol = 0;
            int iTotalDayOfMonth = 0;
            int iCurrColumn = 0;
            DateTime dtmCurrentDate = dtmStartDate;
            DateTime dtmNextMonth = dtmStartDate.AddMonths(1);

            #region First Month

            dtmCurrentDate = dtmStartDate;
            iTotalDayOfMonth = dtmNextMonth.AddDays(-1).Day;
            iCurrColumn = ((int)eColView.StartBalanceDay) + 1;
            iRemainCol = iTotalColOfMonth - iTotalDayOfMonth;

            data.Columns[(int)eColView.FirstMonthTotal].ColumnName = "Total\n(" + dtmCurrentDate.ToString("MMM") + ")";
            data.Columns[(int)eColView.FirstMonthAmount].ColumnName = "Amount\n(" + dtmCurrentDate.ToString("MMM") + ")";

            for (int i = 0; i < iTotalDayOfMonth; i++)
            {
                data.Columns[iCurrColumn].ColumnName = dtmCurrentDate.ToString("dd-MMM");
                dtmCurrentDate = dtmCurrentDate.AddDays(1);
                iCurrColumn = iCurrColumn + 1;
            }
            for (int i = 0; i < iRemainCol; i++)
            {
                data.Columns[iCurrColumn].ColumnName = strEmptyDay.Append(" ").ToString();
                iCurrColumn = iCurrColumn + 1;
            }

            #endregion


            #region Last Month

            dtmCurrentDate = dtmNextMonth;
            dtmNextMonth = dtmNextMonth.AddMonths(1);
            iTotalDayOfMonth = dtmNextMonth.AddDays(-1).Day;
            iCurrColumn = ((int)eColView.FirstMonthAmount) + 1;
            iRemainCol = iTotalColOfMonth - iTotalDayOfMonth;

            data.Columns[(int)eColView.LastMonthTotal].ColumnName = "Total\n(" + dtmCurrentDate.ToString("MMM") + ")";
            data.Columns[(int)eColView.LastMonthAmount].ColumnName = "Amount\n(" + dtmCurrentDate.ToString("MMM") + ")";

            for (int i = 0; i < iTotalDayOfMonth; i++)
            {
                data.Columns[iCurrColumn].ColumnName = dtmCurrentDate.ToString("dd-MMM");
                dtmCurrentDate = dtmCurrentDate.AddDays(1);
                iCurrColumn = iCurrColumn + 1;
            }
            for (int i = 0; i < iRemainCol; i++)
            {
                data.Columns[iCurrColumn].ColumnName = strEmptyDay.Append(" ").ToString();
                iCurrColumn = iCurrColumn + 1;
            }

            #endregion

            //Mat
            data.Columns[(int)eColView.THB].ColumnName = "Unit Price\n(THB)";
            data.Columns[(int)eColView.MatName].ColumnName = "Mat. Name";
            data.Columns[(int)eColView.MatSize].ColumnName = "Mat. Size";
            data.Columns[(int)eColView.Weight].ColumnName = "Weight\n(g)";

            return data;
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


        private void LoadData(NZDateTime dtDateFrom, string keyFilter)
        {
            try
            {
                if (dtDateFrom.IsNull)
                {
                    shtInventorySummary.RowCount = 0;
                    MessageDialog.ShowBusiness(this, EVOFramework.Message.LoadMessage(TKPMessages.eValidate.VLM0224.ToString()));
                    return;
                }

                //== Start to search data.
                SalesSummaryController ctlInvent = new SalesSummaryController();

                //== 20091203 Add by Teerayt S.                

                //NZString yearMonth = GetLatestYearMonthInInvOnhand();

                //== 20091203 End Add by Teerayt S.


                //List<InventorySummaryViewDTO> dtoView = ctlInvent.LoadInventorySummary(yearMonth);
                //m_dtAllData = DTOUtility.ConvertListToDataTable(dtoView);

                m_dtAllData = ctlInvent.LoadSalesSummary(dtDateBegin.NZValue);

                FindDataFromMemory(keyFilter);

            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusiness(this, ex.Message);
            }
        }

        private void SetFormatData()
        {
            //Set Format            
            FormatUtil.SetNumberFormat(shtInventorySummary.Columns[(int)eColView.RowNo], FormatUtil.eNumberFormat.Qty_PCS);
            FormatUtil.SetNumberFormat(shtInventorySummary.Columns[(int)eColView.ItemCd], FormatUtil.eNumberFormat.MasterNo);

            FormatUtil.SetNumberFormat(shtInventorySummary.Columns[(int)eColView.Header], FormatUtil.eNumberFormat.Qty_PCS);
            FormatUtil.SetNumberFormat(shtInventorySummary.Columns[(int)eColView.Rolling], FormatUtil.eNumberFormat.Qty_PCS);
            FormatUtil.SetNumberFormat(shtInventorySummary.Columns[(int)eColView.Cutting_I], FormatUtil.eNumberFormat.Qty_PCS);
            FormatUtil.SetNumberFormat(shtInventorySummary.Columns[(int)eColView.Cutting_E], FormatUtil.eNumberFormat.Qty_PCS);
            FormatUtil.SetNumberFormat(shtInventorySummary.Columns[(int)eColView.Plating_I], FormatUtil.eNumberFormat.Qty_PCS);
            FormatUtil.SetNumberFormat(shtInventorySummary.Columns[(int)eColView.Plating_E], FormatUtil.eNumberFormat.Qty_PCS);
            FormatUtil.SetNumberFormat(shtInventorySummary.Columns[(int)eColView.Heating_E], FormatUtil.eNumberFormat.Qty_PCS);
            FormatUtil.SetNumberFormat(shtInventorySummary.Columns[(int)eColView.Others], FormatUtil.eNumberFormat.Qty_PCS);
            FormatUtil.SetNumberFormat(shtInventorySummary.Columns[(int)eColView.QC], FormatUtil.eNumberFormat.Qty_PCS);
            FormatUtil.SetNumberFormat(shtInventorySummary.Columns[(int)eColView.QC_Hold], FormatUtil.eNumberFormat.Qty_PCS);
            FormatUtil.SetNumberFormat(shtInventorySummary.Columns[(int)eColView.Packing], FormatUtil.eNumberFormat.Qty_PCS);
            FormatUtil.SetNumberFormat(shtInventorySummary.Columns[(int)eColView.WIP], FormatUtil.eNumberFormat.Qty_PCS);
            FormatUtil.SetNumberFormat(shtInventorySummary.Columns[(int)eColView.FG], FormatUtil.eNumberFormat.Qty_PCS);

            FormatUtil.SetNumberFormat(shtInventorySummary.Columns[(int)eColView.Stock], FormatUtil.eNumberFormat.Qty_PCS);
            FormatUtil.SetNumberFormat(shtInventorySummary.Columns[(int)eColView.Previous], FormatUtil.eNumberFormat.Qty_PCS);
            FormatUtil.SetNumberFormat(shtInventorySummary.Columns[(int)eColView.CurrMonth], FormatUtil.eNumberFormat.Qty_PCS);
            FormatUtil.SetNumberFormat(shtInventorySummary.Columns[(int)eColView.CurrMonth1], FormatUtil.eNumberFormat.Qty_PCS);
            FormatUtil.SetNumberFormat(shtInventorySummary.Columns[(int)eColView.CurrMonth2], FormatUtil.eNumberFormat.Qty_PCS);
            FormatUtil.SetNumberFormat(shtInventorySummary.Columns[(int)eColView.CurrMonth3], FormatUtil.eNumberFormat.Qty_PCS);
            FormatUtil.SetNumberFormat(shtInventorySummary.Columns[(int)eColView.Later], FormatUtil.eNumberFormat.Qty_PCS);

            FormatUtil.SetNumberFormat(shtInventorySummary.Columns[(int)eColView.FirstMonthDay1], FormatUtil.eNumberFormat.Qty_PCS);
            FormatUtil.SetNumberFormat(shtInventorySummary.Columns[(int)eColView.FirstMonthDay2], FormatUtil.eNumberFormat.Qty_PCS);
            FormatUtil.SetNumberFormat(shtInventorySummary.Columns[(int)eColView.FirstMonthDay3], FormatUtil.eNumberFormat.Qty_PCS);
            FormatUtil.SetNumberFormat(shtInventorySummary.Columns[(int)eColView.FirstMonthDay4], FormatUtil.eNumberFormat.Qty_PCS);
            FormatUtil.SetNumberFormat(shtInventorySummary.Columns[(int)eColView.FirstMonthDay5], FormatUtil.eNumberFormat.Qty_PCS);
            FormatUtil.SetNumberFormat(shtInventorySummary.Columns[(int)eColView.FirstMonthDay6], FormatUtil.eNumberFormat.Qty_PCS);
            FormatUtil.SetNumberFormat(shtInventorySummary.Columns[(int)eColView.FirstMonthDay7], FormatUtil.eNumberFormat.Qty_PCS);
            FormatUtil.SetNumberFormat(shtInventorySummary.Columns[(int)eColView.FirstMonthDay8], FormatUtil.eNumberFormat.Qty_PCS);
            FormatUtil.SetNumberFormat(shtInventorySummary.Columns[(int)eColView.FirstMonthDay9], FormatUtil.eNumberFormat.Qty_PCS);
            FormatUtil.SetNumberFormat(shtInventorySummary.Columns[(int)eColView.FirstMonthDay10], FormatUtil.eNumberFormat.Qty_PCS);
            FormatUtil.SetNumberFormat(shtInventorySummary.Columns[(int)eColView.FirstMonthDay11], FormatUtil.eNumberFormat.Qty_PCS);
            FormatUtil.SetNumberFormat(shtInventorySummary.Columns[(int)eColView.FirstMonthDay12], FormatUtil.eNumberFormat.Qty_PCS);
            FormatUtil.SetNumberFormat(shtInventorySummary.Columns[(int)eColView.FirstMonthDay13], FormatUtil.eNumberFormat.Qty_PCS);
            FormatUtil.SetNumberFormat(shtInventorySummary.Columns[(int)eColView.FirstMonthDay14], FormatUtil.eNumberFormat.Qty_PCS);
            FormatUtil.SetNumberFormat(shtInventorySummary.Columns[(int)eColView.FirstMonthDay15], FormatUtil.eNumberFormat.Qty_PCS);
            FormatUtil.SetNumberFormat(shtInventorySummary.Columns[(int)eColView.FirstMonthDay16], FormatUtil.eNumberFormat.Qty_PCS);
            FormatUtil.SetNumberFormat(shtInventorySummary.Columns[(int)eColView.FirstMonthDay17], FormatUtil.eNumberFormat.Qty_PCS);
            FormatUtil.SetNumberFormat(shtInventorySummary.Columns[(int)eColView.FirstMonthDay18], FormatUtil.eNumberFormat.Qty_PCS);
            FormatUtil.SetNumberFormat(shtInventorySummary.Columns[(int)eColView.FirstMonthDay19], FormatUtil.eNumberFormat.Qty_PCS);
            FormatUtil.SetNumberFormat(shtInventorySummary.Columns[(int)eColView.FirstMonthDay20], FormatUtil.eNumberFormat.Qty_PCS);
            FormatUtil.SetNumberFormat(shtInventorySummary.Columns[(int)eColView.FirstMonthDay21], FormatUtil.eNumberFormat.Qty_PCS);
            FormatUtil.SetNumberFormat(shtInventorySummary.Columns[(int)eColView.FirstMonthDay22], FormatUtil.eNumberFormat.Qty_PCS);
            FormatUtil.SetNumberFormat(shtInventorySummary.Columns[(int)eColView.FirstMonthDay23], FormatUtil.eNumberFormat.Qty_PCS);
            FormatUtil.SetNumberFormat(shtInventorySummary.Columns[(int)eColView.FirstMonthDay24], FormatUtil.eNumberFormat.Qty_PCS);
            FormatUtil.SetNumberFormat(shtInventorySummary.Columns[(int)eColView.FirstMonthDay25], FormatUtil.eNumberFormat.Qty_PCS);
            FormatUtil.SetNumberFormat(shtInventorySummary.Columns[(int)eColView.FirstMonthDay26], FormatUtil.eNumberFormat.Qty_PCS);
            FormatUtil.SetNumberFormat(shtInventorySummary.Columns[(int)eColView.FirstMonthDay27], FormatUtil.eNumberFormat.Qty_PCS);
            FormatUtil.SetNumberFormat(shtInventorySummary.Columns[(int)eColView.FirstMonthDay28], FormatUtil.eNumberFormat.Qty_PCS);
            FormatUtil.SetNumberFormat(shtInventorySummary.Columns[(int)eColView.FirstMonthDay29], FormatUtil.eNumberFormat.Qty_PCS);
            FormatUtil.SetNumberFormat(shtInventorySummary.Columns[(int)eColView.FirstMonthDay30], FormatUtil.eNumberFormat.Qty_PCS);
            FormatUtil.SetNumberFormat(shtInventorySummary.Columns[(int)eColView.FirstMonthDay31], FormatUtil.eNumberFormat.Qty_PCS);
            FormatUtil.SetNumberFormat(shtInventorySummary.Columns[(int)eColView.FirstMonthTotal], FormatUtil.eNumberFormat.Qty_PCS);
            FormatUtil.SetNumberFormat(shtInventorySummary.Columns[(int)eColView.FirstMonthAmount], FormatUtil.eNumberFormat.Amount_THB);
            FormatUtil.SetNumberFormat(shtInventorySummary.Columns[(int)eColView.LastMonthDay1], FormatUtil.eNumberFormat.Qty_PCS);
            FormatUtil.SetNumberFormat(shtInventorySummary.Columns[(int)eColView.LastMonthDay2], FormatUtil.eNumberFormat.Qty_PCS);
            FormatUtil.SetNumberFormat(shtInventorySummary.Columns[(int)eColView.LastMonthDay3], FormatUtil.eNumberFormat.Qty_PCS);
            FormatUtil.SetNumberFormat(shtInventorySummary.Columns[(int)eColView.LastMonthDay4], FormatUtil.eNumberFormat.Qty_PCS);
            FormatUtil.SetNumberFormat(shtInventorySummary.Columns[(int)eColView.LastMonthDay5], FormatUtil.eNumberFormat.Qty_PCS);
            FormatUtil.SetNumberFormat(shtInventorySummary.Columns[(int)eColView.LastMonthDay6], FormatUtil.eNumberFormat.Qty_PCS);
            FormatUtil.SetNumberFormat(shtInventorySummary.Columns[(int)eColView.LastMonthDay7], FormatUtil.eNumberFormat.Qty_PCS);
            FormatUtil.SetNumberFormat(shtInventorySummary.Columns[(int)eColView.LastMonthDay8], FormatUtil.eNumberFormat.Qty_PCS);
            FormatUtil.SetNumberFormat(shtInventorySummary.Columns[(int)eColView.LastMonthDay9], FormatUtil.eNumberFormat.Qty_PCS);
            FormatUtil.SetNumberFormat(shtInventorySummary.Columns[(int)eColView.LastMonthDay10], FormatUtil.eNumberFormat.Qty_PCS);
            FormatUtil.SetNumberFormat(shtInventorySummary.Columns[(int)eColView.LastMonthDay11], FormatUtil.eNumberFormat.Qty_PCS);
            FormatUtil.SetNumberFormat(shtInventorySummary.Columns[(int)eColView.LastMonthDay12], FormatUtil.eNumberFormat.Qty_PCS);
            FormatUtil.SetNumberFormat(shtInventorySummary.Columns[(int)eColView.LastMonthDay13], FormatUtil.eNumberFormat.Qty_PCS);
            FormatUtil.SetNumberFormat(shtInventorySummary.Columns[(int)eColView.LastMonthDay14], FormatUtil.eNumberFormat.Qty_PCS);
            FormatUtil.SetNumberFormat(shtInventorySummary.Columns[(int)eColView.LastMonthDay15], FormatUtil.eNumberFormat.Qty_PCS);
            FormatUtil.SetNumberFormat(shtInventorySummary.Columns[(int)eColView.LastMonthDay16], FormatUtil.eNumberFormat.Qty_PCS);
            FormatUtil.SetNumberFormat(shtInventorySummary.Columns[(int)eColView.LastMonthDay17], FormatUtil.eNumberFormat.Qty_PCS);
            FormatUtil.SetNumberFormat(shtInventorySummary.Columns[(int)eColView.LastMonthDay18], FormatUtil.eNumberFormat.Qty_PCS);
            FormatUtil.SetNumberFormat(shtInventorySummary.Columns[(int)eColView.LastMonthDay19], FormatUtil.eNumberFormat.Qty_PCS);
            FormatUtil.SetNumberFormat(shtInventorySummary.Columns[(int)eColView.LastMonthDay20], FormatUtil.eNumberFormat.Qty_PCS);
            FormatUtil.SetNumberFormat(shtInventorySummary.Columns[(int)eColView.LastMonthDay21], FormatUtil.eNumberFormat.Qty_PCS);
            FormatUtil.SetNumberFormat(shtInventorySummary.Columns[(int)eColView.LastMonthDay22], FormatUtil.eNumberFormat.Qty_PCS);
            FormatUtil.SetNumberFormat(shtInventorySummary.Columns[(int)eColView.LastMonthDay23], FormatUtil.eNumberFormat.Qty_PCS);
            FormatUtil.SetNumberFormat(shtInventorySummary.Columns[(int)eColView.LastMonthDay24], FormatUtil.eNumberFormat.Qty_PCS);
            FormatUtil.SetNumberFormat(shtInventorySummary.Columns[(int)eColView.LastMonthDay25], FormatUtil.eNumberFormat.Qty_PCS);
            FormatUtil.SetNumberFormat(shtInventorySummary.Columns[(int)eColView.LastMonthDay26], FormatUtil.eNumberFormat.Qty_PCS);
            FormatUtil.SetNumberFormat(shtInventorySummary.Columns[(int)eColView.LastMonthDay27], FormatUtil.eNumberFormat.Qty_PCS);
            FormatUtil.SetNumberFormat(shtInventorySummary.Columns[(int)eColView.LastMonthDay28], FormatUtil.eNumberFormat.Qty_PCS);
            FormatUtil.SetNumberFormat(shtInventorySummary.Columns[(int)eColView.LastMonthDay29], FormatUtil.eNumberFormat.Qty_PCS);
            FormatUtil.SetNumberFormat(shtInventorySummary.Columns[(int)eColView.LastMonthDay30], FormatUtil.eNumberFormat.Qty_PCS);
            FormatUtil.SetNumberFormat(shtInventorySummary.Columns[(int)eColView.LastMonthDay31], FormatUtil.eNumberFormat.Qty_PCS);
            FormatUtil.SetNumberFormat(shtInventorySummary.Columns[(int)eColView.LastMonthTotal], FormatUtil.eNumberFormat.Qty_PCS);
            FormatUtil.SetNumberFormat(shtInventorySummary.Columns[(int)eColView.LastMonthAmount], FormatUtil.eNumberFormat.Amount_THB);
            FormatUtil.SetNumberFormat(shtInventorySummary.Columns[(int)eColView.THB], FormatUtil.eNumberFormat.UnitPrice);
            FormatUtil.SetNumberFormat(shtInventorySummary.Columns[(int)eColView.Weight], FormatUtil.eNumberFormat.Qty_Gram);

            //set back ground format   
            bool bNormalColor = false;
            for (int i = 0; i < shtInventorySummary.RowCount; i++)
            {
                if (i % 3 == 0)
                    bNormalColor = !bNormalColor;

                if (bNormalColor)
                    shtInventorySummary.Rows[i].BackColor = Common.COLOR_NORMAL_BG;
                else
                    shtInventorySummary.Rows[i].BackColor = Common.COLOR_ALTERNATE_BG;

                string strStartBalanceMonth = shtInventorySummary.Cells[i, (int)eColView.StartBalanceMonth].Value.ToString();
                //string str = shtInventorySummary.GetValue(i, (int)eColView.StartBalanceMonth) != null ? shtInventorySummary.GetValue(i, (int)eColView.StartBalanceMonth).ToString().Trim() : "";
                if (strStartBalanceMonth.Equals("WIP Balance") || strStartBalanceMonth.Equals("FG Balance"))
                {
                    for (int j = (int)eColView.CurrMonth; j <= (int)eColView.Later; j++)
                    {
                        string strValue = shtInventorySummary.Cells[i, j].Value!= null?shtInventorySummary.Cells[i, j].Value.ToString():"";
                        decimal value;
                        bool b = decimal.TryParse(strValue, out value);
                        if (b)
                        {
                            if (value < 0)
                            {
                                if (j != (int)eColView.CurrMonth)
                                    shtInventorySummary.Cells[i, j].BackColor = Common.COLOR_MINUS_NEXT_MONTH;
                                else
                                    shtInventorySummary.Cells[i, j].BackColor = Common.COLOR_MINUS_CURRENT_MONTH;
                            }
                            else
                            {
                                shtInventorySummary.Cells[i, j].BackColor = shtInventorySummary.Rows[i].BackColor;
                            }
                        }
                        else
                        {
                            shtInventorySummary.Cells[i, j].BackColor = shtInventorySummary.Rows[i].BackColor;
                        }
                    }
                }
            }

            //Resize Column
            SheetWidthController ctrl = new SheetWidthController();
            ctrl.SetSheetWidth(shtInventorySummary, this.ScreenCode);

            shtInventorySummary.FrozenColumnCount = ((int)eColView.ShortName) + 1;
        }

        #endregion

        #region Form Event

        private void INV010_InventoryOnHandInquiry_Load(object sender, EventArgs e)
        {
            InitialScreen();
            InitialFormat();

            LoadData(this.dtDateBegin.NZValue, txtFilter.Text.Trim());

            //if (shtInventorySummary.ColumnCount > ((int)eColView.HideWeight + 1)) 
            //{
            //    shtInventorySummary.Columns[(int)eColView.HideRowNo].Visible = false;
            //    shtInventorySummary.Columns[(int)eColView.HideCustomer].Visible = false;
            //    shtInventorySummary.Columns[(int)eColView.HideItemCd].Visible = false;
            //    shtInventorySummary.Columns[(int)eColView.HideShortName].Visible = false;
            //    shtInventorySummary.Columns[(int)eColView.HideMatName].Visible = false;
            //    shtInventorySummary.Columns[(int)eColView.HideMatSize].Visible = false;
            //    shtInventorySummary.Columns[(int)eColView.HideWeight].Visible = false;
            //}
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
            //FormatUtil.SetNumberFormat(this.shtInventorySummary.Columns[(int)eColView.Header], FormatUtil.eNumberFormat.Qty_PCS);
            //FormatUtil.SetNumberFormat(this.shtInventorySummary.Columns[(int)eColView.Rolling], FormatUtil.eNumberFormat.Qty_PCS);
            //FormatUtil.SetNumberFormat(this.shtInventorySummary.Columns[(int)eColView.Cutting_I], FormatUtil.eNumberFormat.Qty_PCS);
            //FormatUtil.SetNumberFormat(this.shtInventorySummary.Columns[(int)eColView.Cutting_E], FormatUtil.eNumberFormat.Qty_PCS);
            //FormatUtil.SetNumberFormat(this.shtInventorySummary.Columns[(int)eColView.Plating_I], FormatUtil.eNumberFormat.Qty_PCS);
            //FormatUtil.SetNumberFormat(this.shtInventorySummary.Columns[(int)eColView.Plating_E], FormatUtil.eNumberFormat.Qty_PCS);
            //FormatUtil.SetNumberFormat(this.shtInventorySummary.Columns[(int)eColView.Heating_E], FormatUtil.eNumberFormat.Qty_PCS);
            //FormatUtil.SetNumberFormat(this.shtInventorySummary.Columns[(int)eColView.Others], FormatUtil.eNumberFormat.Qty_PCS);
            //FormatUtil.SetNumberFormat(this.shtInventorySummary.Columns[(int)eColView.QC], FormatUtil.eNumberFormat.Qty_PCS);
            //FormatUtil.SetNumberFormat(this.shtInventorySummary.Columns[(int)eColView.QC_Hold], FormatUtil.eNumberFormat.Qty_PCS);
            //FormatUtil.SetNumberFormat(this.shtInventorySummary.Columns[(int)eColView.Packing], FormatUtil.eNumberFormat.Qty_PCS);
            //FormatUtil.SetNumberFormat(this.shtInventorySummary.Columns[(int)eColView.WIP], FormatUtil.eNumberFormat.Qty_PCS);
            //FormatUtil.SetNumberFormat(this.shtInventorySummary.Columns[(int)eColView.FG], FormatUtil.eNumberFormat.Qty_PCS);

            //FormatUtil.SetNumberFormat(this.shtInventorySummary.Columns[(int)eColView.ItemNo], FormatUtil.eNumberFormat.MasterNo);


            //FormatUtil.SetDateFormat(dtDateBegin);
            //FormatUtil.SetDateFormat(dtDateEnd);

        }

        private void fpInventorySummary_KeyDown(object sender, KeyEventArgs e)
        {
            CtrlUtil.FilterShortCut(e);
        }

    }
}
