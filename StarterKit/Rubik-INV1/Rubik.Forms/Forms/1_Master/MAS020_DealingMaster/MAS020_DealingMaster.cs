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

namespace Rubik.Master
{
    [Screen("MAS020", "Dealing Information Entry", eShowAction.Normal, eScreenType.Dialog, "Dealing Information Entry")]
    public partial class MAS020_DealingMaster : CustomizeForm
    {
        #region Enumeration
        private enum eMode
        {
            ADD, EDIT,
        }
        #endregion

        #region Variables
        private readonly DealingController m_locationController = new DealingController();
        private string m_locationCode = string.Empty;
        private eMode m_screenMode = eMode.ADD;
        private DialogResult m_dummyDialogResult = DialogResult.Cancel;
        #endregion

        #region Constructor
        public MAS020_DealingMaster()
        {
            InitializeComponent();

            m_dummyDialogResult = DialogResult.Cancel;

            InitializeScreenMode();
            InitializeScreen();

        }

        public MAS020_DealingMaster(string LOC_CD)
        {

            InitializeComponent();
            m_dummyDialogResult = DialogResult.Cancel;

            m_locationCode = LOC_CD;

            InitializeScreenMode();
            InitializeScreen();
        }
        #endregion

        #region Private Methods
        private void InitializeScreenMode()
        {
            if (String.IsNullOrEmpty(m_locationCode))
            {
                // New mode.
                m_screenMode = eMode.ADD;
                CtrlUtil.EnabledControl(true, txtDealingCode, txtDealingName, cboDealingType, cboTermOfPayment, chkAllowNegative);
                CtrlUtil.EnabledControl(true, txtAddr1Address1,txtAddr1Address2,txtAddr1Address3, txtAddr1Tel, txtAddr1Fax, txtAddr1Email, txtAddr1ContactPerson, txtAddr1Remark);
                CtrlUtil.EnabledControl(true, txtAddr2Address1, txtAddr2Address2, txtAddr2Address3, txtAddr2Tel, txtAddr2Fax, txtAddr2Email, txtAddr2ContactPerson, txtAddr2Remark);
                CtrlUtil.EnabledControl(true, txtAddr3Address1, txtAddr3Address3, txtAddr3Address3, txtAddr3Tel, txtAddr3Fax, txtAddr3Email, txtAddr3ContactPerson, txtAddr3Remark);

                LookupData();
                tbShipTo.SelectedTab = tpAddress1;
                tsbSaveAndNew.Enabled = true;
                tsbSaveAndClose.Enabled = true;
            }
            else
            {
                // Edit mode.
                m_screenMode = eMode.EDIT;
                CtrlUtil.EnabledControl(true, txtDealingName, cboDealingType, cboTermOfPayment, chkAllowNegative);
                CtrlUtil.EnabledControl(true, txtAddr1Address1, txtAddr1Address2, txtAddr1Address3, txtAddr1Tel, txtAddr1Fax, txtAddr1Email, txtAddr1ContactPerson, txtAddr1Remark);
                CtrlUtil.EnabledControl(true, txtAddr2Address1, txtAddr2Address2, txtAddr2Address3, txtAddr2Tel, txtAddr2Fax, txtAddr2Email, txtAddr2ContactPerson, txtAddr2Remark);
                CtrlUtil.EnabledControl(true, txtAddr3Address1, txtAddr3Address3, txtAddr3Address3, txtAddr3Tel, txtAddr3Fax, txtAddr3Email, txtAddr3ContactPerson, txtAddr3Remark);
                CtrlUtil.EnabledControl(false, txtDealingCode);

                tsbSaveAndNew.Enabled = true;
                tsbSaveAndClose.Enabled = true;
            }
        }

