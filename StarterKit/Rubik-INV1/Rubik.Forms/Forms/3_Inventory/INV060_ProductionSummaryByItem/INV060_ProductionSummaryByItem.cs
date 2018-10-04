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
using Microsoft.Office.Interop.Owc11;

namespace Rubik.Inventory
{
    [Screen("INV060", "Production Summary By Item", eShowAction.Normal, eScreenType.Screen, "Production Summary By Item")]
    public partial class INV060_ProductionSummaryByItem : CustomizeInquiryForm
    {
        #region Enum

        enum eTableColumn
        {
            RunNo,
            MasterNo,
            PartNo,
            CustName,
            Process,
            Day,
            Month,
            Year,
            Qty,
            ItemLevel
        }

        #endregion

        #region Variable
        private ToolStripButton tsbSearch;
        private ToolStripButton tsbExportCost;


        private int m_iWarningRecords = 10000;
        private int m_iErrorRecords = 60000;
        #endregion

        #region Constructor

        public INV060_ProductionSummaryByItem()
        {
            InitializeComponent();
        }

        #endregion

        #region Overriden Method

        public override void OnExport()
        {
            base.OnExport();
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

            tsbExport.Visible = false;

        }



        #endregion

        #region Form Event



        private void INV010_InventoryOnHandInquiry_Load(object sender, EventArgs e)
        {
            InitialScreen();

            SysConfigBIZ sysBiz = new SysConfigBIZ();
            SysConfigDTO dtoWarningRecords = sysBiz.LoadByPK(DataDefine.eSYSTEM_CONFIG.INV060.SYS_GROUP_ID
               , (NZString)DataDefine.eSYSTEM_CONFIG.INV060.SYS_KEY.WARNING_RECORDS.ToString());
            SysConfigDTO dtoErrorRecords = sysBiz.LoadByPK(DataDefine.eSYSTEM_CONFIG.INV060.SYS_GROUP_ID
               , (NZString)DataDefine.eSYSTEM_CONFIG.INV060.SYS_KEY.ERROR_RECORDS.ToString());

            if (dtoWarningRecords != null && dtoWarningRecords.CHAR_DATA.NVL("") != "")
            {
                decimal iRecords = 0;

                if (decimal.TryParse(dtoWarningRecords.CHAR_DATA.NVL("10000"), out iRecords))
                {
                    m_iWarningRecords = (int)iRecords;
                }
            }

            if (dtoErrorRecords != null && dtoErrorRecords.CHAR_DATA.NVL("") != "")
            {
                decimal iRecords = 0;

                if (decimal.TryParse(dtoErrorRecords.CHAR_DATA.NVL("60000"), out iRecords))
                {
                    m_iErrorRecords = (int)iRecords;
                }
            }



            this.dtPeriodBegin.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            this.dtPeriodEnd.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1).AddMonths(1).AddDays(-1);

            QueryData();

        }

        #endregion

        #region Control Event



        #endregion

        #region Spread Event



        #endregion

        private void btnQuery_Click(object sender, EventArgs e)
        {
            QueryData();
        }


        private void ResizeDetailFieldSets(PivotField fSet, Int32 value)
        {
            fSet.DetailAutoFit = false;
            fSet.DetailWidth = value;
        }

        private void ResizeGroupFieldSets(PivotField fSet, Int32 value)
        {
            fSet.GroupedAutoFit = false;
            fSet.GroupedWidth = value;
        }

        private void SetFontFieldSets(PivotFont pFont, string strFont, Int32 iSize, object oColor, bool blBold)
        {
            pFont.Name = strFont == String.Empty ? "Arial" : strFont;
            pFont.Size = iSize == 0 ? 10 : iSize;
            pFont.Color = oColor == null ? "Black" : oColor;
            pFont.Bold = blBold;
        }


