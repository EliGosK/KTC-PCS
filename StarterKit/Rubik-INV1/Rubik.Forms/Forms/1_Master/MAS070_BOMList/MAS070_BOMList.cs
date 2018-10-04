using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Rubik.Controller;
using SystemMaintenance.Forms;
using EVOFramework.Windows.Forms;
using EVOFramework;
using Rubik.BIZ;
using EVOFramework.Data;
using CommonLib;
using Rubik.Validators;

namespace Rubik.Master
{
    //[Screen("MAS070", "BOM List", eShowAction.Normal, eScreenType.ScreenPane, "BOM List")]
    public partial class MAS070_BOMList : CustomizeListPaneForm
    {
        #region Enum

        public enum eColView
        {
            UPPER_ITEM_CD,
            UPPER_ITEM_DESC,
            UPPER_ITEM_CLS,
            LOT_CONTROL_CLS,
            ORDER_PROCESS_CLS,
            ORDER_LOC_CD,
            STORE_LOC_CD,
            CHILD_ORDER_LOC_CD,
            CONSUMTION_CLS,
            SEQ,
            LOWER_ITEM_CD,
            LOWER_ITEM_DESC,
            LOWER_ITEM_CLS,
            UPPER_QTY,
            LOWER_QTY,
            BOM_STATUS,
            MRP_FLAG
        };

        #endregion

        #region Variable

        private DataTable m_dtAllData;
        #endregion

        #region Constructor

        public MAS070_BOMList()
        {
            InitializeComponent();
        }

        #endregion

        #region Overriden Method
        public override void OnAddNew()
        {
            base.OnAddNew();
            MAS050_BOMSetup frmBOM = new MAS050_BOMSetup();
            frmBOM.ShowDialog();
            LoadBOMData(txtSearch.Text.Trim());
        }

        public override void OnRefresh()
        {
            LoadBOMData(txtSearch.Text.Trim());
        }
        //public override void OnAdd ()
        //{
        //    base.OnAdd();
        //    MAS040_ItemMaster frmItemMaster = new MAS040_ItemMaster(new NZString());
        //    frmItemMaster.ShowDialog();
        //    LoadItemData(txtSearch.Text.Trim());
        //}

        #endregion

        #region Private Method

        private void InitialScreen()
        {
            //txtSearch.KeyPress += CommonLib.CtrlUtil.SetRestrictKeyInput;
            //txtSearch.KeyUp += CommonLib.CtrlUtil.FilterRestrictChar;

            InitializeComboBox();
            InitialSpread();
            LoadLookupCellType();
            LoadBOMData(string.Empty);
        }

        private void InitialSpread()
        {
            shtItemView.ActiveSkin = Common.ACTIVE_SKIN;

            CtrlUtil.MappingDataFieldWithEnum(shtItemView, typeof(eColView));
        }

        private void InitializeComboBox()
        {
            cboBOMStatus.Format += Common.ComboBox_Format;
            LookupDataBIZ bizLookup = new LookupDataBIZ();

            LookupData lookupItemType = bizLookup.LoadLookupClassType(new NZString(null, "BOM_STATUS"));
            cboBOMStatus.LoadLookupData(lookupItemType);
        }

        private void LoadLookupCellType()
        {
            LookupDataBIZ bizLookup = new LookupDataBIZ();

            // Lookup Item Type
            LookupData lookupItemType = bizLookup.LoadLookupClassType(DataDefine.ITEM_CLS.ToNZString());
            // Lookup Lot Control
            LookupData lookupLotControl = bizLookup.LoadLookupClassType(DataDefine.LOT_CONTROL_CLS.ToNZString());
            // Lookup Consumption
            LookupData lookupConsumption = bizLookup.LoadLookupClassType(new NZString(null, DataDefine.CONSUMPTION_CLS));
            // Lookup Location
            LookupData lookupLocation = bizLookup.LoadLookupLocation();


            shtItemView.Columns[(int)eColView.UPPER_ITEM_CLS].CellType = CtrlUtil.CreateReadOnlyPairCellType(lookupItemType);
            shtItemView.Columns[(int)eColView.LOWER_ITEM_CLS].CellType = CtrlUtil.CreateReadOnlyPairCellType(lookupItemType);
            shtItemView.Columns[(int)eColView.LOT_CONTROL_CLS].CellType = CtrlUtil.CreateReadOnlyPairCellType(lookupLotControl);
            shtItemView.Columns[(int)eColView.CONSUMTION_CLS].CellType = CtrlUtil.CreateReadOnlyPairCellType(lookupConsumption);
            shtItemView.Columns[(int)eColView.ORDER_PROCESS_CLS].CellType = CtrlUtil.CreateReadOnlyPairCellType(lookupLocation);
            shtItemView.Columns[(int)eColView.ORDER_LOC_CD].CellType = CtrlUtil.CreateReadOnlyPairCellType(lookupLocation);
            shtItemView.Columns[(int)eColView.STORE_LOC_CD].CellType = CtrlUtil.CreateReadOnlyPairCellType(lookupLocation);
            shtItemView.Columns[(int)eColView.CHILD_ORDER_LOC_CD].CellType = CtrlUtil.CreateReadOnlyPairCellType(lookupLocation);

        }