        private void InitializeScreen()
        {
            cboDealingType.Format += Common.ComboBox_Format;

            dmcLocation.AddRangeControl(
                txtDealingCode,
                txtDealingName,
                cboDealingType,
                cboTermOfPayment,
                cboInvoicePattern,

                txtAddr1Address1,
                txtAddr1Address2,
                txtAddr1Address3,
                txtAddr1Tel,
                txtAddr1Fax,
                txtAddr1Email,
                txtAddr1ContactPerson,
                txtAddr1Remark,

                txtAddr2Address1,
                txtAddr2Address2,
                txtAddr2Address3,
                txtAddr2Tel,
                txtAddr2Fax,
                txtAddr2Email,
                txtAddr2ContactPerson,
                txtAddr2Remark,

                txtAddr3Address1,
                txtAddr3Address2,
                txtAddr3Address3,
                txtAddr3Tel,
                txtAddr3Fax,
                txtAddr3Email,
                txtAddr3ContactPerson,
                txtAddr3Remark,

                chkAllowNegative
                );

            txtDealingCode.KeyPress += CtrlUtil.SetNextControl;
            txtDealingName.KeyPress += CtrlUtil.SetNextControl;
            cboDealingType.KeyPress += CtrlUtil.SetNextControl;
            cboTermOfPayment.KeyPress += CtrlUtil.SetNextControl;
            cboInvoicePattern.KeyPress += CtrlUtil.SetNextControl;

            tbShipTo.KeyPress += CtrlUtil.SetNextControl;

            //txtAddr1Address.KeyPress += CtrlUtil.SetNextControl;
            //txtAddr1Tel.KeyPress += CtrlUtil.SetNextControl;
            //txtAddr1Fax.KeyPress += CtrlUtil.SetNextControl;
            //txtAddr1Email.KeyPress += CtrlUtil.SetNextControl;
            //txtAddr1ContactPerson.KeyPress += CtrlUtil.SetNextControl;
            //txtAddr1Remark.KeyPress += CtrlUtil.SetNextControl;

            //txtAddr2Address.KeyPress += CtrlUtil.SetNextControl;
            //txtAddr2Tel.KeyPress += CtrlUtil.SetNextControl;
            //txtAddr2Fax.KeyPress += CtrlUtil.SetNextControl;
            //txtAddr2Email.KeyPress += CtrlUtil.SetNextControl;
            //txtAddr2ContactPerson.KeyPress += CtrlUtil.SetNextControl;
            //txtAddr2Remark.KeyPress += CtrlUtil.SetNextControl;

            //txtAddr3Address.KeyPress += CtrlUtil.SetNextControl;
            //txtAddr3Tel.KeyPress += CtrlUtil.SetNextControl;
            //txtAddr3Fax.KeyPress += CtrlUtil.SetNextControl;
            //txtAddr3Email.KeyPress += CtrlUtil.SetNextControl;
            //txtAddr3ContactPerson.KeyPress += CtrlUtil.SetNextControl;
            //txtAddr3Remark.KeyPress += CtrlUtil.SetNextControl;

            //chkAllowNegative.KeyPress += CtrlUtil.SetNextControl;

            LookupData();


        }

        private void LookupData()
        {
            LookupDataBIZ biz = new LookupDataBIZ();
            NZString[] locationClsType = new NZString[3];
            locationClsType[0] = DataDefine.Convert2ClassCode(DataDefine.eLOCATION_CLS.Customer).ToNZString();
            locationClsType[1] = DataDefine.Convert2ClassCode(DataDefine.eLOCATION_CLS.Vendor).ToNZString();
            locationClsType[2] = DataDefine.Convert2ClassCode(DataDefine.eLOCATION_CLS.CustomerVendor).ToNZString();

            LookupData lookupData = biz.LoadLookupClassType(DataDefine.LOCATION_CLS.ToNZString(), locationClsType);
            cboDealingType.LoadLookupData(lookupData);
            cboDealingType.SelectedIndex = -1;

            LookupData termOfPayment = biz.LoadLookupClassType(DataDefine.TERM_OF_PAYMENT.ToNZString());
            cboTermOfPayment.LoadLookupData(termOfPayment);
            cboTermOfPayment.SelectedIndex = -1;

            LookupData InvoicePattern = biz.LoadLookupClassType(DataDefine.INVOICE_PATTERN.ToNZString());
            cboInvoicePattern.LoadLookupData(InvoicePattern);
            cboInvoicePattern.SelectedIndex = -1;
            

            LookupData lookupData2 = biz.LoadLookupClassType(DataDefine.MRP_LOCATION.ToNZString());
        }

        private void ClearControls()
        {
            dmcLocation.LoadData(new DealingUIDM());
            CommonLib.CtrlUtil.ClearControlData(txtAddr1Address1, txtAddr1Address2, txtAddr1Address3,
                                                txtAddr2Address1, txtAddr2Address2, txtAddr2Address3,
                                                txtAddr3Address1, txtAddr3Address2, txtAddr3Address3);
        }
        #endregion

