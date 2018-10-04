using System;
using System.Collections.Generic;
using System.Drawing;
using EVOFramework.Data;
using Rubik.BIZ;
using EVOFramework;
using EVOFramework.Windows.Forms;
using Rubik.Controller;
using Rubik.UIDataModel;
using Rubik.Validators;
using System.Windows.Forms;
using Rubik.DTO;
using CommonLib;
using SystemMaintenance;
using System.Data;
using FarPoint.Win.Spread;
using Rubik.Forms.FindDialog;
using Message = EVOFramework.Message;
using System.Collections;
using System.Text;

namespace Rubik.Master
{
    [Screen("MAS040", "Master No. Entry", eShowAction.Normal, eScreenType.Dialog, "Master No. Entry")]
    public partial class MAS040_ItemMaster : SystemMaintenance.Forms.CustomizeForm
    {
        #region enum

        public enum eScreenMode
        {
            IDLE,
            VIEW,
            ADD,
            EDIT,
        }

        public enum eColComponent
        {
            SEQ_NO,
            ITEM_CD,
            BTN_ITEM_CD,
            SHORT_NAME,
            CUSTOMER_CD,
            PCS,

        }

        public enum eColumns
        {
            ITEM_SEQ,
            PROCESS_CD,
            BTN_ROUTING,
            PROCESS_NAME,
            WEIGHT,
            PRODUCTION_LEADTIME,
            QTY_PER_DAY,
            SUPPLIER_CD,
        }

        public enum eMachineProcessIndex
        {
            MC1,
            MC2,
            MC3,
            MC4,
            MC5,
            MC6
        }

        #endregion

        #region Variable
        private eScreenMode m_screenMode = eScreenMode.ADD;
        private KeyboardSpread r_keyboardSpread = null;
        private KeyboardSpread c_keyboardSpread = null;
        private bool m_bRowHasModified = false;
        NZString m_ItemCD;
        bool m_bInitial = true;
        private bool m_bCheckProcessMachine = true;
        private bool m_bLoadMachineGroup = true;

        #endregion

        #region Constructor

        public MAS040_ItemMaster() : this(new NZString()) { }

        public MAS040_ItemMaster(NZString ItemCD)
        {
            InitializeComponent();
            m_ItemCD = ItemCD;
        }

        #endregion

        #region Overriden Method

        public override void OnSaveAndNew()
        {
            base.OnSaveAndNew();
            if (m_ItemCD.IsNull)
            {
                if (SaveNewItem())
                {
                    ClearAllItem();
                    InitialComboBox();
                    CommonLib.CtrlUtil.FocusControl(txtMasterNo);
                }

            }
            else
            {
                if (UpdateItem())
                {
                    ClearAllItem();
                    InitialComboBox();
                    CommonLib.CtrlUtil.EnabledControl(true, txtMasterNo);
                    CommonLib.CtrlUtil.FocusControl(txtMasterNo);
                }

            }

            LookupDataBIZ bizLookup = new LookupDataBIZ();

            //LookupData lookupBusinessGroup = bizLookup.LoadLookupTextHelper(ItemDTO.eColumns.BUSINESS_GROUP);
            //txtBusinessGroup.LoadLookupData(lookupBusinessGroup);
        }
        public override void OnSaveAndClose()
        {
            base.OnSaveAndClose();
            if (m_ItemCD.IsNull)
            {

                if (SaveNewItem())
                    this.Close();
            }
            else
            {
                if (UpdateItem())
                    this.Close();
            }
        }

        #endregion

        #region Private Method

        private ItemUIDM CreateSaveModel()
        {
            ItemUIDM uidmItem = dmcItem.SaveData(new ItemUIDM());

            uidmItem.HEAT_FLAG = rdoHeatTreatmentYes.Checked ? new NZInt(rdoHeatTreatmentYes, 1) : new NZInt(rdoHeatTreatmentNo, 0);
            if (rdoHeatTreatmentNo.Checked)
            {
                uidmItem.HEAT_TYPE = new NZString();
                uidmItem.HEAT_HARDNESS = new NZString();
                uidmItem.HEAT_CORE_HARDNESS = new NZString();
                uidmItem.HEAT_CASE_DEPTH = new NZString();
            }

            uidmItem.PLATING_FLAG = rdoPlatingYes.Checked ? new NZInt(rdoPlatingYes, 1) : new NZInt(rdoPlatingNo, 0);
            if (rdoPlatingNo.Checked)
            {
                uidmItem.PLATING_KIND = new NZString();
                uidmItem.PLATING_THICKNESS1_1 = new NZString();
                uidmItem.PLATING_THICKNESS1_2 = new NZString();
                uidmItem.PLATING_THICKNESS2_1 = new NZString();
                uidmItem.PLATING_THICKNESS2_2 = new NZString();
                uidmItem.PLATING_KTC = new NZString();
                uidmItem.PLATING_SUPPLIER_NAME = new NZString();
            }

            uidmItem.BAKING_FLAG = rdoPlatingBakingYes.Checked ? new NZInt(rdoPlatingBakingYes, 1) : new NZInt(rdoPlatingBakingNo, 0);
            if (rdoPlatingBakingNo.Checked)
            {
                uidmItem.BAKING_TEMP = new NZString();
                uidmItem.BAKING_TIME = new NZString();
            }

            uidmItem.OTHER_TREATMENT1_FLAG = rdoOtherTreatment1Yes.Checked ? new NZInt(rdoOtherTreatment1Yes, 1) : new NZInt(rdoOtherTreatment1No, 0);
            if (rdoOtherTreatment1No.Checked)
            {
                uidmItem.OTHER_TREATMENT1_KIND = new NZString();
                uidmItem.OTHER_TREATMENT1_CONDITION = new NZString();
            }

            uidmItem.OTHER_TREATMENT2_FLAG = rdoOtherTreatment2Yes.Checked ? new NZInt(rdoOtherTreatment2Yes, 1) : new NZInt(rdoOtherTreatment2No, 0);
            if (rdoOtherTreatment2No.Checked)
            {
                uidmItem.OTHER_TREATMENT2_KIND = new NZString();
                uidmItem.OTHER_TREATMENT2_CONDITION = new NZString();
            }

            uidmItem.DataView = (DataTable)shtRouting.DataSource;
            uidmItem.DataComponentView = (DataTable)shtComponent.DataSource;

            StringBuilder sbRoutingText = new StringBuilder();
            if (uidmItem.DataView != null)
            {
                foreach (DataRow dr in uidmItem.DataView.Rows)
                {
                    if (dr.RowState == DataRowState.Deleted)
                        continue;

                    if (sbRoutingText.ToString().Length > 0)
                        sbRoutingText.Append(",");
                    sbRoutingText.Append(dr[(int)ItemViewProcessDTO.eColumns.PROCESS_CD]);
                }
            }
            uidmItem.ROUTING_TEXT = sbRoutingText.ToString().ToNZString();

            if (uidmItem.DataItemMachine == null)
            {
                DataTable dt = null;
                ItemMachineDTO dtoItemMachine = new ItemMachineDTO();
                dtoItemMachine.CreateDataTableSchema(out dt);
                uidmItem.DataItemMachine = dt;
            }

            if (cboMachineProcess1.SelectedValue != null && cboMachineMCType1.SelectedValue != null)
            {
                DataRow dr = uidmItem.DataItemMachine.NewRow();
                dr[(int)ItemMachineDTO.eColumns.MACHINE_PROCESS] = cboMachineProcess1.SelectedValue.ToString();
                dr[(int)ItemMachineDTO.eColumns.MACHINE_TYPE] = cboMachineMCType1.SelectedValue.ToString();
                uidmItem.DataItemMachine.Rows.Add(dr);
            }
            if (cboMachineProcess2.SelectedValue != null && cboMachineMCType2.SelectedValue != null)
            {
                DataRow dr = uidmItem.DataItemMachine.NewRow();
                dr[(int)ItemMachineDTO.eColumns.MACHINE_PROCESS] = cboMachineProcess2.SelectedValue.ToString();
                dr[(int)ItemMachineDTO.eColumns.MACHINE_TYPE] = cboMachineMCType2.SelectedValue.ToString();
                uidmItem.DataItemMachine.Rows.Add(dr);
            }
            if (cboMachineProcess3.SelectedValue != null && cboMachineMCType3.SelectedValue != null)
            {
                DataRow dr = uidmItem.DataItemMachine.NewRow();
                dr[(int)ItemMachineDTO.eColumns.MACHINE_PROCESS] = cboMachineProcess3.SelectedValue.ToString();
                dr[(int)ItemMachineDTO.eColumns.MACHINE_TYPE] = cboMachineMCType3.SelectedValue.ToString();
                uidmItem.DataItemMachine.Rows.Add(dr);
            }
            if (cboMachineProcess4.SelectedValue != null && cboMachineMCType4.SelectedValue != null)
            {
                DataRow dr = uidmItem.DataItemMachine.NewRow();
                dr[(int)ItemMachineDTO.eColumns.MACHINE_PROCESS] = cboMachineProcess4.SelectedValue.ToString();
                dr[(int)ItemMachineDTO.eColumns.MACHINE_TYPE] = cboMachineMCType4.SelectedValue.ToString();
                uidmItem.DataItemMachine.Rows.Add(dr);
            }
            if (cboMachineProcess5.SelectedValue != null && cboMachineMCType5.SelectedValue != null)
            {
                DataRow dr = uidmItem.DataItemMachine.NewRow();
                dr[(int)ItemMachineDTO.eColumns.MACHINE_PROCESS] = cboMachineProcess5.SelectedValue.ToString();
                dr[(int)ItemMachineDTO.eColumns.MACHINE_TYPE] = cboMachineMCType5.SelectedValue.ToString();
                uidmItem.DataItemMachine.Rows.Add(dr);
            }
            if (cboMachineProcess6.SelectedValue != null && cboMachineMCType6.SelectedValue != null)
            {
                DataRow dr = uidmItem.DataItemMachine.NewRow();
                dr[(int)ItemMachineDTO.eColumns.MACHINE_PROCESS] = cboMachineProcess6.SelectedValue.ToString();
                dr[(int)ItemMachineDTO.eColumns.MACHINE_TYPE] = cboMachineMCType6.SelectedValue.ToString();
                uidmItem.DataItemMachine.Rows.Add(dr);
            }

            return uidmItem;
        }

