using System;
using SystemMaintenance;
using EVOFramework;
using EVOFramework.Data;
using EVOFramework.Windows.Forms;
using Rubik.BIZ;
using Rubik.Controller;
using Rubik.UIDataModel;
using Rubik.Validators;
using System.Windows.Forms;
using Rubik.DTO;
using Rubik.Forms.FindDialog;

namespace Rubik.Transaction
{
    //[Screen("TRN040", "Issue By Item", eShowAction.Normal, eScreenType.Screen, "Issue By Item")]
    public partial class TRN040 : SystemMaintenance.Forms.CustomizeForm
    {
        #region Enum

        private enum eSaveMode
        {
            ADD, UPDATE, VIEW
        }

        #endregion

        #region Variable

        private eSaveMode m_Mode = eSaveMode.ADD;
        private IssueByItemUIDM m_uidm;
        private string m_REF_NO = string.Empty;
        #endregion

        #region Contructor

        public TRN040()
        {
            InitializeComponent();
        }

        public TRN040(IssueByItemUIDM uidm, bool CanEdit)
        {
            InitializeComponent();
            if (CanEdit)
            {
                m_Mode = eSaveMode.UPDATE;
            }
            else
            {
                m_Mode = eSaveMode.VIEW;
            }
            m_uidm = uidm;
        }

        #endregion

        #region Overriden Method

        public override void OnSaveAndNew()
        {
            if (CheckMandatory())
            {
                MessageDialogResult dr = MessageDialog.ShowConfirmation(this, new EVOFramework.Message(Messages.eConfirm.CFM9001.ToString()));
                if (dr == MessageDialogResult.Cancel)
                    return;

                if (dr == MessageDialogResult.No)
                    Close();

                if (dr == MessageDialogResult.Yes)
                {
                    if (SaveData())
                    {
                        MessageDialog.ShowInformation(this, null, new EVOFramework.Message(Messages.eInformation.INF9003.ToString()).MessageDescription);


                        CommonLib.CtrlUtil.EnabledControl(true, txtItemCode, btnItemCode, cboFromLoc, cboToLoc, txtLotNo
                    , dtIssueDate, txtRemark);
                        ClearAllExceptDefaultValue();
                    }

                }

            }
        }
        public override void OnSaveAndClose()
        {
            if (CheckMandatory())
            {
                MessageDialogResult dr = MessageDialog.ShowConfirmation(this, new EVOFramework.Message(Messages.eConfirm.CFM9001.ToString()));
                if (dr == MessageDialogResult.Cancel)
                    return;

                if (dr == MessageDialogResult.No)
                    Close();

                if (dr == MessageDialogResult.Yes)
                {
                    if (SaveData())
                    {
                        MessageDialog.ShowInformation(this, null, new EVOFramework.Message(Messages.eInformation.INF9003.ToString()).MessageDescription);

                        Close();
                    }
                }
            }
        }

        #endregion

        #region Private Method

