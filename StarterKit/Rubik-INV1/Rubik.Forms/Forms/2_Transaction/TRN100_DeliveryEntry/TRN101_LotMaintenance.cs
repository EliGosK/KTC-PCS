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
using System.Text;
using System.Drawing;

namespace Rubik.Transaction
{
    [Screen("TRN101", "Pack Selection", eShowAction.Normal, eScreenType.Screen, "Pack Selection")]
    public partial class TRN101_LotMaintenance : CustomizeForm
    {
        #region Enum
        public enum eColumns
        {
            //// OLD ENUM
            //EDIT_FLAG,
            //ITEM_CD,
            //SHORT_NAME,
            //ITEM_DESC,
            //ON_HAND_QTY,
            //Shipment,
            ////Location,
            ////Item_NO,
            ////Item_Name

            CHECK_FLAG,
            LAST_RECEIVE_DATE,
            PACK_NO,
            FG_NO,
            LOT_NO,
            EXTERNAL_LOT_NO,
            ONHAND_QTY,
            RETURN_QTY

        }

        public enum eColPreviousLot
        {
            //OrderNo,
            //OrderDetailNo,
            //ItemCode,
            //ShortName,
            //DeliveryDate,
            //PackNo,
            //LotNo,
            //CustomerLotNo,
            //LotQty

            REF_NO,
            REF_SLIP_NO,
            TRANS_ID,
            ITEM_CD,
            SHORT_NAME,
            TRANS_DATE,
            PACK_NO,
            FG_NO,
            LOT_NO,
            EXTERNAL_LOT_NO,
            PRICE,
            AMOUNT,
            QTY
        }
        #endregion

        #region Constructor
        public TRN101_LotMaintenance()
        {
            InitializeComponent();
        }

        public TRN101_LotMaintenance(string strOrderDetailNo, string strLocation, string strItem_Cd, string strPartNo, decimal dRemainQty, NZString strSlipNo, SheetView shtLot)
        {
            InitializeComponent();
            OrderDetailNo = strOrderDetailNo.ToNZString();
            ItemCd = strItem_Cd.ToNZString();
            LocCd = strLocation.ToNZString();
            SlipNo = strSlipNo;
            PartNo = strPartNo.ToNZString();
            RemainQty = dRemainQty.ToNZDecimal();
            if (shtLot.RowCount != 0) shtPreviousLot = shtLot;
        }
        #endregion

        #region Variable
        private Common.eScreenMode m_Mode = Common.eScreenMode.ADD;
        private ToolStripButton tsbOk = new System.Windows.Forms.ToolStripButton();
        private ToolStripButton tsbCancel = new System.Windows.Forms.ToolStripButton();
        private NZString ItemCd = new NZString();
        private NZString LocCd = new NZString();
        private NZString SlipNo = new NZString();
        private NZDecimal RemainQty = new NZDecimal();
        private NZString PartNo = new NZString();
        private NZString OrderDetailNo = new NZString();
        private SheetView shtPreviousLot;
        private DataTable m_Data = new DataTable();
        private DataTable dt = new DataTable();

        const string CONST_COLUMN_NAME_CHECK_FLAG = "CHECK_FLAG";

        private List<string> ChoosePack = new List<string>();
        #endregion

        #region FormLoad
        private void Lot_Maintenance_Load(object sender, EventArgs e)
        {
            InitializeMenuButton();
            InitialFormat();
            InitialSpread();
            InitialDefaultValue();

            CtrlUtil.EnabledControl(false, txtItemNo, txtPartNo, txtRemainQty, txtQty);

            // Get all data
            DeliveryBIZ bizDelivery = new DeliveryBIZ();
            List<ActualOnhandViewDTO> listDTO = bizDelivery.Load_LotMaintenance(SlipNo, LocCd, ItemCd, false);
            m_Data = DTOUtility.ConvertListToDataTable<ActualOnhandViewDTO>(listDTO);
            m_Data.Columns.Add(CONST_COLUMN_NAME_CHECK_FLAG, typeof(int));


            m_Data = OrderData(m_Data);

            // Filter
            loadData();
        }
        #endregion