        private bool SaveNewItem()
        {
            try
            {
                if (!ValidateData())
                {
                    return false;
                }
                MessageDialogResult dr = MessageDialog.ShowConfirmation(this, new EVOFramework.Message(SystemMaintenance.Messages.eConfirm.CFM9001.ToString()).MessageDescription);
                switch (dr)
                {
                    case MessageDialogResult.Cancel:
                        return false;

                    case MessageDialogResult.No:
                        //Close();
                        return false;

                    case MessageDialogResult.Yes:
                        break;

                }

                ItemUIDM uidmItem = CreateSaveModel();

                ItemController ctlItem = new ItemController();
                ctlItem.AddNewItem(uidmItem);

                MessageDialog.ShowInformation(this, "Information", new EVOFramework.Message(SystemMaintenance.Messages.eInformation.INF9003.ToString()).MessageDescription);
                return true;
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
            return false;
        }

        private bool UpdateItem()
        {
            try
            {
                if (!ValidateData())
                {
                    return false;
                }
                MessageDialogResult dr = MessageDialog.ShowConfirmation(this, new EVOFramework.Message(SystemMaintenance.Messages.eConfirm.CFM9001.ToString()).MessageDescription);
                switch (dr)
                {
                    case MessageDialogResult.Cancel:
                        return false;

                    case MessageDialogResult.No:
                        //this.Close();
                        return false;

                    case MessageDialogResult.Yes:
                        break;

                }

                ItemUIDM uidmItem = CreateSaveModel();

                ItemController ctlItem = new ItemController();
                //ItemUIDM uidmItem = dmcItem.SaveData(new ItemUIDM());
                //uidmItem.DataView = (DataTable)shtRouting.DataSource;
                //uidmItem.DataComponentView = (DataTable)shtComponent.DataSource;
                //uidmItem.DataView.AcceptChanges();
                ctlItem.UpdateItem(uidmItem);

                MessageDialog.ShowInformation(this, "Information", new EVOFramework.Message(SystemMaintenance.Messages.eInformation.INF9003.ToString()).MessageDescription);
                return true;
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
            return false;
        }

        private void ClearAllItem()
        {
            CommonLib.CtrlUtil.ClearControlData(txtMasterNo, txtPartName, cboPartType
                                                , txtPartNo, txtWeight, cboKindOfProduct, cboCustomer, txtCustomerUsePoint, txtWeight, cboBOI, cboProduction
                                                , cboItemLevel, txtMatName, txtMatSize, cboMatSupplier, txtKindOfMat, cboMatDI, txtRemark, cboScrewKind
                                                , cboScrewHead, txtScrewM, txtScrewL, cboScrewType, cboScrewRemark1, cboScrewRemark2, txtScrewHexabular
                                                , cboMachineMCType1, cboMachineMCType2, cboMachineMCType3, cboMachineMCType4, cboMachineMCType5, cboMachineMCType6
                                                , cboMachineProcess1, cboMachineProcess2, cboMachineProcess3, cboMachineProcess4, cboMachineProcess5, cboMachineProcess6
                                                , cboHeatTreatmentType, txtHardingSurface, txtCoreHardness, txtCaseDeptAndCondition, txtPlatingKind
                                                , txtPlatingThickness1From, txtPlatingThickness1To, txtPlatingThickness2From, txtPlatingThickness2To, cboKTCPlating
                                                , cboPlatingSupplier, cboPlatingBakingTime, cboPlatingBakingTemp, cboOtherKind1, cboOtherKind2, cboOtherCondition1, cboOtherCondition2
                                                , txtCreateBy, txtCreateDate, txtReviseBy, txtReviseDate);


            rdoHeatTreatmentNo.Checked = true;
            rdoHeatTreatmentYes.Checked = false;
            rdoOtherTreatment1No.Checked = true;
            rdoOtherTreatment1Yes.Checked = false;
            rdoOtherTreatment2No.Checked = true;
            rdoOtherTreatment2Yes.Checked = false;
            rdoPlatingBakingNo.Checked = true;
            rdoPlatingBakingYes.Checked = false;
            rdoPlatingNo.Checked = true;
            rdoPlatingYes.Checked = false;

            m_ItemCD = new NZString();

            shtRouting.RowCount = 0;
            if (shtRouting.DataSource != null)
                shtRouting.DataSource = null;

            shtComponent.RowCount = 0;
            if (shtComponent.DataSource != null)
                shtComponent.DataSource = null;

            ItemUIDM model = new ItemUIDM();
            shtRouting.DataSource = model.DataView;
            shtComponent.DataSource = model.DataComponentView;

            MachineCombobox((DataTable)shtRouting.DataSource);
        }

        private bool ValidateData()
        {
            bool bResult = true;

            ItemValidator valItem = new ItemValidator();

            #region Validate
            ErrorItem errorItem;
            errorItem = valItem.CheckEmptyItemCode(new NZString(txtMasterNo, txtMasterNo.Text.Trim()));
            if (null != errorItem) ValidateException.ThrowErrorItem(errorItem);

            errorItem = valItem.CheckEmptyItemDesc(new NZString(txtPartNo, txtPartNo.Text.Trim()));
            if (null != errorItem) ValidateException.ThrowErrorItem(errorItem);

            errorItem = valItem.CheckEmptyKindOfProduct(new NZString(cboKindOfProduct, cboKindOfProduct.SelectedValue));
            if (null != errorItem) ValidateException.ThrowErrorItem(errorItem);

            errorItem = valItem.CheckEmptyCustomer(new NZString(cboCustomer, cboCustomer.SelectedValue));
            if (null != errorItem) ValidateException.ThrowErrorItem(errorItem);

            #endregion

            //Validate Routing            
            for (int rRow = 0; rRow < shtRouting.RowCount; rRow++)
            {
                bResult = ValidateRowSpreadRouting(rRow, true);
                if (!bResult)
                    return false;
            }

            //Validate Component            
            for (int cRow = 0; cRow < shtComponent.RowCount; cRow++)
            {
                bResult = ValidateRowSpreadComponent(cRow, true);
                if (!bResult)
                    return false;
            }

            //Validate Machine Process
            ValidateProcessMachine(1, cboMachineProcess1, cboMachineMCType1);
            ValidateProcessMachine(2, cboMachineProcess2, cboMachineMCType2);
            ValidateProcessMachine(3, cboMachineProcess3, cboMachineMCType3);
            ValidateProcessMachine(4, cboMachineProcess4, cboMachineMCType4);
            ValidateProcessMachine(5, cboMachineProcess5, cboMachineMCType5);
            ValidateProcessMachine(6, cboMachineProcess6, cboMachineMCType6);

            return true;
        }

        private bool ValidateRowSpreadComponent(int row, bool forceValidate)
        {
            if (shtComponent.RowCount <= 0) return true;

            if (!forceValidate && !m_bRowHasModified)
                return true;

            ErrorItem errorItem = null;
            BusinessException errorBiz = null;
            //Check item
            if (shtComponent.RowCount > 0)
            {
                string itemCd = shtComponent.Cells[row, (int)eColComponent.ITEM_CD].Text;
                decimal qty = string.Empty.Equals(shtComponent.Cells[row, (int)eColComponent.PCS].Text) ? 0 :
                                Convert.ToDecimal(shtComponent.Cells[row, (int)eColComponent.PCS].Value);

                if (String.IsNullOrEmpty(itemCd))
                {
                    errorItem = new ErrorItem(null, TKPMessages.eValidate.VLM0006.ToString());
                    MessageDialog.ShowBusiness(this, errorItem.Message);
                    return false;
                }
                else
                {
                    ItemValidator itemValidator = new ItemValidator();
                    errorBiz = itemValidator.CheckItemNotExist(itemCd.ToNZString());
                    if (errorBiz != null)
                    {
                        MessageDialog.ShowBusiness(this, errorBiz.Error.Message);
                        return false;
                    }

                    for (int i = 0; i < shtComponent.RowCount; i++)
                    {
                        if (i == row)
                            continue;

                        if (itemCd.Equals(shtComponent.Cells[i, (int)eColComponent.ITEM_CD].Text))
                        {
                            errorItem = new ErrorItem(null, TKPMessages.eValidate.VLM0199.ToString());
                            MessageDialog.ShowBusiness(this, errorItem.Message);
                            return false;
                        }
                    }

                    if (qty == 0)
                    {
                        errorItem = new ErrorItem(null, TKPMessages.eValidate.VLM0207.ToString());
                        MessageDialog.ShowBusiness(this, errorItem.Message);
                        return false;
                    }

                }

            }
            // ถ้า Validate Row ผ่าน แสดงว่า แถวนั้นไม่จำเป็นต้องเช็คอีกรอบ
            m_bRowHasModified = false;
            return true;
        }

        private bool ValidateRowSpreadRouting(int row, bool forceValidate)
        {
            if (shtRouting.RowCount <= 0) return true;

            if (!forceValidate && !m_bRowHasModified)
                return true;

            ErrorItem error = null;

            //Check item
            if (shtRouting.RowCount > 0)
            {
                string process = shtRouting.Cells[row, (int)eColumns.PROCESS_CD].Text;
                string itemSeq = shtRouting.Cells[row, (int)eColumns.ITEM_SEQ].Text;
                decimal decLT = string.Empty.Equals(shtRouting.Cells[row, (int)eColumns.PRODUCTION_LEADTIME].Text) ? 0 :
                                Convert.ToDecimal(shtRouting.Cells[row, (int)eColumns.PRODUCTION_LEADTIME].Value);

                if (string.Empty.Equals(process))
                {
                    error = new ErrorItem(null, TKPMessages.eValidate.VLM0160.ToString());
                    MessageDialog.ShowBusiness(this, error.Message);
                    return false;
                }

                for (int i = 0; i < shtRouting.RowCount; i++)
                {
                    if (i == row)
                        continue;

                    if (process.Equals(shtRouting.Cells[i, (int)eColumns.PROCESS_CD].Text))
                    {
                        error = new ErrorItem(null, TKPMessages.eValidate.VLM0198.ToString());
                        MessageDialog.ShowBusiness(this, error.Message);
                        return false;
                    }
                }


                if (String.IsNullOrEmpty(itemSeq))
                {
                    error = new ErrorItem(null, TKPMessages.eValidate.VLM0211.ToString());
                    MessageDialog.ShowBusiness(this, error.Message);
                    return false;
                }

                if (decLT < 1)
                {
                    error = new ErrorItem(null, TKPMessages.eValidate.VLM0210.ToString());
                    MessageDialog.ShowBusiness(this, error.Message);
                    return false;
                }
                //else
                //{

                //Comment by Sansanee K. 23 March 2012
                //ItemValidator itemValidator = new ItemValidator();
                //BusinessException error = itemValidator.CheckItemNotExist(itemSeq.ToNZString());
                //if (error != null)
                //{

                //    MessageDialog.ShowBusiness(this, error.Error.Message);
                //    return false;
                //}
                //}

            }
            // ถ้า Validate Row ผ่าน แสดงว่า แถวนั้นไม่จำเป็นต้องเช็คอีกรอบ
            m_bRowHasModified = false;
            return true;
        }

        private void InitialScreen()
        {
            // look up combobox
            InitialComboBox();
            InitialFormat();

            CtrlUtil.EnabledControl(false, txtCreateBy, txtCreateDate, txtReviseBy, txtReviseDate);

            //SetScreenMode(eScreenMode.IDLE);

            #region set keypress
            txtMasterNo.KeyPress += CommonLib.CtrlUtil.SetNextControl;
            txtPartNo.KeyPress += CommonLib.CtrlUtil.SetNextControl;
            txtPartName.KeyPress += CommonLib.CtrlUtil.SetNextControl;
            cboPartType.KeyPress += CommonLib.CtrlUtil.SetNextControl;

            #region Product Tab

            //cboModel.KeyPress += CommonLib.CtrlUtil.SetNextControl;            
            cboKindOfProduct.KeyPress += CommonLib.CtrlUtil.SetNextControl;
            cboCustomer.KeyPress += CommonLib.CtrlUtil.SetNextControl;
            txtCustomerUsePoint.KeyPress += CommonLib.CtrlUtil.SetNextControl;
            txtWeight.KeyPress += CommonLib.CtrlUtil.SetNextControl;
            cboBOI.KeyPress += CommonLib.CtrlUtil.SetNextControl;
            cboProduction.KeyPress += CommonLib.CtrlUtil.SetNextControl;
            cboItemLevel.KeyPress += CommonLib.CtrlUtil.SetNextControl;

            txtMatName.KeyPress += CommonLib.CtrlUtil.SetNextControl;
            txtMatSize.KeyPress += CommonLib.CtrlUtil.SetNextControl;
            cboMatSupplier.KeyPress += CommonLib.CtrlUtil.SetNextControl;
            txtKindOfMat.KeyPress += CommonLib.CtrlUtil.SetNextControl;
            cboMatDI.KeyPress += CommonLib.CtrlUtil.SetNextControl;
            txtRemark.KeyPress += CommonLib.CtrlUtil.SetNextControl;

            #endregion

            #region Screw Tab

            //cboScrewKind.KeyPress += CommonLib.CtrlUtil.SetNextControl;
            //cboScrewHead.KeyPress += CommonLib.CtrlUtil.SetNextControl;
            txtScrewM.KeyPress += CommonLib.CtrlUtil.SetNextControl;
            txtScrewL.KeyPress += CommonLib.CtrlUtil.SetNextControl;
            cboScrewType.KeyPress += CommonLib.CtrlUtil.SetNextControl;
            cboScrewRemark1.KeyPress += CommonLib.CtrlUtil.SetNextControl;
            cboScrewRemark2.KeyPress += CommonLib.CtrlUtil.SetNextControl;
            txtScrewHexabular.KeyPress += CommonLib.CtrlUtil.SetNextControl;

            #endregion

            #region Machine Tab

            cboMachineProcess1.KeyPress += CommonLib.CtrlUtil.SetNextControl;
            cboMachineMCType1.KeyPress += CommonLib.CtrlUtil.SetNextControl;
            cboMachineProcess2.KeyPress += CommonLib.CtrlUtil.SetNextControl;
            cboMachineMCType2.KeyPress += CommonLib.CtrlUtil.SetNextControl;
            cboMachineProcess3.KeyPress += CommonLib.CtrlUtil.SetNextControl;
            cboMachineMCType3.KeyPress += CommonLib.CtrlUtil.SetNextControl;
            cboMachineProcess4.KeyPress += CommonLib.CtrlUtil.SetNextControl;
            cboMachineMCType4.KeyPress += CommonLib.CtrlUtil.SetNextControl;
            cboMachineProcess5.KeyPress += CommonLib.CtrlUtil.SetNextControl;
            cboMachineMCType5.KeyPress += CommonLib.CtrlUtil.SetNextControl;
            cboMachineProcess6.KeyPress += CommonLib.CtrlUtil.SetNextControl;
            cboMachineMCType6.KeyPress += CommonLib.CtrlUtil.SetNextControl;

            #endregion

            #region Heat Treatment Tab

            rdoHeatTreatmentYes.KeyPress += CommonLib.CtrlUtil.SetNextControl;
            rdoHeatTreatmentNo.KeyPress += CommonLib.CtrlUtil.SetNextControl;
            cboHeatTreatmentType.KeyPress += CommonLib.CtrlUtil.SetNextControl;
            txtHardingSurface.KeyPress += CommonLib.CtrlUtil.SetNextControl;
            txtCoreHardness.KeyPress += CommonLib.CtrlUtil.SetNextControl;
            txtCaseDeptAndCondition.KeyPress += CommonLib.CtrlUtil.SetNextControl;

            #endregion

            #region Plating Tab

            rdoPlatingYes.KeyPress += CommonLib.CtrlUtil.SetNextControl;
            rdoPlatingNo.KeyPress += CommonLib.CtrlUtil.SetNextControl;
            txtPlatingKind.KeyPress += CommonLib.CtrlUtil.SetNextControl;
            cboPlatingSupplier.KeyPress += CommonLib.CtrlUtil.SetNextControl;
            txtPlatingThickness1From.KeyPress += CommonLib.CtrlUtil.SetNextControl;
            txtPlatingThickness1To.KeyPress += CommonLib.CtrlUtil.SetNextControl;
            txtPlatingThickness2From.KeyPress += CommonLib.CtrlUtil.SetNextControl;
            txtPlatingThickness2To.KeyPress += CommonLib.CtrlUtil.SetNextControl;
            //cboKTCPlating.KeyPress += CommonLib.CtrlUtil.SetNextControl;
            rdoPlatingBakingYes.KeyPress += CommonLib.CtrlUtil.SetNextControl;
            rdoPlatingBakingNo.KeyPress += CommonLib.CtrlUtil.SetNextControl;
            //cboPlatingBakingTime.KeyPress += CommonLib.CtrlUtil.SetNextControl;
            //cboPlatingBakingTemp.KeyPress += CommonLib.CtrlUtil.SetNextControl;

            #endregion

            #region Other Tab

            rdoOtherTreatment1Yes.KeyPress += CommonLib.CtrlUtil.SetNextControl;
            rdoOtherTreatment1No.KeyPress += CommonLib.CtrlUtil.SetNextControl;
            //cboOtherKind1.KeyPress += CommonLib.CtrlUtil.SetNextControl;
            //cboOtherCondition1.KeyPress += CommonLib.CtrlUtil.SetNextControl;
            rdoOtherTreatment2Yes.KeyPress += CommonLib.CtrlUtil.SetNextControl;
            rdoOtherTreatment2No.KeyPress += CommonLib.CtrlUtil.SetNextControl;
            //cboOtherKind2.KeyPress += CommonLib.CtrlUtil.SetNextControl;
            //cboOtherCondition2.KeyPress += CommonLib.CtrlUtil.SetNextControl;

            #endregion

            #endregion

            #region Bind DataModel

            dmcItem.AddControl(txtMasterNo);
            dmcItem.AddControl(txtPartNo);
            dmcItem.AddControl(txtPartName);
            dmcItem.AddControl(cboPartType);

            #region Product Tab

            //dmcItem.AddControl(cboModel);
            dmcItem.AddControl(cboKindOfProduct);
            dmcItem.AddControl(cboCustomer);
            dmcItem.AddControl(txtCustomerUsePoint);
            dmcItem.AddControl(txtWeight);
            dmcItem.AddControl(cboBOI);
            dmcItem.AddControl(cboProduction);
            dmcItem.AddControl(cboItemLevel);
            dmcItem.AddControl(txtMatName);
            dmcItem.AddControl(txtMatSize);
            dmcItem.AddControl(cboMatSupplier);
            dmcItem.AddControl(txtKindOfMat);
            dmcItem.AddControl(cboMatDI);
            dmcItem.AddControl(txtRemark);

            dmcItem.AddControl(txtCreateDate);
            dmcItem.AddControl(txtCreateBy);
            dmcItem.AddControl(txtReviseDate);
            dmcItem.AddControl(txtReviseBy);
            #endregion

            #region Screw Tab

            dmcItem.AddControl(cboScrewKind);
            dmcItem.AddControl(cboScrewHead);
            dmcItem.AddControl(txtScrewM);
            dmcItem.AddControl(txtScrewL);
            dmcItem.AddControl(cboScrewType);
            dmcItem.AddControl(cboScrewRemark1);
            dmcItem.AddControl(cboScrewRemark2);
            dmcItem.AddControl(txtScrewHexabular);

            #endregion

            #region Machine Tab

            dmcItem.AddControl(cboMachineProcess1);
            dmcItem.AddControl(cboMachineProcess2);
            dmcItem.AddControl(cboMachineProcess3);
            dmcItem.AddControl(cboMachineProcess4);
            dmcItem.AddControl(cboMachineProcess5);
            dmcItem.AddControl(cboMachineProcess6);
            dmcItem.AddControl(cboMachineMCType1);
            dmcItem.AddControl(cboMachineMCType2);
            dmcItem.AddControl(cboMachineMCType3);
            dmcItem.AddControl(cboMachineMCType4);
            dmcItem.AddControl(cboMachineMCType5);
            dmcItem.AddControl(cboMachineMCType6);

            #endregion

            #region Heat Treatment

            //dmcItem.AddControl(rdoHeatTreatmentYes); 
            //dmcItem.AddControl(rdoHeatTreatmentNo);
            dmcItem.AddControl(cboHeatTreatmentType);
            dmcItem.AddControl(txtHardingSurface);
            dmcItem.AddControl(txtCoreHardness);
            dmcItem.AddControl(txtCaseDeptAndCondition);

            #endregion

            #region Plating Tab

            //dmcItem.AddControl(rdoPlatingYes);
            //dmcItem.AddControl(rdoPlatingNo);
            dmcItem.AddControl(txtPlatingKind);
            dmcItem.AddControl(cboPlatingSupplier);
            dmcItem.AddControl(txtPlatingThickness1From);
            dmcItem.AddControl(txtPlatingThickness1To);
            dmcItem.AddControl(txtPlatingThickness2From);
            dmcItem.AddControl(txtPlatingThickness2To);
            dmcItem.AddControl(cboKTCPlating);
            //dmcItem.AddControl(rdoPlatingBakingYes);
            //dmcItem.AddControl(rdoPlatingBakingNo);
            dmcItem.AddControl(cboPlatingBakingTime);
            dmcItem.AddControl(cboPlatingBakingTemp);

            #endregion

            #region Other Tab

            //dmcItem.AddControl(rdoOtherTreatment1Yes);
            //dmcItem.AddControl(rdoOtherTreatment1No);
            dmcItem.AddControl(cboOtherKind1);
            dmcItem.AddControl(cboOtherCondition1);
            //dmcItem.AddControl(rdoOtherTreatment2Yes);
            //dmcItem.AddControl(rdoOtherTreatment2No);
            dmcItem.AddControl(cboOtherKind2);
            dmcItem.AddControl(cboOtherCondition2);

            #endregion

            #endregion
        }

        private void InitialSpread()
        {
            // set skin 
            shtRouting.ActiveSkin = Common.ACTIVE_SKIN;
            shtComponent.ActiveSkin = Common.ACTIVE_SKIN;

            //ItemUIDM model = new ItemUIDM();
            //shtRouting.DataSource = model.DataView;
            //ItemUIDM modelComponent = new ItemUIDM();
            //shtComponent.DataSource = modelComponent.DataView;

            // SUPPLIER_CD Combobox in shtRouting
            LookupDataBIZ bizLookup = new LookupDataBIZ();
            NZString[] SupplierType = new NZString[] { (NZString)DataDefine.Convert2ClassCode(DataDefine.eLOCATION_CLS.Vendor), (NZString)DataDefine.Convert2ClassCode(DataDefine.eLOCATION_CLS.CustomerVendor) };
            LookupData LookupSupplier = bizLookup.LoadLookupLocation(SupplierType);
            shtRouting.Columns[(int)eColumns.SUPPLIER_CD].CellType = CtrlUtil.CreateComboBoxCellType(LookupSupplier);

            // Customer
            NZString[] CustomerType = new NZString[] { (NZString)DataDefine.Convert2ClassCode(DataDefine.eLOCATION_CLS.Customer), (NZString)DataDefine.Convert2ClassCode(DataDefine.eLOCATION_CLS.Vendor), (NZString)DataDefine.Convert2ClassCode(DataDefine.eLOCATION_CLS.CustomerVendor) };
            LookupData LookupCustomer = bizLookup.LoadLookupLocation(CustomerType);
            shtComponent.Columns[(int)eColComponent.CUSTOMER_CD].CellType = CtrlUtil.CreateComboBoxCellType(LookupCustomer);

            // new keyboard spread
            r_keyboardSpread = new KeyboardSpread(fpRouting);
            r_keyboardSpread.RowAdding += r_keyboardSpread_RowAdding;
            r_keyboardSpread.RowAdded += r_keyboardSpread_RowAdded;
            r_keyboardSpread.RowRemoving += r_keyboardSpread_RowRemoving;
            r_keyboardSpread.RowRemoved += r_keyboardSpread_RowRemoved;
            r_keyboardSpread.StartBind();

            c_keyboardSpread = new KeyboardSpread(fpComponent);
            c_keyboardSpread.RowAdding += c_keyboardSpread_RowAdding;
            c_keyboardSpread.RowAdded += c_keyboardSpread_RowAdded;
            c_keyboardSpread.RowRemoved += c_keyboardSpread_RowRemoved;
            c_keyboardSpread.StartBind();

            //  set bind data table with column of spread
            CtrlUtil.MappingDataFieldWithEnum(shtRouting, typeof(eColumns));
            CtrlUtil.MappingDataFieldWithEnum(shtComponent, typeof(eColComponent));
        }

        private void InitialComboBox()
        {
            #region Initial Format

            cboKindOfProduct.Format += Common.ComboBox_Format;
            cboCustomer.Format += Common.ComboBox_Format;
            cboBOI.Format += Common.ComboBox_Format;
            cboProduction.Format += Common.ComboBox_Format;
            cboItemLevel.Format += Common.ComboBox_Format;
            cboMatSupplier.Format += Common.ComboBox_Format;
            cboMatDI.Format += Common.ComboBox_Format;

            //cboScrewKind.Format += Common.ComboBox_Format;
            //cboScrewHead.Format += Common.ComboBox_Format;
            cboScrewType.Format += Common.ComboBox_Format;
            cboScrewRemark1.Format += Common.ComboBox_Format;
            cboScrewRemark2.Format += Common.ComboBox_Format;

            cboMachineProcess1.Format += Common.ComboBox_Format;
            cboMachineProcess2.Format += Common.ComboBox_Format;
            cboMachineProcess3.Format += Common.ComboBox_Format;
            cboMachineProcess4.Format += Common.ComboBox_Format;
            cboMachineProcess5.Format += Common.ComboBox_Format;
            cboMachineProcess6.Format += Common.ComboBox_Format;
            //cboMachineMCType1.Format += Common.ComboBox_Format;
            //cboMachineMCType2.Format += Common.ComboBox_Format;
            //cboMachineMCType3.Format += Common.ComboBox_Format;
            //cboMachineMCType4.Format += Common.ComboBox_Format;
            //cboMachineMCType5.Format += Common.ComboBox_Format;
            //cboMachineMCType6.Format += Common.ComboBox_Format;

            cboHeatTreatmentType.Format += Common.ComboBox_Format;

            cboPlatingSupplier.Format += Common.ComboBox_Format;
            //cboKTCPlating.Format += Common.ComboBox_Format;
            //cboPlatingBakingTime.Format += Common.ComboBox_Format;
            //cboPlatingBakingTemp.Format += Common.ComboBox_Format;
            //cboOtherKind1.Format += Common.ComboBox_Format;
            //cboOtherKind2.Format += Common.ComboBox_Format;

            //Comment by Sansnaee K. 23 March 2012
            //cboPartType.Format += Common.ComboBox_Format;
            //cboKindOfProduct.Format += Common.ComboBox_Format;
            //txtBOI.Format += Common.ComboBox_Format;
            ////cboCustomer.Format += Common.ComboBox_Format;
            //txtProduction.Format += Common.ComboBox_Format;
            //cboMatSupplier.Format += Common.ComboBox_Format;
            //txtMatDI.Format += Common.ComboBox_Format;
            ////cboItemLevel.Format += Common.ComboBox_Format;
            //cboPlatingSupplier.Format += Common.ComboBox_Format;
            ////cboMachineProcess1 += Common.ComboBox_Format;
            ////cboMachineProcess2 += Common.ComboBox_Format;
            ////cboMachineProcess3 += Common.ComboBox_Format;
            ////cboMachineProcess4 += Common.ComboBox_Format;
            ////cboMachineProcess5 += Common.ComboBox_Format;
            ////cboMachineProcess6  += Common.ComboBox_Format;

            #endregion

            #region Load Lookup data

            LookupDataBIZ bizLookup = new LookupDataBIZ();

            string strItemTableName = EVOFramework.Data.DTOUtility.ReadTableName(typeof(ItemDTO));

            // Lookup model,main material,color, for customer
            //LookupData lookupModel = bizLookup.LoadLookupTextHelper(ItemDTO.eColumns.MODEL);
            //cboModel.LoadLookupData(lookupModel);

            LookupData lookupProductGroup = bizLookup.LoadLookupClassType(DataDefine.KIND_OF_PRODUCT.ToNZString());
            cboKindOfProduct.LoadLookupData(lookupProductGroup);
            cboKindOfProduct.SelectedIndex = -1;

            // Lookup BOI
            LookupData lookupBOI = bizLookup.LoadLookupClassType(DataDefine.BOI_PROJECT.ToNZString());
            cboBOI.LoadLookupData(lookupBOI);
            cboBOI.SelectedIndex = -1;

            // Customer
            NZString[] CustomerType = new NZString[] { (NZString)DataDefine.Convert2ClassCode(DataDefine.eLOCATION_CLS.Customer), (NZString)DataDefine.Convert2ClassCode(DataDefine.eLOCATION_CLS.CustomerVendor) };
            LookupData LookupCustomer = bizLookup.LoadLookupLocation(CustomerType);
            cboCustomer.LoadLookupData(LookupCustomer);
            cboCustomer.SelectedIndex = -1;

            // Production DI
            LookupData LookupProductionDI = bizLookup.LoadLookupClassType(DataDefine.PRODUCTION_DI.ToNZString());
            cboProduction.LoadLookupData(LookupProductionDI);
            cboProduction.SelectedIndex = -1;

            // Matchine Supplier
            NZString[] MatSupplier = new NZString[] { (NZString)DataDefine.Convert2ClassCode(DataDefine.eLOCATION_CLS.Vendor), (NZString)DataDefine.Convert2ClassCode(DataDefine.eLOCATION_CLS.CustomerVendor) };
            LookupData LookupMatSupplier = bizLookup.LoadLookupLocation(MatSupplier);
            cboMatSupplier.LoadLookupData(LookupMatSupplier.Clone());
            cboPlatingSupplier.LoadLookupData(LookupMatSupplier.Clone());
            cboMatSupplier.SelectedIndex = -1;
            cboPlatingSupplier.SelectedIndex = -1;

            // Matchine DI
            LookupData LookupMatDI = bizLookup.LoadLookupClassType(DataDefine.MAT_DI.ToNZString());
            cboMatDI.LoadLookupData(LookupMatDI);
            cboMatDI.SelectedIndex = -1;

            // Item Level
            LookupData LookupItemLevel = bizLookup.LoadLookupClassType(DataDefine.ITEM_LEVEL.ToNZString());
            cboItemLevel.LoadLookupData(LookupItemLevel);
            cboItemLevel.SelectedIndex = -1;

            // Screw Kind
            // Modified by Pongthorn S. @ 2012-05-08
            //LookupData LookupScrewKind = bizLookup.LoadLookupClassType(DataDefine.SCREW_KIND.ToNZString());
            //cboScrewKind.LoadLookupData(LookupScrewKind);
            LookupData lookupScrewKind = bizLookup.LoadLookupTextHelper(strItemTableName, ItemDTO.eColumns.SCREW_KIND.ToString());
            cboScrewKind.LoadLookupData(lookupScrewKind);
            cboScrewKind.SelectedIndex = -1;

            // Screw Head
            // Modified by Pongthorn S. @ 2012-05-08
            //LookupData LookupScrewHead = bizLookup.LoadLookupClassType(DataDefine.SCREW_HEAD.ToNZString());
            //cboScrewHead.LoadLookupData(LookupScrewHead);
            LookupData lookupScrewHead = bizLookup.LoadLookupTextHelper(strItemTableName, ItemDTO.eColumns.SCREW_HEAD.ToString());
            cboScrewHead.LoadLookupData(lookupScrewHead);
            cboScrewHead.SelectedIndex = -1;

            // Screw Type
            LookupData LookupScrewType = bizLookup.LoadLookupClassType(DataDefine.SCREW_TYPE.ToNZString());
            cboScrewType.LoadLookupData(LookupScrewType);
            cboScrewType.SelectedIndex = -1;

            // Screw Remark1
            LookupData LookupScrewRemark1 = bizLookup.LoadLookupClassType(DataDefine.SCREW_REMARK1.ToNZString());
            cboScrewRemark1.LoadLookupData(LookupScrewRemark1);
            cboScrewRemark1.SelectedIndex = -1;

            // Screw Remark2
            LookupData LookupScrewRemark2 = bizLookup.LoadLookupClassType(DataDefine.SCREW_REMARK2.ToNZString());
            cboScrewRemark2.LoadLookupData(LookupScrewRemark2);
            cboScrewRemark2.SelectedIndex = -1;

            //// Machine Type1
            ////LookupData LookupMCType1 = bizLookup.LoadLookupClassType(DataDefine.MACHINE_TYPE.ToNZString());
            //LookupData LookupMCType1 = bizLookup.LoadMachineGroup();
            //cboMachineMCType1.LoadLookupData(LookupMCType1);
            //cboMachineMCType1.SelectedIndex = -1;

            //// Machine Type2
            ////LookupData LookupMCType2 = bizLookup.LoadLookupClassType(DataDefine.MACHINE_TYPE.ToNZString());            
            //cboMachineMCType2.LoadLookupData(LookupMCType1.Clone());
            //cboMachineMCType2.SelectedIndex = -1;

            //// Machine Type3
            ////LookupData LookupMCType3 = bizLookup.LoadLookupClassType(DataDefine.MACHINE_TYPE.ToNZString());
            //cboMachineMCType3.LoadLookupData(LookupMCType1.Clone());
            //cboMachineMCType3.SelectedIndex = -1;

            //// Machine Type4
            ////LookupData LookupMCType4 = bizLookup.LoadLookupClassType(DataDefine.MACHINE_TYPE.ToNZString());
            //cboMachineMCType4.LoadLookupData(LookupMCType1.Clone());
            //cboMachineMCType4.SelectedIndex = -1;

            //// Machine Type5
            ////LookupData LookupMCType5 = bizLookup.LoadLookupClassType(DataDefine.MACHINE_TYPE.ToNZString());
            //cboMachineMCType5.LoadLookupData(LookupMCType1.Clone());
            //cboMachineMCType5.SelectedIndex = -1;

            //// Machine Type6
            ////LookupData LookupMCType6 = bizLookup.LoadLookupClassType(DataDefine.MACHINE_TYPE.ToNZString());
            //cboMachineMCType6.LoadLookupData(LookupMCType1.Clone());
            //cboMachineMCType6.SelectedIndex = -1;

            // HeatTreatmentType
            LookupData LookupHeatTreatmentType = bizLookup.LoadLookupClassType(DataDefine.HEAT_TREATMENT_TYPE.ToNZString());
            cboHeatTreatmentType.LoadLookupData(LookupHeatTreatmentType);
            cboHeatTreatmentType.SelectedIndex = -1;


            // KTC Plating
            // Modified by Pongthorn S. @ 2012-05-08
            //LookupData LookupKTCPlating = bizLookup.LoadLookupClassType(DataDefine.KTC_PLATING.ToNZString());
            //cboKTCPlating.LoadLookupData(LookupKTCPlating);
            LookupData LookupKTCPlating = bizLookup.LoadLookupTextHelper(strItemTableName, ItemDTO.eColumns.PLATING_KTC.ToString());
            cboKTCPlating.LoadLookupData(LookupKTCPlating);
            cboKTCPlating.SelectedIndex = -1;

            // Baking Time
            // Modified by Pongthorn S. @ 2012-05-08
            //LookupData LookupBakTime = bizLookup.LoadLookupClassType(DataDefine.BAKING_TIME.ToNZString());
            //cboPlatingBakingTime.LoadLookupData(LookupBakTime);
            LookupData LookupBakTime = bizLookup.LoadLookupTextHelper(strItemTableName, ItemDTO.eColumns.BAKING_TIME.ToString());
            cboPlatingBakingTime.LoadLookupData(LookupBakTime);
            cboPlatingBakingTime.SelectedIndex = -1;

            // Baking Temp
            // Modified by Pongthorn S. @ 2012-05-08
            //LookupData LookupBakTemp = bizLookup.LoadLookupClassType(DataDefine.BAKING_TEMP.ToNZString());
            //cboPlatingBakingTemp.LoadLookupData(LookupBakTemp);
            LookupData LookupBakTemp = bizLookup.LoadLookupTextHelper(strItemTableName, ItemDTO.eColumns.BAKING_TEMP.ToString());
            cboPlatingBakingTemp.LoadLookupData(LookupBakTemp);
            cboPlatingBakingTemp.SelectedIndex = -1;

            // Other Kind
            // Modified by Pongthorn S. @ 2012-05-08
            //LookupData LookupOtherKind = bizLookup.LoadLookupClassType(DataDefine.OTHER_KIND.ToNZString());
            //cboOtherKind1.LoadLookupData(LookupOtherKind.Clone());
            //cboOtherKind2.LoadLookupData(LookupOtherKind.Clone());
            LookupData LookupOtherKind1 = bizLookup.LoadLookupTextHelper(strItemTableName, ItemDTO.eColumns.OTHER_TREATMENT1_KIND.ToString());
            LookupData LookupOtherKind2 = bizLookup.LoadLookupTextHelper(strItemTableName, ItemDTO.eColumns.OTHER_TREATMENT2_KIND.ToString());
            cboOtherKind1.LoadLookupData(LookupOtherKind1);
            cboOtherKind2.LoadLookupData(LookupOtherKind2);
            cboOtherKind1.SelectedIndex = -1;
            cboOtherKind2.SelectedIndex = -1;


            // Other Condition
            // Modified by Pongthorn S. @ 2012-05-08
            //LookupData LookupOtherCon = bizLookup.LoadLookupClassType(DataDefine.OTHER_CONDITION.ToNZString());
            //cboOtherCondition1.LoadLookupData(LookupOtherCon.Clone());
            //cboOtherCondition2.LoadLookupData(LookupOtherCon.Clone());
            LookupData LookupOtherCon1 = bizLookup.LoadLookupTextHelper(strItemTableName, ItemDTO.eColumns.OTHER_TREATMENT1_CONDITION.ToString());
            LookupData LookupOtherCon2 = bizLookup.LoadLookupTextHelper(strItemTableName, ItemDTO.eColumns.OTHER_TREATMENT2_CONDITION.ToString());
            cboOtherCondition1.LoadLookupData(LookupOtherCon1);
            cboOtherCondition2.LoadLookupData(LookupOtherCon2);
            cboOtherCondition1.SelectedIndex = -1;
            cboOtherCondition2.SelectedIndex = -1;

            #endregion
        }

        private void InitialFormat()
        {
            //dtPeriodBegin.Format = Common.CurrentUserInfomation.DateFormatString;
            //dtPeriodEnd.Format = Common.CurrentUserInfomation.DateFormatString;

            // Set Control Format
            CommonLib.FormatUtil.SetNumberFormat(this.txtWeight, FormatUtil.eNumberFormat.Qty_Gram);

            // Set Spread Format
            //FormatUtil.SetDateFormat(shtDelivery.Columns[(int)eColView.TRANS_DATE]);
            FormatUtil.SetNumberFormat(shtRouting.Columns[(int)eColumns.ITEM_SEQ], FormatUtil.eNumberFormat.MasterNo);
            FormatUtil.SetNumberFormat(shtRouting.Columns[(int)eColumns.WEIGHT], FormatUtil.eNumberFormat.Qty_Gram);
            FormatUtil.SetNumberFormat(shtRouting.Columns[(int)eColumns.QTY_PER_DAY], FormatUtil.eNumberFormat.Qty_PCS);
            FormatUtil.SetNumberFormat(shtRouting.Columns[(int)eColumns.PRODUCTION_LEADTIME], FormatUtil.eNumberFormat.Qty_PCS);
            FormatUtil.SetNumberFormat(shtComponent.Columns[(int)eColComponent.SEQ_NO], FormatUtil.eNumberFormat.MasterNo);
            FormatUtil.SetNumberFormat(shtComponent.Columns[(int)eColComponent.PCS], FormatUtil.eNumberFormat.Qty_PCS);
        }

        private void MachineCombobox(DataTable dtProcess)
        {
            m_bCheckProcessMachine = false;
            m_bLoadMachineGroup = false;

            DataTable Machine = dtProcess;//(DataTable)shtRouting.DataSource;
            if (Machine == null)
            {
                //clear datasource of combobox
                cboMachineProcess1.DataSource = null;
                cboMachineProcess2.DataSource = null;
                cboMachineProcess3.DataSource = null;
                cboMachineProcess4.DataSource = null;
                cboMachineProcess5.DataSource = null;
                cboMachineProcess6.DataSource = null;

                return;
            }

            // MachineCombobox
            LookupDataBIZ bizLookup = new LookupDataBIZ();
            LookupData lookupMachineProcess = bizLookup.LoadLookupMachine(Machine);
            NZString MachineProcess1 = new NZString(cboMachineProcess1, cboMachineProcess1.SelectedValue);
            NZString MachineProcess2 = new NZString(cboMachineProcess2, cboMachineProcess2.SelectedValue);
            NZString MachineProcess3 = new NZString(cboMachineProcess3, cboMachineProcess3.SelectedValue);
            NZString MachineProcess4 = new NZString(cboMachineProcess4, cboMachineProcess4.SelectedValue);
            NZString MachineProcess5 = new NZString(cboMachineProcess5, cboMachineProcess5.SelectedValue);
            NZString MachineProcess6 = new NZString(cboMachineProcess6, cboMachineProcess6.SelectedValue);
            cboMachineProcess1.LoadLookupData(lookupMachineProcess.Clone());
            cboMachineProcess2.LoadLookupData(lookupMachineProcess.Clone());
            cboMachineProcess3.LoadLookupData(lookupMachineProcess.Clone());
            cboMachineProcess4.LoadLookupData(lookupMachineProcess.Clone());
            cboMachineProcess5.LoadLookupData(lookupMachineProcess.Clone());
            cboMachineProcess6.LoadLookupData(lookupMachineProcess.Clone());

            if (MachineProcess1.IsNull)
            {
                cboMachineProcess1.SelectedIndex = -1;
            }
            else
            {
                cboMachineProcess1.SelectedValue = MachineProcess1;
            }

            if (MachineProcess2.IsNull)
            {
                cboMachineProcess2.SelectedIndex = -1;
            }
            else
            {
                cboMachineProcess2.SelectedValue = MachineProcess2;
            }

            if (MachineProcess3.IsNull)
            {
                cboMachineProcess3.SelectedIndex = -1;
            }
            else
            {
                cboMachineProcess3.SelectedValue = MachineProcess3;
            }

            if (MachineProcess4.IsNull)
            {
                cboMachineProcess4.SelectedIndex = -1;
            }
            else
            {
                cboMachineProcess4.SelectedValue = MachineProcess4;
            }

            if (MachineProcess5.IsNull)
            {
                cboMachineProcess5.SelectedIndex = -1;
            }
            else
            {
                cboMachineProcess5.SelectedValue = MachineProcess5;
            }

            if (MachineProcess6.IsNull)
            {
                cboMachineProcess6.SelectedIndex = -1;
            }
            else
            {
                cboMachineProcess6.SelectedValue = MachineProcess6;
            }

            m_bCheckProcessMachine = true;
            m_bLoadMachineGroup = true;
        }

        private void LoadDataForEdit(NZString ItemCD)
        {
            //SetScreenMode(eScreenMode.EDIT);
            ItemUIDM uidmItem = new ItemUIDM();
            ItemController ctlItem = new ItemController();
            uidmItem = ctlItem.LoadItem(ItemCD);

            MachineCombobox((DataTable)uidmItem.DataView);

            dmcItem.LoadData(uidmItem);

            if (!uidmItem.HEAT_FLAG.IsNull && uidmItem.HEAT_FLAG.StrongValue == 1)
            {
                rdoHeatTreatmentYes.Checked = true;
            }
            else
            {
                rdoHeatTreatmentNo.Checked = true;
            }

            if (!uidmItem.PLATING_FLAG.IsNull && uidmItem.PLATING_FLAG.StrongValue == 1)
            {
                rdoPlatingYes.Checked = true;
            }
            else
            {
                rdoPlatingNo.Checked = true;
            }

            if (!uidmItem.BAKING_FLAG.IsNull && uidmItem.BAKING_FLAG.StrongValue == 1)
            {
                rdoPlatingBakingYes.Checked = true;
            }
            else
            {
                rdoPlatingBakingNo.Checked = true;
            }

            if (!uidmItem.OTHER_TREATMENT1_FLAG.IsNull && uidmItem.OTHER_TREATMENT1_FLAG.StrongValue == 1)
            {
                rdoOtherTreatment1Yes.Checked = true;
            }
            else
            {
                rdoOtherTreatment1No.Checked = true;
            }

            if (!uidmItem.OTHER_TREATMENT2_FLAG.IsNull && uidmItem.OTHER_TREATMENT2_FLAG.StrongValue == 1)
            {
                rdoOtherTreatment2Yes.Checked = true;
            }
            else
            {
                rdoOtherTreatment2No.Checked = true;
            }

            shtRouting.RowCount = 0;
            shtRouting.DataSource = null;
            shtRouting.DataSource = uidmItem.DataView;

            shtComponent.RowCount = 0;
            shtComponent.DataSource = null;
            shtComponent.DataSource = uidmItem.DataComponentView;

            if (uidmItem.DataItemMachine != null)
            {
                m_bCheckProcessMachine = false;

                for (int i = 0; i < uidmItem.DataItemMachine.Rows.Count; i++)
                {
                    switch (i)
                    {
                        case 0:
                            cboMachineProcess1.SelectedValue = uidmItem.DataItemMachine.Rows[i][(int)ItemMachineDTO.eColumns.MACHINE_PROCESS];
                            cboMachineMCType1.SelectedValue = uidmItem.DataItemMachine.Rows[i][(int)ItemMachineDTO.eColumns.MACHINE_TYPE];
                            break;
                        case 1:
                            cboMachineProcess2.SelectedValue = uidmItem.DataItemMachine.Rows[i][(int)ItemMachineDTO.eColumns.MACHINE_PROCESS];
                            cboMachineMCType2.SelectedValue = uidmItem.DataItemMachine.Rows[i][(int)ItemMachineDTO.eColumns.MACHINE_TYPE];
                            break;
                        case 2:
                            cboMachineProcess3.SelectedValue = uidmItem.DataItemMachine.Rows[i][(int)ItemMachineDTO.eColumns.MACHINE_PROCESS];
                            cboMachineMCType3.SelectedValue = uidmItem.DataItemMachine.Rows[i][(int)ItemMachineDTO.eColumns.MACHINE_TYPE];
                            break;
                        case 3:
                            cboMachineProcess4.SelectedValue = uidmItem.DataItemMachine.Rows[i][(int)ItemMachineDTO.eColumns.MACHINE_PROCESS];
                            cboMachineMCType4.SelectedValue = uidmItem.DataItemMachine.Rows[i][(int)ItemMachineDTO.eColumns.MACHINE_TYPE];
                            break;
                        case 4:
                            cboMachineProcess5.SelectedValue = uidmItem.DataItemMachine.Rows[i][(int)ItemMachineDTO.eColumns.MACHINE_PROCESS];
                            cboMachineMCType5.SelectedValue = uidmItem.DataItemMachine.Rows[i][(int)ItemMachineDTO.eColumns.MACHINE_TYPE];
                            break;
                        case 5:
                            cboMachineProcess6.SelectedValue = uidmItem.DataItemMachine.Rows[i][(int)ItemMachineDTO.eColumns.MACHINE_PROCESS];
                            cboMachineMCType6.SelectedValue = uidmItem.DataItemMachine.Rows[i][(int)ItemMachineDTO.eColumns.MACHINE_TYPE];
                            break;
                    }
                }

                m_bCheckProcessMachine = true;
            }

            //LoadImage(ItemCD);
        }

        private bool LoadItemIntoRow(int row, NZString ITEM_CD, ItemUIDM SelectedItem)
        {
            ItemValidator itemValidator = new ItemValidator();

            if (ITEM_CD != null)
            {
                BusinessException error = itemValidator.CheckItemNotExist(ITEM_CD);
                if (error != null)
                {
                    shtComponent.Cells[row, (int)eColComponent.SHORT_NAME].Value = null;
                    shtComponent.Cells[row, (int)eColComponent.CUSTOMER_CD].Value = null;
                    return false;
                }

                ItemBIZ itemBIZ = new ItemBIZ();
                ItemDTO itemDTO = itemBIZ.LoadItem(ITEM_CD);
                shtComponent.Cells[row, (int)eColComponent.ITEM_CD].Value = itemDTO.ITEM_CD.Value;
                shtComponent.Cells[row, (int)eColComponent.SHORT_NAME].Value = itemDTO.SHORT_NAME.Value;
                shtComponent.Cells[row, (int)eColComponent.CUSTOMER_CD].Value = itemDTO.CUSTOMER_CD.Value;

            }

            return true;
        }

        private bool LoadItemIntoRouting(int row, NZString LOC_CD)
        {

            ItemBIZ itemBIZ = new ItemBIZ();
            ItemProcessDTO itemDTO = itemBIZ.LoadItemProcess(LOC_CD);
            shtRouting.Cells[row, (int)eColumns.ITEM_SEQ].Value = itemDTO.ITEM_SEQ.Value;
            shtRouting.Cells[row, (int)eColumns.PROCESS_CD].Value = itemDTO.PROCESS_CD.Value;
            shtRouting.Cells[row, (int)eColumns.WEIGHT].Value = itemDTO.WEIGHT.Value;
            shtRouting.Cells[row, (int)eColumns.PRODUCTION_LEADTIME].Value = itemDTO.PRODUCTION_LEADTIME.Value;
            shtRouting.Cells[row, (int)eColumns.QTY_PER_DAY].Value = itemDTO.QTY_PER_DAY.Value;
            shtRouting.Cells[row, (int)eColumns.SUPPLIER_CD].Value = itemDTO.SUPPLIER_CD.Value;

            return true;
        }

        void ComboBoxMaxLength(object sender, KeyPressEventArgs e)
        {
            EVOComboBox cbo = (EVOComboBox)sender;
            if (cbo.Text.Length > cbo.MaxLength)
            {
                cbo.Text = cbo.Text.Remove(cbo.MaxLength);
            }
        }

        private void BrowsImage()
        {
            try
            {
                OpenFileDialog fileDialog = new OpenFileDialog();
                fileDialog.Filter = @"Image Type (gif, ico, jpg, jpeg, png)|*.gif;*.ico;*.jpg;*.jpeg;*.png;
                                        |Icon (ico)|*.ico
                                        |Icon (gif)|*.gif
                                        |Image (jpg, jpeg, png)|*.jpg;*.jpeg;*.png;
                                        |All File|*.*";
                fileDialog.Multiselect = false;
                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    ItemController ctlItem = new ItemController();
                    Image image = Image.FromFile(fileDialog.FileName);
                    ctlItem.AddNewImage(txtMasterNo.Text, image);

                }
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusiness(this, ex.Message);
            }
        }

        private void LoadImage(NZString ItemCD)
        {

        }

        private void RemoveImage()
        {
            ItemController ctl = new ItemController();
            ctl.ReMoveImage((NZString)txtMasterNo.Text.Trim());

        }

        private void ValidateProcessMachine(int Index, EVOComboBox cboProcess, EVOComboBox cboMachineType)
        {
            if (!m_bCheckProcessMachine)
                return;

            if (cboProcess.SelectedValue == null || cboMachineType.SelectedValue == null)
                return;

            string Process = cboProcess.SelectedValue.ToString();
            string Machine = cboMachineType.SelectedValue.ToString();

            if (Index != 1 && cboMachineProcess1.SelectedValue != null && cboMachineMCType1.SelectedValue != null)
            {
                string strProcess1 = cboMachineProcess1.SelectedValue.ToString();
                string strMachineType1 = cboMachineMCType1.SelectedValue.ToString();

                if (strProcess1.Equals(Process) && strMachineType1.Equals(Machine))
                {
                    ErrorItem error = new ErrorItem(null, TKPMessages.eValidate.VLM0200.ToString());
                    throw new BusinessException(error);
                }
            }

            if (Index != 2 && cboMachineProcess2.SelectedValue != null && cboMachineMCType2.SelectedValue != null)
            {
                string strProcess2 = cboMachineProcess2.SelectedValue.ToString();
                string strMachineType2 = cboMachineMCType2.SelectedValue.ToString();

                if (strProcess2.Equals(Process) && strMachineType2.Equals(Machine))
                {
                    ErrorItem error = new ErrorItem(null, TKPMessages.eValidate.VLM0200.ToString());
                    throw new BusinessException(error);
                }
            }

            if (Index != 3 && cboMachineProcess3.SelectedValue != null && cboMachineMCType3.SelectedValue != null)
            {
                string strProcess3 = cboMachineProcess3.SelectedValue.ToString();
                string strMachineType3 = cboMachineMCType3.SelectedValue.ToString();

                if (strProcess3.Equals(Process) && strMachineType3.Equals(Machine))
                {
                    ErrorItem error = new ErrorItem(null, TKPMessages.eValidate.VLM0200.ToString());
                    throw new BusinessException(error);
                }
            }

            if (Index != 4 && cboMachineProcess4.SelectedValue != null && cboMachineMCType4.SelectedValue != null)
            {
                string strProcess4 = cboMachineProcess4.SelectedValue.ToString();
                string strMachineType4 = cboMachineMCType4.SelectedValue.ToString();

                if (strProcess4.Equals(Process) && strMachineType4.Equals(Machine))
                {
                    ErrorItem error = new ErrorItem(null, TKPMessages.eValidate.VLM0200.ToString());
                    throw new BusinessException(error);
                }
            }

            if (Index != 5 && cboMachineProcess5.SelectedValue != null && cboMachineMCType5.SelectedValue != null)
            {
                string strProcess5 = cboMachineProcess5.SelectedValue.ToString();
                string strMachineType5 = cboMachineMCType5.SelectedValue.ToString();

                if (strProcess5.Equals(Process) && strMachineType5.Equals(Machine))
                {
                    ErrorItem error = new ErrorItem(null, TKPMessages.eValidate.VLM0200.ToString());
                    throw new BusinessException(error);
                }
            }

            if (Index != 6 && cboMachineProcess6.SelectedValue != null && cboMachineMCType6.SelectedValue != null)
            {
                string strProcess6 = cboMachineProcess6.SelectedValue.ToString();
                string strMachineType6 = cboMachineMCType6.SelectedValue.ToString();

                if (strProcess6.Equals(Process) && strMachineType6.Equals(Machine))
                {
                    ErrorItem error = new ErrorItem(null, TKPMessages.eValidate.VLM0200.ToString());
                    throw new BusinessException(error);
                }
            }
        }

        private void cbo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Control ctrl = (Control)sender;
                Form frm = ctrl.FindForm();
                if (frm == null)
                    return;

                if (!e.Handled)
                    frm.SelectNextControl(frm.ActiveControl, true, true, true, false);
            }
        }