        #region Form events
        private void MAS020_LocationMaster_Load(object sender, EventArgs e)
        {
            if (m_screenMode == eMode.EDIT)
            {
                DealingUIDM model = m_locationController.LoadLocation(m_locationCode.ToNZString());
                dmcLocation.LoadData(model);

                string[] Address1Line = model.ADDRESS1.StrongValue.Split(new string[] { System.Environment.NewLine } , StringSplitOptions.None);
                if (Address1Line.Length > 0)
                    txtAddr1Address1.Text = Address1Line[0];
                if (Address1Line.Length > 1)
                    txtAddr1Address2.Text = Address1Line[1];
                if (Address1Line.Length > 2)
                    txtAddr1Address3.Text = Address1Line[2];

                string[] Address2Line = model.ADDRESS2.StrongValue.Split(new string[] { System.Environment.NewLine }, StringSplitOptions.None);
                if (Address2Line.Length > 0)
                    txtAddr2Address1.Text = Address2Line[0];
                if (Address2Line.Length > 1)
                    txtAddr2Address2.Text = Address2Line[1];
                if (Address2Line.Length > 2)
                    txtAddr2Address3.Text = Address2Line[2];

                string[] Address3Line = model.ADDRESS3.StrongValue.Split(new string[] { System.Environment.NewLine }, StringSplitOptions.None);
                if (Address3Line.Length > 0)
                    txtAddr3Address1.Text = Address3Line[0];
                if (Address3Line.Length > 1)
                    txtAddr3Address2.Text = Address3Line[1];
                if (Address3Line.Length > 2)
                    txtAddr3Address3.Text = Address3Line[2];

            }
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

            DealingUIDM model = dmcLocation.SaveData(new DealingUIDM());
            string ADDRESS01 = txtAddr1Address1.Text + System.Environment.NewLine + txtAddr1Address2.Text + System.Environment.NewLine + txtAddr1Address3.Text;
            model.ADDRESS1 = ADDRESS01.ToNZString();
            string ADDRESS02 = txtAddr2Address1.Text + System.Environment.NewLine + txtAddr2Address2.Text + System.Environment.NewLine + txtAddr2Address3.Text;
            model.ADDRESS2 = ADDRESS02.ToNZString();
            string ADDRESS03 = txtAddr3Address1.Text + System.Environment.NewLine + txtAddr3Address2.Text + System.Environment.NewLine + txtAddr3Address3.Text;
            model.ADDRESS3 = ADDRESS03.ToNZString();          
            try
            {
                DealingValidator validator = new DealingValidator();
                // Mandatory check
                #region
                ErrorItem errorItem = null;
                errorItem = validator.CheckEmptyLocationCode(new NZString(txtDealingCode, txtDealingCode.Text));
                if (null != errorItem) ValidateException.ThrowErrorItem(errorItem);

                errorItem = validator.CheckEmptyLocationName(new NZString(txtDealingName, txtDealingName.Text));
                if (null != errorItem) ValidateException.ThrowErrorItem(errorItem);

                errorItem = validator.CheckEmptyLocationType(new NZString(cboDealingType, cboDealingType.SelectedValue));
                if (null != errorItem) ValidateException.ThrowErrorItem(errorItem);

                //errorItem = validator.CheckEmptyTermOfPayment(new NZString(cboTermOfPayment, cboTermOfPayment.SelectedValue));
                //if (null != errorItem) ValidateException.ThrowErrorItem(errorItem);

                errorItem = validator.CheckInvoicePattern(new NZString(cboInvoicePattern, cboInvoicePattern.SelectedValue), new NZString(cboDealingType, cboDealingType.SelectedValue));
                if (null != errorItem) ValidateException.ThrowErrorItem(errorItem);
                #endregion

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
                    m_locationController.SaveNew(model);
                else
                    m_locationController.SaveUpdate(model);

                m_dummyDialogResult = DialogResult.OK;

                ClearControls();


                m_locationCode = null;
                InitializeScreenMode();

                CtrlUtil.FocusControl(txtDealingCode);
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
            DealingUIDM model = dmcLocation.SaveData(new DealingUIDM());
            string ADDRESS01 = txtAddr1Address1.Text + System.Environment.NewLine + txtAddr1Address2.Text + System.Environment.NewLine + txtAddr1Address3.Text;
            model.ADDRESS1 = ADDRESS01.ToNZString();
            string ADDRESS02 = txtAddr2Address1.Text + System.Environment.NewLine + txtAddr2Address2.Text + System.Environment.NewLine + txtAddr2Address3.Text;
            model.ADDRESS2 = ADDRESS02.ToNZString();
            string ADDRESS03 = txtAddr3Address1.Text + System.Environment.NewLine + txtAddr3Address2.Text + System.Environment.NewLine + txtAddr3Address3.Text;
            model.ADDRESS3 = ADDRESS03.ToNZString();
            try
            {
                DealingValidator validator = new DealingValidator();
                // Mandatory check
                #region
                ErrorItem errorItem = null;
                errorItem = validator.CheckEmptyLocationCode(new NZString(txtDealingCode, txtDealingCode.Text));
                if (null != errorItem) ValidateException.ThrowErrorItem(errorItem);

                errorItem = validator.CheckEmptyLocationName(new NZString(txtDealingName, txtDealingName.Text));
                if (null != errorItem) ValidateException.ThrowErrorItem(errorItem);

                errorItem = validator.CheckEmptyLocationType(new NZString(cboDealingType, cboDealingType.SelectedValue));
                if (null != errorItem) ValidateException.ThrowErrorItem(errorItem);

                errorItem = validator.CheckEmptyTermOfPayment(new NZString(cboTermOfPayment, cboTermOfPayment.SelectedValue));
                if (null != errorItem) ValidateException.ThrowErrorItem(errorItem);

                errorItem = validator.CheckInvoicePattern(new NZString(cboInvoicePattern, cboInvoicePattern.SelectedValue), new NZString(cboDealingType, cboDealingType.SelectedValue));
                if (null != errorItem) ValidateException.ThrowErrorItem(errorItem);
                #endregion

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
                    m_locationController.SaveNew(model);
                else
                    m_locationController.SaveUpdate(model);

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