        private void InitialScreen()
        {
            CheckCurrentInvPeriod();
            InitialComboBox();

            CommonLib.CtrlUtil.EnabledControl(false, txtTransactionID, txtOnHandQty, txtItemDesc, cboInventoryUM);

            dtIssueDate.Format = CommonLib.Common.CurrentUserInfomation.DateFormatString;

            //dtIssueDate.KeyPress += CommonLib.CtrlUtil.SetNextControl;
            cboFromLoc.KeyPress += CommonLib.CtrlUtil.SetNextControl;
            cboToLoc.KeyPress += CommonLib.CtrlUtil.SetNextControl;
            txtLotNo.KeyPress += CommonLib.CtrlUtil.SetNextControl;
            txtIssueQty.KeyPress += CommonLib.CtrlUtil.SetNextControl;
            //txtRemark.KeyPress += CommonLib.CtrlUtil.SetNextControl;
            cboSubType.KeyPress += CommonLib.CtrlUtil.SetNextControl;
            txtRefDocNo.KeyPress += CommonLib.CtrlUtil.SetNextControl;
            txtJobOrderNo.KeyPress += CommonLib.CtrlUtil.SetNextControl;
            txtForMachine.KeyPress += CommonLib.CtrlUtil.SetNextControl;
            cboForCustomer.KeyPress += CommonLib.CtrlUtil.SetNextControl;
            txtItemCode.KeyPress += CommonLib.CtrlUtil.SetNextControl;

            //txtLotNo.KeyDown += CommonLib.CtrlUtil.SetHelpButton;

            dmcIssueByItem.AddControl(txtTransactionID);
            //dmcIssueByItem.AddControl(txtRefTransID);
            dmcIssueByItem.AddControl(txtItemDesc);
            dmcIssueByItem.AddControl(txtItemCode);
            dmcIssueByItem.AddControl(cboToLoc);
            dmcIssueByItem.AddControl(txtLotNo);
            dmcIssueByItem.AddControl(cboFromLoc);
            dmcIssueByItem.AddControl(txtOnHandQty);
            dmcIssueByItem.AddControl(txtIssueQty);
            dmcIssueByItem.AddControl(txtRemark);
            // dmcIssueByItem.AddControl(rdoIssueType_Issue);
            // dmcIssueByItem.AddControl(rdoIssueType_IssueReturn);
            dmcIssueByItem.AddControl(dtIssueDate);

            dmcIssueByItem.AddControl(cboSubType);
            dmcIssueByItem.AddControl(txtRefDocNo);
            dmcIssueByItem.AddControl(txtJobOrderNo);
            dmcIssueByItem.AddControl(txtForMachine);
            dmcIssueByItem.AddControl(cboForCustomer);

            ClearAll();
            // rdoIssueType_Issue.Checked = true;


            if (m_Mode == eSaveMode.ADD)
            {
                SysConfigBIZ sysBiz = new SysConfigBIZ();
                SysConfigDTO argScreenInfo = new SysConfigDTO();
                argScreenInfo.SYS_GROUP_ID = DataDefine.eSYSTEM_CONFIG.TRN040.SYS_GROUP_ID;
                argScreenInfo.SYS_KEY = (NZString)DataDefine.eSYSTEM_CONFIG.TRN040.SYS_KEY.DEFAULT_DATE.ToString();
                dtIssueDate.Value = sysBiz.GetDefaultDateForScreen(argScreenInfo);
            }
            else if (m_Mode == eSaveMode.UPDATE)
            {

                LoadInventoryUM(m_uidm.ITEM_CD);
                dmcIssueByItem.LoadData(m_uidm);
                LoadLotNo(m_uidm.ITEM_CD, m_uidm.FROM_LOC_CD);
                //txtLotNo.SelectedValue = m_uidm.LOT_NO.StrongValue;

                txtOnHandQty.Text = CommonLib.CtrlUtil.GetCompleteNumberFormatValue(txtOnHandQty.MaxDecimalPlaces, (NZDecimal)(m_uidm.QTY.StrongValue + GetOnHandQty().NVL(0)));
                txtIssueQty.Tag = txtIssueQty.Double;
                CommonLib.CtrlUtil.EnabledControl(false, txtItemCode, btnItemCode, cboFromLoc, cboToLoc, txtLotNo
                    //, rdoIssueType_IssueReturn, rdoIssueType_Issue
                    , dtIssueDate, txtRemark, btnLotNo);

                m_REF_NO = m_uidm.REF_NO.StrongValue;
                txtIssueQty.Focus();
                txtIssueQty.Select();
                txtIssueQty.SelectAll();
            }
            else if (m_Mode == eSaveMode.VIEW)
            {


                dmcIssueByItem.LoadData(m_uidm);
                LoadInventoryUM(m_uidm.ITEM_CD);
                LoadLotNo(m_uidm.ITEM_CD, m_uidm.FROM_LOC_CD);
                //txtLotNo.SelectedValue = m_uidm.LOT_NO.StrongValue;
                txtOnHandQty.Text = CommonLib.CtrlUtil.GetCompleteNumberFormatValue(txtOnHandQty.MaxDecimalPlaces, (NZDecimal)(m_uidm.QTY.StrongValue + GetOnHandQty().StrongValue));
                txtIssueQty.Tag = txtIssueQty.Double;
                CommonLib.CtrlUtil.EnabledControl(false, txtItemCode, btnItemCode, cboFromLoc, cboToLoc, txtLotNo
                    //, rdoIssueType_IssueReturn, rdoIssueType_Issue
                    , dtIssueDate, txtRemark, txtIssueQty);
                CommonLib.CtrlUtil.EnabledControl(false, tsbSaveAndClose, tsbSaveAndNew);
                //m_REF_NO = m_uidm.REF_NO.StrongValue;
                //txtIssueQty.SelectAll();
            }
        }