        #endregion

        #region Form Event

        private void MAS040_ItemMaster_Load(object sender, EventArgs e)
        {
            InitialScreen();
            InitialSpread();

            if (m_ItemCD == null || m_ItemCD.IsNull)
            {
                ClearAllItem();
                SetScreenMode(eScreenMode.ADD);
            }
            else
            {
                LoadDataForEdit(m_ItemCD);
                SetScreenMode(eScreenMode.EDIT);
            }

            m_bInitial = false;
        }

        #endregion

        #region Screen Mode
        private void SetScreenMode(eScreenMode mode)
        {
            switch (mode)
            {
                case eScreenMode.IDLE:
                    //tsbSaveAndNew.Enabled = false;
                    //tsbSaveAndClose.Enabled = false;
                    //shtComponent.OperationMode = OperationMode.Normal;
                    //shtRouting.OperationMode = OperationMode.Normal;
                    //this.shtComponent.RowCount = 0;
                    //this.shtRouting.RowCount = 0;
                    break;

                case eScreenMode.VIEW:

                    //tsbSaveAndNew.Enabled = false;
                    //tsbSaveAndClose.Enabled = false;
                    //shtComponent.OperationMode = OperationMode.ReadOnly;
                    //shtRouting.OperationMode = OperationMode.ReadOnly;

                    //CtrlUtil.SpreadSetColumnsLocked(shtComponent, true, (int)eColComponent.BTN_ITEM_CD);
                    //CtrlUtil.SpreadSetColumnsLocked(shtRouting, true, (int)eColumns.BTN_ROUTING);                    
                    break;

                case eScreenMode.ADD:

                    tsbSaveAndNew.Enabled = true;
                    tsbSaveAndClose.Enabled = true;

                    CommonLib.CtrlUtil.EnabledControl(true, txtMasterNo);

                    shtComponent.OperationMode = OperationMode.Normal;
                    shtRouting.OperationMode = OperationMode.Normal;

                    CtrlUtil.SpreadSetColumnsLocked(shtComponent, false, (int)eColComponent.SEQ_NO);
                    CtrlUtil.SpreadSetColumnsLocked(shtComponent, true, (int)eColComponent.ITEM_CD);
                    CtrlUtil.SpreadSetColumnsLocked(shtComponent, false, (int)eColComponent.BTN_ITEM_CD);
                    CtrlUtil.SpreadSetColumnsLocked(shtComponent, true, (int)eColComponent.SHORT_NAME);
                    CtrlUtil.SpreadSetColumnsLocked(shtComponent, true, (int)eColComponent.CUSTOMER_CD);
                    CtrlUtil.SpreadSetColumnsLocked(shtComponent, false, (int)eColComponent.PCS);

                    CtrlUtil.SpreadSetColumnsLocked(shtRouting, false, (int)eColumns.ITEM_SEQ);
                    CtrlUtil.SpreadSetColumnsLocked(shtRouting, true, (int)eColumns.PROCESS_CD);
                    CtrlUtil.SpreadSetColumnsLocked(shtRouting, false, (int)eColumns.BTN_ROUTING);
                    CtrlUtil.SpreadSetColumnsLocked(shtRouting, true, (int)eColumns.PROCESS_NAME);
                    CtrlUtil.SpreadSetColumnsLocked(shtRouting, false, (int)eColumns.PRODUCTION_LEADTIME);
                    CtrlUtil.SpreadSetColumnsLocked(shtRouting, false, (int)eColumns.QTY_PER_DAY);
                    CtrlUtil.SpreadSetColumnsLocked(shtRouting, false, (int)eColumns.SUPPLIER_CD);
                    CtrlUtil.SpreadSetColumnsLocked(shtRouting, false, (int)eColumns.WEIGHT);


                    CtrlUtil.FocusControl(txtMasterNo);

                    break;
                case eScreenMode.EDIT:

                    tsbSaveAndNew.Enabled = true;
                    tsbSaveAndClose.Enabled = true;

                    CommonLib.CtrlUtil.EnabledControl(false, txtMasterNo);

                    shtComponent.OperationMode = OperationMode.Normal;
                    shtRouting.OperationMode = OperationMode.Normal;

                    CtrlUtil.SpreadSetColumnsLocked(shtComponent, false, (int)eColComponent.SEQ_NO);
                    CtrlUtil.SpreadSetColumnsLocked(shtComponent, true, (int)eColComponent.ITEM_CD);
                    CtrlUtil.SpreadSetColumnsLocked(shtComponent, false, (int)eColComponent.BTN_ITEM_CD);
                    CtrlUtil.SpreadSetColumnsLocked(shtComponent, true, (int)eColComponent.SHORT_NAME);
                    CtrlUtil.SpreadSetColumnsLocked(shtComponent, true, (int)eColComponent.CUSTOMER_CD);
                    CtrlUtil.SpreadSetColumnsLocked(shtComponent, false, (int)eColComponent.PCS);

                    CtrlUtil.SpreadSetColumnsLocked(shtRouting, true, (int)eColumns.ITEM_SEQ);
                    CtrlUtil.SpreadSetColumnsLocked(shtRouting, true, (int)eColumns.PROCESS_CD);
                    CtrlUtil.SpreadSetColumnsLocked(shtRouting, false, (int)eColumns.BTN_ROUTING);
                    CtrlUtil.SpreadSetColumnsLocked(shtRouting, true, (int)eColumns.PROCESS_NAME);
                    CtrlUtil.SpreadSetColumnsLocked(shtRouting, false, (int)eColumns.PRODUCTION_LEADTIME);
                    CtrlUtil.SpreadSetColumnsLocked(shtRouting, false, (int)eColumns.QTY_PER_DAY);
                    CtrlUtil.SpreadSetColumnsLocked(shtRouting, false, (int)eColumns.SUPPLIER_CD);
                    CtrlUtil.SpreadSetColumnsLocked(shtRouting, false, (int)eColumns.WEIGHT);

                    CtrlUtil.FocusControl(txtPartNo);

                    break;
            }

            m_screenMode = mode;
        }

