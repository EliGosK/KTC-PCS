using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using EVOFramework.Windows.Forms;
using Rubik.DTO;
using Rubik.BIZ;
using EVOFramework;
using EVOFramework.Data;
using CommonLib;
using Rubik.UIDataModel;
using Rubik.Controller;
using SystemMaintenance;
using Message = EVOFramework.Message;
using Rubik.Forms.FindDialog;
using Rubik.Validators;

namespace Rubik.Transaction
{
    [Screen("TRN120", "Adjust Entry", eShowAction.Normal, eScreenType.Screen, "Adjust Entry")]
    public partial class TRN120 : SystemMaintenance.Forms.CustomizeForm
    {
        #region Enum

        public enum eScreenMode
        {
            VIEW,
            ADD,
            EDIT
        }
        #endregion

        #region Variables
        private DealingConstraintBIZ bizConstraint = new DealingConstraintBIZ();
        private readonly AdjustmentEntryController m_controller = new AdjustmentEntryController();
        private NZString m_editTransactionID = null;
        private eScreenMode m_screenMode = eScreenMode.ADD;
        private TransactionValidator m_transactionValidator = new TransactionValidator();
        private bool m_isSelected = false;
        #endregion

        #region Constructor
        public TRN120()
        {
            InitializeComponent();

            DialogResult = DialogResult.Cancel;
        }

        public TRN120(NZString transactionID)
        {
            InitializeComponent();

            m_editTransactionID = transactionID;
            DialogResult = DialogResult.Cancel;
        }

        public bool IsSelected
        {
            get { return m_isSelected; }
        }

        #endregion

        #region Initialize Screen
        private void InitializeScreen()
        {
            if (DesignMode)
                return;

            dtAdjustDate.KeyPress += CtrlUtil.SetNextControl;
            //rdoIncrease.KeyPress += CtrlUtil.SetNextControl;
            //rdoDecrease.KeyPress += CtrlUtil.SetNextControl;
            cboReasonCode.KeyPress += CtrlUtil.SetNextControl;
            txtMasterNo.KeyPress += CtrlUtil.SetNextControl;
            txtItemDesc.KeyPress += CtrlUtil.SetNextControl;
            txtCustomerName.KeyPress += CtrlUtil.SetNextControl;
            cboStoredLoc.KeyPress += CtrlUtil.SetNextControl;
            txtPackNo.KeyPress += CtrlUtil.SetNextControl;
            txtFGNo.KeyPress += CtrlUtil.SetNextControl;
            txtLotNo.KeyPress += CtrlUtil.SetNextControl;
            txtCustomerLotNo.KeyPress += CtrlUtil.SetNextControl;
            txtAdjustQty.KeyPress += CtrlUtil.SetNextControl;
            //txtAdjustWeight.KeyPress += CtrlUtil.SetNextControl;
            txtRemark.KeyPress += CtrlUtil.SetNextControl;

            btnItemCode.Click += btnItemCode_Click;

            dtAdjustDate.Format = Common.CurrentUserInfomation.DateFormatString;

            CtrlUtil.EnabledControl(false, cboInventoryUM);

            FormatUtil.SetNumberFormat(this.txtOnhandQty, FormatUtil.eNumberFormat.Qty_PCS);
            FormatUtil.SetNumberFormat(this.txtAdjustQty, FormatUtil.eNumberFormat.Qty_Adjust_PCS);
            FormatUtil.SetNumberFormat(this.txtAdjustWeight, FormatUtil.eNumberFormat.Qty_Adjust_KG);

            InitializeComboBox();

            InitializeControlBinding();

            InitializeScreenMode();

            CheckCurrentInvPeriod();
        }

