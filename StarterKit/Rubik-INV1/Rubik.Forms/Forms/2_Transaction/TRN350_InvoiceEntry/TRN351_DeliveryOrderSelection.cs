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
    //[Screen("TRN351", "Delivery Selection", eShowAction.Normal, eScreenType.Screen, "Delivery Selection")]
    public partial class TRN351_DeliveryOrderSelection : CustomizeForm
    {
        #region Enum
        public enum eColumns
        {
            //OLD
            /*EDIT_FLAG,
            CUST_ORDER_NO,
            PO_NO,
            ITEM_CD,
            SHORT_NAME,
            DELIVERY_DATE,
            REMAIN_QTY,
            DELIVERY_QTY,
            //Location,
            //Item_NO,
            //Item_Name*/
            EDIT_FLAG,
            SLIP_NO,
            GROUP_TRANS_ID,
            TRANS_ID,
            CURRENCY,
            ORDER_NO,
            ORDER_DETAIL_NO,
            PO_NO,
            ITEM_CD,
            SHORT_NAME,
            TRANS_DATE,
            PACK_NO,
            LOT_NO,
            EXTERNAL_LOT_NO,
            LOT_QTY,
            RETURNABLE_QTY
        }
        public enum eColPreviousScreen
        {
            PO_NO,
            SLIP_NO,
            TRANS_ID,
            GROUP_TRANS_ID,
            REF_NO,
            ORDER_NO,
            REF_SLIP_NO,
            ITEM_CD,
            SHORT_NAME,
            TRANS_DATE,
            PACK_NO,
            LOT_NO,
            EXTERNAL_LOT_NO,
            SHIP_QTY,
            RETURNABLE_QTY,
            QTY
        }
        #endregion

        #region Constructor
        public TRN351_DeliveryOrderSelection()
        {
            InitializeComponent();
        }

        public TRN351_DeliveryOrderSelection(string strLocation, string strCustomer, string strReturnSlipNo, SheetView shtData)
        {
            InitializeComponent();
            shtPreviousData = shtData;
            m_LocCd = strLocation;
            m_Customer = strCustomer;
            m_Return_Slip_No = strReturnSlipNo;
        }
        #endregion

        #region Variable
        private Common.eScreenMode m_Mode = Common.eScreenMode.ADD;
        private DataTable m_dtAllData;
        private ToolStripButton tsbOk = new System.Windows.Forms.ToolStripButton();
        private ToolStripButton tsbCancel = new System.Windows.Forms.ToolStripButton();
        private SheetView shtPreviousData = new SheetView();
        private string m_Customer;
        private string m_LocCd;
        private string m_Return_Slip_No;
        #endregion

        #region FormLoad
        private void Lot_Maintenance_Load(object sender, EventArgs e)
        {

            InitializeMenuButton();
            InitialFormat();
            InitialDefaultValue();
            InitialSpread();
            //loadData();
            //CtrlUtil.EnabledControl(false, txtItemDesc);

            //CtrlUtil.EnabledControl(true, txtItemCode);
            //CtrlUtil.EnabledControl(true, txtLocation);
            //SetScreenMode(Common.eScreenMode.ADD);
            //dmc.AddRangeControl(txtMasterNo, txtItemDesc, dtPeriodBegin,dtPeriodEnd);

            txtMasterNo.KeyPress += CtrlUtil.SetNextControl;
            //btnItemCode.KeyPress += CtrlUtil.SetNextControl;
            txtItemDesc.KeyPress += CtrlUtil.SetNextControl;
            dtPeriodBegin.KeyPress += CtrlUtil.SetNextControl;
            dtPeriodEnd.KeyPress += CtrlUtil.SetNextControl;

            CtrlUtil.EnabledControl(false, txtItemDesc);
            //CtrlUtil.SpreadSetColumnsLocked(shtView, true, (int)eColumns.LOT_NO);
            //CtrlUtil.SpreadSetColumnsLocked(shtView, true, (int)eColumns.ON_HAND_QTY);
            //CtrlUtil.SpreadSetColumnsLocked(shtView, false, (int)eColumns.Shipment);


        }
        private void InitialFormat()
        {
            // Set Format Control
            dtPeriodBegin.Format = Common.CurrentUserInfomation.DateFormatString;
            dtPeriodEnd.Format = Common.CurrentUserInfomation.DateFormatString;

            // Set Spread Format
            FormatUtil.SetDateFormat(shtView.Columns[(int)eColumns.TRANS_DATE]);
            FormatUtil.SetNumberFormat(shtView.Columns[(int)eColumns.LOT_QTY], FormatUtil.eNumberFormat.Qty_PCS);
            FormatUtil.SetNumberFormat(shtView.Columns[(int)eColumns.RETURNABLE_QTY], FormatUtil.eNumberFormat.Qty_PCS);
        }
        private void InitialSpread()
        {
            shtView.ActiveSkin = Common.ACTIVE_SKIN;
            CtrlUtil.MappingDataFieldWithEnum(shtView, typeof(eColumns));

            string[] names = Enum.GetNames(typeof(eColumns));
            for (int i = 0; i < names.Length; i++)
            {
                shtView.Columns[i].DataField = names[i];
                CtrlUtil.SpreadSetColumnsLocked(shtView, true, i);
            }

            CtrlUtil.SpreadSetColumnsLocked(shtView, false, (int)eColumns.EDIT_FLAG);
        }
        private void InitialDefaultValue()
        {
            //dtPeriodBegin.Value = DateTime.Today;
            //dtPeriodEnd.Value = DateTime.Today;
            SysConfigBIZ sysBiz = new SysConfigBIZ();
            SysConfigDTO argDateFrom = new SysConfigDTO();
            argDateFrom.SYS_GROUP_ID = DataDefine.eSYSTEM_CONFIG.TRN271.SYS_GROUP_ID;
            argDateFrom.SYS_KEY = (NZString)DataDefine.eSYSTEM_CONFIG.TRN271.SYS_KEY.DEFAULT_DATE_FROM.ToString();
            dtPeriodBegin.Value = sysBiz.GetDefaultDateForScreen_No_Fix(argDateFrom);

            SysConfigDTO argDateTo = new SysConfigDTO();
            argDateTo.SYS_GROUP_ID = DataDefine.eSYSTEM_CONFIG.TRN271.SYS_GROUP_ID;
            argDateTo.SYS_KEY = (NZString)DataDefine.eSYSTEM_CONFIG.TRN271.SYS_KEY.DEFAULT_DATE_TO.ToString();
            dtPeriodEnd.Value = sysBiz.GetDefaultDateForScreen_No_Fix(argDateTo);
        }
        #endregion

        #region LoadData
        private void loadData()
        {
            try
            {

                //LotMaintenanceController ctlsys = new LotMaintenanceController();
                //LotMaintenanceUIDM model = dmc.SaveData(new LotMaintenanceUIDM());
                //LotMaintenanceUIDM models = ctlsys.loaddata(model);
                DeliveryBIZ bizDelivery = new DeliveryBIZ();
                DataTable dt = bizDelivery.Load_DeliveryOrderListForReturn(dtPeriodBegin.NZValue, dtPeriodEnd.NZValue, txtMasterNo.Text.ToNZString(), txtItemDesc.Text.ToNZString(), m_Customer.ToNZString(), m_Return_Slip_No.ToNZString(), false);
                fpView.DataSource = dt;//models.DATA_VIEW;

                for (int i = 0; i < shtPreviousData.RowCount; i++)
                {
                    for (int j = shtView.RowCount - 1; j >= 0; j--)
                    {
                        if (Convert.ToDecimal(shtPreviousData.GetValue(i, (int)eColPreviousScreen.RETURNABLE_QTY)) <= 0)
                        {
                            shtView.RemoveRows(j, 1);
                            continue;
                        }
                        if (Convert.ToString(shtPreviousData.GetValue(i, (int)eColPreviousScreen.REF_SLIP_NO)) == Convert.ToString(shtView.GetValue(j, (int)eColumns.ORDER_DETAIL_NO))
                            && Convert.ToString(shtPreviousData.GetValue(i, (int)eColPreviousScreen.REF_NO)) == Convert.ToString(shtView.GetValue(j, (int)eColumns.TRANS_ID)))
                            shtView.RemoveRows(j, 1);
                    }
                }



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
            //for (int i = 0; i < shtView.Rows.Count; i++)
            //{
            //    if (Convert.ToInt32(shtView.Cells[i, (int)eColumns.Shipment].Value) >
            //    Convert.ToInt32(shtView.Cells[i, (int)eColumns.ON_HAND_QTY].Value))
            //    {
            //        MessageDialog.ShowBusiness(this,
            //        Message.LoadMessage(TKPMessages.eValidate.VLM0104.ToString()).MessageDescription);
            //        return;
            //    }

            //    /*  else if ((Convert.ToBoolean(shtView.Cells[i, (int)eColumns.EDIT_FLAG].Value) == true)
            //               (Convert.ToInt32(shtView.Cells[i,(int)eColumns.Shipment].Value == null)))
            //      {
            //           MessageDialog.ShowBusiness(this,
            //          Message.LoadMessage(TKPMessages.eValidate.VLM0103.ToString()).MessageDescription);
            //          return;
            //      }
            //      */
            //}
            DialogResult = DialogResult.OK;

        }

        private void tsbCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {


            loadData();


            //CtrlUtil.SpreadSetColumnsLocked(shtView, true, (int)eColumns.LOT_NO);
            //CtrlUtil.SpreadSetColumnsLocked(shtView, false, (int)eColumns.Shipment);
        }

        private void fpView_ButtonClicked(object sender, EditorNotifyEventArgs e)
        {
            //if ((int)eColumns.EDIT_FLAG == e.Column)
            //{
            //    if (Convert.ToBoolean(shtView.Cells[shtView.ActiveRowIndex, (int)eColumns.EDIT_FLAG].Value) == true)
            //    {
            //        shtView.Cells[shtView.ActiveRowIndex, (int)eColumns.Shipment].Value = shtView.Cells[shtView.ActiveRowIndex, (int)eColumns.ON_HAND_QTY].Value;
            //    }
            //    else
            //        shtView.Cells[shtView.ActiveRowIndex, (int)eColumns.Shipment].Value = null;
            //}

        }



        #endregion


        private void fpView_Change(object sender, ChangeEventArgs e)
        {
            //if (Convert.ToInt32(shtView.Cells[shtView.ActiveRowIndex, (int)eColumns.Shipment].Value) > Convert.ToInt32(shtView.Cells[shtView.ActiveRowIndex, (int)eColumns.ON_HAND_QTY].Value))
            //{
            //    MessageDialog.ShowBusiness(this,
            //        Message.LoadMessage(TKPMessages.eValidate.VLM0104.ToString()).MessageDescription);
            //    shtView.Cells[shtView.ActiveRowIndex, (int)eColumns.Shipment].Value = shtView.Cells[shtView.ActiveRowIndex, (int)eColumns.ON_HAND_QTY].Value;
            //    shtView.Cells[shtView.ActiveRowIndex, (int)eColumns.EDIT_FLAG].Value = true;
            //    return;
            //}

            //if (shtView.Cells[shtView.ActiveRowIndex, (int)eColumns.Shipment].Value != null)
            //    shtView.Cells[shtView.ActiveRowIndex, (int)eColumns.EDIT_FLAG].Value = true;
            //else
            //    shtView.Cells[shtView.ActiveRowIndex, (int)eColumns.EDIT_FLAG].Value = false;

        }

        public override void OnSaveFormat()
        {
            base.OnSaveFormat();

            SheetWidthController ctrl = new SheetWidthController();
            ctrl.SaveSheetWidth(shtView, this.ScreenCode);
        }

        public override void OnResetFormat()
        {
            base.OnResetFormat();

            SheetWidthController ctrl = new SheetWidthController();
            ctrl.ResetSheetWidth(shtView);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (Common.UserGroupShowFormatButton.ToUpper().Equals(Common.CurrentUserInfomation.GroupCode.NVL("").ToUpper()))
            {
                tsbDefaultSize.Visible = true;
                tsbSaveFormat.Visible = true;
            }

            SheetWidthController ctrl = new SheetWidthController();
            ctrl.SetSheetWidth(shtView, this.ScreenCode);
        }

        private void fpView_KeyDown(object sender, KeyEventArgs e)
        {
            CtrlUtil.FilterShortCut(e);
        }

        private void TRN271_DeliveryOrderSelection_Shown(object sender, EventArgs e)
        {
            CtrlUtil.FocusControl(txtMasterNo);
        }

    }
}