        #endregion

        #region Keyboard Spread

        #region Routing Spread
        // ใช้ set ค่า spread หลังจาก row เสร็จ เช่น default value , lock column
        void r_keyboardSpread_RowAdded(object sender, int rowIndex)
        {

            //default value
            shtRouting.Cells[shtRouting.ActiveRowIndex, (int)eColumns.PRODUCTION_LEADTIME].Value = 1;

            int iMaxPriority = 0;
            int iPriority = 0;
            for (int i = 0; i < shtRouting.RowCount; i++)
            {
                iPriority = 0;
                iPriority = Convert.ToInt32(shtRouting.Cells[i, (int)eColumns.ITEM_SEQ].Value);

                if (iPriority > iMaxPriority)
                {
                    iMaxPriority = iPriority;
                }
            }

            iMaxPriority = (int)(iMaxPriority / 10 + 1) * 10;

            shtRouting.Cells[shtRouting.ActiveRowIndex, (int)eColumns.ITEM_SEQ].Value = iMaxPriority;

            // Unlock cells

            CtrlUtil.SpreadSetCellLocked(shtRouting, false, rowIndex, (int)eColumns.ITEM_SEQ);
            CtrlUtil.SpreadSetCellLocked(shtRouting, true, rowIndex, (int)eColumns.PROCESS_CD);
            CtrlUtil.SpreadSetCellLocked(shtRouting, false, rowIndex, (int)eColumns.BTN_ROUTING);
            CtrlUtil.SpreadSetCellLocked(shtRouting, true, rowIndex, (int)eColumns.PROCESS_NAME);
            CtrlUtil.SpreadSetCellLocked(shtRouting, false, rowIndex, (int)eColumns.WEIGHT);
            CtrlUtil.SpreadSetCellLocked(shtRouting, false, rowIndex, (int)eColumns.PRODUCTION_LEADTIME);
            CtrlUtil.SpreadSetCellLocked(shtRouting, false, rowIndex, (int)eColumns.QTY_PER_DAY);
            CtrlUtil.SpreadSetCellLocked(shtRouting, false, rowIndex, (int)eColumns.SUPPLIER_CD);

            //set seq no.

        }

