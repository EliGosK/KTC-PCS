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


    [Screen("MAS090", "Class List", eShowAction.Normal, eScreenType.Screen, "Class List")]
    public partial class MAS090_ClassList : CustomizeForm
    {
        #region Enum
        public enum eColumns
        {
            CLS_INFO_CD,
            CLS_CD,
            CLS_DESC,
            SEQ,
            EDIT_FLAG
        };
        #endregion

        #region Constructor
        public MAS090_ClassList()
        {
            InitializeComponent();
        }
        #endregion

        #region Variable
        private DataTable m_dtAllData;
        private int AddCheck = 0;
        private ToolStripButton tsbEdit = new System.Windows.Forms.ToolStripButton();
        private ToolStripButton tsbSave = new System.Windows.Forms.ToolStripButton();
        private ToolStripButton tsbCancel = new System.Windows.Forms.ToolStripButton();
        private ToolStripButton tsbAdd = new System.Windows.Forms.ToolStripButton();
        private ToolStripButton tsbDelete = new System.Windows.Forms.ToolStripButton();
        private int Edit;
        #endregion

        #region FormLoad
        private void MAS090_ClassList_Load(object sender, EventArgs e)
        {
             InitializeMenuButton();

            dmc.AddRangeControl(txtClsInfoCd, txtClsCd, txtClsDesc, txtSEQ);

            loadData();
        }



        #endregion

        private void fpView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Convert.ToBoolean(shtView.Cells[shtView.ActiveRowIndex, (int)eColumns.EDIT_FLAG].Value) == true)
            {
                tsbEdit.Enabled = true;
                tsbAdd.Enabled = true;
                tsbDelete.Enabled = true;
            }
            else
            {
                tsbEdit.Enabled = false;
                tsbAdd.Enabled = false;
                tsbDelete.Enabled = false;
            }
            tsbSave.Enabled = false;
            tsbCancel.Enabled = false;

            txtClsInfoCd.Text = Convert.ToString(shtView.Cells[shtView.ActiveRowIndex, (int)eColumns.CLS_INFO_CD].Value);
            txtClsCd.Text = Convert.ToString(shtView.Cells[shtView.ActiveRowIndex, (int)eColumns.CLS_CD].Value);
            txtClsDesc.Text = Convert.ToString(shtView.Cells[shtView.ActiveRowIndex, (int)eColumns.CLS_DESC].Value);
            txtSEQ.Text = Convert.ToString(shtView.Cells[shtView.ActiveRowIndex, (int)eColumns.SEQ].Value);
            Edit = Convert.ToInt32(shtView.Cells[shtView.ActiveRowIndex, (int)eColumns.EDIT_FLAG].Value);
        }


        #region LoadData

        private void loadData()
        {
            tsbSave.Enabled = false;
            tsbCancel.Enabled = false;
            CtrlUtil.EnabledControl(false, txtClsCd);
            CtrlUtil.EnabledControl(false, txtClsDesc);
            CtrlUtil.EnabledControl(false, txtSEQ);
            shtView.ActiveSkin = Common.ACTIVE_SKIN;
            try
            {
                ClassListController ctlsys = new ClassListController();
                ClassListUIDM model = ctlsys.LoadClassList();

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
                //if ((shtView.Rows.Count > 0) && (Convert.ToBoolean(shtView.Cells[0, (int)eColumns.EDIT_FLAG].Value) == true))
                //{
                //    txtClsInfoCd.Text = Convert.ToString(shtView.Cells[shtView.ActiveRowIndex, (int)eColumns.CLS_INFO_CD].Value);
                //    txtClsCd.Text = Convert.ToString(shtView.Cells[shtView.ActiveRowIndex, (int)eColumns.CLS_CD].Value);
                //    txtClsDesc.Text = Convert.ToString(shtView.Cells[shtView.ActiveRowIndex, (int)eColumns.CLS_DESC].Value);
                //    txtSEQ.Text = Convert.ToString(shtView.Cells[shtView.ActiveRowIndex, (int)eColumns.SEQ].Value);
                //    tsbEdit.Enabled = true;
                //    tsbAdd.Enabled = true;
                //}

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
            ClassListUIDM datamodel = dmc.SaveData(new ClassListUIDM());
            try
            {
                ClassListController ctlsys = new ClassListController();
                int check = ctlsys.UpdateClassList(datamodel);
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

        #region AddData
        private void AddData()
        {
            ClassListUIDM datamodel = dmc.SaveData(new ClassListUIDM());
            try
            {
                ClassListController ctlsys = new ClassListController();
                int check = ctlsys.AddClassList(datamodel, Edit);
                if (check == 0)
                {
                    MessageDialog.ShowInformation(this, null, Message.LoadMessage(TKPMessages.eValidate.VLM0102.ToString()).MessageDescription);
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

        #region Delete Data
        private void DeleteData()
        {
            ClassListUIDM datamodel = dmc.SaveData(new ClassListUIDM());
            try
            {
                ClassListController ctlsys = new ClassListController();
                int check = ctlsys.DeleteClassList(datamodel);
                if (check == 0)
                {
                    MessageDialog.ShowInformation(this, null, Message.LoadMessage(TKPMessages.eValidate.VLM0068.ToString()).MessageDescription);
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

            // Add Menu "CAncel","Save","Add","Edit" in menu bar
            tsbCancel.Text = "Cancel";
            tsbCancel.Image = global::Rubik.Forms.Properties.Resources.CANCEL_ICON;
            tslControl.Items.Insert(tslControl.Items.IndexOf(tslControl.Items[tsbSaveAndClose.Name]) + 1, tsbCancel);
            tsbCancel.Click += new EventHandler(tsbCancel_Click);

            tsbSave.Text = "Save";
            tsbSave.Image = global::Rubik.Forms.Properties.Resources.SAVE;
            tslControl.Items.Insert(tslControl.Items.IndexOf(tslControl.Items[tsbSaveAndClose.Name]) + 1, tsbSave);
            tsbSave.Click += new EventHandler(tsbSave_Click);

            tsbDelete.Text = "Delete";
            tsbDelete.Image = global::Rubik.Forms.Properties.Resources.CLEAR;
            tslControl.Items.Insert(tslControl.Items.IndexOf(tslControl.Items[tsbSaveAndClose.Name]) + 1, tsbDelete);
            tsbDelete.Click += new EventHandler(tsbDelete_Click);

            tsbEdit.Text = "Edit";
            tsbEdit.Image = global::Rubik.Forms.Properties.Resources.ADD_TO_LIST;
            tslControl.Items.Insert(tslControl.Items.IndexOf(tslControl.Items[tsbSaveAndClose.Name]) + 1, tsbEdit);
            tsbEdit.Click += new EventHandler(tsbEdit_Click);

            tsbAdd.Text = "Add";
            tsbAdd.Image = global::Rubik.Forms.Properties.Resources.ADD_ICON;
            tslControl.Items.Insert(tslControl.Items.IndexOf(tslControl.Items[tsbSaveAndClose.Name]) + 1, tsbAdd);
            tsbAdd.Click += new EventHandler(tsbAdd_Click);

        }
        private void tsbEdit_Click(object sender, EventArgs e)
        {
            tsbEdit.Enabled = false;
            tsbAdd.Enabled = false;
            tsbDelete.Enabled = false;
            tsbSave.Enabled = true;
            tsbCancel.Enabled = true;
            fpView.Enabled = false;
            CtrlUtil.EnabledControl(true, txtClsDesc);
            CtrlUtil.EnabledControl(true, txtSEQ);
            AddCheck = 1;
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
                if (AddCheck == 1)
                {
                    UpdateData();
                    AddCheck = 0;
                }
                else
                {
                    AddData();
                    tsbAdd.Enabled = true;
                    tsbEdit.Enabled = true;
                    tsbDelete.Enabled = true;
                    fpView.Enabled = true;
                    loadData();
                }
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
                tsbAdd.Enabled = true;
                tsbEdit.Enabled = true;
                tsbDelete.Enabled = true;
                fpView.Enabled = true;
                loadData();
            }
        }

        private void tsbAdd_Click(object sender, EventArgs e)
        {
            tsbEdit.Enabled = false;
            tsbAdd.Enabled = false;
            tsbDelete.Enabled = false;
            tsbSave.Enabled = true;
            tsbCancel.Enabled = true;
            fpView.Enabled = false;
            CtrlUtil.EnabledControl(true, txtClsCd);
            CtrlUtil.EnabledControl(true, txtClsDesc);
            CtrlUtil.EnabledControl(true, txtSEQ);
            txtClsCd.Text = "";
            txtClsDesc.Text = "";
            txtSEQ.Text = "";

        }
        private void tsbDelete_Click(object sender, EventArgs e)
        {
            MessageDialogResult dr = MessageDialog.ShowConfirmation(this, Message.LoadMessage(Messages.eConfirm.CFM9002.ToString()));
            if (dr == MessageDialogResult.Cancel)
            {
                return;
            }
            if (dr == MessageDialogResult.Yes)
            {
                DeleteData();
            }
        }
        #endregion

        private void fpView_KeyDown(object sender, KeyEventArgs e)
        {
            CtrlUtil.FilterShortCut(e);
        }

    }
}
