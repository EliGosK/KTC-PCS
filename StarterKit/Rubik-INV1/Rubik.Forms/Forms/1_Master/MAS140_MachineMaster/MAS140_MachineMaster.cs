using System;
using System.Windows.Forms;
using SystemMaintenance.Forms;
using EVOFramework;
using EVOFramework.Data;
using EVOFramework.Windows.Forms;
using Rubik.BIZ;
using Rubik.DTO;
using CommonLib;
using Rubik.UIDataModel;
using Rubik.Controller;
using Rubik.Validators;
using SystemMaintenance;
using EVOFramework.Win32.API;

namespace Rubik.Master
{
    [Screen("MAS140", "Machine Information Entry", eShowAction.Normal, eScreenType.Dialog, "Machine Information Entry")]
    public partial class MAS140_MachineMaster : CustomizeForm
    {
        #region Enumeration
        private enum eMode
        {
            ADD, EDIT,
        }
        #endregion

        #region Variables
        private readonly MachineController m_MachineController = new MachineController();
        private string m_MachineNo = string.Empty;
        private eMode m_screenMode = eMode.ADD;
        private DialogResult m_dummyDialogResult = DialogResult.Cancel;
        #endregion

        #region Constructor
        public MAS140_MachineMaster()
        {
            InitializeComponent();
            m_dummyDialogResult = DialogResult.Cancel;

            InitializeScreenMode();
            InitializeScreen();

        }

        public MAS140_MachineMaster(string MACHINE_NO)
        {

            InitializeComponent();
            m_dummyDialogResult = DialogResult.Cancel;

            m_MachineNo = MACHINE_NO;

            InitializeScreenMode();
            InitializeScreen();
        }
        #endregion

        #region Private Methods
        private void InitializeScreenMode()
        {
            if (String.IsNullOrEmpty(m_MachineNo))
            {
                // New mode.
                m_screenMode = eMode.ADD;
                CtrlUtil.EnabledControl(true, txtMachineNo, cboMachineType, cboProcess, cboMachineGroup, cboProject, txtRemark, txtMachineName);

                ClearControls();

                tsbSaveAndNew.Enabled = true;
                tsbSaveAndClose.Enabled = true;
            }
            else
            {
                // Edit mode.
                m_screenMode = eMode.EDIT;
                CtrlUtil.EnabledControl(true, cboMachineType, cboProcess, cboMachineGroup, cboProject, txtRemark, txtMachineName);
                CtrlUtil.EnabledControl(false, txtMachineNo);

                tsbSaveAndNew.Enabled = true;
                tsbSaveAndClose.Enabled = true;
            }
        }
        private void InitializeScreen()
        {
            //this.cboMachineType.Format += Common.ComboBox_Format;
            this.cboProcess.Format += Common.ComboBox_Format;
            //this.cboMachineGroup.Format += Common.ComboBox_Format;
            this.cboProject.Format += Common.ComboBox_Format;
            this.cboMachineType.Format += Common.ComboBox_Format;

            dmcMachine.AddRangeControl(
                txtMachineNo,
                cboMachineType,
                cboProcess,
                cboMachineGroup,
                cboProject,
                txtRemark//,
                //txtMachineName
                );

            txtMachineNo.KeyPress += CtrlUtil.SetNextControl;
            //cboMachineType.KeyPress += CtrlUtil.SetNextControl;
            //cboProcess.KeyPress += CtrlUtil.SetNextControl;
            //cboMachineGroup.KeyPress += CtrlUtil.SetNextControl;
            //cboProject.KeyPress += CtrlUtil.SetNextControl;
            txtRemark.KeyPress += CtrlUtil.SetNextControl;
            txtMachineName.KeyPress += CtrlUtil.SetNextControl;

            LookupData();

            if (m_screenMode == eMode.EDIT)
            {
                MachineUIDM model = m_MachineController.LoadMachine(m_MachineNo.ToNZString());
                dmcMachine.LoadData(model);
            }
        }

