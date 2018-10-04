//Create Date 12 Oct 2010
//Author: Bunyapat L.
//Screen Name: Print Stock Checking List
//Description: To print stock checking list for using as guideline to count stock

using System;
using System.Collections.Generic;
using EVOFramework.Windows.Forms;
using EVOFramework;
using System.Data;
using System.IO;
using System.Windows.Forms;
using CommonLib;
using SystemMaintenance;
using Message = EVOFramework.Message;
using EVOFramework.Data;
using Rubik.DTO;
using Rubik.BIZ;
using Rubik;
using Rubik.Report;
using Rubik.Forms.FindDialog;


namespace Rubik.StockTaking
{
    [Screen("STK020", "Export Stock Checking List", eShowAction.Normal, eScreenType.Process, "Export Stock Checking List")]
    public partial class STK020_PrintStockCheckingList : SystemMaintenance.Forms.CustomizeBaseForm
    {
        public bool IncompleteData
        {
            set { this.chkIncomplete.Checked = value; }
        }

        public string LocationCode
        {
            //set { this.txtLocation.Text = value; }
            set { cboProcess.SelectedValue = value; }
        }

        private object m_strPartType;
        private object m_strPartSubType;

        public object PartType
        {
            set { m_strPartType = value; }
        }

        public object PartSubType
        {
            set { m_strPartSubType = value; }
        }

        public STK020_PrintStockCheckingList()
        {
            InitializeComponent();
        }

        private void STK020_PrintStockCheckingList_Load(object sender, EventArgs e)
        {
            try
            {
                InitialScreen();
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusiness(this, ex.Message);
            }
        }

        private void InitialScreen()
        {
            cboProcess.Format += Common.ComboBox_Format;

            rdoReportCheckingList.KeyPress += CtrlUtil.SetNextControl;
            rdoReportCountingResult.KeyPress += CtrlUtil.SetNextControl;
            //txtLocation.KeyPress += CtrlUtil.SetNextControl;
            cboProcess.KeyPress += CtrlUtil.SetNextControl;
            txtMasterNo.KeyPress += CtrlUtil.SetNextControl;
            cboItemType.KeyPress += CtrlUtil.SetNextControl;
            cboItemClassMinor04.KeyPress += CtrlUtil.SetNextControl;
            chkIncomplete.KeyPress += CtrlUtil.SetNextControl;
            chkDiff.KeyPress += CtrlUtil.SetNextControl;
            chkNoMaster.KeyPress += CtrlUtil.SetNextControl;


            LookupDataBIZ bizLookup = new LookupDataBIZ();

            LookupData lookupItemType = bizLookup.LoadLookupClassType(new NZString(null, "ITEM_CLS"));
            cboItemType.LoadLookupData(lookupItemType);
            cboItemType.SelectedIndex = -1;

            //------------ Location --------------------//
            NZString[] locationtype = new NZString[1];
            locationtype[0] = DataDefine.Convert2ClassCode(DataDefine.eLOCATION_CLS.Production).ToNZString();
            LookupData dataProductionProcess = bizLookup.LoadLookupLocation(locationtype);
            cboProcess.LoadLookupData(dataProductionProcess);
            cboProcess.SelectedIndex = -1;
            //------------ Location --------------------//

            if (m_strPartSubType != null)
            {
                this.cboItemType.SelectedValue = m_strPartType;
            }

            if (m_strPartSubType != null)
            {
                this.cboItemClassMinor04.SelectedValue = m_strPartSubType;
            }



            dtStockTakingDate.Format = Common.CurrentUserInfomation.DateFormatString;

            CtrlUtil.EnabledControl(false, dtStockTakingDate, txtPreProcessBy, txtRemark);

            LoadCurrentStockTakingData();


            if (btnPrintTag.Visible == false)
            {

                SysConfigBIZ sysBiz = new SysConfigBIZ();
                SysConfigDTO argScreenInfo = new SysConfigDTO();
                argScreenInfo.SYS_GROUP_ID = DataDefine.eSYSTEM_CONFIG.STK020.SYS_GROUP_ID;
                argScreenInfo.SYS_KEY = (NZString)DataDefine.eSYSTEM_CONFIG.STK020.SYS_KEY.DEV_VERSION.ToString();

                SysConfigDTO data = sysBiz.LoadByPK(argScreenInfo.SYS_GROUP_ID, argScreenInfo.SYS_KEY);

                if (data != null && "1".Equals(data.CHAR_DATA.NVL("").Trim()))
                {
                    btnPrintTag.Visible = true;
                }

            }
        }

