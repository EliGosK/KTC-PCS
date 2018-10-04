using System.Windows.Forms;
using EVOFramework;
using EVOFramework.Data;
using EVOFramework.Windows.Forms;
using SystemMaintenance.Forms;
using Rubik.BIZ;
using System.Data;
using System;
using FarPoint.Win.Spread.Model;
using Rubik.Controller;
using Message = EVOFramework.Message;
using SystemMaintenance;
using CommonLib;

namespace Rubik.Master
{
    [Screen("MAS110", "Sales Unit Price List", eShowAction.Normal, eScreenType.ScreenPane, "Sales Unit Price List")]
    [Permission(true, false, false, false)]
    public partial class MAS110_SalesUnitPriceList : CustomizeListPaneForm
    {
        #region Enumeration
        public enum eColView
        {
            MASTER_NO,
            PART_NO,
            CUSTOMER_NAME,
            PRICE,
            CURRENCY,
            CURRENCY_NAME,
            START_EFFECTIVE_DATE,

            REMARK
        }
        #endregion

        #region Variables
        private readonly SalesUnitPriceController m_SalesUnitPriceController = new SalesUnitPriceController();
        private DataTable m_dtView = null;
        #endregion

        #region Constructor
        public MAS110_SalesUnitPriceList()
        {
            InitializeComponent();
        }

        #endregion

        #region Private methods
        private void InitializeScreen()
        {
            shtView.ActiveSkin = CommonLib.Common.ACTIVE_SKIN;

            InitialFormat();
            LoadLookupCellType();

            CtrlUtil.MappingDataFieldWithEnum(shtView, typeof(eColView));
            CtrlUtil.SpreadUpdateColumnSorting(shtView);
            shtView.Columns[(int)eColView.CURRENCY_NAME].Visible = false;

            LoadData(false);
        }

        private void InitialFormat()
        {
            FormatUtil.SetDateFormat(shtView.Columns[(int)eColView.START_EFFECTIVE_DATE]);
            FormatUtil.SetNumberFormat(shtView.Columns[(int)eColView.PRICE], FormatUtil.eNumberFormat.UnitPrice);

        }

        private void LoadLookupCellType()
        {
            LookupDataBIZ biz = new LookupDataBIZ();
            LookupData currencyData = biz.LoadLookupClassType(DataDefine.CURRENCY.ToNZString());
            ReadOnlyPairCellType cellCurrencyType = new ReadOnlyPairCellType(currencyData, CommonLib.Common.COMBOBOX_SEPERATOR_SYMBOL);
            shtView.Columns[(int)eColView.CURRENCY].CellType = cellCurrencyType;
        }

        private void LoadData(bool LimitRow)
        {
            SalesUnitPriceBIZ biz = new SalesUnitPriceBIZ();
            if (dtPriceOn.Value == null)
                m_dtView = biz.LoadSalesUnitPriceList(false, null);
            else
                m_dtView = biz.LoadSalesUnitPriceList(false, dtPriceOn.Value);

            shtView.RowCount = 0;
            shtView.DataSource = FilterData(m_dtView, txtFind.Text.Trim());

        }

        private DataTable FilterData(DataTable dtView, string filterText)
        {
            try
            {
                if (filterText.Trim() == String.Empty)
                    return dtView;

                //string[] colNames = Enum.GetNames(typeof(eColView));
                //string filterString = string.Empty;

                //for (int i = 0; i < colNames.Length; i++) {
                //    filterString += string.Format(@"CONVERT({0},'System.String') LIKE '%{1}%' ", colNames[i], filterText);
                //    if (i != colNames.Length - 1)
                //        filterString += " OR ";
                //}

                string filterString = FilterStringUtil.GetFilterstring(typeof(eColView), filterText);

                //get only the rows you want
                DataRow[] results = dtView.Select(filterString);
                DataTable dtFilter = dtView.Clone();

                //populate new destination table
                foreach (DataRow dr in results)
                    dtFilter.ImportRow(dr);

                return dtFilter;
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusiness(this, ex.Message);
            }
            return null;
        }
        private void FindDataFromMemory()
        {
            //CtrlUtil.FilterRestrictChar(txtFind);
            shtView.DataSource = FilterData(m_dtView, txtFind.Text.Trim());
            CtrlUtil.SpreadUpdateColumnSorting(shtView);
        }
        #endregion

        #region Form events
        private void MAS010_LocationList_Load(object sender, System.EventArgs e)
        {
            InitializeScreen();
        }

        private void MAS010_LocationList_Shown(object sender, System.EventArgs e)
        {
            PermissionControl();
            CtrlUtil.FocusControl(txtFind);
        }
        #endregion

        #region Control events
        private void txtFind_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (DataDefine.ENABLED_AUTO_SEARCH_WHEN_TEXT_CHANGED)
            {
                FindDataFromMemory();
            }
        }