        private void ClearAll()
        {
            CommonLib.CtrlUtil.ClearControlData(txtTransactionID, txtItemDesc
                                                , txtItemCode, cboToLoc, txtLotNo, cboFromLoc, txtOnHandQty
                                                , txtIssueQty, txtRemark, cboInventoryUM
                                                , cboForCustomer, cboSubType, txtForMachine, txtRefDocNo, txtJobOrderNo);

            dtIssueDate.Focus();
            dtIssueDate.Select();
        }

        private void ClearAllExceptDefaultValue()
        {
            CommonLib.CtrlUtil.ClearControlData(txtTransactionID
                                                , txtLotNo, txtOnHandQty
                                                , txtIssueQty, txtRemark, cboInventoryUM
                                                , cboForCustomer, txtForMachine, txtRefDocNo, txtJobOrderNo);
            txtLotNo.Focus();
            txtLotNo.Select();
        }

        private NZDecimal GetOnHandQty()
        {
            NZDecimal dOnHandQty = new NZDecimal();
            try
            {
                IssueByItemUIDM uidm = dmcIssueByItem.SaveData(new IssueByItemUIDM());
                if (uidm.ITEM_CD.IsNull || uidm.FROM_LOC_CD.IsNull)
                    return new NZDecimal();
                IssueByItemController ctlIssue = new IssueByItemController();
                dOnHandQty = ctlIssue.GetOnHandQty(uidm);
                if (dOnHandQty.IsNull)
                    return new NZDecimal();
                return dOnHandQty;
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusiness(this, ex.Message);
            }
            return new NZDecimal();
        }

        private void InitialComboBox()
        {
            cboFromLoc.Format += CommonLib.Common.ComboBox_Format;
            cboInventoryUM.Format += CommonLib.Common.ComboBox_Format;
            cboToLoc.Format += CommonLib.Common.ComboBox_Format;
            cboForCustomer.Format += CommonLib.Common.ComboBox_Format;
            cboSubType.Format += CommonLib.Common.ComboBox_Format;
            LookupDataBIZ bizLookup = new LookupDataBIZ();

            // Lookup To Location
            LookupData lookupOrderLocation = bizLookup.LoadLookupLocation(null);
            cboToLoc.LoadLookupData(lookupOrderLocation);

            // Lookup From Location
            LookupData lookupStoreLocation = bizLookup.LoadLookupLocation(null);
            cboFromLoc.LoadLookupData(lookupStoreLocation);

            // Lookup Inventory U/M
            LookupData lookupInventoryUM = bizLookup.LoadLookupClassType(DataDefine.UM_CLS.ToNZString());
            cboInventoryUM.LoadLookupData(lookupInventoryUM);

            // Lookup To CustomerLocation
            LookupData lookupCustomer = bizLookup.LoadLookupLocation(new NZString[]{(NZString)DataDefine.Convert2ClassCode(DataDefine.eLOCATION_CLS.Customer)
            ,(NZString)DataDefine.Convert2ClassCode(DataDefine.eLOCATION_CLS.CustomerVendor)});
            cboForCustomer.LoadLookupData(lookupCustomer);

            // Lookup SubType
            LookupData lookupSubType = bizLookup.LoadLookupClassType(DataDefine.ISSUE_SUBTYPE.ToNZString());
            cboSubType.LoadLookupData(lookupSubType);
        }