        private void LoadCurrentStockTakingData()
        {
            StockTakingBIZ stkBiz = new StockTakingBIZ();
            StockTakingDTO stkDTO = stkBiz.LoadLastStockTaking();

            if (stkDTO != null)
            {
                this.txtRemark.Text = stkDTO.REMARK;
                this.dtStockTakingDate.DateValue = stkDTO.STOCK_TAKING_DATE;
                this.txtPreProcessBy.Text = stkDTO.PRE_PROCESS_BY + " - " + stkDTO.PRE_PROCESS_NAME;
            }
            else
            {
                MessageDialog.ShowBusiness(this
                    , new EVOFramework.Message(TKPMessages.eValidate.VLM0086.ToString()));

            }
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            try
            {
                ErrorItem err = CheckCanRunProcess();
                if (err != null)
                {
                    MessageDialog.ShowBusiness(this, err.Message);
                    this.Close();
                    return;
                }

                try
                {
                    if (txtPreProcessBy.Text.Trim().Length == 0)
                    {
                        MessageDialog.ShowBusiness(this
                                , new EVOFramework.Message(TKPMessages.eValidate.VLM0086.ToString()));

                        return;
                    }

                    StockTakingDTO dto = new StockTakingDTO();
                    dto.STOCK_TAKING_DATE = Convert.ToDateTime(dtStockTakingDate.DateValue);
                    dto.LOCATION_CODE = cboProcess.SelectedValue == null ? string.Empty : cboProcess.SelectedValue.ToString();//txtLocation.Text;
                    dto.PART_NO = txtMasterNo.Text;
                    dto.PART_TYPE = Convert.ToString(cboItemType.SelectedValue);
                    dto.PART_SUB_TYPE = Convert.ToString(cboItemClassMinor04.SelectedValue);

                    if (chkIncomplete.Checked)
                    {
                        dto.SEARCH_INCOMPLETE = 1;
                    }
                    else
                    {
                        dto.SEARCH_INCOMPLETE = 0;
                    }

                    if (chkDiff.Checked)
                    {
                        dto.SEARCH_DIFF = 1;
                    }
                    else
                    {
                        dto.SEARCH_DIFF = 0;
                    }

                    if (chkNoMaster.Checked)
                    {
                        dto.NO_MASTER = 1;
                    }
                    else
                    {
                        dto.NO_MASTER = 0;
                    }

                    DataSet ds = GetReportTable(dto);
                    if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        string strReportFileName = @"Report\STR010_StockCheckingList.rpt";

                        if (rdoReportCheckingList.Checked)
                        {
                            strReportFileName = @"Report\STR010_StockCheckingList.rpt";
                        }
                        else if (rdoReportCountingResult.Checked)
                        {
                            strReportFileName = @"Report\STR020_StockCountingResult.rpt";
                        }
                        else
                        {
                            strReportFileName = @"Report\STR010_StockCheckingList.rpt";
                        }



                        RPT999_PreviewReport preview = new RPT999_PreviewReport(
                                Path.Combine(Application.StartupPath, strReportFileName)
                            );

                        preview.SetDataSource(ds);
                        preview.ReportDoc.SetParameterValue("StockTakingDate", dto.STOCK_TAKING_DATE);
                        preview.ReportDoc.SetParameterValue("IncompleteData", dto.SEARCH_INCOMPLETE);
                        preview.ReportDoc.SetParameterValue("DiffMoreThanZero", dto.SEARCH_DIFF);

                        preview.ShowPreview();

                    }
                    else
                    {
                        MessageDialog.ShowInformation(this, null, Message.LoadMessage(TKPMessages.eInformation.INF0001.ToString()).MessageDescription);
                    }
                }
                catch (Exception ex)
                {
                    MessageDialog.ShowBusiness(this, ex.Message);
                }
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusiness(this, ex.Message);
            }

        }

