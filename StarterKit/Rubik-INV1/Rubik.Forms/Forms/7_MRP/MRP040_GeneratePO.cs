
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
using Rubik.Data;
using FarPoint.Win.Spread;
using SystemMaintenance;
using System.Data;
using Rubik.Forms.FindDialog;
using SystemMaintenance.BIZ;

namespace Rubik.MRP {
    //[Screen("MRP040", "Generate PO", eShowAction.Normal, eScreenType.Screen, "Generate PO")]
    public class MRP040_GeneratePO : SystemMaintenance.Forms.CustomizeBaseForm {

        private Color m_colorUrgent = Color.OrangeRed;  //0 = urgent to generate
        private Color m_colorSuggest = Color.Gold;
        private EVOIntegerTextBox txtPOInterval;
        private EVOLabel evoLabel7;
        private EVOLabel evoLabel8;
        public ToolStrip tsControl;
        public ToolStripButton tsbGeneratePO;
        public ToolStripSeparator tlsSeperator1;
        public ToolStripButton tsbIssuePO;
        public ToolStripSeparator tlsSeperator2;
        public ToolStripButton tsbExit;
        private EVOLabel evoLabel9;
        private EVOLabel evoLabel10;
        private EVOLabel evoLabel11;
        private EVOLabel evoLabel12;
        private EVOLabel evoLabel13;
        private EVOLabel evoLabel14;      //1 = suggest to generate
        private Color m_colorNonUrgent = Color.LightGreen;  //2 = not urgent

        #region Enum

        public enum eScreenMode {
            View,
            Idle,
            Add,
            Edit,
        }

        private enum eDetail 
        {
            CRT_BY,
            CRT_DATE,
            CRT_MACHINE,
            UPD_BY,
            UPD_DATE,
            UPD_MACHINE,
            IS_ACTIVE,                     
            PO_LINE,
            ITEM_CD,
            ITEM_DESC,
            REQ_DATE,
            PO_DUE_DATE,
            ISSUE_PO_DATE,
            CURRENCY,
            UNIT_PRICE,
            PO_QTY,
            UNIT,
            AMOUNT,

            DELIVERY_TO,
            DELIVERY_TO_NAME,
            DELIVERY_TO_ADDRESS,            
            VAT_TYPE,
            VAT_RATE,
            TERM_OF_PAYMENT,
            IS_EXPORT,
            STATUS,
            REMARK,            
            RECEIVE_QTY,
            BACK_ORDER_QTY,
            LAST_RECEIVE_ID,
            LAST_RECEIVE_DATE,
            PO_GROUP,
            PO_NO,
            PO_TYPE,
            PO_DATE,
            SUPPLIER_CD,
            SUPPLIER_NAME,
            ADDRESS,   
            RECORD_STATUS
        }

        #endregion

        #region Construction

        public MRP040_GeneratePO() 
        {
            this.InitializeComponent();

            this.WindowState = FormWindowState.Maximized;
            InitialSpread();
            InitialControl();
            SetScreenMode(eScreenMode.Idle);
        }

        #endregion

        #region General

        private void SetScreenMode(eScreenMode eMode) 
        {
            switch (eMode) 
            {
                case eScreenMode.Idle:
                    CtrlUtil.ClearControlData(this.Controls);
                    ClearSpread();
                    InitialData();

                    break;
                case eScreenMode.View:                    
                    CtrlUtil.SpreadSetColumnsLocked(shtViewHeader, false, (int)eDetail.IS_ACTIVE);
                    CtrlUtil.SpreadSetColumnsLocked(shtViewHeader, false, (int)eDetail.PO_QTY);
                    CtrlUtil.SpreadSetColumnsLocked(shtViewHeader, false, (int)eDetail.UNIT_PRICE); 
                    break;
            }
        }

        private void InitialControl() 
        {
            dtpStartDate.Format = Common.CurrentUserInfomation.DateFormatString;
            dtpEndDate.Format = Common.CurrentUserInfomation.DateFormatString;

            dtpStartDate.KeyPress += CtrlUtil.SetNextControl;
            dtpEndDate.KeyPress += CtrlUtil.SetNextControl;
            txtItemCodeFrom.KeyPress += CtrlUtil.SetNextControl;
            btnSearchItemFrom.KeyPress += CtrlUtil.SetNextControl;
            txtItemCodeTo.KeyPress += CtrlUtil.SetNextControl;
            btnSearchItemTo.KeyPress += CtrlUtil.SetNextControl;
            txtLocationFrom.KeyPress += CtrlUtil.SetNextControl;
            btnSearchLocationFrom.KeyPress += CtrlUtil.SetNextControl;
            txtLocationTo.KeyPress += CtrlUtil.SetNextControl;
            btnSearchLocationTo.KeyPress += CtrlUtil.SetNextControl;
            txtPOInterval.KeyPress += CtrlUtil.SetNextControl;           
        }        
        private void InitialSpread() 
        {
            shtViewHeader.ActiveSkin = Common.ACTIVE_SKIN;            

            CtrlUtil.MappingDataFieldWithEnum(shtViewHeader, typeof(eDetail));

            shtViewHeader.Columns[(int)eDetail.CRT_BY].Visible = false;
            shtViewHeader.Columns[(int)eDetail.CRT_DATE].Visible = false;
            shtViewHeader.Columns[(int)eDetail.CRT_MACHINE].Visible = false;
            shtViewHeader.Columns[(int)eDetail.ADDRESS].Visible = false;
            //shtViewHeader.Columns[(int)eDetail.CURRENCY].Visible = false;
            //shtViewHeader.Columns[(int)eDetail.DELIVERY_TO].Visible = false;
            shtViewHeader.Columns[(int)eDetail.DELIVERY_TO_ADDRESS].Visible = false;
            shtViewHeader.Columns[(int)eDetail.DELIVERY_TO_NAME].Visible = false;
            shtViewHeader.Columns[(int)eDetail.IS_EXPORT].Visible = false;
            shtViewHeader.Columns[(int)eDetail.PO_NO].Visible = false;
            shtViewHeader.Columns[(int)eDetail.PO_TYPE].Visible = false;
            shtViewHeader.Columns[(int)eDetail.VAT_TYPE].Visible = false;
            shtViewHeader.Columns[(int)eDetail.REMARK].Visible = false;
            shtViewHeader.Columns[(int)eDetail.STATUS].Visible = false;
            shtViewHeader.Columns[(int)eDetail.TERM_OF_PAYMENT].Visible = false;
            shtViewHeader.Columns[(int)eDetail.UPD_BY].Visible = false;
            shtViewHeader.Columns[(int)eDetail.UPD_DATE].Visible = false;
            shtViewHeader.Columns[(int)eDetail.UPD_MACHINE].Visible = false;
            shtViewHeader.Columns[(int)eDetail.RECORD_STATUS].Visible = false;
            shtViewHeader.Columns[(int)eDetail.LAST_RECEIVE_DATE].Visible = false;
            shtViewHeader.Columns[(int)eDetail.LAST_RECEIVE_ID].Visible = false;
            shtViewHeader.Columns[(int)eDetail.RECEIVE_QTY].Visible = false;
            shtViewHeader.Columns[(int)eDetail.BACK_ORDER_QTY].Visible = false;
            shtViewHeader.Columns[(int)eDetail.SUPPLIER_NAME].Visible = false;
            shtViewHeader.Columns[(int)eDetail.PO_GROUP].Visible = false;
            shtViewHeader.Columns[(int)eDetail.DELIVERY_TO].Visible = false;
            shtViewHeader.Columns[(int)eDetail.VAT_RATE].Visible = false;
            shtViewHeader.Columns[(int)eDetail.PO_LINE].Visible = false;
            
            shtViewHeader.Columns[(int)eDetail.PO_DATE].CellType = CtrlUtil.CreateDateTimeCellType(Common.CurrentUserInfomation.DateFormatString);
            shtViewHeader.Columns[(int)eDetail.PO_DATE].HorizontalAlignment = CellHorizontalAlignment.Center;
            shtViewHeader.Columns[(int)eDetail.PO_DUE_DATE].CellType = CtrlUtil.CreateDateTimeCellType(Common.CurrentUserInfomation.DateFormatString);
            shtViewHeader.Columns[(int)eDetail.PO_DUE_DATE].HorizontalAlignment = CellHorizontalAlignment.Center;
            shtViewHeader.Columns[(int)eDetail.REQ_DATE].CellType = CtrlUtil.CreateDateTimeCellType(Common.CurrentUserInfomation.DateFormatString);
            shtViewHeader.Columns[(int)eDetail.REQ_DATE].HorizontalAlignment = CellHorizontalAlignment.Center;
            shtViewHeader.Columns[(int)eDetail.ISSUE_PO_DATE].CellType = CtrlUtil.CreateDateTimeCellType(Common.CurrentUserInfomation.DateFormatString);
            shtViewHeader.Columns[(int)eDetail.ISSUE_PO_DATE].HorizontalAlignment = CellHorizontalAlignment.Center;
            shtViewHeader.Columns[(int)eDetail.IS_ACTIVE].CellType = CtrlUtil.CreateCheckboxCellType("", "");

            LookupDataBIZ biz = new LookupDataBIZ();
            LookupData umClassLookupData = biz.LoadLookupClassType(DataDefine.UM_CLS.ToNZString());
            shtViewHeader.Columns[(int)eDetail.UNIT].CellType = CtrlUtil.CreateReadOnlyPairCellType(umClassLookupData);

            LookupData postatusClassLookupData = biz.LoadLookupClassType(DataDefine.PO_STATUS.ToNZString());
            shtViewHeader.Columns[(int)eDetail.STATUS].CellType = CtrlUtil.CreateReadOnlyPairCellType(postatusClassLookupData);

            LookupData currClassLookupData = biz.LoadLookupClassType(DataDefine.CURRENCY.ToNZString());
            shtViewHeader.Columns[(int)eDetail.CURRENCY].CellType = CtrlUtil.CreateReadOnlyPairCellType(currClassLookupData);

            LookupData potypeClassLookupData = biz.LoadLookupClassType(DataDefine.PO_TYPE.ToNZString());
            shtViewHeader.Columns[(int)eDetail.PO_TYPE].CellType = CtrlUtil.CreateReadOnlyPairCellType(potypeClassLookupData);

            LookupData payClassLookupData = biz.LoadLookupClassType(DataDefine.TERM_OF_PAYMENT.ToNZString());
            shtViewHeader.Columns[(int)eDetail.TERM_OF_PAYMENT].CellType = CtrlUtil.CreateReadOnlyPairCellType(payClassLookupData);

            LookupData vatClassLookupData = biz.LoadLookupClassType(DataDefine.VAT_TYPE.ToNZString());
            shtViewHeader.Columns[(int)eDetail.VAT_TYPE].CellType = CtrlUtil.CreateReadOnlyPairCellType(vatClassLookupData);

            LookupData locationLookupData = biz.LoadLookupLocation();
            shtViewHeader.Columns[(int)eDetail.SUPPLIER_CD].CellType = CtrlUtil.CreateReadOnlyPairCellType(locationLookupData);
                        
            for (int i = 0; i < shtViewHeader.ColumnCount; i++) 
            {
                shtViewHeader.Columns[i].AllowAutoFilter = true;
                shtViewHeader.Columns[i].AllowAutoSort = true;
            }
        }
        private void ClearSpread() 
        {
            shtViewHeader.RowCount = 0;
        }
        private Color SelectColor(NZString strStatus) {
            Color m_Color = m_colorNonUrgent;
            switch (strStatus) {
                case "0":
                    m_Color = m_colorUrgent;
                    break;
                case "1":
                    m_Color = m_colorSuggest;
                    break;
                case "2":
                    m_Color = m_colorNonUrgent;
                    break;
            }
            return m_Color;
        }
        private void SetBackgroundColor() 
        {
            for (int i = 0; i < shtViewHeader.RowCount; i++) 
            {
                NZString strStatus = new NZString(null, shtViewHeader.GetValue(i, (int)eDetail.RECORD_STATUS));
                shtViewHeader.Rows[i].BackColor = SelectColor(strStatus);

                //shtViewHeader.Columns[(int)eDetail.AMOUNT].Formula = shtViewHeader.Columns[(int)eDetail.UNIT_PRICE].ToString() + "*" + shtViewHeader.Columns[(int)eDetail.UNIT_PRICE].ToString();
            }
        }

