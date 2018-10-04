//Create Date 12 Oct 2010
//Author: Bunyapat L.
//Screen Name: Stock Taking Prepare Process
//Description: To copy current inventory on hand to stock taking table 
//             (used to compare with stock taking entry data


using System;
using System.Collections.Generic;
using EVOFramework.Windows.Forms;
using EVOFramework;
using CommonLib;
using Rubik.BIZ;
using Rubik.DTO;


namespace Rubik.StockTaking
{
    [Screen("STK010", "Stock Taking Prepare Process", eShowAction.Normal, eScreenType.Process, "Stock Taking Prepare Process")]
    public partial class STK010_StockTakingPrepareProcess : SystemMaintenance.Forms.CustomizeBaseForm
    {
        public STK010_StockTakingPrepareProcess()
        {
            InitializeComponent();
        }

        private void STK010_PreProcess_Load(object sender, EventArgs e)
        {
            try
            {
                //this.Text = "STK010 - Stock Taking Prepare Process";
                //this.lblHeaderSTK010.Text = "STK010 - Stock Taking Prepare Process";
                InitialScreen();
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusiness(this, ex.Message);
            }
        }

        private void InitialScreen()
        {
            dtpStockTakingDate.KeyPress += CtrlUtil.SetNextControl;
            txtRemark.KeyPress += CtrlUtil.SetNextControl;

            picWaiting.Visible = false;

            dtpLastSTKDate.Format = Common.CurrentUserInfomation.DateFormatString;
            dtpStockTakingDate.Format = Common.CurrentUserInfomation.DateFormatString;

            CtrlUtil.EnabledControl(false, txtYearMonth, dtpLastSTKDate, txtLastPreProcessBy, txtLastRemark);

            LoadCurrentStockTakingData();
        }

        private void LoadCurrentStockTakingData()
        {
            InventoryPeriodBIZ biz = new InventoryPeriodBIZ();
            InventoryPeriodDTO dto = biz.LoadCurrentPeriod();

            //DateTime currentYearMonth = new DateTime(
            //    Convert.ToInt32(dto.YEAR_MONTH.StrongValue.Substring(0, 4)),
            //    Convert.ToInt32(dto.YEAR_MONTH.StrongValue.Substring(4, 2)),
            //    1);
            txtYearMonth.Text = dto.YEAR_MONTH;
            dtpStockTakingDate.Value = DateTime.Today;


            StockTakingBIZ stkBiz = new StockTakingBIZ();
            StockTakingDTO stkDTO = stkBiz.LoadLastStockTaking();

            if (stkDTO != null)
            {
                this.txtLastRemark.Text = stkDTO.REMARK;
                this.dtpLastSTKDate.DateValue = stkDTO.STOCK_TAKING_DATE;
                this.txtLastPreProcessBy.Text = stkDTO.PRE_PROCESS_BY + " - " + stkDTO.PRE_PROCESS_NAME;
            }
            //CommonLib.CtrlUtil.EnabledControl(false, txtInfo, dtInventoryMonth);

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

                //if (dtInventoryMonth.DateValue != null)
                //{
                //    // check exist in inventory period
                //    InventoryPeriodBIZ bizPeriod = new InventoryPeriodBIZ();
                //    NZString YearMonth = new NZString(null, Convert.ToDateTime(dtInventoryMonth.DateValue).ToString("yyyyMM"));
                //    if (!bizPeriod.Exist(YearMonth))
                //    {
                //        MessageDialog.ShowBusiness(this,
                //                                  Message.LoadMessage(
                //                                      TKPMessages.eValidate.VLM0045.ToString()));
                //        return;
                //    }


                //}

                ////MessageDialog.ShowBusiness(this,
                ////                                  Message.LoadMessage(
                ////                                      TKPMessages.eValidate.VLM0020.ToString()));


                MessageDialogResult dr = MessageDialog.ShowConfirmation(this, new Message(SystemMaintenance.Messages.eConfirm.CFM9008.ToString()).MessageDescription);
                if (dr == MessageDialogResult.Yes)
                {

                    StockTakingBIZ biz = new StockTakingBIZ();

                    StockTakingDTO stk = new StockTakingDTO();
                    stk.STOCK_TAKING_DATE = Convert.ToDateTime(dtpStockTakingDate.Value);
                    stk.REMARK = txtRemark.Text;
                    stk.YEAR_MONTH = txtYearMonth.Text;

                    bool bAlreadyRunPreProcess = biz.CheckExistsStockTaking(stk);

                    if (bAlreadyRunPreProcess)
                    {
                        MessageDialogResult drExistStockTaking
                            = MessageDialog.ShowConfirmation(this,
                                new Message(SystemMaintenance.Messages.eConfirm.CFM9010.ToString()
                                     , new object[] { stk.STOCK_TAKING_DATE.ToString(Common.CurrentUserInfomation.DateFormatString) }
                                ).MessageDescription
                            );
                        if (drExistStockTaking != MessageDialogResult.Yes)
                        {
                            return;
                        }
                    }

                    picWaiting.Visible = true;

                    try
                    {
                        if (RunProcess())
                        {
                            picWaiting.Visible = false;

                            MessageDialog.ShowBusiness(this, Message.LoadMessage(SystemMaintenance.Messages.eInformation.INF9003.ToString()));
                        }

                        //Modify on 20 oct 2010
                        //Disable run button after run process complete
                        //To prevent user execute process again, otherwise user close and open this screen again
                        this.btnRun.Enabled = false;
                    }
                    catch (Exception ex)
                    {
                        MessageDialog.ShowBusiness(this, ex.Message);
                    }
                    finally
                    {
                        picWaiting.Visible = false;
                    }

                    LoadCurrentStockTakingData();
                }
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
                // get year month 
                InventoryPeriodBIZ bizPeriod = new InventoryPeriodBIZ();
                InventoryPeriodDTO dtoPeriod = bizPeriod.LoadCurrentPeriod();


                if (!dtoPeriod.YEAR_MONTH.StrongValue.Equals(Convert.ToDateTime(dtpStockTakingDate.Value).ToString("yyyyMM")))
                {
                    return new ErrorItem(null, TKPMessages.eValidate.VLM0084.ToString(), new[] { "" });
                }

                if (Convert.ToDateTime(dtpLastSTKDate.DateValue) > Convert.ToDateTime(dtpStockTakingDate.Value))
                {
                    return new ErrorItem(null, TKPMessages.eValidate.VLM0084.ToString(), new[] { "" });

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
                stk.STOCK_TAKING_DATE = Convert.ToDateTime(dtpStockTakingDate.Value);
                stk.REMARK = txtRemark.Text;
                stk.YEAR_MONTH = txtYearMonth.Text;

                biz.RunStockTakingPreProcess(stk);

                return true;
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusiness(this, ex.Message);
                picWaiting.Visible = false;
            }

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

        private void STK010_PreProcess_Shown(object sender, EventArgs e)
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
    }
}