        private DataSet GetReportTable(StockTakingDTO argSTK)
        {
            DataSet ds = null;

            ReportBIZ biz = new ReportBIZ();
            if (rdoReportCountingResult.Checked)
            {
                ds = biz.LoadStockCountingResult(argSTK);
            }
            else
            {

                ds = biz.LoadStockCheckingList(argSTK);

            }


            return ds;
        }

        private DataSet GetExportTable(StockTakingDTO argSTK)
        {
            DataSet ds = null;

            ReportBIZ biz = new ReportBIZ();

            ds = biz.LoadStockCountingResultForExport(argSTK);

            return ds;
        }

        private ErrorItem CheckCanRunProcess()
        {
            //try
            //{
            //    // get year month 
            //    InventoryPeriodBIZ bizPeriod = new InventoryPeriodBIZ();
            //    InventoryPeriodDTO dtoPeriod = bizPeriod.LoadCurrentPeriod();

            //    // load Transaction in this yearmonth
            //    InventoryBIZ bizInv = new InventoryBIZ();
            //    List<InventoryTransactionDTO> dtoTransList = bizInv.LoadAllTransactionsOnPeriod(dtoPeriod.PERIOD_BEGIN_DATE, dtoPeriod.PERIOD_END_DATE);

            //    if (dtoTransList == null || dtoTransList.Count == 0)
            //    {
            //        return new ErrorItem(null, TKPMessages.eValidate.VLM0074.ToString(), new[] { dtoPeriod.YEAR_MONTH.StrongValue });
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageDialog.ShowBusiness(this, ex.Message);
            //}

            return null;
        }

