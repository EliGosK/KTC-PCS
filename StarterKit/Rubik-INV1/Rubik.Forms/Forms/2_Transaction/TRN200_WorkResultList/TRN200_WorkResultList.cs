using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using EVOFramework;
using EVOFramework.Data;
using EVOFramework.Windows.Forms;
using FarPoint.Win.Spread.Model;
using Rubik.BIZ;
using CommonLib;
using Rubik.Controller;
using Rubik.DTO;
using SystemMaintenance;
using Message = EVOFramework.Message;
using Rubik.Validators;

namespace Rubik.Transaction
{
    [Screen("TRN200", "Production Report List", eShowAction.Normal, eScreenType.ScreenPane, "Production Report List")]
    public partial class TRN200_WorkResultList : SystemMaintenance.Forms.CustomizeListPaneBaseForm
    {
        #region Enum
        public enum eColView
        {
            TRANS_ID,
            PRODUCTION_REPORT_DATE,
            MASTER_NO,
            PART_NO,
            CUSTOMER_NAME,
            MACHINE_NO,
            MACHINE_NAME,
            SHIFT,
            SHIFT_NAME,
            PRODUCTION_REPORT_NO,
            PROCESS,
            PROCESS_NAME,
            SUPPLIER,
            SUPPLIER_NAME,
            REWORK,
            LOT_NO,
            CUST_LOT_NO,
            PERSON_IN_CHARGE,
            PERSON_IN_CHARGE_NAME,
            QTY,
            NG_QTY,
            REMARK
        }
        #endregion

        #region Variables

        private readonly ProductionReportController m_controller = new ProductionReportController();
        private readonly TransactionValidator m_transactionValidator = new TransactionValidator();

        #endregion

        #region Constructor
        public TRN200_WorkResultList()
        {
            InitializeComponent();
        }
        #endregion

        #region InitializeScreen
        private void InitializeScreen()
        {
            InitializeSpread();

            //txt.KeyPress += CommonLib.CtrlUtil.SetRestrictKeyInput;
            //txtSearch.KeyPress += CommonLib.CtrlUtil.SetRestrictKeyInput;
            //txtSearch.TextChanged += CommonLib.CtrlUtil.FilterRestrictChar;

            InitialFormat();

            dtPeriodBegin.KeyPress += CtrlUtil.SetNextControl;
            dtPeriodEnd.KeyPress += CtrlUtil.SetNextControl;
        }