        private void LookupData()
        {
            string strTableName = EVOFramework.Data.DTOUtility.ReadTableName(typeof(MachineDTO));

            LookupDataBIZ biz = new LookupDataBIZ();

            LookupData MachineProjectData = biz.LoadLookupClassType(DataDefine.MACHINE_PROJECT.ToNZString());
            cboProject.LoadLookupData(MachineProjectData);
            cboProject.SelectedIndex = -1;

            NZString[] locationtype = new NZString[1];
            locationtype[0] = DataDefine.Convert2ClassCode(DataDefine.eLOCATION_CLS.Production).ToNZString();
            LookupData ProductionProcessData = biz.LoadLookupLocation(locationtype);
            //LookupData ProductionProcessData = biz.LoadLookupClassType(DataDefine.PRODUCTION_PROCESS.ToNZString());
            cboProcess.LoadLookupData(ProductionProcessData);
            cboProcess.SelectedIndex = -1;

            //LookupData lookupMachineType = biz.LoadLookupTextHelper(strTableName, MachineDTO.eColumns.MACHINE_TYPE.ToString());
            //cboMachineType.LoadLookupData(lookupMachineType);
            //cboMachineType.SelectedIndex = -1;
            LookupData lookupMachineType = biz.LoadLookupClassType(DataDefine.MACHINE_TYPE.ToNZString());
            cboMachineType.LoadLookupData(lookupMachineType);
            cboMachineType.SelectedIndex = -1;

            LookupData lookupMachineGroup = biz.LoadLookupTextHelper(strTableName, MachineDTO.eColumns.MACHINE_GROUP.ToString());
            cboMachineGroup.LoadLookupData(lookupMachineGroup);
            cboMachineGroup.SelectedIndex = -1;

        }

        private void ClearControls()
        {
            dmcMachine.LoadData(new MachineUIDM());
        }
        #endregion

        #region Form events
        private void MAS020_LocationMaster_Load(object sender, EventArgs e)
        {

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
            MachineUIDM model = dmcMachine.SaveData(new MachineUIDM());
            try
            {

                #region
                MachineValidator validator = new MachineValidator();

                ErrorItem errorItem = null;
                errorItem = validator.CheckEmptyMachineNo(new NZString(txtMachineNo, txtMachineNo.Text));
                if (null != errorItem) ValidateException.ThrowErrorItem(errorItem);

                errorItem = validator.CheckEmptyMachineType(new NZString(cboMachineType, cboMachineType.Text));
                if (null != errorItem) ValidateException.ThrowErrorItem(errorItem);

                errorItem = validator.CheckEmptyProcess(new NZString(cboProcess, cboProcess.SelectedValue));
                if (null != errorItem) ValidateException.ThrowErrorItem(errorItem);

                errorItem = validator.CheckEmptyMachineGroup(new NZString(cboMachineGroup, cboMachineGroup.Text));
                if (null != errorItem) ValidateException.ThrowErrorItem(errorItem);

                errorItem = validator.CheckEmptyProject(new NZString(cboProject, cboProject.SelectedValue));
                if (null != errorItem) ValidateException.ThrowErrorItem(errorItem);

                #endregion

                // Confirm to save.
                MessageDialogResult dr = MessageDialog.ShowConfirmation(this, new EVOFramework.Message(Messages.eConfirm.CFM9001.ToString()));
                if (dr == MessageDialogResult.Cancel || dr == MessageDialogResult.No)
                    return;

                if (eMode.ADD == m_screenMode)
                    m_MachineController.SaveNew(model);
                else
                    m_MachineController.SaveUpdate(model);

                m_dummyDialogResult = DialogResult.OK;

                //ClearControls();

                m_MachineNo = null;

                LookupData();
                InitializeScreenMode();

                CtrlUtil.FocusControl(txtMachineNo);
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
            MachineUIDM model = dmcMachine.SaveData(new MachineUIDM());
            try
            {

                #region
                MachineValidator validator = new MachineValidator();

                ErrorItem errorItem = null;
                errorItem = validator.CheckEmptyMachineNo(new NZString(txtMachineNo, txtMachineNo.Text));
                if (null != errorItem) ValidateException.ThrowErrorItem(errorItem);

                errorItem = validator.CheckEmptyMachineType(new NZString(cboMachineType, cboMachineType.Text));
                if (null != errorItem) ValidateException.ThrowErrorItem(errorItem);

                errorItem = validator.CheckEmptyProcess(new NZString(cboProcess, cboProcess.SelectedValue));
                if (null != errorItem) ValidateException.ThrowErrorItem(errorItem);

                errorItem = validator.CheckEmptyMachineGroup(new NZString(cboMachineGroup, cboMachineGroup.Text));
                if (null != errorItem) ValidateException.ThrowErrorItem(errorItem);

                errorItem = validator.CheckEmptyProject(new NZString(cboProject, cboProject.SelectedValue));
                if (null != errorItem) ValidateException.ThrowErrorItem(errorItem);

                #endregion

                // Confirm to save.
                MessageDialogResult dr = MessageDialog.ShowConfirmation(this, new EVOFramework.Message(Messages.eConfirm.CFM9001.ToString()));
                if (dr == MessageDialogResult.Cancel || dr == MessageDialogResult.No)
                    return;

                if (eMode.ADD == m_screenMode)
                    m_MachineController.SaveNew(model);
                else
                    m_MachineController.SaveUpdate(model);

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