        private bool RunProcess()
        {
            //try
            //{
            //    InventoryBIZ biz = new InventoryBIZ();

            //    NZString YearMonth = new NZString(null, Convert.ToDateTime(dtInventoryMonth.DateValue).ToString("yyyyMM"));
            //    //pgbProgress.PerformStep();
            //    biz.RunInventoryClosingProcess(YearMonth);
            //    return true;
            //}
            //catch (Exception ex)
            //{
            //    MessageDialog.ShowBusiness(this, ex.Message);
            //    picWaiting.Visible = false;
            //}
            return false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                Close();
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusiness(this, ex.Message);
            }
        }

        private void STK020_PrintStockCheckingList_Shown(object sender, EventArgs e)
        {
            try
            {
                this.PerformLayout();
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusiness(this, ex.Message);
            }
        }

        private void btnLocation_Click(object sender, EventArgs e)
        {
            try
            {
                DynamicFindDialog fnd2 = new DynamicFindDialog("S_DynamicFindDialog_STK020_SearchStockTakingLocation", "Location");
                fnd2.ShowDialog();

                if (fnd2.IsSelectItem)
                {
                    this.txtLocation.Text = fnd2.SelectedKey.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusiness(this, ex.Message);
            }
        }

        private void cboItemType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboItemType.SelectedValue != null && cboItemType.SelectedValue != DBNull.Value)
            {
                if (cboItemType.SelectedValue.ToString() == Rubik.DataDefine.Convert2ClassCode(Rubik.DataDefine.eITEM_CLS.RawMaterial))
                {
                    CtrlUtil.EnabledControl(true, cboItemClassMinor04);
                    LookupDataBIZ biz = new LookupDataBIZ();
                    LookupData data = biz.LoadLookupClassType((NZString)Rubik.DataDefine.ITEM_CLS_MINOR04);
                    cboItemClassMinor04.LoadLookupData(data);

                    cboItemClassMinor04.SelectedIndex = -1;
                    return;
                }

            }
            cboItemClassMinor04.DataSource = null;
            CtrlUtil.EnabledControl(false, cboItemClassMinor04);
        }

        private void txtLocation_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                btnLocation_Click(sender, e);
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            ExportData();
        }


        private void ExportData()
        {
            string strFileName = GenerateFileName("StockTaking");

            string strTemplateFileName = @"Report\STR030_StockTaking.xls";
            string strTemplatePath = Path.Combine(Application.StartupPath, strTemplateFileName);

            string strExportPath = SaveDialogUtil.GetBrowseFileDialogForExport(strFileName);

            if (!"".Equals(strExportPath))
            {
                StockTakingDTO dto = new StockTakingDTO();
                dto.STOCK_TAKING_DATE = Convert.ToDateTime(dtStockTakingDate.DateValue);
                dto.LOCATION_CODE = cboProcess.SelectedValue == null ? string.Empty : cboProcess.SelectedValue.ToString();//txtLocation.Text;
                dto.PART_NO = txtMasterNo.Text;
                dto.PART_TYPE = Convert.ToString(cboItemType.SelectedValue);
                dto.PART_SUB_TYPE = Convert.ToString(cboItemClassMinor04.SelectedValue);

                if (chkIncomplete.Checked)
                {
                    dto.SEARCH_INCOMPLETE = 1;
                }
                else
                {
                    dto.SEARCH_INCOMPLETE = 0;
                }

                if (chkDiff.Checked)
                {
                    dto.SEARCH_DIFF = 1;
                }
                else
                {
                    dto.SEARCH_DIFF = 0;
                }

                if (chkNoMaster.Checked)
                {
                    dto.NO_MASTER = 1;
                }
                else
                {
                    dto.NO_MASTER = 0;
                }

                DataSet ds = GetExportTable(dto);

                ExportUtil.Export(ds, strTemplatePath, strExportPath);


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

            strFilename = strReportID + "_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".xls";

            return strFilename;
        }

        private void txtPartNo_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.Empty.Equals(txtPartNo.Text.Trim()))
            {
                txtMasterNo.Text = string.Empty;
                txtCustomerName.Text = string.Empty;
                return;
            }

            try
            {
                ItemBIZ biz = new ItemBIZ();
                ItemDescriptionDTO dto = biz.LoadItemDescription(new NZString(), txtPartNo.Text.Trim().ToNZString());
                if (dto == null)
                {
                    ErrorItem errorItem = new ErrorItem(txtPartNo, TKPMessages.eValidate.VLM0009.ToString());
                    throw new BusinessException(errorItem);
                }

                txtMasterNo.Text = dto.MASTER_NO;
                txtCustomerName.Text = dto.CUSTOMER_NAME;
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
            catch (Exception ex)
            {
                MessageDialog.ShowBusiness(this, ex.Message);
            }
        }

        private void btnPrintTag_Click(object sender, EventArgs e)
        {
            try
            {
                ErrorItem err = CheckCanRunProcess();
                if (err != null)
                {
                    MessageDialog.ShowBusiness(this, err.Message);
                    this.Close();
                    return;
                }

                try
                {
                    if (txtPreProcessBy.Text.Trim().Length == 0)
                    {
                        MessageDialog.ShowBusiness(this
                                , new EVOFramework.Message(TKPMessages.eValidate.VLM0086.ToString()));

                        return;
                    }

                    ReportBIZ biz = new ReportBIZ();


                    DataSet ds = biz.LoadStockTakingTagSummary();


                    if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        string strReportFileName = @"Report\STR040_StockTakingTagSummary.rpt";


                        RPT999_PreviewReport preview = new RPT999_PreviewReport(
                                Path.Combine(Application.StartupPath, strReportFileName)
                            );

                        preview.SetDataSource(ds);
                        preview.ReportDoc.SetParameterValue("USER", Common.CurrentUserInfomation.Username.ToString().ToUpper());

                        preview.ShowPreview();

                    }
                    else
                    {
                        MessageDialog.ShowInformation(this, null, Message.LoadMessage(TKPMessages.eInformation.INF0001.ToString()).MessageDescription);
                    }
                }
                catch (Exception ex)
                {
                    MessageDialog.ShowBusiness(this, ex.Message);
                }
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusiness(this, ex.Message);
            }
        }
    }
}
