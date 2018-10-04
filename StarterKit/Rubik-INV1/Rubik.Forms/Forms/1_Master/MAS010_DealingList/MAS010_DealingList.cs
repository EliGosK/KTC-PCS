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
using FarPoint.Win.Spread;
using Rubik.DTO;
using System.Collections.Generic;
using Rubik.Validators;

namespace Rubik.Master
{
    [Screen("MAS010", "Dealing List", eShowAction.Normal, eScreenType.ScreenPane, "Dealing List")]
    [Permission(true, false, false, false)]
    public partial class MAS010_DealingList : CustomizeListPaneForm
    {
        #region Enumeration
        public enum eColView
        {
            LOC_CD,
            LOC_DESC,
            LOC_CLS,
            LOC_CLS_NAME,
            TERM_OF_PAYMENT,
            INVOICE_PATTERN,

            ADDRESS1,
            TEL1,
            FAX1,
            EMAIL1,
            CONTACT_PERSON1,
            REMARK1,

            ADDRESS2,
            TEL2,
            FAX2,
            EMAIL2,
            CONTACT_PERSON2,
            REMARK2,

            ADDRESS3,
            TEL3,
            FAX3,
            EMAIL3,
            CONTACT_PERSON3,
            REMARK3,

        }
        #endregion

        #region Variables
        private readonly DealingController m_locationController = new DealingController();
        private DataTable m_dtView = null;
        #endregion

        #region Constructor
        public MAS010_DealingList()
        {
            InitializeComponent();
        }

        #endregion

        #region Private methods
        private void InitializeScreen()
        {
            shtView.ActiveSkin = CommonLib.Common.ACTIVE_SKIN;

            LoadLookupCellType();

            CtrlUtil.MappingDataFieldWithEnum(shtView, typeof(eColView));

            #region No Export Column

            shtView.Columns[(int)eColView.ADDRESS3].StyleName = DataDefine.NO_EXPORT.ToString();
            shtView.Columns[(int)eColView.TEL3].StyleName = DataDefine.NO_EXPORT.ToString();
            shtView.Columns[(int)eColView.FAX3].StyleName = DataDefine.NO_EXPORT.ToString();
            shtView.Columns[(int)eColView.EMAIL3].StyleName = DataDefine.NO_EXPORT.ToString();
            shtView.Columns[(int)eColView.CONTACT_PERSON3].StyleName = DataDefine.NO_EXPORT.ToString();
            shtView.Columns[(int)eColView.REMARK3].StyleName = DataDefine.NO_EXPORT.ToString();

            #endregion

            #region visible column

            shtView.Columns[(int)eColView.LOC_CLS_NAME].Visible = false;
            shtView.Columns[(int)eColView.ADDRESS3].Visible = false;
            shtView.Columns[(int)eColView.CONTACT_PERSON3].Visible = false;
            shtView.Columns[(int)eColView.EMAIL3].Visible = false;
            shtView.Columns[(int)eColView.FAX3].Visible = false;
            shtView.Columns[(int)eColView.REMARK3].Visible = false;
            shtView.Columns[(int)eColView.TEL3].Visible = false;

            #endregion
            
            LoadData(false);
        }

        private void LoadLookupCellType()
        {
            LookupDataBIZ bizLookup = new LookupDataBIZ();

            LookupData locationTypeData = bizLookup.LoadLookupClassType(DataDefine.LOCATION_CLS.ToNZString());
            ReadOnlyPairCellType cellProcess = new ReadOnlyPairCellType(locationTypeData, CommonLib.Common.COMBOBOX_SEPERATOR_SYMBOL);
            shtView.Columns[(int)eColView.LOC_CLS].CellType = cellProcess;

            LookupData termOfPayment = bizLookup.LoadLookupClassType(DataDefine.TERM_OF_PAYMENT.ToNZString());
            ReadOnlyPairCellType cellProcess1 = new ReadOnlyPairCellType(termOfPayment, CommonLib.Common.COMBOBOX_SEPERATOR_SYMBOL,false);
            shtView.Columns[(int)eColView.TERM_OF_PAYMENT].CellType = cellProcess1;

            LookupData invoicePattern = bizLookup.LoadLookupClassType(DataDefine.INVOICE_PATTERN.ToNZString());
            ReadOnlyPairCellType cellProcess2 = new ReadOnlyPairCellType(invoicePattern, CommonLib.Common.COMBOBOX_SEPERATOR_SYMBOL, false);
            shtView.Columns[(int)eColView.INVOICE_PATTERN].CellType = cellProcess2;
        }