        #region LoadData


        private void loadData()
        {
            try
            {
                //LotMaintenanceController ctlsys = new LotMaintenanceController();
                //LotMaintenanceUIDM model = dmc.SaveData(new LotMaintenanceUIDM());
                //model.Item_No = ItemCd;
                //LotMaintenanceUIDM models = ctlsys.loaddata(model);

                if (shtView.RowCount > 0)
                {
                    for (int i = 0; i < shtView.RowCount; i++)
                    {
                        if (Convert.ToBoolean(shtView.GetValue(i, (int)eColumns.CHECK_FLAG)))
                            if (!ChoosePack.Contains(shtView.GetValue(i, (int)eColumns.PACK_NO).ToString()))
                                ChoosePack.Add(shtView.GetValue(i, (int)eColumns.PACK_NO).ToString());
                            else
                            {
                                if (ChoosePack.Contains(shtView.GetValue(i, (int)eColumns.PACK_NO).ToString()))
                                    ChoosePack.Remove(shtView.GetValue(i, (int)eColumns.PACK_NO).ToString());
                            }
                    }
                }

                dt = m_Data;//.Copy();




                //for (int i = 0; i < dt.Rows.Count; i++)
                //{
                //    dt.Rows[i]["CHECK_FLAG"] = 0;

                //    for (int j = 0; j < ChoosePack.Count; j++)
                //    {
                //        if (dt.Rows[i]["PACK_NO"].ToString() == ChoosePack[j])
                //        {
                //            dt.Rows[i]["CHECK_FLAG"] = 1;
                //            continue;
                //        }
                //    }

                //}


                string keyword = txtLotNo.Text.Trim();


                DataTable dtBindData = null;

                DataView dv = dt.DefaultView;
                if (keyword != "")
                {
                    dv.RowFilter = ActualOnhandViewDTO.eColumns.LOT_NO.ToString() + " LIKE '" + keyword + "%'";

                    DataTable dtPackNo = dv.ToTable(true, ActualOnhandViewDTO.eColumns.PACK_NO.ToString());

                    StringBuilder sbFilterString = new StringBuilder();
                    if (dtPackNo.Rows.Count > 0)
                    {
                        sbFilterString.Append(" " + ActualOnhandViewDTO.eColumns.PACK_NO.ToString() + " IN (");

                        foreach (DataRow row in dtPackNo.Rows)
                        {
                            sbFilterString.Append("'" + row[ActualOnhandViewDTO.eColumns.PACK_NO.ToString()] + "',");
                        }
                        foreach (string FromChoose in ChoosePack)
                        {
                            sbFilterString.Append("'" + FromChoose + "',");
                        }

                        sbFilterString.Remove(sbFilterString.Length - 1, 1);

                        sbFilterString.AppendLine(")");
                    }

                    //กรณีที่ search ไม่เจอ pack จะได้ไม่ error
                    if (sbFilterString.Length > 0)
                    {
                        sbFilterString.Append(" OR ");
                    }

                    sbFilterString.Append("  (" + CONST_COLUMN_NAME_CHECK_FLAG + "=1)");

                    dv.RowFilter = sbFilterString.ToString();

                    //fpView.DataSource = dt.DefaultView.ToTable();
                    dtBindData = dt.DefaultView.ToTable();



                    //for (int i = 0; i < shtView.Rows.Count; i++)
                    //{
                    //    foreach (string pack in ChoosePack)
                    //    {
                    //        if (Convert.ToString(shtView.Cells[i, (int)eColumns.PACK_NO].Value) == pack)
                    //            shtView.Cells[i, (int)eColumns.EDIT_FLAG].Value = true;
                    //        else
                    //            shtView.Cells[i, (int)eColumns.EDIT_FLAG].Value = false;
                    //    }
                    //}
                }
                else
                {
                    dv.RowFilter = "";

                    //fpView.DataSource = dt;
                    dtBindData = dt;

                }



                fpView.DataSource = dt;

                AutoCheckFromMainScreen();
                CalTotatValue();
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusiness(this, ex.Message);
            }
        }

