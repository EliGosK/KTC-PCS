//Create Date 12 Oct 2010
//Author: Bunyapat L.
//Screen Name: Stock Taking Update Process
//Description: To accept stock taking data and adjust to inventory on hand

using System;
using System.Collections.Generic;
using EVOFramework.Windows.Forms;
using EVOFramework;
using System.Windows.Forms;
using Message = EVOFramework.Message;
using CommonLib;
using Rubik.BIZ;
using Rubik.DTO;
using Rubik.Forms.FindDialog;
using System.Data;
using EVOFramework.Data;


namespace Rubik.StockTaking
{
    [Screen("STK040", "Stock Taking Update Process", eShowAction.Normal, eScreenType.Process, "Stock Taking Update Process")]
    public partial class STK040_StockTakingUpdateProcess : SystemMaintenance.Forms.CustomizeBaseForm
    {
        public STK040_StockTakingUpdateProcess()
        {
            InitializeComponent();
        }

        private void STK040_StockTakingUpdateProcess_Load(object sender, EventArgs e)
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
            this.cboProcess.KeyPress += CtrlUtil.SetNextControl;
            cboProcess.Format += Common.ComboBox_Format;


            dtpLastSTKDate.Format = Common.CurrentUserInfomation.DateFormatString;

            CtrlUtil.EnabledControl(false, dtpLastSTKDate, txtLastPreProcessBy, txtYearMonth);

            SearchDialogBIZ biz = new SearchDialogBIZ();

            DataTable dt = biz.searchData("S_DynamicFindDialog_STK040_SearchStockTakingLocation", null);
            LookupData lookupData = new LookupData(dt,
                    "Process Name",
                    "Process");

            cboProcess.LoadLookupData(lookupData);
            cboProcess.SelectedIndex = -1;

            LoadCurrentStockTakingData();
        }

        private void LoadCurrentStockTakingData()
        {
            StockTakingBIZ stkBiz = new StockTakingBIZ();
            StockTakingDTO stkDTO = stkBiz.LoadLastStockTaking();

            if (stkDTO != null)
            {
                this.dtpLastSTKDate.DateValue = stkDTO.STOCK_TAKING_DATE;
                this.txtLastPreProcessBy.Text = stkDTO.PRE_PROCESS_BY + " - " + stkDTO.PRE_PROCESS_NAME;
                this.txtYearMonth.Text = stkDTO.YEAR_MONTH;

                CtrlUtil.EnabledControl(true, btnLocation, btnRun, cboProcess);
            }
            else
            {
                CtrlUtil.EnabledControl(false, btnLocation, btnRun, cboProcess);

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
                    return;
                }

                StockTakingDTO dtoStockTaking = new StockTakingDTO();
                dtoStockTaking.STOCK_TAKING_DATE = Convert.ToDateTime(dtpLastSTKDate.DateValue);
                dtoStockTaking.YEAR_MONTH = txtYearMonth.Text;
                dtoStockTaking.LOCATION_CODE = Convert.ToString(cboProcess.SelectedValue);

                StockTakingBIZ bizStockTaking = new StockTakingBIZ();
                string strTextEffectInventory = bizStockTaking.GetTextEffectInventory(dtoStockTaking);

                MessageDialogResult dr = MessageDialog.ShowConfirmation(this, new Message(SystemMaintenance.Messages.eConfirm.CFM9009.ToString(), new object[] { strTextEffectInventory }).MessageDescription, MessageDialogButtons.YesNo);
                if (dr == MessageDialogResult.Yes)
                {
                    if (RunProcess())
                        MessageDialog.ShowBusiness(this, Message.LoadMessage(SystemMaintenance.Messages.eInformation.INF9003.ToString()));

                    this.cboProcess.SelectedIndex = -1;
                    LoadCurrentStockTakingData();
                }
            }
            catch (ValidateException ex)
            {
                MessageDialog.ShowBusiness(this, ex.ErrorResults[0].Message);
            }
            catch (BusinessException ex)
            {
                MessageDialog.ShowBusiness(this, ex.Error.Message);
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusiness(this, ex.Message);
            }
        }

        private ErrorItem CheckCanRunProcess()
        {
            try
            {
                // modify on 30/oct
                // fix to support in case run closing period before end of month


                //// get year month 
                //InventoryPeriodBIZ bizPeriod = new InventoryPeriodBIZ();
                //InventoryPeriodDTO dtoPeriod = bizPeriod.LoadCurrentPeriod();


                //if (!dtoPeriod.YEAR_MONTH.StrongValue.Equals(Convert.ToDateTime(dtpLastSTKDate.DateValue).ToString("yyyyMM")))
                //{
                //    return new ErrorItem(null, TKPMessages.eValidate.VLM0075.ToString());
                //}

                if (cboProcess.SelectedIndex == -1)
                {
                    return new ErrorItem(null, TKPMessages.eValidate.VLM0087.ToString());
                }


                StockTakingBIZ bizStockTaking = new StockTakingBIZ();
                StockTakingDTO dtoStockTaking = new StockTakingDTO();
                dtoStockTaking.STOCK_TAKING_DATE = Convert.ToDateTime(dtpLastSTKDate.DateValue);
                dtoStockTaking.LOCATION_CODE = Convert.ToString(this.cboProcess.SelectedValue);

                bool bRunUpdateProcess = bizStockTaking.CheckLocationRunUpdateProcess(dtoStockTaking);
                if (bRunUpdateProcess)
                {
                    return new ErrorItem(null, TKPMessages.eValidate.VLM0090.ToString(), new object[] { Convert.ToString(this.cboProcess.SelectedValue) });
                }

                bool bCompleteInputData = bizStockTaking.CheckCompleteInputData(dtoStockTaking);
                if (bCompleteInputData == false)
                {
                    return new ErrorItem(null, TKPMessages.eValidate.VLM0091.ToString(), new object[] { Convert.ToString(this.cboProcess.SelectedValue) });

                }

            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusiness(this, ex.Message);
            }

            return null;
        }

        private bool RunProcess()
        {
            try
            {
                StockTakingBIZ biz = new StockTakingBIZ();

                StockTakingDTO stk = new StockTakingDTO();
                stk.STOCK_TAKING_DATE = Convert.ToDateTime(dtpLastSTKDate.DateValue);
                stk.YEAR_MONTH = txtYearMonth.Text;
                stk.LOCATION_CODE = Convert.ToString(cboProcess.SelectedValue);

                biz.RunStockTakingUpdateProcess(stk);

                return true;
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusiness(this, ex.Message);
            }

            return false;
        }

        private void STK040_StockTakingUpdateProcess_Shown(object sender, EventArgs e)
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
                DynamicFindDialog fnd2 = new DynamicFindDialog("S_DynamicFindDialog_STK040_SearchStockTakingLocation", "Location");
                fnd2.ShowDialog();

                if (fnd2.IsSelectItem)
                {
                    this.cboProcess.SelectedValue = fnd2.SelectedKey.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusiness(this, ex.Message);
            }
        }

        private void txtLocation_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                btnLocation_Click(sender, e);
            }
        }
    }
}