        // check before add new row
        void r_keyboardSpread_RowAdding(object sender, EventRowAdding e)
        {
            if (m_bRowHasModified)
            { // ถ้า Row กำลังแก้ไขอยู่
                if (!ValidateRowSpreadRouting(shtRouting.ActiveRowIndex, false))
                {
                    e.Cancel = true;
                    return;
                }
            }
            else
            {
                // ถ้าไม่มีการแก้ไข Row  แต่ก่อนที่จะเพิ่มแถวใหม่ จะต้อง Validate แถวล่าสุด (ล่างสุด) ก่อน
                if (shtRouting.RowCount > 0 && shtRouting.ActiveRowIndex >= 0)
                {

                    if (!ValidateRowSpreadRouting(shtRouting.RowCount - 1, true))
                    {
                        e.Cancel = true;
                        return;
                    }
                    else
                    {
                        int Column = Convert.ToInt32(shtRouting.Cells[shtRouting.ActiveRowIndex, (int)eColumns.PRODUCTION_LEADTIME].Value);
                        if (Column < 1)
                        {
                            ErrorItem error = new ErrorItem(null, TKPMessages.eValidate.VLM0175.ToString());
                            MessageDialog.ShowBusiness(this, error.Message);
                            e.Cancel = true;
                            return;
                        }
                    }
                }
            }
        }

