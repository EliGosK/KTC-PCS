using System;
using EVOFramework.Windows.Forms;
using SystemMaintenance.Forms;
using EVOFramework;
using EVOFramework.Data;
using Rubik.BIZ;
using Rubik.Controller;
using Rubik.DTO;
using Rubik.UIDataModel;
using System.Collections.Generic;
using System.Data;
using CommonLib;

namespace Rubik.Inventory
{
    [Screen("INV020", "Inventory Movement Inquiry", eShowAction.Normal, eScreenType.Dialog, "Inventory Movement Inquiry")]
    public partial class INV020_InventoryMovementInquiry : CustomizeInquiryForm
    {
        #region Enumeration
        public enum eColView
        {
            TRANS_DATE,
            TRANS_ID,
            TRANS_INFO,
            LOT_NO,
            IN_QTY,
            OUT_QTY,
            BALANCE,
            NG_CRITERIA,
            NG_QTY,
            PRICE,
            REF_TYPE,
            REF_SLIP_NO,
            REF_NO,
            FOR_CUSTOMER,
            REMARK,
        }
        #endregion

        #region Variables
        private readonly NZString m_yearMonth;
        private readonly NZString m_wareHouseCode;
        private readonly NZString m_itemCode;
        private readonly NZString m_lotNo;
        private readonly NZString m_packNo;
        private readonly NZDateTime m_periodBeginDate;
        private readonly NZDateTime m_periodEndDate;
        private readonly NZInt m_QueryType;

        private readonly InventoryMovementInqController m_inventoryMovementInqController = new InventoryMovementInqController();
        private readonly ItemBIZ m_bizItem = new ItemBIZ();
        private readonly LookupDataBIZ m_bizLookup = new LookupDataBIZ();
        private readonly ClassListBIZ m_bizClassList = new ClassListBIZ();
        #endregion

        #region Constructor
        public INV020_InventoryMovementInquiry()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="yearMonth"></param>
        /// <param name="locationCD"></param>
        /// <param name="itemCD"></param>
        /// <param name="lotNo"></param>
        /// <param name="periodBeginDate"></param>
        /// <param name="periodEndDate"></param>
        public INV020_InventoryMovementInquiry(NZString yearMonth, NZString locationCD, NZString itemCD, NZString lotNo, NZString packNo, NZDateTime periodBeginDate, NZDateTime periodEndDate, NZInt QueryType)
        {
            InitializeComponent();

            m_yearMonth = yearMonth;
            m_wareHouseCode = locationCD;
            m_itemCode = itemCD;
            m_lotNo = lotNo;
            m_packNo = packNo;
            m_periodBeginDate = periodBeginDate;
            m_periodEndDate = periodEndDate;
            m_QueryType = QueryType;

            ItemDTO dtoItem = m_bizItem.LoadItem(itemCD);

            txtUnitMeasure.Text = string.Empty;
            if (dtoItem != null)
            {

                //ClassListDTO dtoClassList = m_bizClassList.LoadByPK((NZString)DataDefine.UM_CLS, dtoItem.INV_UM_CLS);
                //if (dtoClassList != null)
                //{
                //    txtUnitMeasure.Text = String.Format("{0}{1}{2}", dtoItem.INV_UM_CLS.Value, Common.COMBOBOX_SEPERATOR_SYMBOL, dtoClassList.CLS_DESC.Value);
                //}
            }
            //InitializeScreen();           
        }
        #endregion

        #region Overriden Method
        public override void OnExport()
        {
            base.OnExport();
            ExportDialog frmExport = new ExportDialog(fpView);

            frmExport.ShowDialog(this);
        }
        #endregion

        #region Properties
        public NZString WareHouseCode
        {
            get { return m_wareHouseCode; }
        }

        public NZString ItemCode
        {
            get { return m_itemCode; }
        }

        public NZString LotNo
        {
            get { return m_lotNo; }
        }

        public NZDateTime PeriodBeginDate
        {
            get { return m_periodBeginDate; }
        }

        public NZDateTime PeriodEndDate
        {
            get { return m_periodEndDate; }
        }

        public NZString YearMonth
        {
            get { return m_yearMonth; }
        }

        #endregion