        private DataTable OrderData(DataTable dt)
        {
            if (shtPreviousLot == null || shtPreviousLot.RowCount <= 0) return dt;


            for (int j = 0; j < dt.Rows.Count; j++)
            {
                for (int i = 0; i < shtPreviousLot.RowCount; i++)
                {
                    string pOrderDetailNo = Convert.ToString(shtPreviousLot.GetValue(i, (int)eColPreviousLot.REF_SLIP_NO));
                    string pItemCd = Convert.ToString(shtPreviousLot.GetValue(i, (int)eColPreviousLot.ITEM_CD));
                    string pPackNo = Convert.ToString(shtPreviousLot.GetValue(i, (int)eColPreviousLot.PACK_NO));
                    string pLotNo = Convert.ToString(shtPreviousLot.GetValue(i, (int)eColPreviousLot.LOT_NO));

                    if (pItemCd != ItemCd) continue;


                    string dataPackNo = null;
                    string dataLotNo = null;

                    if (dt.Rows[j][ActualOnhandViewDTO.eColumns.PACK_NO.ToString()] != DBNull.Value)
                    {
                        dataPackNo = dt.Rows[j][ActualOnhandViewDTO.eColumns.PACK_NO.ToString()].ToString();
                    }
                    else
                    {
                        dataPackNo = "";
                    }

                    if (dt.Rows[j][ActualOnhandViewDTO.eColumns.LOT_NO.ToString()] != DBNull.Value)
                    {
                        dataLotNo = dt.Rows[j][ActualOnhandViewDTO.eColumns.LOT_NO.ToString()].ToString();
                    }
                    else
                    {
                        dataLotNo = "";
                    }


                    if (dataPackNo == pPackNo && dataLotNo == pLotNo)
                    {
                        if (OrderDetailNo.StrongValue == pOrderDetailNo)
                        {
                            dt.Rows[j][CONST_COLUMN_NAME_CHECK_FLAG] = 1;
                        }

                        break;
                    }
                }
            }

            dt.DefaultView.Sort = CONST_COLUMN_NAME_CHECK_FLAG + " DESC"
                + "," + ActualOnhandViewDTO.eColumns.LAST_RECEIVE_DATE.ToString()
                + "," + ActualOnhandViewDTO.eColumns.PACK_NO.ToString()
                + "," + ActualOnhandViewDTO.eColumns.LOT_NO.ToString();

            return dt.DefaultView.ToTable();
        }


        private void InitialFormat()
        {
            // Set Control Format
            CommonLib.FormatUtil.SetNumberFormat(this.txtRemainQty, FormatUtil.eNumberFormat.Total_Qty_PCS);
            CommonLib.FormatUtil.SetNumberFormat(this.txtQty, FormatUtil.eNumberFormat.Total_Qty_PCS);

            // Set Spread Format
            FormatUtil.SetDateFormat(shtView.Columns[(int)eColumns.LAST_RECEIVE_DATE]);
            FormatUtil.SetNumberFormat(shtView.Columns[(int)eColumns.ONHAND_QTY], FormatUtil.eNumberFormat.Qty_PCS);
        }
        private void InitialSpread()
        {
            shtView.ActiveSkin = Common.ACTIVE_SKIN;
            CtrlUtil.MappingDataFieldWithEnum(shtView, typeof(eColumns));
            shtView.OperationMode = OperationMode.Normal;

            shtView.Columns[(int)eColumns.CHECK_FLAG].CellType = CtrlUtil.CreateCheckboxCellType();
            shtView.Columns[(int)eColumns.CHECK_FLAG].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;

            CtrlUtil.SpreadSetColumnsLocked(shtView, false, (int)eColumns.CHECK_FLAG);
            CtrlUtil.SpreadSetColumnsLocked(shtView, true, (int)eColumns.LAST_RECEIVE_DATE);
            CtrlUtil.SpreadSetColumnsLocked(shtView, true, (int)eColumns.PACK_NO);
            CtrlUtil.SpreadSetColumnsLocked(shtView, true, (int)eColumns.FG_NO);
            CtrlUtil.SpreadSetColumnsLocked(shtView, true, (int)eColumns.LOT_NO);
            CtrlUtil.SpreadSetColumnsLocked(shtView, true, (int)eColumns.EXTERNAL_LOT_NO);
            CtrlUtil.SpreadSetColumnsLocked(shtView, true, (int)eColumns.ONHAND_QTY);
            fpView.ContextMenuStrip = null;
            fpView.SubEditorOpening += CtrlUtil.SpreadDisableSubEditorOpening;
        }
        private void InitialDefaultValue()
        {
            txtItemNo.Text = ItemCd.StrongValue;
            txtPartNo.Text = PartNo.StrongValue;
            txtRemainQty.Decimal = RemainQty.StrongValue;
        }