        private bool CheckMandatory()
        {
            try
            {
                IssueEntryValidator val = new IssueEntryValidator();
                CommonBizValidator commonVal = new CommonBizValidator();
                #region Mandatory check

                ErrorItem errorItem;
                NZString FromLoc = new NZString(cboFromLoc, cboFromLoc.SelectedValue);
                NZString ToLoc = new NZString(cboToLoc, cboToLoc.SelectedValue);
                NZString ItemCD = new NZString(txtItemCode, txtItemCode.Text);
                NZString LotNo = new NZString(txtLotNo, txtLotNo.Text);
                NZString SubType = new NZString(cboSubType, cboSubType.SelectedValue);

                InventoryPeriodBIZ biz = new InventoryPeriodBIZ();
                InventoryPeriodDTO dto = biz.LoadPeriodByDate(new NZDateTime(dtIssueDate, dtIssueDate.Value));

                errorItem = val.CheckIssueDate(new NZDateTime(null, dtIssueDate.Value));
                if (null != errorItem)
                {
                    // ถ้าเป็น issue ของเดือนถัดไปจะต้องทำได้
                    errorItem = val.CheckIssueMonth(new NZDateTime(null, dtIssueDate.Value));
                    if (null != errorItem)
                        ValidateException.ThrowErrorItem(errorItem);
                }

                errorItem = val.CheckEmptyItemCode(ItemCD);
                if (null != errorItem) ValidateException.ThrowErrorItem(errorItem);

                errorItem = val.CheckEmptyLocFrom(FromLoc);
                if (null != errorItem) ValidateException.ThrowErrorItem(errorItem);

                errorItem = val.CheckEmptyLocTo(ToLoc);
                if (null != errorItem) ValidateException.ThrowErrorItem(errorItem);

                errorItem = val.CheckFromToLocation(FromLoc, ToLoc);
                if (null != errorItem) ValidateException.ThrowErrorItem(errorItem);

                errorItem = val.CheckEmptySubType(SubType);
                if (null != errorItem) ValidateException.ThrowErrorItem(errorItem);

                if (m_Mode == eSaveMode.ADD)
                {
                    //if (txtLotNo.Text == string.Empty)
                    //    ValidateException.ThrowErrorItem(new ErrorItem(txtLotNo,
                    //                                                   TKPMessages.eValidate.VLM0067.ToString(),
                    //                                                   new[] { FromLoc.StrongValue }));
                    errorItem = commonVal.CheckInputLot(ItemCD, FromLoc, LotNo, true);
                    if (null != errorItem) ValidateException.ThrowErrorItem(errorItem);
                }
                if (txtIssueQty.Text.Trim() == string.Empty) txtIssueQty.Text = "0";
                if (txtOnHandQty.Text.Trim() == string.Empty) txtOnHandQty.Text = "0";

                errorItem = val.CheckIssueQTY(new NZDecimal(txtIssueQty, Convert.ToDecimal(txtIssueQty.Text)));
                if (null != errorItem) ValidateException.ThrowErrorItem(errorItem);



                #endregion

                return true;
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
            return false;
        }

        private NZString GetYearMonth(DateTime? dtDate)
        {
            InventoryPeriodBIZ biz = new InventoryPeriodBIZ();
            InventoryPeriodDTO dto = biz.LoadPeriodByDate(new NZDateTime(null, dtDate.Value));
            if (dto == null)
                return new NZString(null, dtDate.Value.ToString("yyyyMM"));

            return dto.YEAR_MONTH;

        }

        private bool SaveData()
        {
            try
            {
                IssueByItemController ctlIssue = new IssueByItemController();
                IssueByItemUIDM uidmIssue = dmcIssueByItem.SaveData(new IssueByItemUIDM());

                switch (m_Mode)
                {
                    case eSaveMode.ADD:
                        ctlIssue.SaveAddIssue(uidmIssue);
                        break;
                    case eSaveMode.UPDATE:
                        uidmIssue.REF_NO.Value = m_REF_NO;
                        //uidmIssue.LOT_NO.Value = txtLotNo.Text;
                        ctlIssue.SaveUpdateIssue(uidmIssue);
                        break;

                }
                return true;
            }
            catch (ValidateException err)
            {
                for (int i = 0; i < err.ErrorResults.Count; i++)
                {
                    MessageDialog.ShowBusiness(this, err.ErrorResults[i].Message.MessageDescription);
                    err.ErrorResults[i].FocusOnControl();
                }
            }
            catch (BusinessException err)
            {
                MessageDialog.ShowBusiness(this, err.Error.Message.MessageDescription);
                err.Error.FocusOnControl();
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusiness(this, ex.Message);
            }
            return false;
        }

        private void LoadInventoryUM(NZString ItemCD)
        {
            ItemBIZ biz = new ItemBIZ();
            ItemDTO dto = biz.LoadItem(ItemCD);
            //if (dto != null) cboInventoryUM.SelectedValue = dto.INV_UM_CLS.StrongValue;
            //else cboInventoryUM.SelectedIndex = -1;
        }
        #endregion

        #region Form Event

        private void INV040_Load(object sender, EventArgs e)
        {
            InitialScreen();

            this.btnItemCode.Click += new System.EventHandler(this.btnItemCode_Click);
        }

        #endregion

        #region Control Event
        private void txtItemCode_TextChanged(object sender, EventArgs e)
        {
            NZDecimal onhandQTY = GetOnHandQty();
            if (onhandQTY.IsNull == false)
                txtOnHandQty.Text = CommonLib.CtrlUtil.GetCompleteNumberFormatValue(txtOnHandQty.MaxDecimalPlaces, onhandQTY);
            else
            {
                txtOnHandQty.Text = "0";
            }

        }

        private void txtItemCode_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar != (char)Keys.Return) return;
            NZString ItemCD = new NZString(txtItemCode, txtItemCode.Text.Trim());
            NZString LocCD = new NZString(cboFromLoc, cboFromLoc.SelectedValue);
            LoadLotNo(ItemCD, LocCD);