        private void InitialFormat()
        {
            FormatUtil.SetDateFormat(dtPeriodBegin);
            FormatUtil.SetDateFormat(dtPeriodEnd);

            FormatUtil.SetNumberFormat(shtProductionReportList.Columns[(int)eColView.QTY], FormatUtil.eNumberFormat.Qty_PCS);
            FormatUtil.SetNumberFormat(shtProductionReportList.Columns[(int)eColView.NG_QTY], FormatUtil.eNumberFormat.Qty_PCS);
            FormatUtil.SetDateFormat(shtProductionReportList.Columns[(int)eColView.PRODUCTION_REPORT_DATE]);
        }
        private void InitializeSpread()
        {
            shtProductionReportList.ActiveSkin = Common.ACTIVE_SKIN;

            #region Cell Type

            LookupDataBIZ m_bizLookupData = new LookupDataBIZ();

            LookupData dataShiftCls = m_bizLookupData.LoadLookupClassType(DataDefine.SHIFT_CLS.ToNZString());
            shtProductionReportList.Columns[(int)eColView.SHIFT].CellType = CtrlUtil.CreateReadOnlyPairCellType(dataShiftCls);

            NZString[] locationtype = new NZString[1];
            locationtype[0] = DataDefine.Convert2ClassCode(DataDefine.eLOCATION_CLS.Production).ToNZString();
            LookupData dataProductionProcess = m_bizLookupData.LoadLookupLocation(locationtype);
            shtProductionReportList.Columns[(int)eColView.PROCESS].CellType = CtrlUtil.CreateReadOnlyPairCellType(dataProductionProcess);

            LookupData dataMachine = m_bizLookupData.LoadMachineAll();
            shtProductionReportList.Columns[(int)eColView.MACHINE_NO].CellType = CtrlUtil.CreateReadOnlyPairCellType(dataMachine);

            LookupData dataPersonInCharge = m_bizLookupData.LoadPersonInCharge();
            shtProductionReportList.Columns[(int)eColView.PERSON_IN_CHARGE].CellType = CtrlUtil.CreateReadOnlyPairCellType(dataPersonInCharge);

            NZString[] supplier = new NZString[2];
            supplier[0] = DataDefine.Convert2ClassCode(DataDefine.eLOCATION_CLS.Vendor).ToNZString();
            supplier[1] = DataDefine.Convert2ClassCode(DataDefine.eLOCATION_CLS.CustomerVendor).ToNZString();
            LookupData supplierData = m_bizLookupData.LoadLookupLocation(supplier);
            shtProductionReportList.Columns[(int)eColView.SUPPLIER].CellType = CtrlUtil.CreateReadOnlyPairCellType(supplierData);
            //NZString[] suppliertype = new NZString[1]; //04 = Supplier
            //suppliertype[0] = DataDefine.Convert2ClassCode(DataDefine.eLOCATION_CLS.Vendor).ToNZString();
            //LookupData dataSupplier = m_bizLookupData.LoadLookupLocation(suppliertype);
            //shtProductionReportList.Columns[(int)eColView.Fo].CellType = CtrlUtil.CreateReadOnlyPairCellType(dataSupplier);

            shtProductionReportList.Columns[(int)eColView.REWORK].CellType = CtrlUtil.CreateCheckboxCellType();
            shtProductionReportList.Columns[(int)eColView.REWORK].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;

            #endregion
            
            #region Export Type

            shtProductionReportList.Columns[(int)eColView.TRANS_ID].StyleName = DataDefine.EXPORT_LAST.ToString();
            shtProductionReportList.Columns[(int)eColView.MACHINE_NAME].StyleName = DataDefine.NO_EXPORT.ToString(); 

            #endregion
            
            #region Visible

            shtProductionReportList.Columns[(int)eColView.TRANS_ID].Visible = false;
            shtProductionReportList.Columns[(int)eColView.MACHINE_NAME].Visible = false;
            shtProductionReportList.Columns[(int)eColView.SHIFT_NAME].Visible = false;
            shtProductionReportList.Columns[(int)eColView.PROCESS_NAME].Visible = false;
            shtProductionReportList.Columns[(int)eColView.PERSON_IN_CHARGE_NAME].Visible = false;
            shtProductionReportList.Columns[(int)eColView.SUPPLIER_NAME].Visible = false;
            // 14 Feb 2013: hide lot no and cust lot no
            shtProductionReportList.Columns[(int)eColView.LOT_NO].Visible = false;
            shtProductionReportList.Columns[(int)eColView.CUST_LOT_NO].Visible = false;
            // end 14 Feb 2013
            #endregion

            CtrlUtil.MappingDataFieldWithEnum(shtProductionReportList, typeof(eColView));
        }
        #endregion

        #region Private method
        private void LoadData(NZDateTime from, NZDateTime to)
        {
            //List<InventoryTransactionViewDTO> list = m_controller.LoadReceivingList(from, to);
            //DataTable dt = DTOUtility.ConvertListToDataTable(list);
            m_dtAllData = m_controller.LoadProductionReportList(from, to);
            shtProductionReportList.RowCount = 0;
            shtProductionReportList.DataSource = null;
            FindDataFromMemory();
            //shtProductionReportList.DataSource = m_dtAllData;

            CtrlUtil.SpreadUpdateColumnSorting(shtProductionReportList);
        }
        #endregion

        #region Form event
        private void TRN010_Load(object sender, EventArgs e)
        {
            InitializeScreen();
            InitialToolbar();

            InventoryPeriodBIZ biz = new InventoryPeriodBIZ();
            InventoryPeriodDTO dto = biz.LoadCurrentPeriodWithQueryRange();
            dtPeriodBegin.NZValue = dto.PERIOD_BEGIN_DATE;
            dtPeriodEnd.NZValue = dto.PERIOD_END_DATE;

            LoadData(dto.PERIOD_BEGIN_DATE, dto.PERIOD_END_DATE);
        }

        private void TRN010_Shown(object sender, EventArgs e)
        {
            CtrlUtil.FocusControl(txtSearch);
        }
        #endregion

