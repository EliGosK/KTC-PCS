using System;
using System.Windows.Forms;
using SystemMaintenance.Forms;
using EVOFramework;
using EVOFramework.Windows.Forms;
using Rubik.UIDataModel;
using Rubik.Controller;
using CommonLib;
using Rubik.Validators;
using EVOFramework.Data;
using Rubik.BIZ;
using System.Collections.Generic;
using System.Data;

namespace Rubik.Master {
    //[Screen("MAS051", "Register BOM", eShowAction.Normal, eScreenType.Dialog, "Register Item to BOM Setup")]
    public partial class MAS051_RegisterBOM : CustomizeBaseForm {
        #region Variables
        private BOMRegisterUIDM m_model = null;
        #endregion


        #region Constructor
        public MAS051_RegisterBOM() {
            InitializeComponent();
        }

        public MAS051_RegisterBOM(string parentItemCode) {
            InitializeComponent();

            txtParentItemCode.Text = parentItemCode;

            ItemController controller = new ItemController();
            ItemUIDM uidm = controller.LoadItem(parentItemCode.ToNZString());
            txtParentItemDesc.Text = uidm.ITEM_DESC.NVL(string.Empty);
        }
        #endregion

        #region Properties
        public bool IsSelected {
            get { return (m_model != null); }
        }

        public BOMRegisterUIDM SelectedItem {
            get { return m_model; }
        }
        #endregion

        #region Protected method
        protected virtual void OnSave() {
            // Validate data
            try {
                ItemValidator itemValidator = new ItemValidator();
                ValidateException.ThrowErrorItem(itemValidator.CheckEmptyItemCode(txtItemCode.ToNZString()));
                BusinessException itemException = itemValidator.CheckItemNotExist(txtItemCode.ToNZString());
                if (itemException != null)
                    ValidateException.ThrowErrorItem(itemException.Error);

                if (txtUpperQty.Decimal == 0) {
                    ValidateException.ThrowErrorItem(new ErrorItem(txtUpperQty, string.Empty, "Can't input zero"));
                }

                if (txtLowerQty.Decimal == 0) {
                    ValidateException.ThrowErrorItem(new ErrorItem(txtLowerQty, string.Empty, "Can't input zero"));
                }

                ItemController controller = new ItemController();
                ItemUIDM uidm = controller.LoadItem(txtItemCode.Text.Trim().ToNZString());

                BOMRegisterUIDM model = new BOMRegisterUIDM();
                model.ITEM_CD = uidm.ITEM_CD;
                model.ITEM_DESC = uidm.ITEM_DESC;
                //model.ITEM_CLS = uidm.ITEM_CLS;
                //model.LOT_CONTROL_CLS = uidm.LOT_CONTROL_CLS;
                //model.ORDER_LOC_CD = uidm.ORDER_LOC_CD;
                //model.STORE_LOC_CD = uidm.STORE_LOC_CD;
                //model.ORDER_PROCESS_CLS = uidm.ORDER_PROCESS_CLS;
                //model.CONSUMTION_CLS = uidm.CONSUMTION_CLS;
                //model.PACK_SIZE = uidm.PACK_SIZE;
                //model.INV_UM_CLS = uidm.INV_UM_CLS;
                //model.ORDER_UM_CLS = uidm.ORDER_UM_CLS;
                //model.INV_UM_RATE = uidm.INV_UM_RATE;
                //model.ORDER_UM_RATE = uidm.ORDER_UM_RATE;
                model.LOWER_QTY.Value = txtLowerQty.Decimal;
                model.UPPER_QTY.Value = txtUpperQty.Decimal;
                model.CHILD_ORDER_LOC_CD.Value = (chkChildOrderLoc.Checked ? null : (string)cboOrderLoc.SelectedValue);
                model.MRP_FLAG.Value = (chkMRPFlag.Checked ? null : (string)cboMRPFlag.SelectedValue);

                m_model = model;

                this.Close();
            }
            catch (ValidateException err) {
                MessageDialog.ShowBusiness(this, err.ErrorResults[0].Message);
                err.ErrorResults[0].FocusOnControl();
            }
        }

        protected virtual void OnCancel() {
            m_model = null;
            this.Close();
        }
        #endregion

        #region Control event
        protected void tsbAdd_Click(object sender, EventArgs e) {
            OnSave();
        }

        protected void tsbCancel_Click(object sender, EventArgs e)
        {
            OnCancel();
        }
        #endregion



        #region Form event
        protected void MAS051_ReigsterBOM_Load(object sender, EventArgs e)
        {
            txtItemCode.KeyPress += CtrlUtil.SetNextControl;
            txtItemDesc.KeyPress += CtrlUtil.SetNextControl;
            txtUpperQty.KeyPress += CtrlUtil.SetNextControl;
            txtLowerQty.KeyPress += CtrlUtil.SetNextControl;
            cboOrderLoc.KeyPress += CtrlUtil.SetNextControl;
            chkChildOrderLoc.KeyPress += CtrlUtil.SetNextControl;
            cboMRPFlag.KeyPress += CtrlUtil.SetNextControl;
            chkMRPFlag.KeyPress += CtrlUtil.SetNextControl;           

            cboOrderLoc.Format += Common.ComboBox_Format;
            cboMRPFlag.Format += Common.ComboBox_Format;

            txtUpperQty.PathValue = 1;
            txtLowerQty.PathValue = 1;

            CtrlUtil.EnabledControl(false, txtParentItemCode, txtParentItemDesc, txtItemDesc);
            CtrlUtil.EnabledControl(true, txtItemCode, txtUpperQty, txtLowerQty, cboOrderLoc, cboMRPFlag);

            LookupDataBIZ m_bizLookupData = new LookupDataBIZ();
            LookupData locationData = m_bizLookupData.LoadLookupLocation();
            cboOrderLoc.LoadLookupData(locationData);
            cboOrderLoc.SelectedIndex = -1;

            LookupData lookupMRPFlag = m_bizLookupData.LoadLookupClassType(DataDefine.MRP_FLAG.ToNZString());
            cboMRPFlag.LoadLookupData(lookupMRPFlag);
            cboMRPFlag.SelectedIndex = -1;

            chkChildOrderLoc_CheckedChanged(this, null);
            chkMRPFlag_CheckedChanged(this, null);
        }

        protected void MAS051_ReigsterBOM_Shown(object sender, EventArgs e)
        {
            CtrlUtil.FocusControl(txtItemCode);
        }
        #endregion

        protected void chkChildOrderLoc_CheckedChanged(object sender, EventArgs e)
        {
            cboOrderLoc.Enabled = !chkChildOrderLoc.Checked;
            if (chkChildOrderLoc.Checked && txtItemCode.Text != string.Empty)
            {
                BOMBIZ bizBOM = new BOMBIZ();
                DTO.ItemProcessDTO dto = bizBOM.LoadLocationandMRPFLag((NZString)txtItemCode.Text);
                //cboOrderLoc.SelectedValue = dto.ORDER_LOC_CD.ToString();
            }
        }

        protected void chkMRPFlag_CheckedChanged(object sender, EventArgs e)
        {
            cboMRPFlag.Enabled = !chkMRPFlag.Checked;
            if (chkMRPFlag.Checked && txtItemCode.Text != string.Empty)
            {
                BOMBIZ bizBOM = new BOMBIZ();
                DTO.ItemProcessDTO dto = bizBOM.LoadLocationandMRPFLag((NZString)txtItemCode.Text);
                //cboMRPFlag.SelectedValue = dto.MRP_FLAG.ToString();
            }
        }

    }
}