            //if (txtItemCode.SelectedItemData != null)
            //    cboInventoryUM.SelectedValue = txtItemCode.SelectedItemData.INV_UM_CLS.StrongValue;
            //else
            //    cboInventoryUM.SelectedIndex = -1;

            cboFromLoc.Focus();


            // get onhand qty
            NZDecimal onhandQTY = GetOnHandQty();
            if (onhandQTY.IsNull == false)
                txtOnHandQty.Text = CommonLib.CtrlUtil.GetCompleteNumberFormatValue(txtOnHandQty.MaxDecimalPlaces, onhandQTY);
            else
            {
                txtOnHandQty.Text = "0";
            }
        }

        private void LoadLotNo(NZString ItemCD, NZString LocCD)
        {
            //// load lot
            //LookupDataBIZ bizLookup = new LookupDataBIZ();

            //// Lookup To Location
            //LookupData lookupOrderLocation = bizLookup.LoadLookupLotNo(ItemCD, LocCD, dtIssueDate.Value.Value.ToString("yyyyMM").ToNZString());
            //txtLotNo.LoadLookupData(lookupOrderLocation);
            if (m_Mode == eSaveMode.ADD)
            {
                //txtLotNo.SelectedIndex = -1;
                txtLotNo.Text = string.Empty;
            }
            else
            {
                txtLotNo.Text = m_uidm.LOT_NO.StrongValue;
            }
        }

        private void txtRemark_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != (char)Keys.Return) return;
            tslControl.Select();
            tsbSaveAndNew.Select();
        }

        private void cboFromLoc_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cboFromLoc.SelectedValue == null) return;

            NZString ItemCD = new NZString(txtItemCode, txtItemCode.Text.Trim());
            NZString LocCD = new NZString(cboFromLoc, cboFromLoc.SelectedValue);

            if (ItemCD.IsNull) return;
            LoadLotNo(ItemCD, LocCD);

            // get onhand qty
            NZDecimal onhandQTY = GetOnHandQty();
            if (onhandQTY.IsNull == false)
                txtOnHandQty.Text = CommonLib.CtrlUtil.GetCompleteNumberFormatValue(txtOnHandQty.MaxDecimalPlaces, onhandQTY);
            else
            {
                txtOnHandQty.Text = "0";
            }
        }

        //private void txtLotNo_SelectedValueChanged(object sender, EventArgs e)
        //{
        //    fh
        //    if (txtLotNo.SelectedValue == null) return;

        //    NZDecimal onhandQTY = GetOnHandQty();
        //    if (onhandQTY.IsNull == false)
        //        txtOnHandQty.Text = CommonLib.CtrlUtil.GetCompleteNumberFormatValue(txtOnHandQty.MaxDecimalPlaces, onhandQTY);
        //    else
        //    {
        //        txtOnHandQty.Text = "0";
        //    }
        //}

        private void btnItemCode_Click(object sender, EventArgs e)
        {
            //cboFromLoc.Focus();
            txtItemCode_KeyPress(txtItemCode, new KeyPressEventArgs((char)Keys.Return));
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

        private void dtIssueDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != (char)Keys.Return) return;
            cboSubType.Select();
            cboSubType.SelectAll();
        }

        private void btnLotNo_Click(object sender, EventArgs e)
        {
            NZString locCD = new NZString(null, cboFromLoc.SelectedValue);
            LotNoFindDialog dialog = new LotNoFindDialog(txtItemCode.Text.ToNZString(), locCD);

            dialog.ShowDialog(this);
            if (dialog.IsSelected)
            {
                txtLotNo.Text = dialog.SelectedLotNo.NVL(string.Empty);
                txtLotNo_KeyPress(txtLotNo, new KeyPressEventArgs((char)Keys.Return));
            }
        }

        private void txtLotNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                NZDecimal onhandQTY = GetOnHandQty();
                if (onhandQTY.IsNull == false)
                    txtOnHandQty.Text = CommonLib.CtrlUtil.GetCompleteNumberFormatValue(txtOnHandQty.MaxDecimalPlaces, onhandQTY);
                else
                {
                    txtOnHandQty.Text = "0";
                }

            }
        }

    }
}