        private void QueryData()
        {
            try
            {
                //QueryLunchBiz biz = new QueryLunchBiz();
                //QueryLunchDTO a = new QueryLunchDTO();
                //a.SQLCommand = "exec __SelectPivot".ToNZString();


                //DataSet ds = biz.ExecuteSQLCommand(a);

                //pivotMPA.DataSource


                // this solution call connection string from web service (fast but can see user+wpd)
                //pivotMPA.ConnectionString = RptServ.GetAdoConnectionString();
                //pivotMPA.CommandText = Command;
                // this solution call data from web service (slow but secure)
                //string strResult = RptServ.LoadPivotData(Command);
                //if (strResult.StartsWith("Error"))
                //{
                //    msgBox msgBox = new msgBox();
                //    msgBox.MessageNo = "10011";
                //    msgBox.MessageErr = strResult;
                //    msgBox.ShowDialog();
                //}
                //else
                //{
                //XmlDocument oxmldoc = new XmlDocument();
                //oxmldoc.LoadXml(strResult);
                //oxmldoc.Save(strFileXML);
                //pivotMPA.ConnectionString = "Provider=MSPersist";
                //pivotMPA.CommandText = strFileXML;


                ReportBIZ biz = new ReportBIZ();
                ReportCriteriaDTO.INV060 cri = new ReportCriteriaDTO.INV060();
                cri.DateFrom = dtPeriodBegin.Value.Value;
                cri.DateTo = dtPeriodEnd.Value.Value;

                DataSet dsData = biz.LoadINV060_ProductionSummaryByItem(cri);

                if (dsData != null && dsData.Tables.Count > 0)
                {
                    if (dsData.Tables[0].Rows.Count > m_iErrorRecords)
                    {
                        //Message . show "Error"
                        MessageDialog.ShowBusiness(this, EVOFramework.Message.LoadMessage(TKPMessages.eValidate.VLM0206.ToString(), new object[] { m_iErrorRecords }));
                        return;
                    }

                    if (dsData.Tables[0].Rows.Count > m_iWarningRecords)
                    {
                        MessageDialogResult dr = MessageDialog.ShowConfirmation(this, EVOFramework.Message.LoadMessage(TKPMessages.eConfirm.CFM0011.ToString(), new object[] { m_iWarningRecords }), MessageDialogButtons.YesNo);
                        if (dr != MessageDialogResult.Yes)
                        {
                            return;
                        }
                    }

                }
                else
                {
                    return;
                }



                string strDateFrom = dtPeriodBegin.Value.GetValueOrDefault().ToString("yyyyMMdd");
                string strDateTo = dtPeriodEnd.Value.GetValueOrDefault().ToString("yyyyMMdd");


                pivotMPA.ConnectionString = Common.CurrentDatabase.OleDbConnectionString;


                pivotMPA.CommandText = string.Format("exec S_INV060_ProductionSummaryByItem @pDtm_DateFrom='{0}', @pDtm_DateTo='{1}' ", strDateFrom, strDateTo);
                //pivotMPA.CommandText = "select * from __ProductionSummary2";

                PivotView pView = pivotMPA.ActiveView;
                PivotFieldSets fSets = pivotMPA.ActiveView.FieldSets;



                // Add Category to the Row axis and Item to the Column axis
                // Data Row
                pView.RowAxis.InsertFieldSet(fSets[eTableColumn.Day.ToString()], 0, true);
                //pView.RowAxis.InsertFieldSet(fSets[eTableColumn.yyyymm.ToString()], 0, true);
                //pView.RowAxis.InsertFieldSet(fSets[eTableColumn.yyyy.ToString()], 0, true);
                pView.RowAxis.InsertFieldSet(fSets[eTableColumn.CustName.ToString()], 0, true);
                pView.RowAxis.InsertFieldSet(fSets[eTableColumn.PartNo.ToString()], 0, true);
                pView.RowAxis.InsertFieldSet(fSets[eTableColumn.MasterNo.ToString()], 0, true);




                // remove subtotal of empFullName
                //pView.RowAxis.FieldSets[eTableColumn.EmpFullName.ToString()].Fields[eTableColumn.EmpFullName.ToString()].set_Subtotals(0, false);

                // hidden detail
                pView.RowAxis.FieldSets[eTableColumn.Day.ToString()].Fields[eTableColumn.Day.ToString()].Expanded = false;
                //pView.RowAxis.FieldSets[eTableColumn.yyyymm.ToString()].Fields[eTableColumn.yyyymm.ToString()].Expanded = false;
                //pView.RowAxis.FieldSets[eTableColumn.yyyy.ToString()].Fields[eTableColumn.yyyy.ToString()].Expanded = false;
                pView.RowAxis.FieldSets[eTableColumn.CustName.ToString()].Fields[eTableColumn.CustName.ToString()].Expanded = false;
                pView.RowAxis.FieldSets[eTableColumn.PartNo.ToString()].Fields[eTableColumn.PartNo.ToString()].Expanded = false;
                pView.RowAxis.FieldSets[eTableColumn.MasterNo.ToString()].Fields[eTableColumn.MasterNo.ToString()].Expanded = false;

                // set size
                //ResizeGroupFieldSets(pView.RowAxis.FieldSets[eTableColumn.EmpID.ToString()].Fields[eTableColumn.EmpID.ToString()], 62);
                //ResizeGroupFieldSets(pView.RowAxis.FieldSets[eTableColumn.EmpFullName.ToString()].Fields[eTableColumn.EmpFullName.ToString()], 80);

                // set font and back color
                SetFontFieldSets(pView.RowAxis.FieldSets[eTableColumn.Day.ToString()].Fields[eTableColumn.Day.ToString()].SubtotalFont, String.Empty, 0, "Blue", false);
                pView.RowAxis.FieldSets[eTableColumn.Day.ToString()].Fields[eTableColumn.Day.ToString()].SubtotalBackColor = "#C0FFC0";
                //SetFontFieldSets(pView.RowAxis.FieldSets[eTableColumn.yyyymm.ToString()].Fields[eTableColumn.yyyymm.ToString()].SubtotalFont, String.Empty, 0, "Blue", false);
                //pView.RowAxis.FieldSets[eTableColumn.yyyymm.ToString()].Fields[eTableColumn.yyyymm.ToString()].SubtotalBackColor = "#C0FFC0";
                //SetFontFieldSets(pView.RowAxis.FieldSets[eTableColumn.yyyy.ToString()].Fields[eTableColumn.yyyy.ToString()].SubtotalFont, String.Empty, 0, "Blue", false);
                //pView.RowAxis.FieldSets[eTableColumn.yyyy.ToString()].Fields[eTableColumn.yyyy.ToString()].SubtotalBackColor = "#C0FFC0";
                SetFontFieldSets(pView.RowAxis.FieldSets[eTableColumn.CustName.ToString()].Fields[eTableColumn.CustName.ToString()].SubtotalFont, String.Empty, 0, "Blue", false);
                pView.RowAxis.FieldSets[eTableColumn.CustName.ToString()].Fields[eTableColumn.CustName.ToString()].SubtotalBackColor = "#C0FFC0";
                SetFontFieldSets(pView.RowAxis.FieldSets[eTableColumn.PartNo.ToString()].Fields[eTableColumn.PartNo.ToString()].SubtotalFont, String.Empty, 0, "Blue", false);
                pView.RowAxis.FieldSets[eTableColumn.PartNo.ToString()].Fields[eTableColumn.PartNo.ToString()].SubtotalBackColor = "#C0FFC0";
                SetFontFieldSets(pView.RowAxis.FieldSets[eTableColumn.MasterNo.ToString()].Fields[eTableColumn.MasterNo.ToString()].SubtotalFont, String.Empty, 0, "Blue", false);
                pView.RowAxis.FieldSets[eTableColumn.MasterNo.ToString()].Fields[eTableColumn.MasterNo.ToString()].SubtotalBackColor = "#C0FFC0";

                // Data Column
                pView.ColumnAxis.InsertFieldSet(fSets[eTableColumn.Process.ToString()], 0, true);

                // set font and back color
                SetFontFieldSets(pView.ColumnAxis.FieldSets[eTableColumn.Process.ToString()].Fields[eTableColumn.Process.ToString()].SubtotalFont, String.Empty, 0, "Blue", false);
                pView.ColumnAxis.FieldSets[eTableColumn.Process.ToString()].Fields[eTableColumn.Process.ToString()].SubtotalBackColor = "#C0FFC0";

                // Group filter
                pView.FilterAxis.InsertFieldSet(fSets[eTableColumn.Month.ToString()], 0, true);
                SetFontFieldSets(pView.FilterAxis.FieldSets[eTableColumn.Month.ToString()].Fields[eTableColumn.Month.ToString()].SubtotalFont, String.Empty, 0, "Blue", false);

                pView.FilterAxis.InsertFieldSet(fSets[eTableColumn.ItemLevel.ToString()], 0, true);
                SetFontFieldSets(pView.FilterAxis.FieldSets[eTableColumn.ItemLevel.ToString()].Fields[eTableColumn.ItemLevel.ToString()].SubtotalFont, String.Empty, 0, "Blue", false);


                //SetFontFieldSets(pView.FilterAxis.FieldSets[eTableColumn.AreaID.ToString()].Fields[eTableColumn.AreaID.ToString()].DetailFont, String.Empty, 0, "Green", true);
                //pView.FilterAxis.InsertFieldSet(fSets["PositionID"], 0, true);
                ////pView.FilterAxis.InsertFieldSet(fSets["DeptID"], 0, true);
                ////pView.FilterAxis.InsertFieldSet(fSets["ProjectGroup"], 0, true);
                //pView.FilterAxis.InsertFieldSet(fSets["DeptID"], 0, true);
                //// set font and back color
                ////SetFontFieldSets(pView.FilterAxis.FieldSets["PositionID"].Fields["PositionID"].SubtotalFont, String.Empty, 0, "Blue", false);
                ////pView.FilterAxis.FieldSets["PositionID"].Fields["PositionID"].SubtotalBackColor = "#C0FFC0";
                ////SetFontFieldSets(pView.FilterAxis.FieldSets["ProjectGroup"].Fields["ProjectGroup"].SubtotalFont, String.Empty, 0, "Blue", false);
                ////pView.FilterAxis.FieldSets["ProjectGroup"].Fields["ProjectGroup"].SubtotalBackColor = "#C0FFC0";

                // Data Detail
                pView.DataAxis.InsertFieldSet(fSets[eTableColumn.Qty.ToString()], 0, true);
                pView.DataAxis.FieldSets[eTableColumn.Qty.ToString()].Fields[eTableColumn.Qty.ToString()].NumberFormat = "#,##0.00";
                //pView.DataAxis.InsertFieldSet(fSets[eTableColumn.NG.ToString()], 0, true);
                //pView.DataAxis.FieldSets[eTableColumn.NG.ToString()].Fields[eTableColumn.NG.ToString()].NumberFormat = "#,##0.00";
                //pView.DataAxis.InsertFieldSet(fSets[eTableColumn.OK.ToString()], 0, true);
                //pView.DataAxis.FieldSets[eTableColumn.OK.ToString()].Fields[eTableColumn.OK.ToString()].NumberFormat = "#,##0.00";

                //// set size 
                //ResizeDetailFieldSets(pView.DataAxis.FieldSets["LoadUsage"].Fields["LoadUsage"], 50);

                // insert total of data detail
                PivotTotal TotalQty;
                TotalQty = pView.AddTotal("Total Qty", pView.DataAxis.FieldSets[eTableColumn.Qty.ToString()].Fields[0], PivotTotalFunctionEnum.plFunctionSum);
                TotalQty.NumberFormat = "#,##0;#,##0;";
                TotalQty.AutoFit = true;
                TotalQty.Width = 50;
                pView.DataAxis.InsertTotal(TotalQty, 0);


                pView.ExpandDetails = PivotTableExpandEnum.plExpandNever;
                pView.ExpandMembers = PivotTableExpandEnum.plExpandNever;

                //PivotTotal TotalNG;
                //TotalNG = pView.AddTotal("Total NG", pView.DataAxis.FieldSets[eTableColumn.NG.ToString()].Fields[0], PivotTotalFunctionEnum.plFunctionSum);
                //TotalNG.NumberFormat = "#,##0.00;#,##0.00;";
                //TotalNG.AutoFit = true;
                //TotalNG.Width = 50;
                //pView.DataAxis.InsertTotal(TotalNG, 0);
                //pView.ExpandDetails = PivotTableExpandEnum.plExpandNever;

                //PivotTotal TotalOK;
                //TotalOK = pView.AddTotal("Total OK", pView.DataAxis.FieldSets[eTableColumn.OK.ToString()].Fields[0], PivotTotalFunctionEnum.plFunctionSum);
                //TotalOK.NumberFormat = "#,##0.00;#,##0.00;";
                //TotalOK.AutoFit = true;
                //TotalOK.Width = 50;
                //pView.DataAxis.InsertTotal(TotalOK, 0);
                //pView.ExpandDetails = PivotTableExpandEnum.plExpandNever;

                // Remove Blank Data
                //pView.ColumnAxis.FieldSets[eTableColumn.MonthsName.ToString()].Fields[eTableColumn.MonthsName.ToString()].ExcludedMembers = "";

                //caption สำหรับ column / row
                pView.RowAxis.FieldSets[eTableColumn.Day.ToString()].Fields[eTableColumn.Day.ToString()].Caption = "Day";
                pView.RowAxis.FieldSets[eTableColumn.CustName.ToString()].Fields[eTableColumn.CustName.ToString()].Caption = "Customer Name";
                pView.RowAxis.FieldSets[eTableColumn.PartNo.ToString()].Fields[eTableColumn.PartNo.ToString()].Caption = "Part No.";
                pView.RowAxis.FieldSets[eTableColumn.MasterNo.ToString()].Fields[eTableColumn.MasterNo.ToString()].Caption = "Master No.";
                pView.ColumnAxis.FieldSets[eTableColumn.Process.ToString()].Fields[eTableColumn.Process.ToString()].Caption = "Process";
                pView.FilterAxis.FieldSets[eTableColumn.Month.ToString()].Fields[eTableColumn.Month.ToString()].Caption = "Month";
                pView.FilterAxis.FieldSets[eTableColumn.ItemLevel.ToString()].Fields[eTableColumn.ItemLevel.ToString()].Caption = "Item Level";

                //caption สำหรับ parameter ที่ไม่ได้ใช้
                pView.RowAxis.FieldSets[eTableColumn.Day.ToString()].Caption = "Day";
                pView.RowAxis.FieldSets[eTableColumn.CustName.ToString()].Caption = "Customer Name";
                pView.RowAxis.FieldSets[eTableColumn.PartNo.ToString()].Caption = "Part No.";
                pView.RowAxis.FieldSets[eTableColumn.MasterNo.ToString()].Caption = "Master No.";
                pView.ColumnAxis.FieldSets[eTableColumn.Process.ToString()].Caption = "Process";
                pView.FilterAxis.FieldSets[eTableColumn.Month.ToString()].Caption = "Month";
                pView.FilterAxis.FieldSets[eTableColumn.ItemLevel.ToString()].Caption = "Item Level";



                // Display All Items (Include Visible)
                pView.TotalAllMembers = false;

                pivotMPA.Visible = true;
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusiness(this, ex.Message);
            }
        }

        void tsbSearch_Click(object sender, EventArgs e)
        {
            QueryData();
        }

    }
}