        #region Control event
        #region Screen control
        //private void tsbRefresh_Click(object sender, EventArgs e)
        //{
        //    LoadData(dtPeriodBegin.NZValue, dtPeriodEnd.NZValue);
        //}
        public override void OnRefresh()
        {
            base.OnRefresh();
            LoadData(dtPeriodBegin.NZValue, dtPeriodEnd.NZValue);
        }
        //private void tsbNew_Click(object sender, EventArgs e)
        //{
        //    OnNew();
        //}
        //public override void OnExit()
        //{
        //    base.OnExit();
        //}
        //private void tsbExit_Click(object sender, EventArgs e)
        //{
        //    this.HidePane();
        //}
        #endregion

        #region Spread
        private void fpView_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {

                bool isClickOnCell = false;

                CellRange cellRange = fpProductionReportList.GetCellFromPixel(0, 0, e.X, e.Y);
                if (cellRange.Column != -1 && cellRange.Row != -1)
                {
                    shtProductionReportList.SetActiveCell(cellRange.Row, cellRange.Column);
                    shtProductionReportList.AddSelection(cellRange.Row, cellRange.Column, 1, 1);
                    isClickOnCell = true;
                }

                if (isClickOnCell)
                {
                    NZString transID = new NZString(null, shtProductionReportList.Cells[cellRange.Row, (int)eColView.TRANS_ID].Value);
                    bool canEditOrDelete = m_transactionValidator.TransactionCanEditOrDelete(transID);

                    miDelete.Enabled = canEditOrDelete && ActivePermission.Delete;
                    miEdit.Enabled = canEditOrDelete && ActivePermission.Edit;
                }
                else
                {
                    miDelete.Enabled = false;
                    miEdit.Enabled = false;
                }

                ctxMenu.Show(fpProductionReportList, e.Location);
            }

        }
        private void fpView_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            OnEdit();
        }
        private void fpView_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                OnEdit();
            }
        }
        #endregion

        #region Context Menu
        private void miEdit_Click(object sender, EventArgs e)
        {
            OnEdit();
        }

        private void miDelete_Click(object sender, EventArgs e)
        {
            OnDelete();
        }
        #endregion
        #endregion

        #region Operation
        public override void OnAddNew()
        {
            base.OnAddNew();
            TRN210_WorkResultEntry dialog = new TRN210_WorkResultEntry();
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                LoadData(dtPeriodBegin.NZValue, dtPeriodEnd.NZValue);
            }
        }
        //private void OnNew()
        //{
        //    TRN020 dialog = new TRN020();
        //    if (dialog.ShowDialog(this) == DialogResult.OK)
        //    {
        //        LoadData(dtPeriodBegin.NZValue, dtPeriodEnd.NZValue);
        //    }
        //}

        private void OnEdit()
        {
            if (!ActivePermission.Edit)
            {
                return;
            }
            if (shtProductionReportList.RowCount <= 0) return;
            NZString TransID = new NZString(null, shtProductionReportList.GetValue(shtProductionReportList.ActiveRowIndex, (int)eColView.TRANS_ID));
            TRN210_WorkResultEntry dialog = new TRN210_WorkResultEntry(TransID);
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                LoadData(dtPeriodBegin.NZValue, dtPeriodEnd.NZValue);
            }
        }

        private void OnDelete()
        {
            try
            {
                NZString transID = new NZString(null, shtProductionReportList.GetValue(shtProductionReportList.ActiveRowIndex, (int)eColView.TRANS_ID));

                MessageDialogResult dr = MessageDialog.ShowConfirmation(this, new Message(Messages.eConfirm.CFM9002.ToString()), MessageDialogButtons.YesNo);
                if (dr == MessageDialogResult.No)
                    return;

                m_controller.DeleteProductionReport(transID);
                LoadData(dtPeriodBegin.NZValue, dtPeriodEnd.NZValue);
                //shtProductionReportList.RemoveRows(shtProductionReportList.ActiveRowIndex, 1);

                MessageDialog.ShowInformation(this, null, new Message(Messages.eInformation.INF9003.ToString()).MessageDescription);
            }
            catch (BusinessException err)
            {
                MessageDialog.ShowBusiness(this, err.Error.Message);
                err.Error.FocusOnControl();
            }
            catch (ValidateException err)
            {
                MessageDialog.ShowBusiness(this, err.ErrorResults[0].Message);
                err.ErrorResults[0].FocusOnControl();
            }
            catch (Exception err)
            {
                MessageDialog.ShowBusiness(this, err.Message);
            }
        }

        private void OnDeleteGroup()
        {
            try
            {
                NZString TransID = new NZString(null, shtProductionReportList.GetValue(shtProductionReportList.ActiveRowIndex, (int)eColView.TRANS_ID));

                MessageDialogResult dr = MessageDialog.ShowConfirmation(this, new Message(Messages.eConfirm.CFM9002.ToString()), MessageDialogButtons.YesNo);
                if (dr == MessageDialogResult.No)
                    return;

                //m_controller.DeleteGroupTransaction(TransID);

                //ไล่ลบจากล่างขึ้นบน เพราะว่าไม่งั้นindex จะเลื่อนแล้วจะลบไม่ครบ
                //for (int iRowIndex = shtProductionReportList.RowCount - 1; iRowIndex >= 0; iRowIndex--)
                //{
                //    if (TransID.NVL("").Equals(shtProductionReportList.GetValue(iRowIndex, (int)eColView.SLIP_NO)))
                //    {
                //        shtProductionReportList.Rows.Remove(iRowIndex, 1);
                //    }
                //}

                LoadData(dtPeriodBegin.NZValue, dtPeriodEnd.NZValue);

                MessageDialog.ShowInformation(this, null, new Message(Messages.eInformation.INF9003.ToString()).MessageDescription);
            }
            catch (BusinessException err)
            {
                MessageDialog.ShowBusiness(this, err.Error.Message);
                err.Error.FocusOnControl();
            }
            catch (ValidateException err)
            {
                MessageDialog.ShowBusiness(this, err.ErrorResults[0].Message);
                err.ErrorResults[0].FocusOnControl();
            }
            catch (Exception err)
            {
                MessageDialog.ShowBusiness(this, err.Message);
            }
        }
        #endregion

        public override void PermissionControl()
        {
            base.PermissionControl();

            //if (ActivePermission.View)
            //{
            this.miDelete.Enabled = ActivePermission.Delete;
            this.miEdit.Enabled = ActivePermission.Edit;

            //}
        }

        private DataTable m_dtAllData;
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (DataDefine.ENABLED_AUTO_SEARCH_WHEN_TEXT_CHANGED)
            {
                FindDataFromMemory();
            }
        }
        private void FindDataFromMemory()
        {
            //CtrlUtil.FilterRestrictChar(txtSearch);
            shtProductionReportList.DataSource = FilterData(m_dtAllData, txtSearch.Text);
            CtrlUtil.SpreadUpdateColumnSorting(shtProductionReportList);
        }

        private DataTable FilterData(DataTable dtView, string filterText)
        {
            try
            {
                if (filterText.Trim() == String.Empty)
                    return dtView;

                //string[] colNames = Enum.GetNames(typeof(eColView));
                //string filterString = string.Empty;

                //for (int i = 0; i < colNames.Length; i++)
                //{
                //    filterString += string.Format(@"CONVERT({0},'System.String') LIKE '%{1}%' ", colNames[i], filterText);
                //    if (i != colNames.Length - 1)
                //        filterString += " OR ";
                //}

                string filterString = FilterStringUtil.GetFilterstring(typeof(eColView), filterText);

                //get only the rows you want
                DataRow[] results = m_dtAllData.Select(filterString);
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

        private void miDeleteGroup_Click(object sender, EventArgs e)
        {
            OnDeleteGroup();
        }

        private void InitialToolbar()
        {
            //tsbNew.Visible = false;

            //ToolStripButton tsbOthers = new System.Windows.Forms.ToolStripButton();
            //tsbOthers.Text = "Others";
            //tsbOthers.Alignment = ToolStripItemAlignment.Left;
            //tsbOthers.Image = global::Rubik.Forms.Properties.Resources.ADD_ICON;
            //tsControl.Items.Insert(tsControl.Items.IndexOf(tsControl.Items[this.toolStripSeparator1.Name]) + 1, tsbOthers);
            //tsbOthers.Click += new EventHandler(tsbOthers_Click);

            //ToolStripButton tsbPlatingSUB = new System.Windows.Forms.ToolStripButton();
            //tsbPlatingSUB.Text = "Plating(Subcontractor)";
            //tsbPlatingSUB.Alignment = ToolStripItemAlignment.Left;
            //tsbPlatingSUB.Image = global::Rubik.Forms.Properties.Resources.ADD_ICON;
            //tsControl.Items.Insert(tsControl.Items.IndexOf(tsControl.Items[this.toolStripSeparator1.Name]) + 1, tsbPlatingSUB);
            //tsbPlatingSUB.Click += new EventHandler(tsbPlatingE_Click);

            //ToolStripButton tsbPlatingKTC = new System.Windows.Forms.ToolStripButton();
            //tsbPlatingKTC.Text = "Plating(KTC)";
            //tsbPlatingKTC.Alignment = ToolStripItemAlignment.Left;
            //tsbPlatingKTC.Image = global::Rubik.Forms.Properties.Resources.ADD_ICON;
            //tsControl.Items.Insert(tsControl.Items.IndexOf(tsControl.Items[this.toolStripSeparator1.Name]) + 1, tsbPlatingKTC);
            //tsbPlatingKTC.Click += new EventHandler(tsbPlatingI_Click);

            //ToolStripButton tsbHeatingE = new System.Windows.Forms.ToolStripButton();
            //tsbHeatingE.Text = "Heating(Subcon)";
            //tsbHeatingE.Alignment = ToolStripItemAlignment.Left;
            //tsbHeatingE.Image = global::Rubik.Forms.Properties.Resources.ADD_ICON;
            //tsControl.Items.Insert(tsControl.Items.IndexOf(tsControl.Items[this.toolStripSeparator1.Name]) + 1, tsbHeatingE);
            //tsbHeatingE.Click += new EventHandler(tsbHeatingE_Click);

            //ToolStripButton tsbHeatingI = new System.Windows.Forms.ToolStripButton();
            //tsbHeatingI.Text = "Heating(KTC)";
            //tsbHeatingI.Alignment = ToolStripItemAlignment.Left;
            //tsbHeatingI.Image = global::Rubik.Forms.Properties.Resources.ADD_ICON;
            //tsControl.Items.Insert(tsControl.Items.IndexOf(tsControl.Items[this.toolStripSeparator1.Name]) + 1, tsbHeatingI);
            //tsbHeatingI.Click += new EventHandler(tsbHeatingI_Click);

            //ToolStripButton tsbCutting = new System.Windows.Forms.ToolStripButton();
            //tsbCutting.Text = "Cutting";
            //tsbCutting.Alignment = ToolStripItemAlignment.Left;
            //tsbCutting.Image = global::Rubik.Forms.Properties.Resources.ADD_ICON;
            //tsControl.Items.Insert(tsControl.Items.IndexOf(tsControl.Items[this.toolStripSeparator1.Name]) + 1, tsbCutting);
            //tsbCutting.Click += new EventHandler(tsbCutting_Click);

            //ToolStripButton tsbRolling = new System.Windows.Forms.ToolStripButton();
            //tsbRolling.Text = "Rolling";
            //tsbRolling.Alignment = ToolStripItemAlignment.Left;
            //tsbRolling.Image = global::Rubik.Forms.Properties.Resources.ADD_ICON;
            //tsControl.Items.Insert(tsControl.Items.IndexOf(tsControl.Items[this.toolStripSeparator1.Name]) + 1, tsbRolling);
            //tsbRolling.Click += new EventHandler(tsbRolling_Click);

            //ToolStripButton tsbHeading = new System.Windows.Forms.ToolStripButton();
            //tsbHeading.Text = "Heading";
            //tsbHeading.Alignment = ToolStripItemAlignment.Left;
            //tsbHeading.Image = global::Rubik.Forms.Properties.Resources.ADD_ICON;
            //tsControl.Items.Insert(tsControl.Items.IndexOf(tsControl.Items[this.toolStripSeparator1.Name]) + 1, tsbHeading);
            //tsbHeading.Click += new EventHandler(tsbHeading_Click);

        }

        //private void tsbHeading_Click(object sender, EventArgs e)
        //{
        //    TRN2101_WorkResult_Heading dialog = new TRN2101_WorkResult_Heading();
        //    if (dialog.ShowDialog(this) == DialogResult.OK)
        //    {
        //        LoadData(dtPeriodBegin.NZValue, dtPeriodEnd.NZValue);
        //    }
        //}

        //private void tsbRolling_Click(object sender, EventArgs e)
        //{
        //    TRN2102_WorkResultEntry_Rolling dialog = new TRN2102_WorkResultEntry_Rolling();
        //    if (dialog.ShowDialog(this) == DialogResult.OK)
        //    {
        //        LoadData(dtPeriodBegin.NZValue, dtPeriodEnd.NZValue);
        //    }
        //}

        //private void tsbCutting_Click(object sender, EventArgs e)
        //{
        //    TRN2103_WorkResultEntry_Cutting dialog = new TRN2103_WorkResultEntry_Cutting();
        //    if (dialog.ShowDialog(this) == DialogResult.OK)
        //    {
        //        LoadData(dtPeriodBegin.NZValue, dtPeriodEnd.NZValue);
        //    }

        //}

        //private void tsbPlatingI_Click(object sender, EventArgs e)
        //{
        //    TRN2104_WorkResultEntry_PlatingI dialog = new TRN2104_WorkResultEntry_PlatingI();
        //    if (dialog.ShowDialog(this) == DialogResult.OK)
        //    {
        //        LoadData(dtPeriodBegin.NZValue, dtPeriodEnd.NZValue);
        //    }
        //}

        //private void tsbPlatingE_Click(object sender, EventArgs e)
        //{
        //    TRN2105_WorkResultEntry_PlatingE dialog = new TRN2105_WorkResultEntry_PlatingE();
        //    if (dialog.ShowDialog(this) == DialogResult.OK)
        //    {
        //        LoadData(dtPeriodBegin.NZValue, dtPeriodEnd.NZValue);
        //    }
        //}

        //private void tsbHeatingI_Click(object sender, EventArgs e)
        //{
        //    TRN2106_WorkResultEntry_HeatingI dialog = new TRN2106_WorkResultEntry_HeatingI();
        //    if (dialog.ShowDialog(this) == DialogResult.OK)
        //    {
        //        LoadData(dtPeriodBegin.NZValue, dtPeriodEnd.NZValue);
        //    }
        //}

        //private void tsbHeatingE_Click(object sender, EventArgs e)
        //{
        //    TRN2107_WorkResultEntry_HeatingE dialog = new TRN2107_WorkResultEntry_HeatingE();
        //    if (dialog.ShowDialog(this) == DialogResult.OK)
        //    {
        //        LoadData(dtPeriodBegin.NZValue, dtPeriodEnd.NZValue);
        //    }
        //}

        //private void tsbOthers_Click(object sender, EventArgs e)
        //{
        //    TRN2108_WorkResultEntry_Others dialog = new TRN2108_WorkResultEntry_Others();
        //    if (dialog.ShowDialog(this) == DialogResult.OK)
        //    {
        //        LoadData(dtPeriodBegin.NZValue, dtPeriodEnd.NZValue);
        //    }
        //}

        public override void OnSorting()
        {
            ShowMultiSortDialog(shtProductionReportList);
        }

        public override void OnSaveFormat()
        {
            base.OnSaveFormat();

            SheetWidthController ctrl = new SheetWidthController();
            ctrl.SaveSheetWidth(shtProductionReportList, this.ScreenCode);
        }

        public override void OnResetFormat()
        {
            base.OnResetFormat();

            SheetWidthController ctrl = new SheetWidthController();
            ctrl.ResetSheetWidth(shtProductionReportList);
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
            ctrl.SetSheetWidth(shtProductionReportList, this.ScreenCode);
        }

        private void fpProductionReportList_KeyDown(object sender, KeyEventArgs e)
        {
            CtrlUtil.FilterShortCut(e);
        }

        public override void OnAdvanceSearch()
        {
            base.OnAdvanceSearch();

            ShowAdvanceSearchDialog(shtProductionReportList, typeof(eColView), m_dtAllData);
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (DataDefine.ENABLED_AUTO_SEARCH_WHEN_PRESS_ENTER_KEY && e.KeyCode == Keys.Enter)
                FindDataFromMemory();
        }
    }
}