        #endregion

        #region SentData
        public SheetView shtData
        { get { return shtView; } set { shtView = value; } }
        //public string ItemNo
        //{ get { return txtItemNo.Text; } set { txtItemNo.Text = value; } }
        //public string ItemName
        //{ get { return txtItemDesc.Text; } set { txtItemDesc.Text = value; } }
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

            if (txtRemainQty.Decimal < txtQty.Decimal)
            {
                MessageDialog.ShowInformation(this, "Information", new Message(TKPMessages.eValidate.VLM0214.ToString()).MessageDescription);
                return;
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


            //CtrlUtil.SpreadSetColumnsLocked(shtView, true, (int)eColumns.SHORT_NAME);
            //CtrlUtil.SpreadSetColumnsLocked(shtView, false, (int)eColumns.Shipment);
        }

        private void fpView_ButtonClicked(object sender, EditorNotifyEventArgs e)
        {
            //if ((int)eColumns.EDIT_FLAG == e.Column)
            //{
            //    if (Convert.ToBoolean(shtView.Cells[shtView.ActiveRowIndex, (int)eColumns.EDIT_FLAG].Value) == true)
            //    {
            //        shtView.Cells[shtView.ActiveRowIndex, (int)eColumns.ONHAND_QTY].Value = shtView.Cells[shtView.ActiveRowIndex, (int)eColumns.ONHAND_QTY].Value;
            //    }
            //    else
            //        shtView.Cells[shtView.ActiveRowIndex, (int)eColumns.ONHAND_QTY].Value = null;
            //}
            if (shtView.Cells[e.Row, e.Column].Locked)
            {
                //shtView.Cells[e.Row, e.Column].Value = false;
            }
            else if ((int)eColumns.CHECK_FLAG == e.Column && !shtView.Cells[e.Row, e.Column].Locked)
            {
                string pack_no = shtView.GetValue(e.Row, (int)eColumns.PACK_NO).ToString();
                //bool CheckValue = Convert.ToBoolean(shtView.Cells[e.Row, (int)eColumns.EDIT_FLAG].Value);

                //for (int i = 0; i < shtView.RowCount; i++)
                //{
                //    if (pack_no == shtView.GetValue(i, (int)eColumns.PACK_NO).ToString())
                //    {
                //        shtView.Cells[i, (int)eColumns.EDIT_FLAG].Value = CheckValue;
                //    }
                //}

                bool isChecked = Convert.ToBoolean(shtView.Cells[e.Row, (int)eColumns.CHECK_FLAG].Value);
                DataRow[] rows = m_Data.Select(ActualOnhandViewDTO.eColumns.PACK_NO.ToString() + "='" + pack_no + "'");

                foreach (DataRow dr in rows)
                {
                    if (isChecked)
                    {
                        dr[CONST_COLUMN_NAME_CHECK_FLAG] = 1;
                    }
                    else
                    {
                        dr[CONST_COLUMN_NAME_CHECK_FLAG] = 0;
                    }
                }

                m_Data.AcceptChanges();

                this.shtView.DataSource = m_Data;
            }


            CalTotatValue();

        }



        #endregion