        private void InitializeScreenMode()
        {
            if (m_editTransactionID == null)
            {
                SetScreenMode(eScreenMode.ADD);

                AdjustmentEntryUIDM model = new AdjustmentEntryUIDM();
                model.TransactionID.Value = "";
                dmcAdjust.LoadData(model);

                SysConfigBIZ sysBiz = new SysConfigBIZ();
                SysConfigDTO argScreenInfo = new SysConfigDTO();
                argScreenInfo.SYS_GROUP_ID = DataDefine.eSYSTEM_CONFIG.TRN120.SYS_GROUP_ID;
                argScreenInfo.SYS_KEY = (NZString)DataDefine.eSYSTEM_CONFIG.TRN120.SYS_KEY.DEFAULT_DATE.ToString();
                dtAdjustDate.Value = sysBiz.GetDefaultDateForScreen(argScreenInfo);
            }
            else
            {
                bool bCanEdit = m_transactionValidator.TransactionCanEditOrDelete(m_editTransactionID);

                if (bCanEdit)
                {
                    SetScreenMode(eScreenMode.EDIT);
                }
                else
                {
                    SetScreenMode(eScreenMode.VIEW);
                }


                AdjustmentEntryUIDM model = m_controller.LoadData(m_editTransactionID);
                //if (model.AdjustType.StrongValue == DataDefine.Convert2ClassCode(DataDefine.eIN_OUT_CLASS.Out)) {
                //    model.OnHandQty.Value = model.OnHandQty.StrongValue + model.AdjustQty.StrongValue;
                //}

                dmcAdjust.LoadData(model);
                LoadInventoryUM(model.ItemCode);
                UpdateOnhandQtyText();
            }
        }
        private void InitializeComboBox()
        {
            LookupDataBIZ bizLookupData = new LookupDataBIZ();

            cboStoredLoc.Format += Common.ComboBox_Format;
            cboInventoryUM.Format += Common.ComboBox_Format;

            cboReasonCode.Format += Common.ComboBox_Format;

            NZString[] locationtype = new NZString[1];
            locationtype[0] = DataDefine.Convert2ClassCode(DataDefine.eLOCATION_CLS.Production).ToNZString();
            LookupData locationLookup = bizLookupData.LoadLookupLocation(locationtype);
            cboStoredLoc.LoadLookupData(locationLookup);

            // Lookup Inventory U/M
            LookupData lookupInventoryUM = bizLookupData.LoadLookupClassType(new NZString(null, DataDefine.UM_CLS));
            cboInventoryUM.LoadLookupData(lookupInventoryUM);

            // Lookup Reason code
            LookupData lookupReason = bizLookupData.LoadLookupClassType(new NZString(null, DataDefine.ADJ_SUBTYPE));
            cboReasonCode.LoadLookupData(lookupReason);

            cboReasonCode.SelectedIndex = -1;
            cboInventoryUM.SelectedIndex = -1;
            cboStoredLoc.SelectedIndex = -1;
        }
        private void InitializeControlBinding()
        {
            dmcAdjust.AddRangeControl(
                lblAdjustNo,
                dtAdjustDate,
                rdoIncrease,
                rdoDecrease,
                txtMasterNo,
                txtItemDesc,
                txtCustomerName,
                cboStoredLoc,
                txtPackNo,
                txtFGNo,
                txtLotNo,
                txtCustomerLotNo,
                txtOnhandQty,
                txtAdjustWeight,
                txtAdjustQty,
                txtRemark,
                cboReasonCode,
                hiddenTransID
                );
        }
        #endregion