        private void LoadData(bool LimitRow)
        {
            DealingBIZ biz = new DealingBIZ();
            m_dtView = biz.LoadDealingList();

            shtView.RowCount = 0;
            shtView.DataSource = FilterData(m_dtView, txtFind.Text.Trim());

            CtrlUtil.SpreadUpdateColumnSorting(shtView);
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

            InitialToolbar();            
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
                string LOC_CLS = shtView.GetValue(shtView.ActiveRowIndex, (int)eColView.LOC_CLS).ToString();
                if (isClickOnCell && LOC_CLS != "02")
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
            string LOC_CLS = shtView.GetValue(shtView.ActiveRowIndex, (int)eColView.LOC_CLS).ToString();
            if (LOC_CLS != "02")
            {
                OpenLocationMaster();
            }
            else
                MessageDialog.ShowBusiness(this, new Message(TKPMessages.eValidate.VLM0227.ToString()));

        }
        private void fpView_KeyPress(object sender, KeyPressEventArgs e)
        {
            //OpenLocationMaster();
        }
        #endregion

        #region Menu Item
        private void OpenLocationMaster()
        {
            if (!ActivePermission.Edit)
            {
                return;
            }
            if (shtView.RowCount <= 0) return;
            string LOC_CD = shtView.GetValue(shtView.ActiveRowIndex, (int)eColView.LOC_CD).ToString();
            MAS020_DealingMaster form = new MAS020_DealingMaster(LOC_CD);
            if (form.ShowDialog(null) == DialogResult.OK)
            {
                LoadData(false);
            }
        }

        private void mnuEdit_Click(object sender, EventArgs e)
        {
            OpenLocationMaster();
        }
        private void mnuDelete_Click(object sender, EventArgs e)
        {
            try
            {
                string LOC_CD = shtView.GetValue(shtView.ActiveRowIndex, (int)eColView.LOC_CD).ToString();

                DealingValidator validator = new DealingValidator();
                ErrorItem errorItem = null;
                errorItem = validator.ValidateBeforeDelete(LOC_CD.ToNZString());
                if (null != errorItem) ValidateException.ThrowErrorItem(errorItem);

                MessageDialogResult dr = MessageDialog.ShowConfirmation(this, new Message(Messages.eConfirm.CFM9002.ToString()), MessageDialogButtons.YesNo);
                if (dr == MessageDialogResult.No)
                    return;

                m_locationController.DeleteLocation(LOC_CD.ToNZString());
                LoadData(false);

                MessageDialog.ShowInformation(this, null, new Message(Messages.eInformation.INF9003.ToString()).MessageDescription);
            }
            catch (ValidateException err)
            {
                MessageDialog.ShowBusiness(this, err.ErrorResults[0].Message);
                err.ErrorResults[0].FocusOnControl();
            }
        
        }


        #endregion

        #endregion

        public override void OnAddNew()
        {
            base.OnAddNew();
            MAS020_DealingMaster form = new MAS020_DealingMaster();
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
                    this.mnuEdit.Enabled = true;// ActivePermission.Edit;
                    this.mnuDelete.Enabled = ActivePermission.Delete;
            }

        }

        //private void btnSorting_Click(object sender, EventArgs e)
        //{
        //    //SortInfo[] si = new SortInfo[10];
        //    //si[0] = new SortInfo(2, true);
        //    //si[1] = new SortInfo(1, true);
        //    //shtView.SortRows(0, shtView.RowCount, si);


        //    MultiColumnSorting mcs = new MultiColumnSorting(shtView);
        //    DialogResult dr = mcs.ShowDialog();

        //    if (dr == System.Windows.Forms.DialogResult.OK)
        //    {
        //        shtView.SortRows(0, shtView.RowCount, mcs.SortingInfo);
        //    }

        //}
        private void InitialToolbar()
        {
            //if (Common.UserGroupShowFormatButton.ToUpper().Equals(Common.CurrentUserInfomation.GroupCode.NVL("").ToUpper()))
            //{
            //    tsbDefaultSize.Visible = true;
            //    tsbSaveFormat.Visible = true;
            //}

            //ToolStripButton tsbSorting = new System.Windows.Forms.ToolStripButton();
            //tsbSorting.Text = "Sorting";
            //tsbSorting.Alignment = ToolStripItemAlignment.Right;
            //tsbSorting.Image = global::Rubik.Forms.Properties.Resources.UP_BTN;
            //tsControl.Items.Insert(tsControl.Items.IndexOf(tsControl.Items[this.tsSeperator2.Name]) + 1, tsbSorting);

            //tsbSorting.Click += new EventHandler(btnSorting_Click);
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