        private void InitialData() {
            SysConfigBIZ biz = new SysConfigBIZ();
            SysConfigDTO dto = biz.LoadByPK((NZString)"PO_INTERVAL", (NZString)"MRP040");
            txtPOInterval.Text = dto.CHAR_DATA;
        }
        private DataTable SearchData() 
        {
            PurchaseOrderBIZ biz = new PurchaseOrderBIZ();
            NZDateTime dtmDateFrom = new NZDateTime(null, dtpStartDate.Value);
            NZDateTime dtmDateTo = new NZDateTime(null, dtpEndDate.Value);
            NZString strItemFrom = new NZString(null, txtItemCodeFrom.Text.Trim());
            NZString strItemTo = new NZString(null, txtItemCodeTo.Text.Trim());
            NZString strLocFrom = new NZString(null, txtLocationFrom.Text.Trim());
            NZString strLocTo = new NZString(null, txtLocationTo.Text.Trim());
            NZInt iInterval = new NZInt(null, txtPOInterval.Text.Trim());
            DataTable dt = biz.LoadGeneratePO(dtmDateFrom, dtmDateTo, strItemFrom, strItemTo, strLocFrom, strLocTo, iInterval);
            return dt;
        }
        private bool LoadData() 
        {
            ClearSpread();

            DataTable dt = SearchData();
            if (dt == null || dt.Rows.Count == 0) 
            {
                ErrorItem errorItem = new ErrorItem(null, TKPMessages.eValidate.VLM0156.ToString());
                throw new BusinessException(errorItem); 
            }
            shtViewHeader.DataSource = dt;
            SetBackgroundColor();
            return true;
        }
        private void SaveData() 
        {
            //Create PO Header & Detail

            RunningNumberBIZ bizRunning = new RunningNumberBIZ();            

            List<PurchaseOrderHDTO> dtoHeader = new List<PurchaseOrderHDTO>();
            List<PurchaseOrderDDTO> dtoDetail = new List<PurchaseOrderDDTO>();
            Dictionary<string, string> dictPOHeader = new Dictionary<string, string>();
            int iLine = 0;
            for (int iRow = 0; iRow < shtViewHeader.RowCount; iRow++) 
            {
                NZBoolean bSelect = new NZBoolean(null,shtViewHeader.GetValue(iRow,(int)eDetail.IS_ACTIVE));
                
                if((!bSelect.IsNull) && (bSelect.StrongValue))
                {   
                    NZString strGroupPONo = new NZString(null, shtViewHeader.GetValue(iRow, (int)eDetail.PO_GROUP));

                    //เช็คว่ามี Group นั้นหรือยัง ถ้ามีจะไม่สรา้ง Header ใหม่
                    if (!dictPOHeader.ContainsKey(strGroupPONo)) 
                    {
                        iLine = 0;
                        NZString strPONo = bizRunning.GetCompleteRunningNo(new NZString(null, "PO_NO"), new NZString(null, "TB_PURCHASE_ORDER_H_TR"));
                        dictPOHeader.Add(strGroupPONo,strPONo);
                        PurchaseOrderHDTO dto = CreateHeader(iRow, strPONo);
                        if (dto != null)
                            dtoHeader.Add(dto);
                    }
    
                    //Create Detail
                    NZString strPONoDetail = null;
                    if (dictPOHeader.ContainsKey(strGroupPONo))
                        strPONoDetail = new NZString(null, dictPOHeader[strGroupPONo]);

                    iLine = iLine + 1;
                    PurchaseOrderDDTO dtoD = CreateDetail(iRow, iLine, strPONoDetail);
                    if (dtoD != null)
                        dtoDetail.Add(dtoD);
                }                
            }

            //Save data
            PurchaseOrderBIZ bizPO = new PurchaseOrderBIZ();
            bizPO.SaveGeneratePO(dtoHeader, dtoDetail);

        }

