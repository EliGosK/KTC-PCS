using System;
using System.Windows.Forms;
using SystemMaintenance.Forms;
using EVOFramework;
using EVOFramework.Data;
using EVOFramework.Windows.Forms;
using Rubik.BIZ;
using CommonLib;
using Rubik.UIDataModel;
using Rubik.Controller;
using Rubik.Validators;
using SystemMaintenance;
using EVOFramework.Win32.API;
using Rubik.Forms.FindDialog;
using Rubik.DTO;

namespace Rubik.Master
{
    [Screen("MAS120", "Sales Unit Price Information Entry", eShowAction.Normal, eScreenType.Dialog, "Sales Unit Price Information Entry")]
    public partial class MAS120_SalesUnitPriceMaster : CustomizeForm
    {
        #region Enumeration
        private enum eMode
        {
            ADD, EDIT,
        }
        #endregion

        #region Variables
        private readonly SalesUnitPriceController m_SalesUnitPriceController = new SalesUnitPriceController();

        private string m_MasterNo = string.Empty;
        private DateTime m_dtmStartEffDate = DateTime.MinValue;
        private string m_Currency = string.Empty;

        private eMode m_screenMode = eMode.ADD;
        private DialogResult m_dummyDialogResult = DialogResult.Cancel;
        #endregion

        #region Constructor
        public MAS120_SalesUnitPriceMaster()
        {
            InitializeComponent();

            m_dummyDialogResult = DialogResult.Cancel;

            InitializeScreenMode();
            InitializeScreen();

        }

        public MAS120_SalesUnitPriceMaster(string MasterNo, DateTime StartEffDate, string Currency)
        {
            InitializeComponent();
            m_dummyDialogResult = DialogResult.Cancel;

            m_MasterNo = MasterNo;
            m_dtmStartEffDate = StartEffDate;
            m_Currency = Currency;

            InitializeScreenMode();
            InitializeScreen();
        }
        #endregion

        #region Private Methods
        private void InitializeScreenMode()
        {
            if (String.IsNullOrEmpty(m_MasterNo))
            {
                // New mode.
                m_screenMode = eMode.ADD;
                CtrlUtil.EnabledControl(true, btnSearchMasterNo, txtPartNo, txtMasterNo, dtStartEffDate, numPrice, cboCurrency, txtRemark);
                CtrlUtil.EnabledControl(false, txtCustomerName, txtPartNo);

                LookupData();

                tsbSaveAndNew.Enabled = true;
                tsbSaveAndClose.Enabled = true;

                CtrlUtil.FocusControl(txtMasterNo);
            }
            else
            {
                // Edit mode.
                m_screenMode = eMode.EDIT;
                CtrlUtil.EnabledControl(true, numPrice, txtRemark);
                CtrlUtil.EnabledControl(false, btnSearchMasterNo, txtPartNo, txtMasterNo, txtCustomerName, dtStartEffDate, txtPartNo, cboCurrency);

                tsbSaveAndNew.Enabled = true;
                tsbSaveAndClose.Enabled = true;

                CtrlUtil.FocusControl(numPrice);
            }
        }
        private void InitializeScreen()
        {
            this.cboCurrency.Format += Common.ComboBox_Format;

            dmcSalesUnitPrice.AddRangeControl(
                txtMasterNo,
                txtPartNo,
                txtCustomerName,
                dtStartEffDate,
                numPrice,
                cboCurrency,
                txtRemark
                );

            txtMasterNo.KeyPress += CtrlUtil.SetNextControl;
            txtPartNo.KeyPress += CtrlUtil.SetNextControl;
            txtCustomerName.KeyPress += CtrlUtil.SetNextControl;
            dtStartEffDate.KeyPress += CtrlUtil.SetNextControl;
            numPrice.KeyPress += CtrlUtil.SetNextControl;
            cboCurrency.KeyPress += CtrlUtil.SetNextControl;
            txtRemark.KeyPress += CtrlUtil.SetNextControl;

            LookupData();

            if (m_screenMode == eMode.EDIT)
            {
                SalesUnitPriceUIDM model = m_SalesUnitPriceController.LoadSalesUnitPriceWithItemInfo(m_MasterNo.ToNZString(),
                                                                                                        m_dtmStartEffDate.ToNZDateTime(),
                                                                                                        m_Currency.ToNZString());
                dmcSalesUnitPrice.LoadData(model);
            }
        }

        private void LookupData()
        {
            LookupDataBIZ biz = new LookupDataBIZ();
            LookupData currencyData = biz.LoadLookupClassType(DataDefine.CURRENCY.ToNZString());
            cboCurrency.LoadLookupData(currencyData);
            cboCurrency.SelectedIndex = -1;

            //LookupData lookupData2 = biz.LoadLookupClassType(DataDefine.MRP_LOCATION.ToNZString());
            //cboMRPLocation.LoadLookupData(lookupData2);
            //cboMRPLocation.SelectedIndex = -1;
        }

        private void ClearControls()
        {
            //dmcSalesUnitPrice.LoadData(new SalesUnitPriceUIDM());
            txtMasterNo.Clear();
            txtPartNo.Clear();
            txtCustomerName.Clear();
            dtStartEffDate.Value = null;
            numPrice.Clear();
            cboCurrency.SelectedIndex = -1;
            txtRemark.Clear();
        }