        private void fpView_Change(object sender, ChangeEventArgs e)
        {
            //return;
            //if (Convert.ToInt32(shtView.Cells[shtView.ActiveRowIndex, (int)eColumns.ONHAND_QTY].Value) > Convert.ToInt32(shtView.Cells[shtView.ActiveRowIndex, (int)eColumns.EXTERNAL_LOT_NO].Value))
            //{
            //    MessageDialog.ShowBusiness(this,
            //        Message.LoadMessage(TKPMessages.eValidate.VLM0104.ToString()).MessageDescription);
            //    shtView.Cells[shtView.ActiveRowIndex, (int)eColumns.ONHAND_QTY].Value = shtView.Cells[shtView.ActiveRowIndex, (int)eColumns.EXTERNAL_LOT_NO].Value;
            //    shtView.Cells[shtView.ActiveRowIndex, (int)eColumns.EDIT_FLAG].Value = true;
            //    return;
            //}

            //if (shtView.Cells[shtView.ActiveRowIndex, (int)eColumns.ONHAND_QTY].Value != null)
            //    shtView.Cells[shtView.ActiveRowIndex, (int)eColumns.EDIT_FLAG].Value = true;
            //else
            //    shtView.Cells[shtView.ActiveRowIndex, (int)eColumns.EDIT_FLAG].Value = false;

        }


        private void btnItemNo_Click(object sender, EventArgs e)
        {
            //if (chkFilterItem.Checked && !"".Equals(txtCustomer.Text.Trim()))
            //{
            //    txtItemNo.CustomerCode = txtCustomer.Text;
            //}
            //else
            //{
            //    txtItemNo.CustomerCode = "";
            //}
        }

        private void txtItemNo_KeyPressResult(object sender, bool isFound, NZString ItemCD)
        {
            if (!isFound)
            {
                //this.txtItemNo.Text = "";
                //this.txtItemDesc.Text = "";

                return;
            }

        }

        #region Private Method
        private void AutoCheckFromMainScreen()
        {
            if (shtPreviousLot == null || shtPreviousLot.RowCount <= 0 || shtView.RowCount <= 0) return;

            for (int i = 0; i < shtPreviousLot.RowCount; i++)
            {
                string pOrderDetailNo = Convert.ToString(shtPreviousLot.GetValue(i, (int)eColPreviousLot.REF_SLIP_NO));
                string pItemCd = Convert.ToString(shtPreviousLot.GetValue(i, (int)eColPreviousLot.ITEM_CD));
                string pPackNo = Convert.ToString(shtPreviousLot.GetValue(i, (int)eColPreviousLot.PACK_NO));
                string pLotNo = Convert.ToString(shtPreviousLot.GetValue(i, (int)eColPreviousLot.LOT_NO));

                if (pItemCd != ItemCd) continue;

                for (int j = 0; j < shtView.RowCount; j++)
                {
                    if (Convert.ToString(shtView.GetValue(j, (int)eColumns.PACK_NO)) == pPackNo
                        && Convert.ToString(shtView.GetValue(j, (int)eColumns.LOT_NO)) == pLotNo)
                    {
                        if (OrderDetailNo.StrongValue != pOrderDetailNo)
                        {
                            shtView.Rows[j].BackColor = Color.DarkSlateGray;
                            CtrlUtil.SpreadSetCellLocked(shtView, true, j, (int)eColumns.CHECK_FLAG);
                        }
                        else shtView.Cells[j, (int)eColumns.CHECK_FLAG].Value = true;
                        break;
                    }
                }
            }
        }
        private void CalTotatValue()
        {
            decimal TotalQTY = 0;
            for (int i = 0; i < shtView.RowCount; i++)
            {
                if (Convert.ToBoolean(shtView.GetValue(i, (int)eColumns.CHECK_FLAG)))
                    TotalQTY += Convert.ToDecimal(shtView.GetValue(i, (int)eColumns.ONHAND_QTY));
            }
            txtQty.Decimal = TotalQTY;
        }
        #endregion

        private void txtLotNo_TextChanged(object sender, EventArgs e)
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


    }
}