        #region Spread
        private void fpView_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {

                bool isClickOnCell = false;

                CellRange cellRange = fpView.GetCellFromPixel(0, 0, e.X, e.Y);
                if (cellRange.Column != -1 && cellRange.Row != -1)
                {
                    shtView.SetActiveCell(cellRange.Row, cellRange.Column);
                    shtView.AddSelection(cellRange.Row, cellRange.Column, 1, 1);
                    isClickOnCell = true;
                }

                if (isClickOnCell)
                {
                    mnuDelete.Enabled = ActivePermission.Delete;
                    mnuEdit.Enabled = ActivePermission.Edit;
                }
                else
                {
                    mnuDelete.Enabled = false;
                    mnuEdit.Enabled = false;
                }

                ctxMenu.Show(fpView, e.Location);
            }

        }
        private void fpView_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            OpenSalesUnitPriceMaster();
        }
        private void fpView_KeyPress(object sender, KeyPressEventArgs e)
        {
            //OpenSalesUnitPriceMaster();
        }
        #endregion

        #region Menu Item
        private void OpenSalesUnitPriceMaster()
        {
            if (!ActivePermission.Edit)
            {
                return;
            }
            if (shtView.RowCount <= 0) return;
            string strMasterNo = shtView.GetValue(shtView.ActiveRowIndex, (int)eColView.MASTER_NO).ToString();
            DateTime dtmStartEffDate = Convert.ToDateTime(shtView.GetValue(shtView.ActiveRowIndex, (int)eColView.START_EFFECTIVE_DATE));
            string strCurrency = shtView.GetValue(shtView.ActiveRowIndex, (int)eColView.CURRENCY).ToString();

            MAS120_SalesUnitPriceMaster form = new MAS120_SalesUnitPriceMaster(strMasterNo, dtmStartEffDate, strCurrency);
            if (form.ShowDialog(null) == DialogResult.OK)
            {
                LoadData(false);
            }
        }

        private void mnuEdit_Click(object sender, EventArgs e)
        {
            OpenSalesUnitPriceMaster();
        }
        private void mnuDelete_Click(object sender, EventArgs e)
        {
            string strMasterNo = shtView.GetValue(shtView.ActiveRowIndex, (int)eColView.MASTER_NO).ToString();
            DateTime dtmStartEffDate = Convert.ToDateTime(shtView.GetValue(shtView.ActiveRowIndex, (int)eColView.START_EFFECTIVE_DATE));
            string strCurrency = shtView.GetValue(shtView.ActiveRowIndex, (int)eColView.CURRENCY).ToString();

            ErrorItem errorItem = new ErrorItem(null,TKPMessages.eValidate.VLM0213.ToString());
            MessageDialog.ShowBusiness(this, errorItem.Message);

            MessageDialogResult dr = MessageDialog.ShowConfirmation(this, new Message(Messages.eConfirm.CFM9002.ToString()), MessageDialogButtons.YesNo);
            if (dr == MessageDialogResult.No)
                return;

            m_SalesUnitPriceController.DeleteSalesUnitPrice(strMasterNo.ToNZString(), dtmStartEffDate.ToNZDateTime(), strCurrency.ToNZString());
            LoadData(false);

            MessageDialog.ShowInformation(this, null, new Message(Messages.eInformation.INF9003.ToString()).MessageDescription);
        }
        #endregion

        #endregion

        public override void OnAddNew()
        {
            base.OnAddNew();
            MAS120_SalesUnitPriceMaster form = new MAS120_SalesUnitPriceMaster();
            if (form.ShowDialog(this) == DialogResult.OK)
            {
                LoadData(false);
            }
        }
        public override void OnRefresh()
        {
            base.OnRefresh();
            LoadData(false);
        }
        public override void OnShowAll()
        {
            base.OnShowAll();
            LoadData(false);
        }

        public override void PermissionControl()
        {
            base.PermissionControl();

            if (ActivePermission.View)
            {
                ctxMenu.Items[0].Enabled = ActivePermission.Edit;
                ctxMenu.Items[1].Enabled = ActivePermission.Delete;
            }

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
                tsbAdvanceSearch.Visible = true;
            }

            SheetWidthController ctrl = new SheetWidthController();
            ctrl.SetSheetWidth(shtView, this.ScreenCode);
        }

        public override void OnSorting()
        {
            ShowMultiSortDialog(shtView);
        }

        private void fpView_KeyDown(object sender, KeyEventArgs e)
        {
            CtrlUtil.FilterShortCut(e);
        }

        public override void OnAdvanceSearch()
        {
            base.OnAdvanceSearch();

            ShowAdvanceSearchDialog(shtView, typeof(eColView), m_dtView);
        }

        private void txtFind_KeyDown(object sender, KeyEventArgs e)
        {
            if (DataDefine.ENABLED_AUTO_SEARCH_WHEN_PRESS_ENTER_KEY && e.KeyCode == Keys.Enter)
                FindDataFromMemory();
        }
    }
}