        #region Private methods
        private void InitializeScreen()
        {
            shtView.ActiveSkin = Common.ACTIVE_SKIN;

            // Mapping DataField.
            CtrlUtil.MappingDataFieldWithEnum(shtView, typeof(eColView));

            txtItem.KeyPress += CtrlUtil.SetNextControl;
            txtLocation.KeyPress += CtrlUtil.SetNextControl;
            txtLotNo.KeyPress += CtrlUtil.SetNextControl;
            txtInvPeriod.KeyPress += CtrlUtil.SetNextControl;
            txtOnHandQty.KeyPress += CtrlUtil.SetNextControl;
            cboItemType.KeyPress += CtrlUtil.SetNextControl;


            // Set default Column Cell Type.
            LookupDataBIZ bizLookupData = new LookupDataBIZ();

            LookupData transTypelookupData = bizLookupData.LoadLookupClassType(DataDefine.TRANS_TYPE.ToNZString());
            LookupData refClassTypelookupData = bizLookupData.LoadLookupClassType(DataDefine.REF_SLIP_CLS.ToNZString());
            shtView.Columns[(int)eColView.TRANS_INFO].CellType = CtrlUtil.CreateReadOnlyPairCellType(transTypelookupData);
            shtView.Columns[(int)eColView.REF_TYPE].CellType = CtrlUtil.CreateReadOnlyPairCellType(refClassTypelookupData);
            shtView.Columns[(int)eColView.TRANS_DATE].CellType = CtrlUtil.CreateDateTimeCellType(Common.CurrentUserInfomation.DateFormatString);

            cboItemType.Format += Common.ComboBox_Format;
            LookupData itemTypelookupData = bizLookupData.LoadLookupClassType(DataDefine.ITEM_CLS.ToNZString());
            cboItemType.LoadLookupData(itemTypelookupData);
            // Enable/Disable Controls
            CtrlUtil.EnabledControl(false, txtItem, txtLocation, txtLotNo, txtInvPeriod, txtOnHandQty, txtUnitMeasure, txtPackNo);
            CtrlUtil.EnabledControl(true, fpView);

            // Load data.
            txtItem.Text = ItemCode.NVL(string.Empty);
            txtLocation.Text = WareHouseCode.NVL(string.Empty);
            txtLotNo.Text = LotNo.NVL(string.Empty);
            txtInvPeriod.Text = String.Format("{0} - {1}",
                                              CtrlUtil.ConvertDateTimeToCurrentFormat(PeriodBeginDate),
                                              CtrlUtil.ConvertDateTimeToCurrentFormat(PeriodEndDate));

            CtrlUtil.EnabledControl(false, cboItemType);
            LoadData();
        }

        private void LoadData()
        {
            List<InventoryMovementInqUIDM> listModel = null;

            //if (m_lotNo.StrongValue == Common.LOT_NO_GROUPBY)
            if (m_QueryType == 1)//Query Type = 1 แปลว่า Group ตาม Item
            {
                // Load all movement.
                listModel = m_inventoryMovementInqController.LoadDataInventoryMovementInquiry(YearMonth, PeriodBeginDate, PeriodEndDate, ItemCode, WareHouseCode, m_lotNo);
            }
            else
            {
                // Load movement only LotNo.
                listModel = m_inventoryMovementInqController.LoadDataInventorymovementInquiryByLotNo(YearMonth, PeriodBeginDate, PeriodEndDate, ItemCode, WareHouseCode, m_lotNo, m_packNo);
            }

            DataTable dataTable = DTOUtility.ConvertListToDataTable(listModel);
            shtView.DataSource = dataTable;

            if (dataTable.Rows.Count > 0)
            {
                shtView.Cells[0, (int)eColView.TRANS_INFO].CellType = new FarPoint.Win.Spread.CellType.TextCellType();
                txtOnHandQty.Text = CtrlUtil.GetCompleteNumberFormatValue(txtOnHandQty.MaxDecimalPlaces, listModel[listModel.Count - 1].BALANCE);// listModel[listModel.Count - 1].BALANCE.StrongValue.ToString();
            }
            else
            {
                txtOnHandQty.PathValue = 0;
            }

            CtrlUtil.SpreadUpdateColumnSorting(shtView);

        }


        #endregion

        #region Form events
        private void INV020_InventoryMovementInquiry_Load(object sender, EventArgs e)
        {
            InitializeScreen();
        }

        private void INV020_InventoryMovementInquiry_Shown(object sender, EventArgs e)
        {
            CtrlUtil.FocusControl(txtLocation);
        }
        #endregion

        private void fpView_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            CtrlUtil.FilterShortCut(e);
        }
    }
}