        #region Screen Mode
        private void SetScreenMode(eScreenMode mode)
        {
            switch (mode)
            {
                case eScreenMode.VIEW:
                    CtrlUtil.EnabledControl(false, txtAdjustWeight, txtAdjustQty, txtItemDesc);
                    CtrlUtil.EnabledControl(false, dtAdjustDate, rdoIncrease, rdoDecrease, txtMasterNo, txtItemDesc
                        , btnItemCode, cboStoredLoc, txtLotNo, btnLotNo, txtPackNo, txtFGNo, txtCustomerLotNo
                        , txtRemark, cboReasonCode);
                    CtrlUtil.EnabledControl(false, txtCustomerName, txtOnhandQty);

                    tsbSaveAndNew.Enabled = false;
                    tsbSaveAndClose.Enabled = false;
                    break;
                case eScreenMode.ADD:
                    CtrlUtil.EnabledControl(true, dtAdjustDate, rdoIncrease, rdoDecrease, txtMasterNo, txtItemDesc
                        , btnItemCode, cboStoredLoc, txtAdjustWeight, txtAdjustQty
                        , txtRemark, cboReasonCode);
                    CtrlUtil.EnabledControl(false, txtLotNo, btnLotNo, txtPackNo, txtItemDesc, txtFGNo, txtCustomerLotNo);
                    CtrlUtil.EnabledControl(false, txtCustomerName, txtOnhandQty);

                    SysConfigBIZ sysBiz = new SysConfigBIZ();
                    SysConfigDTO argScreenInfo = new SysConfigDTO();
                    argScreenInfo.SYS_GROUP_ID = DataDefine.eSYSTEM_CONFIG.TRN120.SYS_GROUP_ID;
                    argScreenInfo.SYS_KEY = (NZString)DataDefine.eSYSTEM_CONFIG.TRN120.SYS_KEY.DEFAULT_DATE.ToString();
                    dtAdjustDate.Value = sysBiz.GetDefaultDateForScreen(argScreenInfo);

                    break;
                case eScreenMode.EDIT:
                    CtrlUtil.EnabledControl(true, txtAdjustWeight, txtAdjustQty, txtRemark, cboReasonCode);
                    CtrlUtil.EnabledControl(false, dtAdjustDate, rdoIncrease, rdoDecrease, txtMasterNo, txtItemDesc,
                                            btnItemCode, cboStoredLoc, txtItemDesc, txtOnhandQty);
                    CtrlUtil.EnabledControl(false, txtPackNo, txtFGNo, txtLotNo, btnLotNo, txtCustomerLotNo);
                    CtrlUtil.EnabledControl(false, txtCustomerName, txtOnhandQty);

                    break;
            }

            m_screenMode = mode;
        }
        #endregion

        #region Private method
        private void UpdateOnhandQtyText()
        {

            NZDecimal onhand = m_controller.GetOnhandQty(
                dtAdjustDate.NZValue,
                txtMasterNo.Text.ToNZString(),
                new NZString(null, cboStoredLoc.SelectedValue),
                new NZString(null, txtLotNo.Text.Trim()));

            if (m_screenMode == eScreenMode.EDIT)
            {
                AdjustmentEntryUIDM model = m_controller.LoadData(m_editTransactionID);
                if (model.AdjustType.StrongValue == DataDefine.Convert2ClassCode(DataDefine.eIN_OUT_CLASS.Out))
                {

                    InventoryTransBIZ biz = new InventoryTransBIZ();
                    onhand.Value = onhand.StrongValue + biz.LoadByTransactionID(m_editTransactionID).QTY.StrongValue;
                }
            }

            txtOnhandQty.PathValue = onhand.NVL(0);
        }
        private void ClearAll()
        {
            lblAdjustNo.Text = string.Empty;

            CtrlUtil.ClearControlData(
                dtAdjustDate,
                txtMasterNo,
                txtItemDesc,
                txtCustomerName,
                cboStoredLoc,
                txtLotNo,
                txtPackNo,
                txtFGNo,
                txtCustomerLotNo,
                txtOnhandQty,
                txtAdjustWeight,
                txtAdjustQty,
                txtRemark,
                cboInventoryUM,
                cboReasonCode,
                hiddenTransID//,
                //lblAdjustNo
                );

            rdoIncrease.Checked = true;
        }