        // ใช้สำหรับ check ก่อนที่จะ remove row
        void r_keyboardSpread_RowRemoving(object sender, EventRowRemoving e)
        {
            string process = shtRouting.Cells[e.RowIndex, (int)eColumns.PROCESS_CD].Text;
            if ("R".Equals(process) && shtComponent.RowCount > 0)
            {
                ErrorItem error = new ErrorItem(null, TKPMessages.eValidate.VLM0219.ToString());
                MessageDialog.ShowBusiness(this, error.Message);
                e.Cancel = true;
                return;
            }


            NZString MachineProcess1 = new NZString(cboMachineProcess1, cboMachineProcess1.SelectedValue);
            NZString MachineProcess2 = new NZString(cboMachineProcess2, cboMachineProcess2.SelectedValue);
            NZString MachineProcess3 = new NZString(cboMachineProcess3, cboMachineProcess3.SelectedValue);
            NZString MachineProcess4 = new NZString(cboMachineProcess4, cboMachineProcess4.SelectedValue);
            NZString MachineProcess5 = new NZString(cboMachineProcess5, cboMachineProcess5.SelectedValue);
            NZString MachineProcess6 = new NZString(cboMachineProcess6, cboMachineProcess6.SelectedValue);

            if (!MachineProcess1.IsNull && process.Equals(MachineProcess1))
            {
                ErrorItem error = new ErrorItem(null, TKPMessages.eValidate.VLM0191.ToString());
                MessageDialog.ShowBusiness(this, error.Message);
                e.Cancel = true;
                return;
            }
            if (!MachineProcess2.IsNull && process.Equals(MachineProcess2))
            {
                ErrorItem error = new ErrorItem(null, TKPMessages.eValidate.VLM0191.ToString());
                MessageDialog.ShowBusiness(this, error.Message);
                e.Cancel = true;
                return;
            }
            if (!MachineProcess3.IsNull && process.Equals(MachineProcess3))
            {
                ErrorItem error = new ErrorItem(null, TKPMessages.eValidate.VLM0191.ToString());
                MessageDialog.ShowBusiness(this, error.Message);
                e.Cancel = true;
                return;
            }
            if (!MachineProcess4.IsNull && process.Equals(MachineProcess4))
            {
                ErrorItem error = new ErrorItem(null, TKPMessages.eValidate.VLM0191.ToString());
                MessageDialog.ShowBusiness(this, error.Message);
                e.Cancel = true;
                return;
            }
            if (!MachineProcess5.IsNull && process.Equals(MachineProcess5))
            {
                ErrorItem error = new ErrorItem(null, TKPMessages.eValidate.VLM0191.ToString());
                MessageDialog.ShowBusiness(this, error.Message);
                e.Cancel = true;
                return;
            }
            if (!MachineProcess6.IsNull && process.Equals(MachineProcess6))
            {
                ErrorItem error = new ErrorItem(null, TKPMessages.eValidate.VLM0191.ToString());
                MessageDialog.ShowBusiness(this, error.Message);
                e.Cancel = true;
                return;
            }


            MessageDialogResult dr = MessageDialog.ShowConfirmation(this, Message.LoadMessage(Messages.eConfirm.CFM9002.ToString()), MessageDialogButtons.YesNo);
            if (dr == MessageDialogResult.No)
            {
                e.Cancel = true;
            }
        }