        private PurchaseOrderHDTO CreateHeader(int iRow, NZString strPO_NO) 
        {
            if (strPO_NO.IsNull || string.Empty.Equals(strPO_NO.StrongValue))
                return null;

            PurchaseOrderHDTO dto = new PurchaseOrderHDTO();
            dto.CRT_BY = Common.CurrentUserInfomation.UserCD;
            dto.CRT_DATE = new NZDateTime(null, DateTime.Now);
            dto.CRT_MACHINE = Common.CurrentUserInfomation.Machine;
            dto.UPD_BY = Common.CurrentUserInfomation.UserCD;
            dto.UPD_DATE = new NZDateTime(null, DateTime.Now);
            dto.UPD_MACHINE = Common.CurrentUserInfomation.Machine;
            dto.IS_ACTIVE = new NZBoolean(null, true);
            dto.PO_NO = strPO_NO;
            dto.PO_TYPE = new NZString(null, shtViewHeader.GetValue(iRow, (int)eDetail.PO_TYPE));
            dto.PO_DATE = new NZDateTime(null, shtViewHeader.GetValue(iRow, (int)eDetail.PO_DATE));
            dto.SUPPLIER_CD = new NZString(null, shtViewHeader.GetValue(iRow, (int)eDetail.SUPPLIER_CD));
            dto.SUPPLIER_NAME = new NZString(null, shtViewHeader.GetValue(iRow, (int)eDetail.SUPPLIER_NAME));
            dto.ADDRESS = new NZString(null, shtViewHeader.GetValue(iRow, (int)eDetail.ADDRESS));
            dto.DELIVERY_TO = new NZString(null, shtViewHeader.GetValue(iRow, (int)eDetail.DELIVERY_TO));
            dto.CURRENCY = new NZString(null, shtViewHeader.GetValue(iRow, (int)eDetail.CURRENCY));
            dto.VAT_TYPE = new NZString(null, shtViewHeader.GetValue(iRow, (int)eDetail.VAT_TYPE));
            dto.VAT_RATE = new NZDecimal(null, shtViewHeader.GetValue(iRow, (int)eDetail.VAT_RATE));
            dto.TERM_OF_PAYMENT = new NZString(null, shtViewHeader.GetValue(iRow, (int)eDetail.TERM_OF_PAYMENT));
            dto.IS_EXPORT = new NZBoolean(null, shtViewHeader.GetValue(iRow, (int)eDetail.IS_EXPORT));
            dto.STATUS = new NZString(null, shtViewHeader.GetValue(iRow, (int)eDetail.STATUS));
            dto.REMARK = new NZString(null, shtViewHeader.GetValue(iRow, (int)eDetail.REMARK));
            return dto;
        }
        private PurchaseOrderDDTO CreateDetail(int iRow, int iLine,NZString strPO_NO) 
        {
            if (strPO_NO.IsNull || string.Empty.Equals(strPO_NO.StrongValue))
                return null;

            PurchaseOrderDDTO dtoD = new PurchaseOrderDDTO();
            dtoD.CRT_BY = Common.CurrentUserInfomation.UserCD;
            dtoD.CRT_DATE = new NZDateTime(null, DateTime.Now);
            dtoD.CRT_MACHINE = Common.CurrentUserInfomation.Machine;
            dtoD.UPD_BY = Common.CurrentUserInfomation.UserCD;
            dtoD.UPD_DATE = new NZDateTime(null, DateTime.Now);
            dtoD.UPD_MACHINE = Common.CurrentUserInfomation.Machine;
            dtoD.IS_ACTIVE = new NZBoolean(null, true);
            dtoD.PO_NO = strPO_NO;
            dtoD.PO_LINE = new NZDecimal(null, iLine);
            dtoD.ITEM_CD = new NZString(null, shtViewHeader.GetValue(iRow, (int)eDetail.ITEM_CD));
            dtoD.ITEM_DESC = new NZString(null, shtViewHeader.GetValue(iRow, (int)eDetail.ITEM_DESC));
            dtoD.DUE_DATE = new NZDateTime(null, shtViewHeader.GetValue(iRow, (int)eDetail.PO_DUE_DATE));
            dtoD.UNIT_PRICE = new NZDecimal(null, shtViewHeader.GetValue(iRow, (int)eDetail.UNIT_PRICE));
            dtoD.PO_QTY = new NZDecimal(null, shtViewHeader.GetValue(iRow, (int)eDetail.PO_QTY));
            dtoD.UNIT = new NZString(null, shtViewHeader.GetValue(iRow, (int)eDetail.UNIT));
            dtoD.AMOUNT = new NZDecimal(null, shtViewHeader.GetValue(iRow, (int)eDetail.AMOUNT));
            dtoD.RECEIVE_QTY = null;
            dtoD.BACK_ORDER_QTY = null;
            dtoD.LAST_RECEIVE_ID = null;
            dtoD.LAST_RECEIVE_DATE = null;
            dtoD.STATUS = new NZString(null, "00");
            return dtoD;
        }

        private string SearchItem() {
            eItemType[] eType = { eItemType.All };
            ItemFindDialog dialog = new ItemFindDialog(eSqlOperator.Equal, eType);
            dialog.ShowDialog(this);
            if (dialog.IsSelected)
                return dialog.SelectedItem.ITEM_CD.ToString();

            return string.Empty;
        }

        private string SearchLocation() {
            NZString [] LocationType = new NZString[] {(NZString)DataDefine.Convert2ClassCode(DataDefine.eLOCATION_CLS.Vendor)};
            LocationFindDialog dialogLocation = new LocationFindDialog(LocationType);

            dialogLocation.ShowDialog(this);
            if (dialogLocation.IsSelected) {
                return dialogLocation.SelectedItem.LOC_CD.ToString();
            }

            return string.Empty;
        }

        #endregion

        #region Control

