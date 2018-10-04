using SystemMaintenance.Forms;
using EVOFramework.Data;
using EVOFramework.Windows.Forms;
using FarPoint.Win.Spread;
using Rubik.BIZ;
using CommonLib;
using EVOFramework;
using Rubik.Controller;
using Rubik.Forms.FindDialog;
using Rubik.UIDataModel;
using Rubik.Validators;
using Rubik.DTO;
using Message = EVOFramework.Message;
using System.Windows.Forms;
using System.Collections.Generic;
using System;
using System.Data;
using System.ComponentModel;
using SystemMaintenance;

namespace Rubik.Master
{


    [Screen("MAS080", "System Configuration", eShowAction.Normal, eScreenType.Screen, "System Configuration")]
    public partial class MAS080_SystemConfiguration : CustomizeForm
    {
        #region Enum
        public enum eColumns
        {
            SYS_GROUP_ID,
            SYS_KEY,
            CHAR_DATA,
            EDIT_FLAG
        };
        #endregion

        #region Constructor
        public MAS080_SystemConfiguration()
        {
            InitializeComponent();
        }
        #endregion

        #region Variable
        private DataTable m_dtAllData;
        private ToolStripButton tsbEdit = new System.Windows.Forms.ToolStripButton();
        private ToolStripButton tsbSave = new System.Windows.Forms.ToolStripButton();
        private ToolStripButton tsbCancel = new System.Windows.Forms.ToolStripButton();
        #endregion

        #region FormLoad
        private void MAS080_SystemConfiguration_Load(object sender, EventArgs e)
        {
            InitializeMenuButton();

            dmc.AddRangeControl(txtSysGroupId, txtSysKey, txtChrData);

            loadData();
        }
        #endregion