        private void LoadBOMData(string keyFilter)
        {
            try
            {
                BOMSetupController ctlBOM = new BOMSetupController();
                m_dtAllData = ctlBOM.LoadBOMList();
                FindDataFromMemory();
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusiness(this, ex.Message);
            }

        }

        private void DeleteBOM()
        {
            if (shtItemView.Rows.Count == 0) return;
            if (shtItemView.ActiveRowIndex < 0) return;

            NZString ItemCD = new NZString(null, shtItemView.Cells[shtItemView.ActiveRowIndex, (int)eColView.UPPER_ITEM_CD].Text);

            ItemValidator validator = new ItemValidator();
            ErrorItem errorItem = validator.CheckExistsTransactionByItem(ItemCD);
            if (errorItem != null)
            {
                MessageDialog.ShowBusiness(this, errorItem.Message);
            }

            MessageDialogResult dr = MessageDialog.ShowConfirmation(this, new EVOFramework.Message(SystemMaintenance.Messages.eConfirm.CFM9002.ToString()).MessageDescription);
            switch (dr)
            {
                case MessageDialogResult.Cancel:
                    return;

                case MessageDialogResult.No:
                    return;

                case MessageDialogResult.Yes:
                    break;
            }

            ItemController ctlItem = new ItemController();
            ctlItem.DeleteItem(ItemCD);

            shtItemView.RemoveRows(shtItemView.ActiveRowIndex, 1);
        }

        private void EditBOM()
        {
            if (!ActivePermission.Edit)
            {
                return;
            }
            if (shtItemView.Rows.Count == 0) return;
            if (shtItemView.ActiveRowIndex < 0) return;

            NZString ItemCD = new NZString(null, shtItemView.Cells[shtItemView.ActiveRowIndex, (int)eColView.UPPER_ITEM_CD].Text);
            NZString ItemName = new NZString(null, shtItemView.Cells[shtItemView.ActiveRowIndex, (int)eColView.UPPER_ITEM_DESC].Text);

            MAS050_BOMSetup frmBOMMaster = new MAS050_BOMSetup(ItemCD, ItemName);
            frmBOMMaster.ShowDialog();

            LoadBOMData(txtSearch.Text.Trim());
        }

        private void FindDataFromMemory()
        {
            shtItemView.DataSource = FilterData(m_dtAllData, txtSearch.Text);
            CtrlUtil.SpreadUpdateColumnSorting(shtItemView);
        }

        public string GenerateFilterString()
        {

            StringBuilder sb = new StringBuilder();

            //foreach (string strCol in Enum.GetNames(typeof(eColView))) {
            //    sb.AppendLine(strCol + " LIKE '%{0}%' OR");
            //}

            //if (sb.Length > 2) {
            //    sb.Length = sb.Length - 2;
            //}

            //like ตาม column ปกติ
            sb.AppendLine("(");
            sb.AppendLine(eColView.UPPER_ITEM_CD.ToString() + " LIKE '%{0}%' OR");
            sb.AppendLine(eColView.UPPER_ITEM_DESC.ToString() + " LIKE '%{0}%' OR");
            //sb.AppendLine(eColView.UPPER_ITEM_CLS.ToString() + " LIKE '%{0}%' OR");
            sb.AppendLine(eColView.LOT_CONTROL_CLS.ToString() + " LIKE '%{0}%' OR");
            sb.AppendLine(eColView.ORDER_PROCESS_CLS.ToString() + " LIKE '%{0}%' OR");
            sb.AppendLine(eColView.ORDER_LOC_CD.ToString() + " LIKE '%{0}%' OR");
            sb.AppendLine(eColView.STORE_LOC_CD.ToString() + " LIKE '%{0}%' OR");
            sb.AppendLine(eColView.CHILD_ORDER_LOC_CD.ToString() + " LIKE '%{0}%' OR");
            sb.AppendLine(eColView.CONSUMTION_CLS.ToString() + " LIKE '%{0}%' OR");
            sb.AppendLine(eColView.LOWER_ITEM_CD.ToString() + " LIKE '%{0}%' OR");
            sb.AppendLine(eColView.LOWER_ITEM_DESC.ToString() + " LIKE '%{0}%' OR");
            sb.AppendLine(eColView.LOWER_ITEM_CLS.ToString() + " LIKE '%{0}%' ");
            sb.AppendLine(")");

            //AND ตาม condition type ที่เลือก
            sb.AppendLine("AND (");
            sb.AppendLine("     (" + eColView.BOM_STATUS.ToString() + "='{1}') OR");
            sb.AppendLine("     ('ALL'='{1}') ");
            sb.AppendLine(")");

            return sb.ToString();
        }

