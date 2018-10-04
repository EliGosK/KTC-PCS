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

namespace Rubik.Transaction
{
    [Screen("TRN171", "Lot Maintenance", eShowAction.Normal, eScreenType.Screen, "Lot Maintenance")]
    public partial class TRN171_LotMaintenance : CustomizeForm
    {
        #region Enum
        public enum eColumns
        {
            EDIT_FLAG,
            LOT_NO,
            ON_HAND_QTY,
            Shipment
        }

        private enum eScreenMode
        {
            VIEW
        }

        #endregion

        #region Constructor
        public TRN171_LotMaintenance()
        {
            InitializeComponent();
        }

        public TRN171_LotMaintenance(string data)
        {
            InitializeComponent();
            txtLocation.Text = data;
        }
        #endregion

        #region Variable
        private Common.eScreenMode m_Mode = Common.eScreenMode.ADD;
        private DataTable m_dtAllData;
        private ToolStripButton tsbOk = new System.Windows.Forms.ToolStripButton();
        private ToolStripButton tsbCancel = new System.Windows.Forms.ToolStripButton();
        #endregion

        #region FormLoad
        private void Lot_Maintenance_Load(object sender, EventArgs e)
        {
            InitializeMenuButton();

            InitializeSpread();

            SetScreenMode(eScreenMode.VIEW);

            //CtrlUtil.EnabledControl(true, txtItemCode);
            //CtrlUtil.EnabledControl(true, txtLocation);
            //SetScreenMode(Common.eScreenMode.ADD);
            dmc.AddRangeControl(txtLocation, txtItemNo, txtItemDesc, txtLotNo, chkShowReserveLot);



        }

        #endregion

        #region LoadData
        private void loadData()
        {
            try
            {
                LotMaintenanceController ctlsys = new LotMaintenanceController();
                LotMaintenanceUIDM model = dmc.SaveData(new LotMaintenanceUIDM());
                LotMaintenanceUIDM models = ctlsys.loaddata(model);

                fpView.DataSource = models.DATA_VIEW;

                //for (int i = 0; i < shtView.Rows.Count; i++)
                //{
                //    if (Convert.ToInt32(shtView.Cells[i, (int)eColumns.EDIT_FLAG].Value) == 1)
                //        shtView.Cells[i, (int)eColumns.EDIT_FLAG].Value = true;
                //    else
                //        shtView.Cells[i, (int)eColumns.EDIT_FLAG].Value = false;
                //}

            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusiness(this, ex.Message);
            }
        }
        #endregion

        #region SentData
        public SheetView shtData
        { get { return shtView; } set { shtView = value; } }
        public string ItemNo
        { get { return txtItemNo.Text; } set { txtItemNo.Text = value; } }
        public string ItemName
        { get { return txtItemDesc.Text; } set { txtItemDesc.Text = value; } }
        #endregion

        #region MenuBotton
        private void InitializeMenuButton()
        {
            tsbSaveAndClose.Visible = false;
            tsbSaveAndNew.Visible = false;

            tsbCancel.Text = "Cancel";
            tsbCancel.Image = global::Rubik.Forms.Properties.Resources.CANCEL_ICON;
            tslControl.Items.Insert(tslControl.Items.IndexOf(tslControl.Items[tsbSaveAndClose.Name]) + 1, tsbCancel);
            tsbCancel.Click += new EventHandler(tsbCancel_Click);

            tsbOk.Text = "Ok";
            tsbOk.Image = global::Rubik.Forms.Properties.Resources.ADD_ICON;
            tslControl.Items.Insert(tslControl.Items.IndexOf(tslControl.Items[tsbSaveAndClose.Name]) + 1, tsbOk);
            tsbOk.Click += new EventHandler(tsbOk_Click);
        }
        private void tsbOk_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < shtView.Rows.Count; i++)
            {
                if (Convert.ToInt32(shtView.Cells[i, (int)eColumns.Shipment].Value) >
                Convert.ToInt32(shtView.Cells[i, (int)eColumns.ON_HAND_QTY].Value))
                {
                    MessageDialog.ShowBusiness(this,
                    Message.LoadMessage(TKPMessages.eValidate.VLM0104.ToString()).MessageDescription);
                    return;
                }

                /*  else if ((Convert.ToBoolean(shtView.Cells[i, (int)eColumns.EDIT_FLAG].Value) == true)
                           (Convert.ToInt32(shtView.Cells[i,(int)eColumns.Shipment].Value == null)))
                  {
                       MessageDialog.ShowBusiness(this,
                      Message.LoadMessage(TKPMessages.eValidate.VLM0103.ToString()).MessageDescription);
                      return;
                  }
                  */
            }
            DialogResult = DialogResult.OK;

        }

        private void tsbCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            loadData();

        }

        private void fpView_ButtonClicked(object sender, EditorNotifyEventArgs e)
        {
            if ((int)eColumns.EDIT_FLAG == e.Column)
            {
                if (Convert.ToBoolean(shtView.Cells[shtView.ActiveRowIndex, (int)eColumns.EDIT_FLAG].Value) == true)
                {
                    shtView.Cells[shtView.ActiveRowIndex, (int)eColumns.Shipment].Value = shtView.Cells[shtView.ActiveRowIndex, (int)eColumns.ON_HAND_QTY].Value;
                }
                else
                    shtView.Cells[shtView.ActiveRowIndex, (int)eColumns.Shipment].Value = null;
            }

        }



        #endregion


        private void fpView_Change(object sender, ChangeEventArgs e)
        {
            if (Convert.ToInt32(shtView.Cells[shtView.ActiveRowIndex, (int)eColumns.Shipment].Value) > Convert.ToInt32(shtView.Cells[shtView.ActiveRowIndex, (int)eColumns.ON_HAND_QTY].Value))
            {
                MessageDialog.ShowBusiness(this,
                    Message.LoadMessage(TKPMessages.eValidate.VLM0104.ToString()).MessageDescription);
                shtView.Cells[shtView.ActiveRowIndex, (int)eColumns.Shipment].Value = shtView.Cells[shtView.ActiveRowIndex, (int)eColumns.ON_HAND_QTY].Value;
                shtView.Cells[shtView.ActiveRowIndex, (int)eColumns.EDIT_FLAG].Value = true;
                return;
            }

            if (shtView.Cells[shtView.ActiveRowIndex, (int)eColumns.Shipment].Value != null)
                shtView.Cells[shtView.ActiveRowIndex, (int)eColumns.EDIT_FLAG].Value = true;
            else
                shtView.Cells[shtView.ActiveRowIndex, (int)eColumns.EDIT_FLAG].Value = false;

        }

        private void fpView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void InitializeSpread()
        {
            shtView.ActiveSkin = Common.ACTIVE_SKIN;

            CtrlUtil.MappingDataFieldWithEnum(shtView, typeof(eColumns));

            CtrlUtil.SpreadSetColumnsLocked(shtView, true, (int)eColumns.LOT_NO);
            CtrlUtil.SpreadSetColumnsLocked(shtView, true, (int)eColumns.ON_HAND_QTY);
        }

        private void SetScreenMode(eScreenMode screenMode)
        {
            switch (screenMode)
            {
                case eScreenMode.VIEW:
                    CtrlUtil.EnabledControl(false, txtItemDesc);
                    break;
                default:
                    break;
            }
        }

        private void fpView_KeyDown(object sender, KeyEventArgs e)
        {
            CtrlUtil.FilterShortCut(e);
        }
    }
}
