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
using Rubik.Controller;


namespace Rubik.StockTaking
{
    [Screen("STK060", "Import Stock Taking", eShowAction.Normal, eScreenType.Process, "Import Stock Taking")]
    public partial class STK060_ImportStockTaking : SystemMaintenance.Forms.CustomizeBaseForm
    {

        #region Enum

        private enum eImportFile
        {
            TagNo,
            Process,
            MasterNo,
            Weight,
            Qty,
            Remark
        }

        #endregion

        #region Member

        //private const string CONST_STR_IMPORT_FILE_TYPE = "Excel Files (*.xls;*.xlsx)|*.xls;*.xlsx";
        private const string CONST_STR_IMPORT_FILE_TYPE = "Excel Files (*.xls)|*.xls;";
        private const bool CONST_B_DATA_INCLUDE_HEADER = true;
        private const int CONST_INT_START_RECORD_NO = 1;

        private ImportStockTakingController m_controller = new ImportStockTakingController();

        #endregion

        #region Constructor

        public STK060_ImportStockTaking()
        {
            InitializeComponent();
        }

        #endregion

        #region Event

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

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            string strFilePath = SaveDialogUtil.GetBrowseFileDialog("Please select import file.", CONST_STR_IMPORT_FILE_TYPE);
            if (string.Empty.Equals(strFilePath))
            {
                CtrlUtil.EnabledControl(!string.Empty.Equals(txtFileName.Text.Trim()), btnImport);

                return;
            }

            txtFileName.Text = strFilePath;
            CtrlUtil.EnabledControl(true, btnImport);
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.Empty.Equals(txtLastPreProcessBy.Text)) 
                {
                    MessageDialog.ShowBusiness(this, Message.LoadMessage(TKPMessages.eValidate.VLM0086.ToString()));
                    return;
                }

                MessageDialogResult dialog = MessageDialog.ShowConfirmation(this, Message.LoadMessage(TKPMessages.eConfirm.CFM0005.ToString()));
                if (dialog == MessageDialogResult.Cancel || dialog == MessageDialogResult.No)
                {
                    return;
                }

                string strFilePath = txtFileName.Text.Trim();

                //Check found data in file
                DataTable dt = ImportUtil.ImportExcel(strFilePath, CONST_B_DATA_INCLUDE_HEADER, 0);
                if (dt == null || dt.Rows.Count == 0)
                {
                    ErrorItem error = new ErrorItem(null, TKPMessages.eValidate.VLM0156.ToString());
                    ValidateException.ThrowErrorItem(error);
                }

                if (dt.Columns.Count < ((int)eImportFile.Remark) + 1)
                {
                    ErrorItem error = new ErrorItem(null, TKPMessages.eValidate.VLM0178.ToString());
                    ValidateException.ThrowErrorItem(error);
                }

                List<ImportStockTakingDTO> dtoList = new List<ImportStockTakingDTO>();
                int iLineNo = CONST_B_DATA_INCLUDE_HEADER ? CONST_INT_START_RECORD_NO : 0;
                foreach (DataRow dr in dt.Rows)
                {
                    if (("".Equals(dr[(int)eImportFile.Process])
                        && "".Equals(dr[(int)eImportFile.MasterNo])
                        && "".Equals(dr[(int)eImportFile.Weight])
                        && "".Equals(dr[(int)eImportFile.Qty])
                        && "".Equals(dr[(int)eImportFile.TagNo])
                        && "".Equals(dr[(int)eImportFile.Remark]))

                     || (DBNull.Value.Equals(dr[(int)eImportFile.Process])
                        && DBNull.Value.Equals(dr[(int)eImportFile.MasterNo])
                        && DBNull.Value.Equals(dr[(int)eImportFile.Weight])
                        && DBNull.Value.Equals(dr[(int)eImportFile.Qty])
                        && DBNull.Value.Equals(dr[(int)eImportFile.TagNo])
                        && DBNull.Value.Equals(dr[(int)eImportFile.Remark])
                    ))
                    {
                        continue;
                    }


                    iLineNo = iLineNo + 1;



                    ImportStockTakingDTO dto = new ImportStockTakingDTO();
                    dto.CREATE_BY = Common.CurrentUserInfomation.UserCD;
                    dto.CREATE_MACHINE = Common.CurrentUserInfomation.Machine;
                    dto.IMPORT_FILE_NAME = new NZString(txtFileName, txtFileName.Text.Trim());
                    dto.LINE_NO = new NZInt(null, iLineNo);
                    dto.PROCESS_CD = new NZString(null, dr[(int)eImportFile.Process]);
                    dto.ITEM_CD = new NZString(null, dr[(int)eImportFile.MasterNo]);
                    dto.WEIGHT = new NZString(null, dr[(int)eImportFile.Weight]);
                    dto.QTY = new NZString(null, dr[(int)eImportFile.Qty]);
                    dto.TAG_NO = new NZString(null, dr[(int)eImportFile.TagNo]);
                    dto.REMARK = new NZString(null, dr[(int)eImportFile.Remark]);
                    dtoList.Add(dto);
                }