        private void ClearAllExceptDefault()
        {
            lblAdjustNo.Text = string.Empty;

            CtrlUtil.ClearControlData(
                //lblAdjustNo,
                txtMasterNo,
                txtItemDesc,
                txtCustomerName,
                cboStoredLoc,
                txtLotNo,
                txtPackNo,
                txtFGNo,
                txtCustomerLotNo,
                txtOnhandQty,
                txtAdjustWeight,
                txtAdjustQty,
                txtRemark,
                cboInventoryUM,
                cboReasonCode

                );

            rdoIncrease.Checked = true;
        }

        private void EnableLotControl() 
        {
            //Clear Lot
            CtrlUtil.ClearControlData(txtPackNo, txtLotNo, txtCustomerLotNo, txtFGNo);

            if (cboStoredLoc.SelectedIndex < 0)
                return;

            //----- Enable Customer Lot No ------//
            DealingConstraintDTO constriant = null;

            string strProcess = cboStoredLoc.SelectedValue.ToString();
            constriant = bizConstraint.LoadDealingConstraint(strProcess.ToNZString());

            if (constriant != null && constriant.ENABLE_LOT_FLAG.StrongValue == 1) 
            {
                CtrlUtil.EnabledControl(rdoIncrease.Checked, txtLotNo, txtCustomerLotNo, txtFGNo);
                CtrlUtil.EnabledControl(true, btnLotNo);                
            }
            else 
            {
                CtrlUtil.EnabledControl(false, txtLotNo, btnLotNo, txtCustomerLotNo, txtFGNo);                
            }
        }


        private void LoadInventoryUM(NZString ItemCD)
        {
            ItemBIZ biz = new ItemBIZ();
            ItemDTO dto = biz.LoadItem(ItemCD);
            //if (dto != null) cboInventoryUM.SelectedValue = dto.INV_UM_CLS.StrongValue;
            //else cboInventoryUM.SelectedIndex = -1;
        }
        #endregion

        #region Form event
        private void TRN120_Load(object sender, EventArgs e)
        {
            InitializeScreen();
        }

        private void TRN120_Shown(object sender, EventArgs e)
        {
            if (m_screenMode == eScreenMode.ADD)
                CtrlUtil.FocusControl(dtAdjustDate);
            else
            {
                CtrlUtil.FocusControl(txtAdjustQty);
            }
        }
        #endregion

        #region Overriden method
        public override void OnSaveAndNew()
        {
            base.OnSaveAndNew();

            try
            {

                UpdateOnhandQtyText();


                ValidateBeforeSave();

                MessageDialogResult dr = MessageDialog.ShowConfirmation(this, Message.LoadMessage(Messages.eConfirm.CFM9001.ToString()));
                if (dr == MessageDialogResult.Cancel || dr == MessageDialogResult.No)
                {
                    return;
                }

                if (dr == MessageDialogResult.Yes)
                {

                    AdjustmentEntryUIDM model = dmcAdjust.SaveData(new AdjustmentEntryUIDM());

                    if (m_screenMode == eScreenMode.ADD)
                    {
                        m_controller.SaveAdd(model);
                        ClearAllExceptDefault();
                    }
                    else
                    {
                        m_controller.SaveEdit(m_editTransactionID, model);
                        ClearAll();
                    }


                    MessageDialog.ShowInformation(this, null, new Message(Messages.eInformation.INF9003.ToString()).MessageDescription);

                }

                m_editTransactionID = null;
                SetScreenMode(eScreenMode.ADD);

                m_isSelected = true;



                CtrlUtil.FocusControl(dtAdjustDate);

            }
            catch (ValidateException err)
            {
                MessageDialog.ShowBusiness(this, err.ErrorResults[0].Message);
                err.ErrorResults[0].FocusOnControl();
            }
            catch (BusinessException err)
            {
                MessageDialog.ShowBusiness(this, err.Error.Message);
                err.Error.FocusOnControl();
            }
            catch (Exception err)
            {
                MessageDialog.ShowBusiness(this, null, err.Message);
            }
            finally
            {
                if (Common.CurrentDatabase.DBConnectionState == ConnectionState.Open)
                    Common.CurrentDatabase.Close();
            }
        }