        // ใช้สำหรับ check หลังจากลบ row แล้ว
        void r_keyboardSpread_RowRemoved(object sender)
        {
            m_bRowHasModified = false;
        }

        //  สำหรับดัก event ตอนกด f5 ซึ่งปัจจุบันยังไม่ได้ใช้
        void r_keyboardSpread_KeyPressF5(object sender, int rowIndex, int colIndex)
        {
            //throw new NotImplementedException();
        }

        #endregion

        #region Component Spread
        // ใช้ set ค่า spread หลังจาก row เสร็จ เช่น default value , lock column
        void c_keyboardSpread_RowAdded(object sender, int rowIndex)
        {
            // Unlock cells

            CtrlUtil.SpreadSetCellLocked(shtComponent, true, rowIndex, (int)eColComponent.ITEM_CD);
            CtrlUtil.SpreadSetCellLocked(shtComponent, false, rowIndex, (int)eColComponent.BTN_ITEM_CD);
            CtrlUtil.SpreadSetCellLocked(shtComponent, true, rowIndex, (int)eColComponent.SHORT_NAME);
            CtrlUtil.SpreadSetCellLocked(shtComponent, true, rowIndex, (int)eColComponent.CUSTOMER_CD);
            CtrlUtil.SpreadSetCellLocked(shtComponent, false, rowIndex, (int)eColComponent.PCS);
            //set seq no.

        }

        // check before add new row
        void c_keyboardSpread_RowAdding(object sender, EventRowAdding e)
        {
            if (m_bRowHasModified)
            { // ถ้า Row กำลังแก้ไขอยู่
                if (!ValidateRowSpreadComponent(shtComponent.ActiveRowIndex, false))
                {
                    e.Cancel = true;
                    return;
                }
            }
            else
            {
                // ถ้าไม่มีการแก้ไข Row  แต่ก่อนที่จะเพิ่มแถวใหม่ จะต้อง Validate แถวล่าสุด (ล่างสุด) ก่อน
                if (shtComponent.RowCount > 0 && shtComponent.ActiveRowIndex >= 0)
                {
                    if (!ValidateRowSpreadComponent(shtComponent.RowCount - 1, true))
                    {
                        e.Cancel = true;
                        return;
                    }
                }
            }
        }

        // ใช้สำหรับ check ก่อนที่จะ remove row
        void c_keyboardSpread_RowRemoving(object sender, EventRowRemoving e)
        {


            MessageDialogResult dr = MessageDialog.ShowConfirmation(this, Message.LoadMessage(Messages.eConfirm.CFM9002.ToString()), MessageDialogButtons.YesNo);
            if (dr == MessageDialogResult.No)
            {
                e.Cancel = true;
            }
        }

        // ใช้สำหรับ check หลังจากลบ row แล้ว
        void c_keyboardSpread_RowRemoved(object sender)
        {
            m_bRowHasModified = false;
        }

        //  สำหรับดัก event ตอนกด f5 ซึ่งปัจจุบันยังไม่ได้ใช้
        void c_keyboardSpread_KeyPressF5(object sender, int rowIndex, int colIndex)
        {
            //throw new NotImplementedException();
        }
        #endregion

        #endregion

        #region Control Event

        private void riAdd_Click(object sender, EventArgs e)
        {
            // add row
            r_keyboardSpread.OnActionAddNewRow();

        }

        private void riDelete_Click(object sender, EventArgs e)
        {
            // delete row
            r_keyboardSpread.OnActionRemoveRow();
        }

        private void ciAdd_Click(object sender, EventArgs e)
        {
            // add row
            c_keyboardSpread.OnActionAddNewRow();
        }

        private void ciDelete_Click(object sender, EventArgs e)
        {
            // delete row
            c_keyboardSpread.OnActionRemoveRow();
        }

        private void picIconDisplay_DoubleClick(object sender, EventArgs e)
        {
            if (txtMasterNo.Text.Trim() == string.Empty) return;
            //// check item exist before brows image
            //ItemValidator val = new ItemValidator();
            //try
            //{
            //    BusinessException bizErr = val.CheckItemExist(new NZString(txtItemCode, txtItemCode.Text.Trim()));
            //    if (bizErr != null) ValidateException.ThrowErrorItem(bizErr.Error);
            //    
            //}
            //catch (Exception)
            //{
            //    return;
            //}
            BrowsImage();
        }