                bool bSuccess = m_controller.ImportStockTakingTemp(strFilePath, ((int)eImportFile.Remark) + 1, dtoList);
                if (bSuccess)
                {
                    MessageDialog.ShowInformation(this, null, Message.LoadMessage(Messages.eInformation.INF9003.ToString()).MessageDescription);
                    InitialScreen();
                    return;
                }
            }
            catch (ValidateException err)
            {
                for (int i = 0; i < err.ErrorResults.Count; i++)
                {
                    MessageDialog.ShowBusiness(this, err.ErrorResults[i].Message);
                    err.ErrorResults[i].FocusOnControl();
                }

            }
            catch (BusinessException err)
            {
                MessageDialog.ShowBusiness(this, err.Error.Message);
                err.Error.FocusOnControl();
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusiness(this, ex.Message);
            }
        }

        private void btnClearAll_Click(object sender, EventArgs e)
        {
            try
            {
                MessageDialogResult dialog = MessageDialog.ShowConfirmation(this, Message.LoadMessage(TKPMessages.eConfirm.CFM0006.ToString()));
                if (dialog == MessageDialogResult.Cancel || dialog == MessageDialogResult.No)
                {
                    return;
                }

                m_controller.ClearImportStockTaking();
                MessageDialog.ShowInformation(this, null, Message.LoadMessage(Messages.eInformation.INF9001.ToString()).MessageDescription);
                InitialScreen();
            }
            catch (ValidateException err)
            {
                for (int i = 0; i < err.ErrorResults.Count; i++)
                {
                    MessageDialog.ShowBusiness(this, err.ErrorResults[i].Message);
                    err.ErrorResults[i].FocusOnControl();
                }

            }
            catch (BusinessException err)
            {
                MessageDialog.ShowBusiness(this, err.Error.Message);
                err.Error.FocusOnControl();
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusiness(this, ex.Message);
            }
        }
        #endregion

        #region Private Method

        private void InitialScreen()
        {
            txtFileName.Clear();

            CtrlUtil.EnabledControl(false, dtpLastSTKDate, txtLastPreProcessBy, txtLastRemark);
            CtrlUtil.EnabledControl(false, txtFileName);

            CtrlUtil.EnabledControl(true, btnBrowse, btnClearAll);
            CtrlUtil.EnabledControl(false, btnImport);

            LoadLastStockTaking();
        }

        private void LoadLastStockTaking() 
        {
            StockTakingBIZ stkBiz = new StockTakingBIZ();
            StockTakingDTO stkDTO = stkBiz.LoadLastStockTaking();

            if (stkDTO != null) 
            {
                this.txtLastRemark.Text = stkDTO.REMARK;
                this.dtpLastSTKDate.DateValue = stkDTO.STOCK_TAKING_DATE;
                this.txtLastPreProcessBy.Text = stkDTO.PRE_PROCESS_BY + " - " + stkDTO.PRE_PROCESS_NAME;
            }
        }

        #endregion

        private void btnGetTemplate_Click(object sender, EventArgs e) 
        {
            try {
                string strFilePath = SaveDialogUtil.GetBrowseFileDialogForExport();
                if (string.Empty.Equals(strFilePath)) {
                    return;
                }

                string strReportPath = @"Report\STK060_ImportStockTakingTemplate.xls";
                File.Copy(Path.Combine(Application.StartupPath, strReportPath), strFilePath);

                MessageDialog.ShowInformation(this, null, Message.LoadMessage(Messages.eInformation.INF0006.ToString()).MessageDescription);
                    
            }
            catch (Exception ex) 
            {
                MessageDialog.ShowBusiness(this, ex.Message, ex.StackTrace);
            }
        }



    }
}