        public override void OnSaveAndClose()
        {
            base.OnSaveAndClose();
            try
            {


                UpdateOnhandQtyText();

                ValidateBeforeSave();

                MessageDialogResult dr = MessageDialog.ShowConfirmation(this, Message.LoadMessage(Messages.eConfirm.CFM9001.ToString()));
                if (dr == MessageDialogResult.Cancel || dr == MessageDialogResult.No)
                {
                    return;
                }

                if (dr == MessageDialogResult.Yes)
                {

                    AdjustmentEntryUIDM model = dmcAdjust.SaveData(new AdjustmentEntryUIDM());

                    if (m_screenMode == eScreenMode.ADD)
                        m_controller.SaveAdd(model);
                    else
                    {
                        m_controller.SaveEdit(m_editTransactionID, model);
                    }
                }

                MessageDialog.ShowInformation(this, null, new Message(Messages.eInformation.INF9003.ToString()).MessageDescription);

                m_isSelected = true;



                this.Close();
            }
            catch (ValidateException err)
            {

                MessageDialog.ShowBusiness(this, err.ErrorResults[0].Message);

            }
            catch (BusinessException err)
            {

                MessageDialog.ShowBusiness(this, err.Error.Message);
            }
            catch (Exception err)
            {

                MessageDialog.ShowBusiness(this, null, err.Message);
            }

        }

        #endregion

        #region Control event
        private void txtItemCode_KeyPressResult(object sender, bool isFound, NZString ItemCD)
        {
            UpdateOnhandQtyText();
        }

        //private void cboStoredLoc_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        //{
        //    if (e.KeyChar == '\r')
        //    {
        //        UpdateOnhandQtyText();
        //    }
        //}              

        private void txtLotNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
                UpdateOnhandQtyText();
        }

        private void btnLotNo_Click(object sender, EventArgs e)
        {
            NZString locCD = new NZString(null, cboStoredLoc.SelectedValue);
            LotNoFindDialog dialog = new LotNoFindDialog(txtMasterNo.Text.ToNZString(), locCD);

            dialog.ShowDialog(this);
            if (dialog.IsSelected)
            {
                txtLotNo.Text = dialog.SelectedLotNo.NVL(string.Empty);
                txtPackNo.Text = dialog.SelectedPackNo.NVL(string.Empty);
                txtCustomerLotNo.Text = dialog.SelectedExternalLotNo.NVL(string.Empty);
                txtFGNo.Text = dialog.SelectedFGNo.NVL(string.Empty);

                txtLotNo_KeyPress(txtLotNo, new KeyPressEventArgs((char)Keys.Return));
            }

        }