        private void ValidateRequireField()
        {
            SalesUnitPriceValidator validator = new SalesUnitPriceValidator();

            ErrorItem errorItem = null;
            errorItem = validator.CheckEmptyMasterNo(new NZString(txtPartNo, txtPartNo.Text));
            if (null != errorItem) ValidateException.ThrowErrorItem(errorItem);

            errorItem = validator.CheckEmptyStartEffeciveDate(new NZDateTime(dtStartEffDate, dtStartEffDate.Value));
            if (null != errorItem) ValidateException.ThrowErrorItem(errorItem);

            errorItem = validator.CheckEmptyCurrency(new NZString(cboCurrency, cboCurrency.SelectedValue));
            if (null != errorItem) ValidateException.ThrowErrorItem(errorItem);

            errorItem = validator.CheckEmptyPrice(numPrice.ToNZDecimal());
            if (null != errorItem) ValidateException.ThrowErrorItem(errorItem);
        }

        #endregion

        #region Form events
        private void MAS020_LocationMaster_Load(object sender, EventArgs e)
        {
            InitialFormat();
        }

        private void InitialFormat()
        {
            CommonLib.FormatUtil.SetDateFormat(this.dtStartEffDate);
            CommonLib.FormatUtil.SetNumberFormat(this.numPrice, FormatUtil.eNumberFormat.UnitPrice);
        }

        private void MAS020_LocationMaster_Shown(object sender, EventArgs e)
        {

        }

        private void MAS020_LocationMaster_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult = m_dummyDialogResult;
        }
        #endregion

        #region Overriden base event.

        public override void OnSaveAndNew()
        {
            SalesUnitPriceUIDM model = dmcSalesUnitPrice.SaveData(new SalesUnitPriceUIDM());
            try
            {
                ValidateRequireField();

                // Confirm to save.
                MessageDialogResult dr = MessageDialog.ShowConfirmation(this, new EVOFramework.Message(Messages.eConfirm.CFM9001.ToString()));
                if (dr == MessageDialogResult.Cancel || dr == MessageDialogResult.No)
                    return;

                //if (dr == MessageDialogResult.No)
                //{
                //    DialogResult = m_dummyDialogResult;
                //    return;
                //}

                if (eMode.ADD == m_screenMode)
                    m_SalesUnitPriceController.SaveNew(model);
                else
                    m_SalesUnitPriceController.SaveUpdate(model);

                m_dummyDialogResult = DialogResult.OK;

                ClearControls();

                m_MasterNo = string.Empty;
                m_dtmStartEffDate = DateTime.MinValue;
                m_Currency = string.Empty;

                InitializeScreenMode();

                //CtrlUtil.FocusControl(txtPartNo);
                MessageDialog.ShowInformation(this, null, new EVOFramework.Message(Messages.eInformation.INF9003.ToString()).MessageDescription);

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
        }

        public override void OnSaveAndClose()
        {
            SalesUnitPriceUIDM model = dmcSalesUnitPrice.SaveData(new SalesUnitPriceUIDM());
            try
            {

                ValidateRequireField();

                // Confirm to save.
                MessageDialogResult dr = MessageDialog.ShowConfirmation(this, new EVOFramework.Message(Messages.eConfirm.CFM9001.ToString()));
                if (dr == MessageDialogResult.Cancel || dr == MessageDialogResult.No)
                    return;

                //if (dr == MessageDialogResult.No)
                //{
                //    DialogResult = m_dummyDialogResult;
                //    return;
                //}

                if (eMode.ADD == m_screenMode)
                    m_SalesUnitPriceController.SaveNew(model);
                else
                    m_SalesUnitPriceController.SaveUpdate(model);

                MessageDialog.ShowInformation(this, null, new EVOFramework.Message(Messages.eInformation.INF9003.ToString()).MessageDescription);

                m_dummyDialogResult = DialogResult.OK;
                DialogResult = m_dummyDialogResult;
                this.Close();
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
        }


        #endregion

        private void btnSearchMasterNo_Click(object sender, EventArgs e)
        {
            //ItemFindDialog dialog = new ItemFindDialog();            
            //dialog.ShowDialog(this);

            //if (dialog.IsSelected) 
            //{
            //    txtMasterNo.Text = dialog.SelectedItem.ITEM_CD;                
            //}
        }

        private void txtPartNo_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.Empty.Equals(txtPartNo.Text.Trim()))
                return;

            try
            {
                ItemBIZ biz = new ItemBIZ();
                ItemDescriptionDTO dto = biz.LoadItemDescription(txtMasterNo.Text.Trim().ToNZString(), txtPartNo.Text.Trim().ToNZString());
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
        }


        #region Permission Control
        //public override void PermissionControl()
        //{
        //    base.PermissionControl();
        //    if (!UserPermission.Edit)
        //    {
        //        CtrlUtil.EnabledControl(false, txtLocationCode, txtLocationName, cboLocationType);
        //    }
        //}
        #endregion
    }
}
