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
    [Screen("TRN102", "Order Selection", eShowAction.Normal, eScreenType.Screen, "Order Selection")]
    public partial class TRN102_OrderSelection : CustomizeForm
    {
        #region Enum
        public enum eColumns
        {
            EDIT_FLAG,
            ORDER_DETAIL_NO,
            PRICE,
            AMOUNT,
            ORDER_NO,
            PO_NO,
            ITEM_CD,
            SHORT_NAME,
            ITEM_DELIVERY_DATE,
            QTY,
            REMAIN_QTY,
            RETURN_QTY,
            SHIP_QTY,
            //Location,
            //Item_NO,
            //Item_Name

        }
        public enum eColCustomerOrder
        {
            //PONo,
            //PONo_Btn,
            //CustomerOrder,
            //OrderDetailNo,
            //ItemCode,
            //ShortName,
            //DeliveryDate,
            //OrderRemainQty,
            //DeliveryQty,
            //Price,
            //Amount,
            //ChoosePart,

            PO_NO,
            ORDER_NO,
            ORDER_DETAIL_NO,
            ITEM_CD,
            SHORT_NAME,
            ITEM_DELIVERY_DATE,
            ORDER_QTY,
            REMAIN_QTY,
            SHIP_QTY,
            SHIP_QTY2,
            PRICE,
            AMOUNT,
            RETURN_QTY,
            ChoosePart,
        }
        #endregion

        #region Constructor
        public TRN102_OrderSelection()
        {
            InitializeComponent();
            //InitialScreen();
        }

        public TRN102_OrderSelection(string strLocation, string strCustomer, string strCurrency, NZString strSlipNo, SheetView ShtOrder)
        {
            // Set Contructor Value
            m_Location = strLocation.ToNZString();
            m_Customer = strCustomer.ToNZString();
            m_Currency = strCurrency.ToNZString();
            m_SlipNo = strSlipNo;
            ShtPreviousOrder = ShtOrder;
            InitializeComponent();
            //InitialScreen();
            //txtCustomer.Text = strCustomer;
        }
        #endregion

        #region Variable
        private Common.eScreenMode m_Mode = Common.eScreenMode.ADD;
        private DataTable m_dtAllData;
        private ToolStripButton tsbOk = new System.Windows.Forms.ToolStripButton();
        private ToolStripButton tsbCancel = new System.Windows.Forms.ToolStripButton();
        private KeyboardSpread m_keyboardSpread = null;
        private SheetView ShtPreviousOrder = new SheetView();
        private NZString m_Location = new NZString();
        private NZString m_Customer = new NZString();
        private NZString m_Currency = new NZString();
        private NZString m_SlipNo = new NZString();
        #endregion

        #region FormLoad
        private void Lot_Maintenance_Load(object sender, EventArgs e)
        {
            //InitializeMenuButton();
            shtView.ActiveSkin = Common.ACTIVE_SKIN;
            //CtrlUtil.MappingDataFieldWithEnum(shtView, typeof(eColumns));

            InitialScreen();

            //loadData();

            //CtrlUtil.EnabledControl(false, txtItemDesc);

            //CtrlUtil.EnabledControl(true, txtItemCode);
            //CtrlUtil.EnabledControl(true, txtLocation);
            //SetScreenMode(Common.eScreenMode.ADD);
            //dmc.AddRangeControl(txtItemNo, txtItemDesc, txtLotNo);



            //CtrlUtil.SpreadSetColumnsLocked(shtView, true, (int)eColumns.LOT_NO);
            //CtrlUtil.SpreadSetColumnsLocked(shtView, true, (int)eColumns.ON_HAND_QTY);
            //CtrlUtil.SpreadSetColumnsLocked(shtView, false, (int)eColumns.Shipment);


        }
        #endregion

        #region LoadData
        private void loadData()
        {
            try
            {

                DeliveryController m_Controller = new DeliveryController();
                List<DeliveryViewDTO> listDTO = new List<DeliveryViewDTO>();
                listDTO = m_Controller.Load_OrderMaintenance(dtPeriodBegin.NZValue, dtPeriodEnd.NZValue, m_Customer, m_Currency, m_SlipNo);
                shtView.RowCount = 0;

                for (int i = 0; i < ShtPreviousOrder.RowCount; i++)
                {
                    for (int j = listDTO.Count - 1; j >= 0; j--)
                    {
                        if (listDTO[j].RETURN_QTY.StrongValue > 0)
                        {
                            listDTO.RemoveAt(j);
                            continue;
                        }
                        if (Convert.ToString(ShtPreviousOrder.GetValue(i, (int)eColCustomerOrder.ITEM_CD)) == listDTO[j].ITEM_CD.StrongValue
                            && Convert.ToString(ShtPreviousOrder.GetValue(i, (int)eColCustomerOrder.ORDER_DETAIL_NO)) == listDTO[j].ORDER_DETAIL_NO.StrongValue)
                            listDTO.RemoveAt(j);
                    }
                }

                shtView.DataSource = DTOUtility.ConvertListToDataTable<DeliveryViewDTO>(listDTO);
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

        private void tsbOk_Click(object sender, EventArgs e)
        {
            //for (int i = 0; i < shtView.Rows.Count; i++)
            //{
            //    //if (Convert.ToInt32(shtView.Cells[i, (int)eColumns.Shipment].Value) >
            //    //Convert.ToInt32(shtView.Cells[i, (int)eColumns.ON_HAND_QTY].Value))
            //    //{
            //    //    MessageDialog.ShowBusiness(this,
            //    //    Message.LoadMessage(TKPMessages.eValidate.VLM0104.ToString()).MessageDescription);
            //    //    return;
            //    //}

            //    if ((Convert.ToBoolean(shtView.Cells[i, (int)eColumns.EDIT_FLAG].Value) == true)
            //               (Convert.ToInt32(shtView.Cells[i,(int)eColumns.Shipment].Value == null)))
            //      {
            //           MessageDialog.ShowBusiness(this,
            //          Message.LoadMessage(TKPMessages.eValidate.VLM0103.ToString()).MessageDescription);
            //          return;
            //      }

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

        #region Initial Screen
        private void InitialScreen()
        {
            InitialFormat();
            InitializeMenuButton();
            InitialDefaultValue();
            InitialSpread();
            InitializeSetKeyPress();
        }
        private void InitialFormat()
        {
            // Set Control Format
            dtPeriodBegin.Format = Common.CurrentUserInfomation.DateFormatString;
            dtPeriodEnd.Format = Common.CurrentUserInfomation.DateFormatString;

            FormatUtil.SetNumberFormat(this.shtView.Columns[(int)eColumns.ITEM_CD], FormatUtil.eNumberFormat.MasterNo);


            // Set Spread Format
            FormatUtil.SetDateFormat(shtView.Columns[(int)eColumns.ITEM_DELIVERY_DATE]);
            FormatUtil.SetNumberFormat(shtView.Columns[(int)eColumns.QTY], FormatUtil.eNumberFormat.Qty_PCS);
            FormatUtil.SetNumberFormat(shtView.Columns[(int)eColumns.REMAIN_QTY], FormatUtil.eNumberFormat.Qty_PCS);
            FormatUtil.SetNumberFormat(shtView.Columns[(int)eColumns.SHIP_QTY], FormatUtil.eNumberFormat.Qty_PCS);

            FormatUtil.SetNumberFormat(this.shtView.Columns[(int)eColumns.ITEM_CD], FormatUtil.eNumberFormat.MasterNo);
        }
        private void InitializeSetKeyPress()
        {
            dtPeriodBegin.KeyPress += CtrlUtil.SetNextControl;
            dtPeriodEnd.KeyPress += CtrlUtil.SetNextControl;
        }
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
        private void InitialSpread()
        {
            shtView.ActiveSkin = Common.ACTIVE_SKIN;

            //m_keyboardSpread = new KeyboardSpread(fpView);
            //m_keyboardSpread.RowAdding += m_keyboardSpread_RowAdding;
            //m_keyboardSpread.RowAdded += m_keyboardSpread_RowAdded;
            //m_keyboardSpread.RowRemoved += m_keyboardSpread_RowRemoved;
            //if (m_screenMode != Common.eScreenMode.VIEW)
            //    m_keyboardSpread.StartBind();


            //fpNGInfo.SubEditorOpening += CtrlUtil.SpreadDisableSubEditorOpening;
            //CtrlUtil.MappingDataFieldWithEnum(shtView, typeof(eNGInfoCol));

            //fpCustomerOrderList.LeaveCell += new LeaveCellEventHandler(fpView_LeaveCell);
            //fpCustomerOrderList.SubEditorOpening += CtrlUtil.SpreadDisableSubEditorOpening;
            CtrlUtil.MappingDataFieldWithEnum(shtView, typeof(eColumns));

            string[] names = Enum.GetNames(typeof(eColumns));
            for (int i = 0; i < names.Length; i++)
            {
                shtView.Columns[i].DataField = names[i];
                CtrlUtil.SpreadSetColumnsLocked(shtView, true, i);
            }

            CtrlUtil.SpreadSetColumnsLocked(shtView, false, (int)eColumns.EDIT_FLAG);
            //if (m_screenMode == Common.eScreenMode.ADD || m_screenMode == Common.eScreenMode.EDIT)
            //{
            //    CtrlUtil.SpreadSetColumnsLocked(shtCustomerOrderList, false, (int)eColView.ITEM_CD_BTN);
            //    CtrlUtil.SpreadSetColumnsLocked(shtCustomerOrderList, false, (int)eColView.ITEM_DELIVERY_DATE);
            //    CtrlUtil.SpreadSetColumnsLocked(shtCustomerOrderList, false, (int)eColView.QTY);
            //}
            //if (m_screenMode == Common.eScreenMode.ADD)
            //{
            //    CtrlUtil.SpreadSetColumnsLocked(shtCustomerOrderList, false, (int)eColView.ITEM_CD_BTN);
            //    CtrlUtil.SpreadSetColumnsLocked(shtCustomerOrderList, false, (int)eColView.ITEM_DELIVERY_DATE);
            //    CtrlUtil.SpreadSetColumnsLocked(shtCustomerOrderList, false, (int)eColView.QTY);
            //}
        }
        private void InitialDefaultValue()
        {
            SysConfigBIZ sysBiz = new SysConfigBIZ();
            SysConfigDTO argDateFrom = new SysConfigDTO();
            argDateFrom.SYS_GROUP_ID = DataDefine.eSYSTEM_CONFIG.TRN102.SYS_GROUP_ID;
            argDateFrom.SYS_KEY = (NZString)DataDefine.eSYSTEM_CONFIG.TRN102.SYS_KEY.DEFAULT_DATE_FROM.ToString();
            dtPeriodBegin.Value = sysBiz.GetDefaultDateForScreen_No_Fix(argDateFrom);

            SysConfigDTO argDateTo = new SysConfigDTO();
            argDateTo.SYS_GROUP_ID = DataDefine.eSYSTEM_CONFIG.TRN102.SYS_GROUP_ID;
            argDateTo.SYS_KEY = (NZString)DataDefine.eSYSTEM_CONFIG.TRN102.SYS_KEY.DEFAULT_DATE_TO.ToString();
            dtPeriodEnd.Value = sysBiz.GetDefaultDateForScreen_No_Fix(argDateTo);
        }
        #endregion

        private void dtPeriodBegin_ValueChanged(object sender, EventArgs e)
        {
            loadData();
        }

        private void dtPeriodEnd_ValueChanged(object sender, EventArgs e)
        {
            loadData();
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

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            loadData();
        }

        private void TRN102_OrderSelection_Shown(object sender, EventArgs e)
        {
            CtrlUtil.FocusControl(dtPeriodBegin);
        }

    }
}