        private void txtItemCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != (char)Keys.Return)
                return;

            //if (txtItemCode.SelectedItemData != null)
            //    cboInventoryUM.SelectedValue = txtItemCode.SelectedItemData.INV_UM_CLS.StrongValue;
            //else
            //    cboInventoryUM.SelectedIndex = -1;
        }

        private void btnItemCode_Click(object sender, EventArgs e)
        {
            txtItemCode_KeyPress(txtMasterNo, new KeyPressEventArgs((char)Keys.Return));
        }

        private void cboStoredLoc_SelectedValueChanged(object sender, EventArgs e)
        {
            if (this.m_screenMode == eScreenMode.EDIT) return;

            UpdateOnhandQtyText();

            txtAdjustWeight_Validating(this, new CancelEventArgs());

            EnableLotControl();

            //if (cboStoredLoc.SelectedIndex < 0)
            //    return;

            ////----- Enable Customer Lot No ------//
            //DealingConstraintDTO constriant = null;

            //string strProcess = cboStoredLoc.SelectedValue.ToString();
            //constriant = bizConstraint.LoadDealingConstraint(strProcess.ToNZString());

            //if (constriant != null && constriant.ENABLE_LOT_FLAG.StrongValue == 1)
            //{                
            //    CtrlUtil.EnabledControl(rdoIncrease.Checked, txtLotNo, txtCustomerLotNo);
            //    CtrlUtil.EnabledControl(true, btnLotNo);
            //}
            //else
            //{
            //    CtrlUtil.EnabledControl(false, txtLotNo, btnLotNo, txtCustomerLotNo);
            //    CtrlUtil.ClearControlData(txtLotNo, txtCustomerLotNo);
            //}

            //if (constriant != null && constriant.ENABLE_PACK_FLAG.StrongValue == 1)
            //{
            //    CtrlUtil.EnabledControl(true, txtPackNo);
            //}
            //else
            //{
            //    CtrlUtil.EnabledControl(false, txtPackNo);
            //    CtrlUtil.ClearControlData(txtPackNo);
            //}

        }

        private void rdoIncrease_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
                CtrlUtil.FocusControl(txtMasterNo);
        }

        private void txtItemDesc_Validating(object sender, CancelEventArgs e)
        {
            if (string.Empty.Equals(txtItemDesc.Text.Trim()))
                return;

            try
            {
                ItemBIZ biz = new ItemBIZ();
                ItemDescriptionDTO dto = biz.LoadItemDescription(new NZString(), txtItemDesc.Text.Trim().ToNZString());
                if (dto == null)
                {
                    ErrorItem errorItem = new ErrorItem(txtItemDesc, TKPMessages.eValidate.VLM0009.ToString());
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
        #endregion

        #region Check Inventory Period
        private void CheckCurrentInvPeriod()
        {

            try
            {
                InventoryPeriodValidator val = new InventoryPeriodValidator();
                ErrorItem err = val.CheckInventoryCurrentPeriod();
                if (err != null)
                {
                    MessageDialog.ShowInformation(this, "Out of period", err.Message.MessageDescription);
                }

            }
            catch (Exception)
            {

            }
        }
        #endregion

        private void txtAdjustWeight_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (string.Empty.Equals(txtAdjustWeight.Text.Trim()))
                    return;

                ItemBIZ biz = new ItemBIZ();

                ItemWeightDTO dto = biz.ConvertKGtoPCS(new NZString(txtMasterNo, txtMasterNo.Text.Trim()),
                                    new NZString(cboStoredLoc, cboStoredLoc.SelectedValue),
                                    new NZDecimal(txtAdjustWeight, txtAdjustWeight.Text.Trim()),
                                    new NZInt(null, 1));
                txtAdjustQty.Text = dto.QtyPCS == null ? string.Empty : dto.QtyPCS.ToString();

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

        private void txtAdjustQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                txtAdjustWeight.Clear();
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

        private void txtLotNo_Validating(object sender, CancelEventArgs e)
        {
            string strLotNo = txtLotNo.Text.Trim();
            if (string.Empty.Equals(strLotNo))
                return;

            try
            {
                FormatUtil.CheckFormatLotNo(new NZString(txtLotNo, strLotNo));
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

        private void txtAdjustWeight_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                if (string.Empty.Equals(txtAdjustWeight.Text))
                    CtrlUtil.FocusControl(txtAdjustQty);
                else
                    CtrlUtil.FocusControl(txtRemark);
            }
        }


        private void ValidateBeforeSave()
        {
            AdjustmentValidator adjustmentValidator = new AdjustmentValidator();
            ItemValidator itemValidator = new ItemValidator();
            DealingValidator locationValidator = new DealingValidator();
            TransactionValidator valTran = new TransactionValidator();
            CommonBizValidator commonVal = new CommonBizValidator();

            ValidateException.ThrowErrorItem(adjustmentValidator.CheckEmptyAdjustDate(new NZDateTime(dtAdjustDate, dtAdjustDate.Value)));
            ValidateException.ThrowErrorItem(adjustmentValidator.CheckEmptyReasonCode(new NZString(cboReasonCode, cboReasonCode.SelectedValue)));
            ValidateException.ThrowErrorItem(valTran.DateIsInCurrentPeriod(new NZDateTime(dtAdjustDate, dtAdjustDate.Value)));
            ValidateException.ThrowErrorItem(itemValidator.CheckEmptyItemCode(new NZString(txtMasterNo, txtMasterNo.Text.Trim())));
            ValidateException.ThrowErrorItem(locationValidator.CheckEmptyLocationCode(new NZString(cboStoredLoc, cboStoredLoc.SelectedValue)));
                  
            if (cboStoredLoc.SelectedValue == null)
                return;

            string strProcess = cboStoredLoc.SelectedValue.ToString();
            DealingConstraintDTO constriant = bizConstraint.LoadDealingConstraint(strProcess.ToNZString());

            AdjustmentValidator validator = new AdjustmentValidator();
            ErrorItem errorItem = null;

            //if (constriant != null && constriant.ENABLE_PACK_FLAG.StrongValue == 1)
            //{
            //    errorItem = validator.CheckEmptyPackNo(txtPackNo.ToNZString());
            //    if (null != errorItem)
            //        ValidateException.ThrowErrorItem(errorItem);//error.AddError(errorItem);
            //}

            if (rdoDecrease.Checked && constriant != null && constriant.ENABLE_PACK_FLAG.StrongValue == 1) 
            {
                errorItem = validator.CheckEmptyPackNo(txtPackNo.ToNZString());
                if (null != errorItem)
                    ValidateException.ThrowErrorItem(errorItem);
            }

            if (constriant != null && constriant.ENABLE_LOT_FLAG.StrongValue == 1)
            {
                errorItem = validator.CheckEmptyLotNo(txtLotNo.ToNZString());
                if (null != errorItem)
                    ValidateException.ThrowErrorItem(errorItem);//error.AddError(errorItem);

                FormatUtil.CheckFormatLotNo(new NZString(txtLotNo, txtLotNo.Text.Trim()));

                //errorItem = validator.CheckEmptyCustomerLotNo(txtCustomerLotNo.ToNZString());
                //if (null != errorItem)
                //    ValidateException.ThrowErrorItem(errorItem);//error.AddError(errorItem);
            }

            ValidateException.ThrowErrorItem(adjustmentValidator.CheckEmptyAdjustQty(new NZDecimal(txtAdjustQty, txtAdjustQty.Decimal)));
            ValidateException.ThrowErrorItem(adjustmentValidator.CheckIsZeroAdjustQty(new NZDecimal(txtAdjustQty, txtAdjustQty.Decimal)));


        }

        private void rdo_CheckedChanged(object sender, EventArgs e) 
        {
            EnableLotControl();            
        }

        private void txtMasterNo_Validating(object sender, CancelEventArgs e) 
        {
            if (string.Empty.Equals(txtMasterNo.Text.Trim())) 
            {
                txtOnhandQty.Decimal = 0;
                txtAdjustQty.Decimal = !(string.Empty.Equals(txtAdjustWeight.Text.Trim())) ? 0 : txtAdjustQty.Decimal;
            }
            else 
            {
                txtAdjustWeight_Validating(this, new CancelEventArgs());
            }
        }

        private void cboStoredLoc_TextChanged(object sender, EventArgs e) 
        {
            if (string.Empty.Equals(cboStoredLoc.Text)) 
            {
                txtOnhandQty.Decimal = 0;
                txtAdjustQty.Decimal = !(string.Empty.Equals(txtAdjustWeight.Text.Trim())) ? 0 : txtAdjustQty.Decimal;

                //Clear Lot
                CtrlUtil.ClearControlData(txtPackNo, txtLotNo, txtCustomerLotNo, txtFGNo);
                CtrlUtil.EnabledControl(false, txtLotNo, btnLotNo, txtCustomerLotNo, txtFGNo);  
            }
        }        
    }
}