        private EVODateTextBoxWithCalendar dtpStartDate;
        private EVOLabel stdReceiveDate;
        private EVODateTextBoxWithCalendar dtpEndDate;
        private EVOLabel evoLabel4;
        private EVOLabel evoLabel1;
        private EVOLabel evoLabel2;
        private EVOButton btnSearchItemFrom;
        private EVOTextBox txtItemCodeFrom;
        private EVOButton btnSearchItemTo;
        private EVOTextBox txtItemCodeTo;
        private EVOLabel evoLabel3;
        private EVOLabel evoLabel6;
        private EVOButton btnSearchLocationTo;
        private EVOTextBox txtLocationTo;
        private EVOButton btnSearchLocationFrom;
        private EVOTextBox txtLocationFrom;
        private FpSpread fpView;
        private SheetView shtViewHeader;
        private EVOLabel evoLabel5;

        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MRP040_GeneratePO));
            this.evoLabel5 = new EVOFramework.Windows.Forms.EVOLabel();
            this.dtpStartDate = new EVOFramework.Windows.Forms.EVODateTextBoxWithCalendar();
            this.stdReceiveDate = new EVOFramework.Windows.Forms.EVOLabel();
            this.dtpEndDate = new EVOFramework.Windows.Forms.EVODateTextBoxWithCalendar();
            this.evoLabel4 = new EVOFramework.Windows.Forms.EVOLabel();
            this.evoLabel1 = new EVOFramework.Windows.Forms.EVOLabel();
            this.evoLabel2 = new EVOFramework.Windows.Forms.EVOLabel();
            this.btnSearchItemFrom = new EVOFramework.Windows.Forms.EVOButton();
            this.txtItemCodeFrom = new EVOFramework.Windows.Forms.EVOTextBox();
            this.btnSearchItemTo = new EVOFramework.Windows.Forms.EVOButton();
            this.txtItemCodeTo = new EVOFramework.Windows.Forms.EVOTextBox();
            this.evoLabel3 = new EVOFramework.Windows.Forms.EVOLabel();
            this.evoLabel6 = new EVOFramework.Windows.Forms.EVOLabel();
            this.btnSearchLocationTo = new EVOFramework.Windows.Forms.EVOButton();
            this.txtLocationTo = new EVOFramework.Windows.Forms.EVOTextBox();
            this.btnSearchLocationFrom = new EVOFramework.Windows.Forms.EVOButton();
            this.txtLocationFrom = new EVOFramework.Windows.Forms.EVOTextBox();
            this.fpView = new FarPoint.Win.Spread.FpSpread();
            this.shtViewHeader = new FarPoint.Win.Spread.SheetView();
            this.txtPOInterval = new EVOFramework.Windows.Forms.EVOIntegerTextBox();
            this.evoLabel7 = new EVOFramework.Windows.Forms.EVOLabel();
            this.evoLabel8 = new EVOFramework.Windows.Forms.EVOLabel();
            this.tsControl = new System.Windows.Forms.ToolStrip();
            this.tsbGeneratePO = new System.Windows.Forms.ToolStripButton();
            this.tlsSeperator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbIssuePO = new System.Windows.Forms.ToolStripButton();
            this.tlsSeperator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbExit = new System.Windows.Forms.ToolStripButton();
            this.evoLabel9 = new EVOFramework.Windows.Forms.EVOLabel();
            this.evoLabel10 = new EVOFramework.Windows.Forms.EVOLabel();
            this.evoLabel11 = new EVOFramework.Windows.Forms.EVOLabel();
            this.evoLabel12 = new EVOFramework.Windows.Forms.EVOLabel();
            this.evoLabel13 = new EVOFramework.Windows.Forms.EVOLabel();
            this.evoLabel14 = new EVOFramework.Windows.Forms.EVOLabel();
            ((System.ComponentModel.ISupportInitialize)(this.fpView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.shtViewHeader)).BeginInit();
            this.tsControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // evoLabel5
            // 
            this.evoLabel5.AppearanceName = "Title";
            this.evoLabel5.AutoSize = true;
            this.evoLabel5.ControlID = "";
            this.evoLabel5.Font = new System.Drawing.Font("Tahoma", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.evoLabel5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.evoLabel5.Location = new System.Drawing.Point(3, 30);
            this.evoLabel5.Name = "evoLabel5";
            this.evoLabel5.PathString = null;
            this.evoLabel5.PathValue = "Generate PO";
            this.evoLabel5.Size = new System.Drawing.Size(219, 39);
            this.evoLabel5.TabIndex = 10004;
            this.evoLabel5.Text = "Generate PO";
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.AppearanceName = "";
            this.dtpStartDate.AppearanceReadOnlyName = "";
            this.dtpStartDate.BackColor = System.Drawing.Color.Transparent;
            this.dtpStartDate.ControlID = "";
            this.dtpStartDate.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.dtpStartDate.Format = "dd/MM/yyyy";
            this.dtpStartDate.Location = new System.Drawing.Point(134, 74);
            this.dtpStartDate.MinimumSize = new System.Drawing.Size(100, 0);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.NZValue = ((EVOFramework.NZDateTime)(resources.GetObject("dtpStartDate.NZValue")));
            this.dtpStartDate.PathString = null;
            this.dtpStartDate.PathValue = ((object)(resources.GetObject("dtpStartDate.PathValue")));
            this.dtpStartDate.ReadOnly = false;
            this.dtpStartDate.ShowButton = true;
            this.dtpStartDate.Size = new System.Drawing.Size(200, 27);
            this.dtpStartDate.TabIndex = 1;
            this.dtpStartDate.Value = null;
            // 
            // stdReceiveDate
            // 
            this.stdReceiveDate.AppearanceName = "";
            this.stdReceiveDate.AutoSize = true;
            this.stdReceiveDate.ControlID = "";
            this.stdReceiveDate.Font = new System.Drawing.Font("Tahoma", 12F);
            this.stdReceiveDate.Location = new System.Drawing.Point(26, 77);
            this.stdReceiveDate.Name = "stdReceiveDate";
            this.stdReceiveDate.PathString = null;
            this.stdReceiveDate.PathValue = "Date Period";
            this.stdReceiveDate.Size = new System.Drawing.Size(91, 19);
            this.stdReceiveDate.TabIndex = 0;
            this.stdReceiveDate.Text = "Date Period";
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.AppearanceName = "";
            this.dtpEndDate.AppearanceReadOnlyName = "";
            this.dtpEndDate.BackColor = System.Drawing.Color.Transparent;
            this.dtpEndDate.ControlID = "";
            this.dtpEndDate.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.dtpEndDate.Format = "dd/MM/yyyy";
            this.dtpEndDate.Location = new System.Drawing.Point(353, 74);
            this.dtpEndDate.MinimumSize = new System.Drawing.Size(100, 0);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.NZValue = ((EVOFramework.NZDateTime)(resources.GetObject("dtpEndDate.NZValue")));
            this.dtpEndDate.PathString = null;
            this.dtpEndDate.PathValue = ((object)(resources.GetObject("dtpEndDate.PathValue")));
            this.dtpEndDate.ReadOnly = false;
            this.dtpEndDate.ShowButton = true;
            this.dtpEndDate.Size = new System.Drawing.Size(200, 27);
            this.dtpEndDate.TabIndex = 2;
            this.dtpEndDate.Value = null;
            // 
            // evoLabel4
            // 
            this.evoLabel4.AppearanceName = "";
            this.evoLabel4.AutoSize = true;
            this.evoLabel4.ControlID = "";
            this.evoLabel4.Font = new System.Drawing.Font("Tahoma", 12F);
            this.evoLabel4.Location = new System.Drawing.Point(336, 77);
            this.evoLabel4.Name = "evoLabel4";
            this.evoLabel4.PathString = null;
            this.evoLabel4.PathValue = "-";
            this.evoLabel4.Size = new System.Drawing.Size(15, 19);
            this.evoLabel4.TabIndex = 0;
            this.evoLabel4.Text = "-";
            // 
            // evoLabel1
            // 
            this.evoLabel1.AppearanceName = "";
            this.evoLabel1.AutoSize = true;
            this.evoLabel1.ControlID = "";
            this.evoLabel1.Font = new System.Drawing.Font("Tahoma", 12F);
            this.evoLabel1.Location = new System.Drawing.Point(26, 113);
            this.evoLabel1.Name = "evoLabel1";
            this.evoLabel1.PathString = null;
            this.evoLabel1.PathValue = "Part No.";
            this.evoLabel1.Size = new System.Drawing.Size(67, 19);
            this.evoLabel1.TabIndex = 0;
            this.evoLabel1.Text = "Part No.";
            // 
            // evoLabel2
            // 
            this.evoLabel2.AppearanceName = "";
            this.evoLabel2.AutoSize = true;
            this.evoLabel2.ControlID = "";
            this.evoLabel2.Font = new System.Drawing.Font("Tahoma", 12F);
            this.evoLabel2.Location = new System.Drawing.Point(27, 144);
            this.evoLabel2.Name = "evoLabel2";
            this.evoLabel2.PathString = null;
            this.evoLabel2.PathValue = "Supplier LOC";
            this.evoLabel2.Size = new System.Drawing.Size(102, 19);
            this.evoLabel2.TabIndex = 0;
            this.evoLabel2.Text = "Supplier LOC";
            // 
            // btnSearchItemFrom
            // 
            this.btnSearchItemFrom.AppearanceName = "";
            this.btnSearchItemFrom.ControlID = null;
            this.btnSearchItemFrom.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnSearchItemFrom.Location = new System.Drawing.Point(519, 108);
            this.btnSearchItemFrom.Name = "btnSearchItemFrom";
            this.btnSearchItemFrom.Size = new System.Drawing.Size(34, 28);
            this.btnSearchItemFrom.TabIndex = 5;
            this.btnSearchItemFrom.Text = "...";
            this.btnSearchItemFrom.UseVisualStyleBackColor = true;
            this.btnSearchItemFrom.Click += new System.EventHandler(this.btnSearchItemFrom_Click);
            // 
            // txtItemCodeFrom
            // 
            this.txtItemCodeFrom.AppearanceName = "";
            this.txtItemCodeFrom.AppearanceReadOnlyName = "";
            this.txtItemCodeFrom.ControlID = "";
            this.txtItemCodeFrom.DisableRestrictChar = false;
            this.txtItemCodeFrom.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtItemCodeFrom.HelpButton = null;
            this.txtItemCodeFrom.Location = new System.Drawing.Point(134, 108);
            this.txtItemCodeFrom.MaxLength = 50;
            this.txtItemCodeFrom.Name = "txtItemCodeFrom";
            this.txtItemCodeFrom.PathString = null;
            this.txtItemCodeFrom.PathValue = "";
            this.txtItemCodeFrom.Size = new System.Drawing.Size(384, 27);
            this.txtItemCodeFrom.TabIndex = 4;
            // 
            // btnSearchItemTo
            // 
            this.btnSearchItemTo.AppearanceName = "";
            this.btnSearchItemTo.ControlID = null;
            this.btnSearchItemTo.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnSearchItemTo.Location = new System.Drawing.Point(967, 107);
            this.btnSearchItemTo.Name = "btnSearchItemTo";
            this.btnSearchItemTo.Size = new System.Drawing.Size(33, 28);
            this.btnSearchItemTo.TabIndex = 7;
            this.btnSearchItemTo.Text = "...";
            this.btnSearchItemTo.UseVisualStyleBackColor = true;
            this.btnSearchItemTo.Click += new System.EventHandler(this.btnSearchItemTo_Click);
            // 
            // txtItemCodeTo
            // 
            this.txtItemCodeTo.AppearanceName = "";
            this.txtItemCodeTo.AppearanceReadOnlyName = "";
            this.txtItemCodeTo.ControlID = "";
            this.txtItemCodeTo.DisableRestrictChar = false;
            this.txtItemCodeTo.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtItemCodeTo.HelpButton = null;
            this.txtItemCodeTo.Location = new System.Drawing.Point(586, 108);
            this.txtItemCodeTo.MaxLength = 50;
            this.txtItemCodeTo.Name = "txtItemCodeTo";
            this.txtItemCodeTo.PathString = null;
            this.txtItemCodeTo.PathValue = "";
            this.txtItemCodeTo.Size = new System.Drawing.Size(379, 27);
            this.txtItemCodeTo.TabIndex = 6;
            // 
            // evoLabel3
            // 
            this.evoLabel3.AppearanceName = "";
            this.evoLabel3.AutoSize = true;
            this.evoLabel3.ControlID = "";
            this.evoLabel3.Font = new System.Drawing.Font("Tahoma", 12F);
            this.evoLabel3.Location = new System.Drawing.Point(565, 113);
            this.evoLabel3.Name = "evoLabel3";
            this.evoLabel3.PathString = null;
            this.evoLabel3.PathValue = "-";
            this.evoLabel3.Size = new System.Drawing.Size(15, 19);
            this.evoLabel3.TabIndex = 0;
            this.evoLabel3.Text = "-";
            // 
            // evoLabel6
            // 
            this.evoLabel6.AppearanceName = "";
            this.evoLabel6.AutoSize = true;
            this.evoLabel6.ControlID = "";
            this.evoLabel6.Font = new System.Drawing.Font("Tahoma", 12F);
            this.evoLabel6.Location = new System.Drawing.Point(565, 144);
            this.evoLabel6.Name = "evoLabel6";
            this.evoLabel6.PathString = null;
            this.evoLabel6.PathValue = "-";
            this.evoLabel6.Size = new System.Drawing.Size(15, 19);
            this.evoLabel6.TabIndex = 0;
            this.evoLabel6.Text = "-";
            // 
            // btnSearchLocationTo
            // 
            this.btnSearchLocationTo.AppearanceName = "";
            this.btnSearchLocationTo.ControlID = null;
            this.btnSearchLocationTo.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnSearchLocationTo.Location = new System.Drawing.Point(966, 140);
            this.btnSearchLocationTo.Name = "btnSearchLocationTo";
            this.btnSearchLocationTo.Size = new System.Drawing.Size(34, 28);
            this.btnSearchLocationTo.TabIndex = 11;
            this.btnSearchLocationTo.Text = "...";
            this.btnSearchLocationTo.UseVisualStyleBackColor = true;
            this.btnSearchLocationTo.Click += new System.EventHandler(this.btnSearchLocationTo_Click);
            // 
            // txtLocationTo
            // 
            this.txtLocationTo.AppearanceName = "";
            this.txtLocationTo.AppearanceReadOnlyName = "";
            this.txtLocationTo.ControlID = "";
            this.txtLocationTo.DisableRestrictChar = false;
            this.txtLocationTo.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtLocationTo.HelpButton = null;
            this.txtLocationTo.Location = new System.Drawing.Point(586, 141);
            this.txtLocationTo.MaxLength = 50;
            this.txtLocationTo.Name = "txtLocationTo";
            this.txtLocationTo.PathString = null;
            this.txtLocationTo.PathValue = "";
            this.txtLocationTo.Size = new System.Drawing.Size(379, 27);
            this.txtLocationTo.TabIndex = 10;
            // 
            // btnSearchLocationFrom
            // 
            this.btnSearchLocationFrom.AppearanceName = "";
            this.btnSearchLocationFrom.ControlID = null;
            this.btnSearchLocationFrom.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnSearchLocationFrom.Location = new System.Drawing.Point(519, 141);
            this.btnSearchLocationFrom.Name = "btnSearchLocationFrom";
            this.btnSearchLocationFrom.Size = new System.Drawing.Size(34, 28);
            this.btnSearchLocationFrom.TabIndex = 9;
            this.btnSearchLocationFrom.Text = "...";
            this.btnSearchLocationFrom.UseVisualStyleBackColor = true;
            this.btnSearchLocationFrom.Click += new System.EventHandler(this.btnSearchLocationFrom_Click);
            // 
            // txtLocationFrom
            // 
            this.txtLocationFrom.AppearanceName = "";
            this.txtLocationFrom.AppearanceReadOnlyName = "";
            this.txtLocationFrom.ControlID = "";
            this.txtLocationFrom.DisableRestrictChar = false;
            this.txtLocationFrom.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtLocationFrom.HelpButton = null;
            this.txtLocationFrom.Location = new System.Drawing.Point(134, 141);
            this.txtLocationFrom.MaxLength = 50;
            this.txtLocationFrom.Name = "txtLocationFrom";
            this.txtLocationFrom.PathString = null;
            this.txtLocationFrom.PathValue = "";
            this.txtLocationFrom.Size = new System.Drawing.Size(384, 27);
            this.txtLocationFrom.TabIndex = 8;
            // 
            // fpView
            // 
            this.fpView.About = "2.5.2015.2005";
            this.fpView.AccessibleDescription = "fpView, Sheet1, Row 0, Column 0, ";
            this.fpView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fpView.BackColor = System.Drawing.Color.AliceBlue;
            this.fpView.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.fpView.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpView.Location = new System.Drawing.Point(12, 177);
            this.fpView.Name = "fpView";
            this.fpView.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.fpView.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.fpView.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.shtViewHeader});
            this.fpView.Size = new System.Drawing.Size(992, 451);
            this.fpView.TabIndex = 12;
            this.fpView.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpView.EditModeOff += new System.EventHandler(this.fpView_EditModeOff);
            this.fpView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fpView_KeyDown);
            // 
            // shtViewHeader
            // 
            this.shtViewHeader.Reset();
            this.shtViewHeader.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.shtViewHeader.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.shtViewHeader.ColumnCount = 39;
            this.shtViewHeader.RowCount = 15;
            this.shtViewHeader.AutoCalculation = false;
            this.shtViewHeader.ColumnHeader.AutoText = FarPoint.Win.Spread.HeaderAutoText.Blank;
            this.shtViewHeader.ColumnHeader.Cells.Get(0, 0).Value = "Create By";
            this.shtViewHeader.ColumnHeader.Cells.Get(0, 1).Value = "Create Date";
            this.shtViewHeader.ColumnHeader.Cells.Get(0, 2).Value = "Create Machine";
            this.shtViewHeader.ColumnHeader.Cells.Get(0, 3).Value = "Update By";
            this.shtViewHeader.ColumnHeader.Cells.Get(0, 4).Value = "Update Date";
            this.shtViewHeader.ColumnHeader.Cells.Get(0, 5).Value = "Update Machine";
            this.shtViewHeader.ColumnHeader.Cells.Get(0, 6).Value = "Select";
            this.shtViewHeader.ColumnHeader.Cells.Get(0, 7).Value = "PO Line";
            this.shtViewHeader.ColumnHeader.Cells.Get(0, 8).Value = "Part No";
            this.shtViewHeader.ColumnHeader.Cells.Get(0, 9).Value = "Part Name";
            this.shtViewHeader.ColumnHeader.Cells.Get(0, 10).Value = "Request Date";
            this.shtViewHeader.ColumnHeader.Cells.Get(0, 11).Value = "PO Due Date";
            this.shtViewHeader.ColumnHeader.Cells.Get(0, 12).Value = "Issue PO Date";
            this.shtViewHeader.ColumnHeader.Cells.Get(0, 13).Value = "Currency";
            this.shtViewHeader.ColumnHeader.Cells.Get(0, 14).Value = "Unit Price";
            this.shtViewHeader.ColumnHeader.Cells.Get(0, 15).Value = "PO Qty";
            this.shtViewHeader.ColumnHeader.Cells.Get(0, 16).Value = "Unit";
            this.shtViewHeader.ColumnHeader.Cells.Get(0, 17).Value = "Amount";
            this.shtViewHeader.ColumnHeader.Cells.Get(0, 18).Value = "Delivery";
            this.shtViewHeader.ColumnHeader.Cells.Get(0, 19).Value = "Delivery To Name";
            this.shtViewHeader.ColumnHeader.Cells.Get(0, 20).Value = "Delivery To Address";
            this.shtViewHeader.ColumnHeader.Cells.Get(0, 21).Value = "Vat Type";
            this.shtViewHeader.ColumnHeader.Cells.Get(0, 22).Value = "Vat Rate";
            this.shtViewHeader.ColumnHeader.Cells.Get(0, 23).Value = "Term Of Payment";
            this.shtViewHeader.ColumnHeader.Cells.Get(0, 24).Value = "Is Export";
            this.shtViewHeader.ColumnHeader.Cells.Get(0, 25).Value = "Status";
            this.shtViewHeader.ColumnHeader.Cells.Get(0, 26).Value = "Remark";
            this.shtViewHeader.ColumnHeader.Cells.Get(0, 27).Value = "Receive Qty";
            this.shtViewHeader.ColumnHeader.Cells.Get(0, 28).Value = "Back Order Qty";
            this.shtViewHeader.ColumnHeader.Cells.Get(0, 29).Value = "Last Receive ID";
            this.shtViewHeader.ColumnHeader.Cells.Get(0, 30).Value = "Last Receive Date";
            this.shtViewHeader.ColumnHeader.Cells.Get(0, 31).Value = "PO Group";
            this.shtViewHeader.ColumnHeader.Cells.Get(0, 32).Value = "PO No.";
            this.shtViewHeader.ColumnHeader.Cells.Get(0, 33).Value = "PO Type";
            this.shtViewHeader.ColumnHeader.Cells.Get(0, 34).Value = "PO Date";
            this.shtViewHeader.ColumnHeader.Cells.Get(0, 35).Value = "Supplier Code";
            this.shtViewHeader.ColumnHeader.Cells.Get(0, 36).Value = "Supplier Name";
            this.shtViewHeader.ColumnHeader.Cells.Get(0, 37).Value = "Address";
            this.shtViewHeader.ColumnHeader.Cells.Get(0, 38).Value = "Record Status";
            this.shtViewHeader.ColumnHeader.Rows.Get(0).Height = 40F;
            this.shtViewHeader.Columns.Get(0).Label = "Create By";
            this.shtViewHeader.Columns.Get(0).Tag = "Create By";
            this.shtViewHeader.Columns.Get(0).Width = 93F;
            this.shtViewHeader.Columns.Get(1).Label = "Create Date";
            this.shtViewHeader.Columns.Get(1).Tag = "Create Date";
            this.shtViewHeader.Columns.Get(1).Width = 117F;
            this.shtViewHeader.Columns.Get(2).Label = "Create Machine";
            this.shtViewHeader.Columns.Get(2).Tag = "Create Machine";
            this.shtViewHeader.Columns.Get(2).Width = 145F;
            this.shtViewHeader.Columns.Get(3).Label = "Update By";
            this.shtViewHeader.Columns.Get(3).Tag = "Update By";
            this.shtViewHeader.Columns.Get(3).Width = 119F;
            this.shtViewHeader.Columns.Get(4).Label = "Update Date";
            this.shtViewHeader.Columns.Get(4).Tag = "Update Date";
            this.shtViewHeader.Columns.Get(4).Width = 120F;
            this.shtViewHeader.Columns.Get(5).Label = "Update Machine";
            this.shtViewHeader.Columns.Get(5).Tag = "Update Machine";
            this.shtViewHeader.Columns.Get(5).Width = 149F;
            this.shtViewHeader.Columns.Get(6).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.shtViewHeader.Columns.Get(6).Label = "Select";
            this.shtViewHeader.Columns.Get(6).Tag = "Select";
            this.shtViewHeader.Columns.Get(6).Width = 85F;
            this.shtViewHeader.Columns.Get(7).Label = "PO Line";
            this.shtViewHeader.Columns.Get(7).Tag = "PO Line";
            this.shtViewHeader.Columns.Get(7).Width = 59F;
            this.shtViewHeader.Columns.Get(8).Label = "Part No";
            this.shtViewHeader.Columns.Get(8).Tag = "Part No";
            this.shtViewHeader.Columns.Get(8).Width = 200F;
            this.shtViewHeader.Columns.Get(9).Label = "Part Name";
            this.shtViewHeader.Columns.Get(9).Tag = "Part Name";
            this.shtViewHeader.Columns.Get(9).Width = 200F;
            this.shtViewHeader.Columns.Get(10).Label = "Request Date";
            this.shtViewHeader.Columns.Get(10).Tag = "Request Date";
            this.shtViewHeader.Columns.Get(10).Width = 110F;
            this.shtViewHeader.Columns.Get(11).Label = "PO Due Date";
            this.shtViewHeader.Columns.Get(11).Tag = "PO Due Date";
            this.shtViewHeader.Columns.Get(11).Width = 110F;
            this.shtViewHeader.Columns.Get(12).Label = "Issue PO Date";
            this.shtViewHeader.Columns.Get(12).Tag = "Issue PO Date";
            this.shtViewHeader.Columns.Get(12).Width = 110F;
            this.shtViewHeader.Columns.Get(13).Label = "Currency";
            this.shtViewHeader.Columns.Get(13).Tag = "Currency";
            this.shtViewHeader.Columns.Get(13).Width = 120F;
            this.shtViewHeader.Columns.Get(14).Label = "Unit Price";
            this.shtViewHeader.Columns.Get(14).Tag = "Unit Price";
            this.shtViewHeader.Columns.Get(14).Width = 120F;
            this.shtViewHeader.Columns.Get(15).Label = "PO Qty";
            this.shtViewHeader.Columns.Get(15).Tag = "PO Qty";
            this.shtViewHeader.Columns.Get(15).Width = 150F;
            this.shtViewHeader.Columns.Get(16).Label = "Unit";
            this.shtViewHeader.Columns.Get(16).Tag = "Unit";
            this.shtViewHeader.Columns.Get(16).Width = 100F;
            this.shtViewHeader.Columns.Get(17).Label = "Amount";
            this.shtViewHeader.Columns.Get(17).Tag = "Amount";
            this.shtViewHeader.Columns.Get(17).Width = 140F;
            this.shtViewHeader.Columns.Get(18).Label = "Delivery";
            this.shtViewHeader.Columns.Get(18).Tag = "Delivery";
            this.shtViewHeader.Columns.Get(18).Width = 145F;
            this.shtViewHeader.Columns.Get(19).Label = "Delivery To Name";
            this.shtViewHeader.Columns.Get(19).Tag = "Delivery To Name";
            this.shtViewHeader.Columns.Get(19).Width = 190F;
            this.shtViewHeader.Columns.Get(20).Label = "Delivery To Address";
            this.shtViewHeader.Columns.Get(20).Tag = "Delivery To Address";
            this.shtViewHeader.Columns.Get(20).Width = 206F;
            this.shtViewHeader.Columns.Get(21).Label = "Vat Type";
            this.shtViewHeader.Columns.Get(21).Tag = "Vat Type";
            this.shtViewHeader.Columns.Get(21).Width = 138F;
            this.shtViewHeader.Columns.Get(22).Label = "Vat Rate";
            this.shtViewHeader.Columns.Get(22).Tag = "Vat Rate";
            this.shtViewHeader.Columns.Get(22).Width = 123F;
            this.shtViewHeader.Columns.Get(23).Label = "Term Of Payment";
            this.shtViewHeader.Columns.Get(23).Tag = "Term Of Payment";
            this.shtViewHeader.Columns.Get(23).Width = 177F;
            this.shtViewHeader.Columns.Get(24).Label = "Is Export";
            this.shtViewHeader.Columns.Get(24).Tag = "Is Export";
            this.shtViewHeader.Columns.Get(24).Width = 117F;
            this.shtViewHeader.Columns.Get(25).Label = "Status";
            this.shtViewHeader.Columns.Get(25).Tag = "Status";
            this.shtViewHeader.Columns.Get(25).Width = 102F;
            this.shtViewHeader.Columns.Get(26).Label = "Remark";
            this.shtViewHeader.Columns.Get(26).Tag = "Remark";
            this.shtViewHeader.Columns.Get(26).Width = 121F;
            this.shtViewHeader.Columns.Get(27).Label = "Receive Qty";
            this.shtViewHeader.Columns.Get(27).Tag = "Receive Qty";
            this.shtViewHeader.Columns.Get(27).Width = 106F;
            this.shtViewHeader.Columns.Get(28).Label = "Back Order Qty";
            this.shtViewHeader.Columns.Get(28).Tag = "Back Order Qty";
            this.shtViewHeader.Columns.Get(28).Width = 161F;
            this.shtViewHeader.Columns.Get(29).Label = "Last Receive ID";
            this.shtViewHeader.Columns.Get(29).Tag = "Last Receive ID";
            this.shtViewHeader.Columns.Get(29).Width = 154F;
            this.shtViewHeader.Columns.Get(30).Label = "Last Receive Date";
            this.shtViewHeader.Columns.Get(30).Tag = "Last Receive Date";
            this.shtViewHeader.Columns.Get(30).Width = 177F;
            this.shtViewHeader.Columns.Get(31).Label = "PO Group";
            this.shtViewHeader.Columns.Get(31).Tag = "PO Group";
            this.shtViewHeader.Columns.Get(31).Width = 106F;
            this.shtViewHeader.Columns.Get(32).Label = "PO No.";
            this.shtViewHeader.Columns.Get(32).Tag = "PO No.";
            this.shtViewHeader.Columns.Get(32).Width = 90F;
            this.shtViewHeader.Columns.Get(33).Label = "PO Type";
            this.shtViewHeader.Columns.Get(33).Tag = "PO Type";
            this.shtViewHeader.Columns.Get(33).Width = 100F;
            this.shtViewHeader.Columns.Get(34).Label = "PO Date";
            this.shtViewHeader.Columns.Get(34).Tag = "PO Date";
            this.shtViewHeader.Columns.Get(34).Width = 132F;
            this.shtViewHeader.Columns.Get(35).Label = "Supplier Code";
            this.shtViewHeader.Columns.Get(35).Tag = "Supplier Code";
            this.shtViewHeader.Columns.Get(35).Width = 217F;
            this.shtViewHeader.Columns.Get(36).Label = "Supplier Name";
            this.shtViewHeader.Columns.Get(36).Tag = "Supplier Name";
            this.shtViewHeader.Columns.Get(36).Width = 183F;
            this.shtViewHeader.Columns.Get(37).Label = "Address";
            this.shtViewHeader.Columns.Get(37).Tag = "Address";
            this.shtViewHeader.Columns.Get(37).Width = 113F;
            this.shtViewHeader.Columns.Get(38).Label = "Record Status";
            this.shtViewHeader.Columns.Get(38).Tag = "Record Status";
            this.shtViewHeader.Columns.Get(38).Width = 156F;
            this.shtViewHeader.DataAutoCellTypes = false;
            this.shtViewHeader.DataAutoHeadings = false;
            this.shtViewHeader.DataAutoSizeColumns = false;
            this.shtViewHeader.DefaultStyle.ForeColor = System.Drawing.Color.Blue;
            this.shtViewHeader.DefaultStyle.Locked = true;
            this.shtViewHeader.DefaultStyle.Parent = "DataAreaDefault";
            this.shtViewHeader.LockForeColor = System.Drawing.Color.Black;
            this.shtViewHeader.RowHeader.Columns.Default.Resizable = true;
            this.shtViewHeader.RowHeader.Columns.Get(0).Width = 50F;
            this.shtViewHeader.RowHeader.Visible = false;
            this.shtViewHeader.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // txtPOInterval
            // 
            this.txtPOInterval.AllowNegative = false;
            this.txtPOInterval.AppearanceName = "";
            this.txtPOInterval.AppearanceReadOnlyName = "";
            this.txtPOInterval.ControlID = "";
            this.txtPOInterval.Decimal = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtPOInterval.DecimalPoint = '\0';
            this.txtPOInterval.DigitsInGroup = 3;
            this.txtPOInterval.Double = 1D;
            this.txtPOInterval.FixDecimalPosition = false;
            this.txtPOInterval.Flags = 65536;
            this.txtPOInterval.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtPOInterval.GroupSeparator = ',';
            this.txtPOInterval.Int = 1;
            this.txtPOInterval.Location = new System.Drawing.Point(698, 74);
            this.txtPOInterval.Long = ((long)(1));
            this.txtPOInterval.MaxDecimalPlaces = 0;
            this.txtPOInterval.MaxWholeDigits = 3;
            this.txtPOInterval.Name = "txtPOInterval";
            this.txtPOInterval.NegativeSign = '\0';
            this.txtPOInterval.PathString = null;
            this.txtPOInterval.PathValue = 1;
            this.txtPOInterval.Prefix = "";
            this.txtPOInterval.RangeMax = 120D;
            this.txtPOInterval.RangeMin = 1D;
            this.txtPOInterval.Size = new System.Drawing.Size(245, 27);
            this.txtPOInterval.TabIndex = 3;
            this.txtPOInterval.Text = "1";
            this.txtPOInterval.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // evoLabel7
            // 
            this.evoLabel7.AppearanceName = "";
            this.evoLabel7.AutoSize = true;
            this.evoLabel7.ControlID = "";
            this.evoLabel7.Font = new System.Drawing.Font("Tahoma", 12F);
            this.evoLabel7.Location = new System.Drawing.Point(582, 77);
            this.evoLabel7.Name = "evoLabel7";
            this.evoLabel7.PathString = null;
            this.evoLabel7.PathValue = "PO Interval";
            this.evoLabel7.Size = new System.Drawing.Size(89, 19);
            this.evoLabel7.TabIndex = 0;
            this.evoLabel7.Text = "PO Interval";
            // 
            // evoLabel8
            // 
            this.evoLabel8.AppearanceName = "";
            this.evoLabel8.AutoSize = true;
            this.evoLabel8.ControlID = "";
            this.evoLabel8.Font = new System.Drawing.Font("Tahoma", 12F);
            this.evoLabel8.Location = new System.Drawing.Point(949, 77);
            this.evoLabel8.Name = "evoLabel8";
            this.evoLabel8.PathString = null;
            this.evoLabel8.PathValue = "Day(s)";
            this.evoLabel8.Size = new System.Drawing.Size(55, 19);
            this.evoLabel8.TabIndex = 15;
            this.evoLabel8.Text = "Day(s)";
            // 
            // tsControl
            // 
            this.tsControl.GripMargin = new System.Windows.Forms.Padding(0);
            this.tsControl.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsControl.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbGeneratePO,
            this.tlsSeperator1,
            this.tsbIssuePO,
            this.tlsSeperator2,
            this.tsbExit});
            this.tsControl.Location = new System.Drawing.Point(0, 0);
            this.tsControl.Name = "tsControl";
            this.tsControl.Padding = new System.Windows.Forms.Padding(0);
            this.tsControl.Size = new System.Drawing.Size(1016, 28);
            this.tsControl.TabIndex = 13;
            this.tsControl.TabStop = true;
            // 
            // tsbGeneratePO
            // 
            this.tsbGeneratePO.Image = global::Rubik.Forms.Properties.Resources.process;
            this.tsbGeneratePO.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbGeneratePO.Margin = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.tsbGeneratePO.Name = "tsbGeneratePO";
            this.tsbGeneratePO.Padding = new System.Windows.Forms.Padding(2);
            this.tsbGeneratePO.Size = new System.Drawing.Size(93, 24);
            this.tsbGeneratePO.Text = "Generate PO";
            this.tsbGeneratePO.ToolTipText = "Edit";
            this.tsbGeneratePO.Click += new System.EventHandler(this.tsbGeneratePO_Click);
            // 
            // tlsSeperator1
            // 
            this.tlsSeperator1.Name = "tlsSeperator1";
            this.tlsSeperator1.Size = new System.Drawing.Size(6, 28);
            // 
            // tsbIssuePO
            // 
            this.tsbIssuePO.Image = global::Rubik.Forms.Properties.Resources.SAVE;
            this.tsbIssuePO.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbIssuePO.Margin = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.tsbIssuePO.Name = "tsbIssuePO";
            this.tsbIssuePO.Padding = new System.Windows.Forms.Padding(2);
            this.tsbIssuePO.Size = new System.Drawing.Size(74, 24);
            this.tsbIssuePO.Text = "Issue PO";
            this.tsbIssuePO.ToolTipText = "Save";
            this.tsbIssuePO.Click += new System.EventHandler(this.tsbIssuePO_Click);
            // 
            // tlsSeperator2
            // 
            this.tlsSeperator2.Name = "tlsSeperator2";
            this.tlsSeperator2.Size = new System.Drawing.Size(6, 28);
            // 
            // tsbExit
            // 
            this.tsbExit.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbExit.Image = global::Rubik.Forms.Properties.Resources.CLOSE;
            this.tsbExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbExit.Margin = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.tsbExit.Name = "tsbExit";
            this.tsbExit.Padding = new System.Windows.Forms.Padding(2);
            this.tsbExit.Size = new System.Drawing.Size(49, 24);
            this.tsbExit.Text = "Exit";
            this.tsbExit.ToolTipText = "Exit";
            this.tsbExit.Click += new System.EventHandler(this.tsbExit_Click);
            // 
            // evoLabel9
            // 
            this.evoLabel9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.evoLabel9.AppearanceName = "";
            this.evoLabel9.BackColor = System.Drawing.Color.OrangeRed;
            this.evoLabel9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.evoLabel9.ControlID = "";
            this.evoLabel9.Font = new System.Drawing.Font("Tahoma", 12F);
            this.evoLabel9.Location = new System.Drawing.Point(31, 635);
            this.evoLabel9.Name = "evoLabel9";
            this.evoLabel9.PathString = null;
            this.evoLabel9.PathValue = "  ";
            this.evoLabel9.Size = new System.Drawing.Size(21, 21);
            this.evoLabel9.TabIndex = 10020;
            this.evoLabel9.Text = "  ";
            // 
            // evoLabel10
            // 
            this.evoLabel10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.evoLabel10.AppearanceName = "";
            this.evoLabel10.BackColor = System.Drawing.Color.Gold;
            this.evoLabel10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.evoLabel10.ControlID = "";
            this.evoLabel10.Font = new System.Drawing.Font("Tahoma", 12F);
            this.evoLabel10.Location = new System.Drawing.Point(161, 635);
            this.evoLabel10.Name = "evoLabel10";
            this.evoLabel10.PathString = null;
            this.evoLabel10.PathValue = "  ";
            this.evoLabel10.Size = new System.Drawing.Size(21, 21);
            this.evoLabel10.TabIndex = 10021;
            this.evoLabel10.Text = "  ";
            // 
            // evoLabel11
            // 
            this.evoLabel11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.evoLabel11.AppearanceName = "";
            this.evoLabel11.BackColor = System.Drawing.Color.LightGreen;
            this.evoLabel11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.evoLabel11.ControlID = "";
            this.evoLabel11.Font = new System.Drawing.Font("Tahoma", 12F);
            this.evoLabel11.Location = new System.Drawing.Point(286, 635);
            this.evoLabel11.Name = "evoLabel11";
            this.evoLabel11.PathString = null;
            this.evoLabel11.PathValue = "  ";
            this.evoLabel11.Size = new System.Drawing.Size(21, 21);
            this.evoLabel11.TabIndex = 10022;
            this.evoLabel11.Text = "  ";
            // 
            // evoLabel12
            // 
            this.evoLabel12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.evoLabel12.AppearanceName = "";
            this.evoLabel12.AutoSize = true;
            this.evoLabel12.ControlID = "";
            this.evoLabel12.Font = new System.Drawing.Font("Tahoma", 12F);
            this.evoLabel12.Location = new System.Drawing.Point(58, 635);
            this.evoLabel12.Name = "evoLabel12";
            this.evoLabel12.PathString = null;
            this.evoLabel12.PathValue = "Urgent";
            this.evoLabel12.Size = new System.Drawing.Size(57, 19);
            this.evoLabel12.TabIndex = 10023;
            this.evoLabel12.Text = "Urgent";
            // 
            // evoLabel13
            // 
            this.evoLabel13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.evoLabel13.AppearanceName = "";
            this.evoLabel13.AutoSize = true;
            this.evoLabel13.ControlID = "";
            this.evoLabel13.Font = new System.Drawing.Font("Tahoma", 12F);
            this.evoLabel13.Location = new System.Drawing.Point(187, 635);
            this.evoLabel13.Name = "evoLabel13";
            this.evoLabel13.PathString = null;
            this.evoLabel13.PathValue = "Suggest";
            this.evoLabel13.Size = new System.Drawing.Size(65, 19);
            this.evoLabel13.TabIndex = 10024;
            this.evoLabel13.Text = "Suggest";
            // 
            // evoLabel14
            // 
            this.evoLabel14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.evoLabel14.AppearanceName = "";
            this.evoLabel14.AutoSize = true;
            this.evoLabel14.ControlID = "";
            this.evoLabel14.Font = new System.Drawing.Font("Tahoma", 12F);
            this.evoLabel14.Location = new System.Drawing.Point(313, 635);
            this.evoLabel14.Name = "evoLabel14";
            this.evoLabel14.PathString = null;
            this.evoLabel14.PathValue = "Non-Urgent";
            this.evoLabel14.Size = new System.Drawing.Size(92, 19);
            this.evoLabel14.TabIndex = 10025;
            this.evoLabel14.Text = "Non-Urgent";
            // 
            // MRP040_GeneratePO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(1016, 665);
            this.Controls.Add(this.evoLabel14);
            this.Controls.Add(this.evoLabel13);
            this.Controls.Add(this.evoLabel12);
            this.Controls.Add(this.evoLabel11);
            this.Controls.Add(this.evoLabel10);
            this.Controls.Add(this.evoLabel9);
            this.Controls.Add(this.tsControl);
            this.Controls.Add(this.evoLabel8);
            this.Controls.Add(this.evoLabel7);
            this.Controls.Add(this.txtPOInterval);
            this.Controls.Add(this.fpView);
            this.Controls.Add(this.btnSearchLocationTo);
            this.Controls.Add(this.txtLocationTo);
            this.Controls.Add(this.btnSearchLocationFrom);
            this.Controls.Add(this.txtLocationFrom);
            this.Controls.Add(this.btnSearchItemTo);
            this.Controls.Add(this.txtItemCodeTo);
            this.Controls.Add(this.btnSearchItemFrom);
            this.Controls.Add(this.txtItemCodeFrom);
            this.Controls.Add(this.evoLabel2);
            this.Controls.Add(this.evoLabel4);
            this.Controls.Add(this.dtpEndDate);
            this.Controls.Add(this.dtpStartDate);
            this.Controls.Add(this.stdReceiveDate);
            this.Controls.Add(this.evoLabel5);
            this.Controls.Add(this.evoLabel3);
            this.Controls.Add(this.evoLabel1);
            this.Controls.Add(this.evoLabel6);
            this.MinimumSize = new System.Drawing.Size(1024, 699);
            this.Name = "MRP040_GeneratePO";
            this.Text = "MRP040 - Generate PO";
            ((System.ComponentModel.ISupportInitialize)(this.fpView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.shtViewHeader)).EndInit();
            this.tsControl.ResumeLayout(false);
            this.tsControl.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        #region Event

        private void btnSearchItemFrom_Click(object sender, EventArgs e) {
            txtItemCodeFrom.Text = SearchItem();
        }
        private void btnSearchItemTo_Click(object sender, EventArgs e) {
            txtItemCodeTo.Text = SearchItem();
        }

        private void btnSearchLocationFrom_Click(object sender, EventArgs e) {
            txtLocationFrom.Text = SearchLocation();
        }
        private void btnSearchLocationTo_Click(object sender, EventArgs e) {
            txtLocationTo.Text = SearchLocation();
        }

        private void tsbGeneratePO_Click(object sender, EventArgs e) {
            try {
                MessageDialogResult dr = MessageDialog.ShowConfirmation(this, EVOFramework.Message.LoadMessage(TKPMessages.eConfirm.CFM0005.ToString()));
                if (dr == MessageDialogResult.Cancel || dr == MessageDialogResult.No) {
                    return;
                }
                if (!LoadData())
                    return;

                MessageDialog.ShowInformation(this, null, EVOFramework.Message.LoadMessage(Messages.eInformation.INF9003.ToString()).MessageDescription);
                SetScreenMode(eScreenMode.View);
            }
            catch (ValidateException ex) {
                MessageDialog.ShowBusiness(this, ex.ErrorResults[0].Message);
            }
            catch (BusinessException ex) {
                MessageDialog.ShowBusiness(this, ex.Error.Message);
            }
            catch (Exception ex) {
                MessageDialog.ShowBusiness(this, ex.Message);
            }
        }
        private void tsbIssuePO_Click(object sender, EventArgs e) {
            try {

                MessageDialogResult dr = MessageDialog.ShowConfirmation(this, EVOFramework.Message.LoadMessage(Messages.eConfirm.CFM9001.ToString()));
                if (dr == MessageDialogResult.Cancel || dr == MessageDialogResult.No) {
                    return;
                }
                if (dr == MessageDialogResult.Yes) {
                    SaveData();
                    MessageDialog.ShowInformation(this, null, EVOFramework.Message.LoadMessage(Messages.eInformation.INF9003.ToString()).MessageDescription);
                }

                this.Close();

            }
            catch (ValidateException ex) {
                MessageDialog.ShowBusiness(this, ex.ErrorResults[0].Message);
            }
            catch (BusinessException ex) {
                MessageDialog.ShowBusiness(this, ex.Error.Message);
            }
            catch (Exception ex) {
                MessageDialog.ShowBusiness(this, ex.Message);
            }
        }

        private void tsbExit_Click(object sender, EventArgs e) {
            this.Close();
        }
        #endregion

        private void fpView_EditModeOff(object sender, EventArgs e) {
            int iCol = shtViewHeader.ActiveColumnIndex;
            int iRow = shtViewHeader.ActiveRowIndex;
            if (iCol != (int)eDetail.UNIT_PRICE && iCol != (int)eDetail.PO_QTY) 
                return;

            NZDecimal decQty = new NZDecimal(null, shtViewHeader.GetValue(iRow, (int)eDetail.PO_QTY));
            NZDecimal decPrice = new NZDecimal(null, shtViewHeader.GetValue(iRow, (int)eDetail.UNIT_PRICE));
            NZDecimal decAmount = new NZDecimal(null, 0);
            if (decQty.IsNull || decPrice.IsNull) {
                shtViewHeader.Cells[iRow, (int)eDetail.AMOUNT].Value = decAmount.StrongValue;
                return;
            }

            decAmount = new NZDecimal(null, decQty.StrongValue * decPrice.StrongValue);
            shtViewHeader.Cells[iRow, (int)eDetail.AMOUNT].Value = decAmount.IsNull ? 0 : decAmount.StrongValue;
            
        }

        private void fpView_KeyDown(object sender, KeyEventArgs e)
        {
            CtrlUtil.FilterShortCut(e);
        }

        
        

        

        

        


    }

}