        private void removeImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RemoveImage();
        }
        /*
                private void cboItemType_SelectedIndexChanged(object sender, EventArgs e)
                {
                    if (cboPartType.SelectedValue != null && cboPartType.SelectedValue != DBNull.Value)
                    {
                        int iSelcted = Convert.ToInt32(cboPartType.SelectedValue);

                        if (iSelcted > (int)eItemType.RawMaterial)
                        {
                            //LookupData lookupOrderProcess = new LookupDataBIZ().LoadLookupClassType(DataDefine.ORDER_PROCESS_CLS.ToNZString());
                            //cboOrderProcess.LoadLookupData(lookupOrderProcess);
                        }
                        else
                        {
                            int iNoofRow;
                            DataTable dt = (new LookupDataBIZ().LoadLookupClassType(DataDefine.ORDER_PROCESS_CLS.ToNZString())).DataSource;

                            if (iSelcted == (int)eItemType.RawMaterial)
                                // โชวฺแค่ PUR , SUB
                                iNoofRow = 2;
                            else
                                // ซ่อน PUR
                                iNoofRow = dt.Rows.Count - 1;

                            string[] strValue = new string[iNoofRow];
                            string[] strItem = new string[iNoofRow];

                            int j = 0;
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                bool bType4 = (iSelcted == (int)eItemType.RawMaterial && (dt.Rows[i]["CLS_CD"].ToString() == "PUR" || dt.Rows[i]["CLS_CD"].ToString() == "SUB"));
                                bool bType1to3 = iSelcted < (int)eItemType.RawMaterial && dt.Rows[i]["CLS_CD"].ToString() != "PUR";
                                if (bType4 || bType1to3)
                                {
                                    strValue[j] = dt.Rows[i]["CLS_CD"].ToString();
                                    strItem[j] = dt.Rows[i]["CLS_DESC"].ToString();
                                    j++;
                                }
                            }

                            DataTable tmpDt = new DataTable();
                            tmpDt.Columns.Add("CLS_CD");
                            tmpDt.Columns.Add("CLS_DESC");
                            for (int i = 0; i < j; i++)
                            {
                                DataRow dr = tmpDt.NewRow();
                                dr["CLS_CD"] = strValue[i];
                                dr["CLS_DESC"] = strItem[i];
                                tmpDt.Rows.Add(dr);
                            }

                            //cboOrderProcess.LoadLookupData(new LookupData(tmpDt, "CLS_DESC", "CLS_CD"));
                        }

                        //cboOrderProcess.SelectedValue = strOrderProcess;

                        //if (cboItemType.SelectedValue.ToString() == DataDefine.Convert2ClassCode(DataDefine.eITEM_CLS.RawMaterial))
                        //{
                        //    CtrlUtil.EnabledControl(true, cboItemClassMinor04);
                        //    LookupDataBIZ biz = new LookupDataBIZ();
                        //    LookupData data = biz.LoadLookupClassType((NZString)DataDefine.ITEM_CLS_MINOR04);
                        //    cboItemClassMinor04.LoadLookupData(data);

                        //    cboItemClassMinor04.SelectedIndex = -1;
                        //    return;
                        //}

                    }
                    //cboItemClassMinor04.DataSource = null;
                    //CtrlUtil.EnabledControl(false, cboItemClassMinor04);
                }
        */

        private void txtItemCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
            if (e.KeyChar == (char)Keys.Enter
                || e.KeyChar == '-'
                || e.KeyChar == '_'
                || e.KeyChar == '/'
                || e.KeyChar == '('
                || e.KeyChar == ')'
                || e.KeyChar == (char)Keys.Back
                || (e.KeyChar >= 'a' && e.KeyChar <= 'z')
                || (e.KeyChar >= 'A' && e.KeyChar <= 'Z')
                || e.KeyChar == ' '
                || char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
        }

        private void rdoHeatTreatmentNo_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoHeatTreatmentNo.Checked)
            {
                CtrlUtil.EnabledControl(false, cboHeatTreatmentType, txtHardingSurface, txtCoreHardness, txtCaseDeptAndCondition);
            }
            else
            {
                CtrlUtil.EnabledControl(true, cboHeatTreatmentType, txtHardingSurface, txtCoreHardness, txtCaseDeptAndCondition);
            }
        }

        private void rdoPlatingNo_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoPlatingNo.Checked)
            {
                CtrlUtil.EnabledControl(false, txtPlatingKind, txtPlatingThickness1From, txtPlatingThickness1To
                    , txtPlatingThickness2From, txtPlatingThickness2To, cboKTCPlating, cboPlatingSupplier);
            }
            else
            {
                CtrlUtil.EnabledControl(true, txtPlatingKind, txtPlatingThickness1From, txtPlatingThickness1To
                  , txtPlatingThickness2From, txtPlatingThickness2To, cboKTCPlating, cboPlatingSupplier);
            }

        }

        private void rdoPlatingBakingNo_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoPlatingBakingNo.Checked)
            {
                CtrlUtil.EnabledControl(false, cboPlatingBakingTime, cboPlatingBakingTemp);
            }
            else
            {
                CtrlUtil.EnabledControl(true, cboPlatingBakingTime, cboPlatingBakingTemp);
            }
        }

        private void rdoOtherTreatment1No_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoOtherTreatment1No.Checked)
            {
                CtrlUtil.EnabledControl(false, cboOtherKind1, cboOtherCondition1);
            }
            else
            {
                CtrlUtil.EnabledControl(true, cboOtherKind1, cboOtherCondition1);
            }
        }

        private void rdoOtherTreatment2No_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoOtherTreatment2No.Checked)
            {
                CtrlUtil.EnabledControl(false, cboOtherKind2, cboOtherCondition2);
            }
            else
            {
                CtrlUtil.EnabledControl(true, cboOtherKind2, cboOtherCondition2);
            }
        }

        #endregion


        public override void PermissionControl()
        {
            base.PermissionControl();

            if (ActivePermission.View)
            {
                cmsOperation.Items[0].Enabled = ActivePermission.Add;
                cmsOperation.Items[1].Enabled = ActivePermission.Delete;
            }
        }

        private void cboModel_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl(this.ActiveControl, true, true, true, false);
            }
        }

        private void txtBusinessGroup_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl(this.ActiveControl, true, true, true, false);
            }
        }

        private void fpComponent_CellClick(object sender, CellClickEventArgs e)
        {
            try
            {
                if (e.RowHeader || e.ColumnHeader)
                    return;

                if (e.Column == (int)eColComponent.BTN_ITEM_CD)
                {
                    eItemType[] itemType = new Rubik.eItemType[] { Rubik.eItemType.WASHER };
                    ItemFindDialog dialog = new ItemFindDialog(eSqlOperator.In, itemType);
                    dialog.ShowDialog(this);

                    if (dialog.IsSelected)
                    {
                        LoadItemIntoRow(e.Row, dialog.SelectedItem.ITEM_CD, dialog.SelectedItem);

                    }
                }
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusiness(this, ex.Message);
            }
        }

        private void fpRouting_CellClick(object sender, CellClickEventArgs e)
        {
            try
            {
                if (e.RowHeader || e.ColumnHeader)
                    return;

                if (e.Column == (int)eColumns.BTN_ROUTING)
                {
                    NZString[] locationtype = new NZString[] { (NZString)DataDefine.Convert2ClassCode(DataDefine.eLOCATION_CLS.Production) };

                    LocationFindDialog dialog = new LocationFindDialog(locationtype);

                    dialog.ShowDialog(this);

                    if (dialog.IsSelected)
                    {

                        shtRouting.Cells[e.Row, (int)eColumns.PROCESS_CD].Value = dialog.SelectedItem.LOC_CD.Value;
                        shtRouting.Cells[e.Row, (int)eColumns.PROCESS_NAME].Value = dialog.SelectedItem.LOC_DESC.Value;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusiness(this, ex.Message);
            }
        }

        private void tcItemInfo_Enter(object sender, EventArgs e)
        {
            //if (tcItemInfo.SelectedTab == tpMachine)
            //{
            //    MachineCombobox();
            //}
        }


        private void tpMachine_Enter(object sender, EventArgs e)
        {

            MachineCombobox((DataTable)shtRouting.DataSource);
        }

        private void LoadMachineGroup(eMachineProcessIndex eMC)
        {
            if (!m_bLoadMachineGroup)
                return;

            m_bCheckProcessMachine = false;

            LookupDataBIZ bizLookup = new LookupDataBIZ();

            switch (eMC)
            {
                case eMachineProcessIndex.MC1:

                    cboMachineMCType1.DataSource = null;
                    cboMachineMCType1.SelectedIndex = -1;

                    if (cboMachineProcess1.SelectedValue == null || string.Empty.Equals(cboMachineProcess1.Text))
                        return;

                    LookupData LookupMCType1 = bizLookup.LoadMachineGroupOfProcess(cboMachineProcess1.SelectedValue.ToString());
                    cboMachineMCType1.LoadLookupData(LookupMCType1);
                    cboMachineMCType1.SelectedIndex = -1;

                    break;

                case eMachineProcessIndex.MC2:

                    cboMachineMCType2.DataSource = null;
                    cboMachineMCType2.SelectedIndex = -1;

                    if (cboMachineProcess2.SelectedValue == null || string.Empty.Equals(cboMachineProcess2.Text))
                        return;

                    LookupData LookupMCType2 = bizLookup.LoadMachineGroupOfProcess(cboMachineProcess2.SelectedValue.ToString());
                    cboMachineMCType2.LoadLookupData(LookupMCType2);
                    cboMachineMCType2.SelectedIndex = -1;

                    break;

                case eMachineProcessIndex.MC3:

                    cboMachineMCType3.DataSource = null;
                    cboMachineMCType3.SelectedIndex = -1;

                    if (cboMachineProcess3.SelectedValue == null || string.Empty.Equals(cboMachineProcess3.Text))
                        return;

                    LookupData LookupMCType3 = bizLookup.LoadMachineGroupOfProcess(cboMachineProcess3.SelectedValue.ToString());
                    cboMachineMCType3.LoadLookupData(LookupMCType3);
                    cboMachineMCType3.SelectedIndex = -1;

                    break;

                case eMachineProcessIndex.MC4:

                    cboMachineMCType4.DataSource = null;
                    cboMachineMCType4.SelectedIndex = -1;

                    if (cboMachineProcess4.SelectedValue == null || string.Empty.Equals(cboMachineProcess4.Text))
                        return;

                    LookupData LookupMCType4 = bizLookup.LoadMachineGroupOfProcess(cboMachineProcess4.SelectedValue.ToString());
                    cboMachineMCType4.LoadLookupData(LookupMCType4);
                    cboMachineMCType4.SelectedIndex = -1;

                    break;

                case eMachineProcessIndex.MC5:

                    cboMachineMCType5.DataSource = null;
                    cboMachineMCType5.SelectedIndex = -1;

                    if (cboMachineProcess5.SelectedValue == null || string.Empty.Equals(cboMachineProcess5.Text))
                        return;

                    LookupData LookupMCType5 = bizLookup.LoadMachineGroupOfProcess(cboMachineProcess5.SelectedValue.ToString());
                    cboMachineMCType5.LoadLookupData(LookupMCType5);
                    cboMachineMCType5.SelectedIndex = -1;

                    break;

                case eMachineProcessIndex.MC6:

                    cboMachineMCType6.DataSource = null;
                    cboMachineMCType6.SelectedIndex = -1;

                    if (cboMachineProcess6.SelectedValue == null || string.Empty.Equals(cboMachineProcess6.Text))
                        return;

                    LookupData LookupMCType6 = bizLookup.LoadMachineGroupOfProcess(cboMachineProcess6.SelectedValue.ToString());
                    cboMachineMCType6.LoadLookupData(LookupMCType6);
                    cboMachineMCType6.SelectedIndex = -1;

                    break;
            }

            m_bCheckProcessMachine = true;
        }

        private void cboMachineProcess1_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                ValidateProcessMachine(1, cboMachineProcess1, cboMachineMCType1);

                LoadMachineGroup(eMachineProcessIndex.MC1);
            }
            catch (BusinessException err)
            {
                MessageDialog.ShowBusiness(this, err.Error.Message);
                CtrlUtil.FocusControl(cboMachineProcess1);
            }
        }
        private void cboMachineMCType1_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                ValidateProcessMachine(1, cboMachineProcess1, cboMachineMCType1);
            }
            catch (BusinessException err)
            {
                MessageDialog.ShowBusiness(this, err.Error.Message);
                //CtrlUtil.FocusControl(cboMachineMCType1);
            }
        }
        private void cboMachineProcess2_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                ValidateProcessMachine(2, cboMachineProcess2, cboMachineMCType2);

                LoadMachineGroup(eMachineProcessIndex.MC2);
            }
            catch (BusinessException err)
            {
                MessageDialog.ShowBusiness(this, err.Error.Message);
                CtrlUtil.FocusControl(cboMachineProcess2);
            }
        }
        private void cboMachineMCType2_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                ValidateProcessMachine(2, cboMachineProcess2, cboMachineMCType2);
            }
            catch (BusinessException err)
            {
                MessageDialog.ShowBusiness(this, err.Error.Message);
                //CtrlUtil.FocusControl(cboMachineMCType2);
            }
        }
        private void cboMachineProcess3_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                ValidateProcessMachine(3, cboMachineProcess3, cboMachineMCType3);

                LoadMachineGroup(eMachineProcessIndex.MC3);
            }
            catch (BusinessException err)
            {
                MessageDialog.ShowBusiness(this, err.Error.Message);
                CtrlUtil.FocusControl(cboMachineProcess4);
            }
        }
        private void cboMachineMCType3_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                ValidateProcessMachine(3, cboMachineProcess3, cboMachineMCType3);
            }
            catch (BusinessException err)
            {
                MessageDialog.ShowBusiness(this, err.Error.Message);
                //CtrlUtil.FocusControl(cboMachineMCType3);
            }
        }
        private void cboMachineProcess4_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                ValidateProcessMachine(4, cboMachineProcess4, cboMachineMCType4);

                LoadMachineGroup(eMachineProcessIndex.MC4);
            }
            catch (BusinessException err)
            {
                MessageDialog.ShowBusiness(this, err.Error.Message);
                CtrlUtil.FocusControl(cboMachineProcess4);
            }
        }
        private void cboMachineMCType4_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                ValidateProcessMachine(4, cboMachineProcess4, cboMachineMCType4);
            }
            catch (BusinessException err)
            {
                MessageDialog.ShowBusiness(this, err.Error.Message);
                CtrlUtil.FocusControl(cboMachineMCType4);
            }
        }
        private void cboMachineProcess5_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                ValidateProcessMachine(5, cboMachineProcess5, cboMachineMCType5);

                LoadMachineGroup(eMachineProcessIndex.MC5);
            }
            catch (BusinessException err)
            {
                MessageDialog.ShowBusiness(this, err.Error.Message);
                CtrlUtil.FocusControl(cboMachineProcess5);
            }
        }
        private void cboMachineMCType5_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                ValidateProcessMachine(5, cboMachineProcess5, cboMachineMCType5);
            }
            catch (BusinessException err)
            {
                MessageDialog.ShowBusiness(this, err.Error.Message);
                //CtrlUtil.FocusControl(cboMachineMCType5);
            }
        }
        private void cboMachineProcess6_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                ValidateProcessMachine(6, cboMachineProcess6, cboMachineMCType6);

                LoadMachineGroup(eMachineProcessIndex.MC6);
            }
            catch (BusinessException err)
            {
                MessageDialog.ShowBusiness(this, err.Error.Message);
                CtrlUtil.FocusControl(cboMachineProcess6);
            }
        }
        private void cboMachineMCType6_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                ValidateProcessMachine(6, cboMachineProcess6, cboMachineMCType6);
            }
            catch (BusinessException err)
            {
                MessageDialog.ShowBusiness(this, err.Error.Message);
                //CtrlUtil.FocusControl(cboMachineMCType6);
            }
        }

        private void fpRouting_KeyDown(object sender, KeyEventArgs e)
        {
            CtrlUtil.FilterShortCut(e);
        }
        private void fpComponent_KeyDown(object sender, KeyEventArgs e)
        {
            CtrlUtil.FilterShortCut(e);
        }
        private void fpComponent_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                bool bExist = false;
                for (int i = 0; i < shtRouting.RowCount; i++)
                {
                    if ("R".Equals(shtRouting.Cells[i, (int)eColumns.PROCESS_CD].Text))
                        bExist = true;
                }

                if (bExist)
                {
                    addToolStripMenu.Enabled = true;
                    deleteToolStripMenu.Enabled = true;
                }
                else
                {
                    addToolStripMenu.Enabled = false;
                    deleteToolStripMenu.Enabled = false;
                }
                cmsComponent.Show(fpComponent, e.Location);
            }
        }

        private void cboMachineProcess1_TextChanged(object sender, EventArgs e)
        {
            LoadMachineGroup(eMachineProcessIndex.MC1);
        }
        private void cboMachineProcess2_TextChanged(object sender, EventArgs e)
        {
            LoadMachineGroup(eMachineProcessIndex.MC2);
        }
        private void cboMachineProcess3_TextChanged(object sender, EventArgs e)
        {
            LoadMachineGroup(eMachineProcessIndex.MC3);
        }
        private void cboMachineProcess4_TextChanged(object sender, EventArgs e)
        {
            LoadMachineGroup(eMachineProcessIndex.MC4);
        }
        private void cboMachineProcess5_TextChanged(object sender, EventArgs e)
        {
            LoadMachineGroup(eMachineProcessIndex.MC5);
        }
        private void cboMachineProcess6_TextChanged(object sender, EventArgs e)
        {
            LoadMachineGroup(eMachineProcessIndex.MC6);
        }

        private void cboMachineMCType1_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                ValidateProcessMachine(1, cboMachineProcess1, cboMachineMCType1);
            }
            catch (BusinessException err)
            {
                MessageDialog.ShowBusiness(this, err.Error.Message);
                e.Cancel = true;
            }
        }
        private void cboMachineMCType2_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                ValidateProcessMachine(2, cboMachineProcess2, cboMachineMCType2);
            }
            catch (BusinessException err)
            {
                MessageDialog.ShowBusiness(this, err.Error.Message);
                e.Cancel = true;
            }
        }
        private void cboMachineMCType3_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                ValidateProcessMachine(3, cboMachineProcess3, cboMachineMCType3);
            }
            catch (BusinessException err)
            {
                MessageDialog.ShowBusiness(this, err.Error.Message);
                e.Cancel = true;
            }
        }

        private void cboMachineMCType4_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                ValidateProcessMachine(4, cboMachineProcess4, cboMachineMCType4);
            }
            catch (BusinessException err)
            {
                MessageDialog.ShowBusiness(this, err.Error.Message);
                e.Cancel = true;
            }
        }

        private void cboMachineMCType5_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                ValidateProcessMachine(5, cboMachineProcess5, cboMachineMCType5);
            }
            catch (BusinessException err)
            {
                MessageDialog.ShowBusiness(this, err.Error.Message);
                e.Cancel = true;
            }
        }

        private void cboMachineMCType6_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                ValidateProcessMachine(6, cboMachineProcess6, cboMachineMCType6);
            }
            catch (BusinessException err)
            {
                MessageDialog.ShowBusiness(this, err.Error.Message);
                e.Cancel = true;
            }
        }

        //private void fpRouting_MouseDown(object sender, MouseEventArgs e) {
        //    if (e.Button == MouseButtons.Right) 
        //    {
        //        bool bExist = shtComponent.RowCount > 0;                

        //        if (bExist) 
        //        {
        //            deleteToolStripMenuItem.Enabled = false;                    
        //        }
        //        else {
        //            deleteToolStripMenuItem.Enabled = true;  
        //        }

        //        cmsOperation.Show(fpComponent, e.Location);
        //    }
        //}
    }
}