        private void fpView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Convert.ToBoolean(shtView.Cells[shtView.ActiveRowIndex, (int)eColumns.EDIT_FLAG].Value) == true)
            {
                tsbEdit.Enabled = true;
            }
            else
            {
                tsbEdit.Enabled = false;
            }
            CtrlUtil.EnabledControl(false, txtChrData);
            txtSysGroupId.Text = Convert.ToString(shtView.Cells[shtView.ActiveRowIndex, (int)eColumns.SYS_GROUP_ID].Value);
            txtSysKey.Text = Convert.ToString(shtView.Cells[shtView.ActiveRowIndex, (int)eColumns.SYS_KEY].Value);
            txtChrData.Text = Convert.ToString(shtView.Cells[shtView.ActiveRowIndex, (int)eColumns.CHAR_DATA].Value);

        }


        #region LoadData
        private void loadData()
        {
            tsbSave.Enabled = false;
            tsbCancel.Enabled = false;
            tsbEdit.Enabled = false;
            CtrlUtil.EnabledControl(false, txtChrData);
            shtView.ActiveSkin = Common.ACTIVE_SKIN;


            try
            {
                SystemConfigController ctlsys = new SystemConfigController();
                SystemConfigurationUIDM model = ctlsys.LoadSysConfig();

                //List<SysConfigDTO> dto = ctlsys.LoadSysConfig();
                //m_dtAllData = DTOUtility.ConvertListToDataTable(dto);
                //DataTable dtView = m_dtAllData.Clone();
                //foreach (DataRow dr in m_dtAllData.Rows)
                //{
                //    dtView.ImportRow(dr);
                //}

                fpView.DataSource = model.DATA_VIEW;
                CtrlUtil.MappingDataFieldWithEnum(shtView, typeof(eColumns));

                for (int i = 0; i < shtView.Rows.Count; i++)
                {
                    if (Convert.ToInt32(shtView.Cells[i, (int)eColumns.EDIT_FLAG].Value) == 1)
                        shtView.Cells[i, (int)eColumns.EDIT_FLAG].Value = true;
                    else
                        shtView.Cells[i, (int)eColumns.EDIT_FLAG].Value = false;
                }

                //if ((shtView.Rows.Count > 0)&& (Convert.ToBoolean(shtView.Cells[0, (int)eColumns.EDIT_FLAG].Value)==true))
                // {
                //     txtSysGroupId.Text = Convert.ToString(shtView.Cells[shtView.ActiveRowIndex, (int)eColumns.SYS_GROUP_ID].Value);
                //     txtSysKey.Text = Convert.ToString(shtView.Cells[shtView.ActiveRowIndex, (int)eColumns.SYS_KEY].Value);
                //     txtChrData.Text = Convert.ToString(shtView.Cells[shtView.ActiveRowIndex, (int)eColumns.CHAR_DATA].Value);
                //     tsbEdit.Enabled = true;
                // }

                if (shtView.RowCount > 0)
                {
                    shtView.ActiveRowIndex = 0;
                    shtView.AddSelection(0, 0, 1, 1);

                    shtView.SetActiveCell(0, 0);
                    fpView.ShowActiveCell(VerticalPosition.Top, HorizontalPosition.Left);
                    fpView_SelectionChanged(null, null);
                }

            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusiness(this, ex.Message);
            }
        }
        #endregion

        #region UpdateData
        private void UpdateData()
        {
            SystemConfigurationUIDM datamodel = dmc.SaveData(new SystemConfigurationUIDM());
            try
            {
                SystemConfigController ctlsys = new SystemConfigController();
                int check = ctlsys.UpdateConfig(datamodel);
                if (check == 0)
                {
                    MessageDialog.ShowInformation(this, null, Message.LoadMessage(TKPMessages.eValidate.VLM0100.ToString()).MessageDescription);
                    return;
                }
                else
                    loadData();
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusiness(this, ex.Message);
            }
        }

        #endregion

        #region MenuBotton
        private void InitializeMenuButton()
        {
            tsbSaveAndClose.Visible = false;
            tsbSaveAndNew.Visible = false;
            // tslControl.Items[tsbSaveAndClose.Text].Visible =false;

            //ToolStripButton tsbCancel = new System.Windows.Forms.ToolStripButton();
            tsbCancel.Text = "Cancel";
            tsbCancel.Image = global::Rubik.Forms.Properties.Resources.CANCEL_ICON;
            tslControl.Items.Insert(tslControl.Items.IndexOf(tslControl.Items[tsbSaveAndClose.Name]) + 1, tsbCancel);
            tsbCancel.Click += new EventHandler(tsbCancel_Click);

            // ToolStripButton tsbSave = new System.Windows.Forms.ToolStripButton();
            tsbSave.Text = "Save";
            tsbSave.Image = global::Rubik.Forms.Properties.Resources.SAVE;
            tslControl.Items.Insert(tslControl.Items.IndexOf(tslControl.Items[tsbSaveAndClose.Name]) + 1, tsbSave);
            tsbSave.Click += new EventHandler(tsbSave_Click);

            tsbEdit.Text = "Edit";
            tsbEdit.Image = global::Rubik.Forms.Properties.Resources.ADD_ICON;
            tslControl.Items.Insert(tslControl.Items.IndexOf(tslControl.Items[tsbSaveAndClose.Name]) + 1, tsbEdit);
            tsbEdit.Click += new EventHandler(tsbEdit_Click);
        }
        private void tsbEdit_Click(object sender, EventArgs e)
        {
            tsbEdit.Enabled = false;
            tsbSave.Enabled = true;
            tsbCancel.Enabled = true;
            fpView.Enabled = false;
            CtrlUtil.EnabledControl(true, txtChrData);
        }
        private void tsbSave_Click(object sender, EventArgs e)
        {
            MessageDialogResult dr = MessageDialog.ShowConfirmation(this, Message.LoadMessage(Messages.eConfirm.CFM9001.ToString()));
            if (dr == MessageDialogResult.Cancel)
            {
                return;
            }
            if (dr == MessageDialogResult.Yes)
            {
                UpdateData();
                tsbEdit.Enabled = true;

                fpView.Enabled = true;
            }
        }
        private void tsbCancel_Click(object sender, EventArgs e)
        {
            MessageDialogResult dr = MessageDialog.ShowConfirmation(this, Message.LoadMessage(Messages.eConfirm.CFM9003.ToString()));
            if (dr == MessageDialogResult.Cancel)
            {
                return;
            }
            if (dr == MessageDialogResult.Yes)
            {
                fpView.Enabled = true;
                loadData();
                tsbEdit.Enabled = true;
            }
        }
        #endregion

        private void fpView_KeyDown(object sender, KeyEventArgs e)
        {
            CtrlUtil.FilterShortCut(e);
        }

    }
}