        private DataTable FilterData(DataTable dtView, string filterText)
        {
            //if (filterText.Trim() == String.Empty)
            //    return dtView;

            //            string filterString = string.Format(@"
            //                                                ITEM_CD LIKE '%{0}%' OR 
            //                                                ITEM_DESC LIKE '%{0}%' OR 
            //                                                SHORT_NAME LIKE '%{0}%' OR 
            //                                                ITEM_CLS LIKE '%{0}%' OR 
            //                                                LOT_CONTROL_CLS LIKE '%{0}%' OR 
            //                                                ORDER_LOC_CD LIKE '%{0}%' OR                                     
            //                                                STORE_LOC_CD LIKE '%{0}%' OR
            //                                                MODEL LIKE '%{0}%' OR
            //                                                COLOR LIKE '%{0}%' OR
            //                                                MAIN_MATTERIAL LIKE '%{0}%' OR
            //                                                FOR_CUSTOMER LIKE '%{0}%' ", filterText);

            string type = "ALL";
            if (cboBOMStatus.SelectedValue != null)
            {
                type = cboBOMStatus.SelectedValue.ToString();
            }

            string filterString =
                        string.Format(GenerateFilterString(), filterText, type);

            //get only the rows you want
            DataRow[] results = m_dtAllData.Select(filterString);
            DataTable dtFilter = dtView.Clone();

            //populate new destination table
            foreach (DataRow dr in results)
                dtFilter.ImportRow(dr);

            return dtFilter;
        }
        #endregion

        #region Form Event

        private void MAS030_ItemList_Load(object sender, EventArgs e)
        {
            InitialScreen();
        }

        #endregion

        #region Control Event

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (DataDefine.ENABLED_AUTO_SEARCH_WHEN_TEXT_CHANGED)
            {
                //LoadItemData(txtSearch.Text.Trim());
                FindDataFromMemory();
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteBOM();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditBOM();
        }

        #endregion

        #region Spread Event

        private void fpItemView_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            EditBOM();
        }
        private void fpItemView_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                EditBOM();
            }
        }
        #endregion

        public override void PermissionControl()
        {
            base.PermissionControl();

            if (ActivePermission.View)
            {
                cmsItem.Items[0].Enabled = ActivePermission.Edit;
                cmsItem.Items[1].Enabled = ActivePermission.Delete;
            }
        }


        private void fpItemView_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {

                bool isClickOnCell = false;

                FarPoint.Win.Spread.Model.CellRange cellRange = fpItemView.GetCellFromPixel(0, 0, e.X, e.Y);
                if (cellRange.Column != -1 && cellRange.Row != -1)
                {
                    shtItemView.SetActiveCell(cellRange.Row, cellRange.Column);
                    shtItemView.AddSelection(cellRange.Row, cellRange.Column, 1, 1);
                    isClickOnCell = true;
                }

                if (isClickOnCell)
                {
                    editToolStripMenuItem.Enabled = ActivePermission.Edit;
                    deleteToolStripMenuItem.Enabled = ActivePermission.Delete;
                }
                else
                {
                    editToolStripMenuItem.Enabled = false;
                    deleteToolStripMenuItem.Enabled = false;
                }
                cmsItem.Show(fpItemView, e.Location);
            }

        }

        private void cboBOMStatus_SelectedValueChanged(object sender, EventArgs e)
        {
            if (DataDefine.ENABLED_AUTO_SEARCH_WHEN_DROPDROWLIST_VALUE_CHANGE)
            {
                if (m_dtAllData != null)
                {
                    FindDataFromMemory();
                }
            }
        }

        private void fpItemView_KeyDown(object sender, KeyEventArgs e)
        {
            CtrlUtil.FilterShortCut(e);
        }

    }
}
