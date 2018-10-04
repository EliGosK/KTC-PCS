using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using EVOFramework;
using Rubik.BIZ;
using EVOFramework.Windows.Forms;
using EVOFramework.Data;
using Rubik.Controller;
using Rubik.UIDataModel;
using CommonLib;
using SystemMaintenance.Forms;
using Rubik.DTO;

namespace Rubik.Forms.FindDialog
{
    [Screen("DLG010", "Part find dialog", eShowAction.Normal, eScreenType.Screen, "Part find dialog")]
    public partial class ItemFindDialog : CustomizeBaseForm
    {
        #region Enum
        public enum eColView
        {
            ITEM_CD,
            SHORT_NAME,
            CUSTOMER_CD,
            LOC_DESC
        };

        private enum eLoadType
        {
            WithOperator,
            WithConsumptionList,
        }


        #endregion

        #region Variables
        public ItemUIDM SelectedItem { get; set; }
        public bool IsSelected { get; set; }
        private string[] ItemTypes;
        private eSqlOperator m_sqlOperator = eSqlOperator.In;
        private eLoadType m_loadType = eLoadType.WithOperator;
        private NZString m_itemCode = new NZString();
        private NZString m_DealingCode = new NZString();
        private DataDefine.eDealingType m_DealingType;

        #endregion

        #region Constructor

        public ItemFindDialog() { InitializeComponent(); }

        public ItemFindDialog(eSqlOperator sqlOperator, eItemType[] eItemTypes, NZString argDealingCode, DataDefine.eDealingType argDealingType)
            : this(sqlOperator, eItemTypes)
        {

            m_DealingType = argDealingType;

            if (argDealingCode != null && !argDealingCode.IsNull)
            {
                this.m_DealingCode = argDealingCode;
            }
            else
            {
                this.m_DealingCode = new NZString(null, "");
            }
        }

        public ItemFindDialog(eSqlOperator sqlOperator, eItemType[] eItemTypes)
        {
            InitializeComponent();

            SelectedItem = new ItemUIDM();

            m_sqlOperator = sqlOperator;

            if (eItemTypes != null && eItemTypes.Length > 0)
            {
                if (eItemTypes.Length == 1 && eItemTypes[0] == eItemType.All)
                {
                    ItemTypes = new string[] { "SHAFT", "SCREW", "WASHER" };
                }
                else
                {
                    ItemTypes = new string[eItemTypes.Length];
                    for (int i = 0; i < eItemTypes.Length; i++)
                    {
                        //ItemTypes[i] = string.Format("{0:00}", (int)eItemTypes[i]);
                        ItemTypes[i] = eItemTypes[i].ToString();
                    }
                }
            }

        }
        #endregion

        #region Initialize Screen
        private void InitialScreen()
        {
            //txtSearch.KeyPress += CtrlUtil.SetRestrictKeyInput;

            shtItemView.ActiveSkin = CommonLib.Common.ACTIVE_SKIN;

            CtrlUtil.MappingDataFieldWithEnum(shtItemView, typeof(eColView));
            this.shtItemView.Columns[(int)eColView.LOC_DESC].Visible = false;

            LoadLookupCellType();
            LoadItemData(string.Empty);

            IsSelected = false;
        }
        private void LoadLookupCellType()
        {
            LookupDataBIZ bizLookup = new LookupDataBIZ();

            LookupData locationLookup = bizLookup.LoadLookupLocation();
            this.shtItemView.Columns[(int)eColView.CUSTOMER_CD].CellType = CtrlUtil.CreateReadOnlyPairCellType(locationLookup);

            //// Lookup Item Type
            //LookupData lookupItemType = bizLookup.LoadLookupClassType(new NZString(null, DataDefine.ITEM_CLS));

            //// Lookup Lot Control
            //LookupData lookupLotControl = bizLookup.LoadLookupClassType(new NZString(null, DataDefine.LOT_CONTROL_CLS));

            //ReadOnlyPairCellType ItemTypecellType = new ReadOnlyPairCellType(lookupItemType, CommonLib.Common.COMBOBOX_SEPERATOR_SYMBOL);
            //shtItemView.Columns[(int)eColView.ITEM_CLS].CellType = ItemTypecellType;

            //shtItemView.Columns[(int)eColView.ITEM_CLS_MINOR].CellType = CtrlUtil.CreateReadOnlyPairCellType(bizLookup.LoadLookupClassType((NZString)DataDefine.ITEM_CLS_MINOR04));
            //ReadOnlyPairCellType LotControlcellType = new ReadOnlyPairCellType(lookupLotControl, CommonLib.Common.COMBOBOX_SEPERATOR_SYMBOL);
            //shtItemView.Columns[(int)eColView.LOT_CONTROL_CLS].CellType = LotControlcellType;
        }
        private void LoadItemData(string keyFilter)
        {
            try
            {
                ItemController ctlItem = new ItemController();

                if (m_DealingCode.IsNull)
                {
                    m_dtAllData = ctlItem.LoadAllItem(m_sqlOperator, ItemTypes);
                }
                else
                {
                    m_dtAllData = ctlItem.LoadAllItem(m_sqlOperator, ItemTypes, m_DealingCode, m_DealingType);
                }


                //List<ItemDTO> list = ctlItem.LoadAllItem();
                //if (list == null || list.Count == 0)
                //    return;

                //m_dtAllData = DTOUtility.ConvertListToDataTable(list);

                //if (m_loadType == eLoadType.WithOperator)
                //{
                //    if (m_DealingCode.IsNull)
                //    {
                //        m_dtAllData = ctlItem.LoadAllItem(m_sqlOperator, ItemTypes);
                //    }
                //    else
                //    {
                //        m_dtAllData = ctlItem.LoadAllItem(m_sqlOperator, ItemTypes, m_DealingCode, m_DealingType);
                //    }
                //}
                //else
                //{
                //    m_dtAllData = ctlItem.LoadConsumptionListOfItem(m_itemCode);
                //}
                FindDataFromMemory();

                //                DataTable dtView = dt.Clone();

                //                if (keyFilter != string.Empty)
                //                {
                //                    string filterString = string.Format(@"ITEM_CD LIKE '%{0}%' OR 
                //                                                ITEM_DESC LIKE '%{0}%' OR 
                //                                                ITEM_CLS LIKE '%{0}%' OR 
                //                                                LOT_CONTROL_CLS LIKE '%{0}%' OR 
                //                                                INV_UM_CLS LIKE '%{0}%' OR 
                //                                                ORDER_UM_CLS LIKE '%{0}%' OR 
                //                                                
                //                                                MODEL LIKE '%{0}%' OR 
                //                                                COLOR LIKE '%{0}%' OR 
                //                                                MAIN_MATTERIAL LIKE '%{0}%' OR 
                //                                                FOR_CUSTOMER LIKE '%{0}%' OR 
                //                                                ITEM_8_DIGITS LIKE '%{0}%' OR 
                //                                                ITEM_CLS_MINOR LIKE '%{0}%' OR 
                //                                                ORDER_LOC_CD LIKE '%{0}%' OR 
                //                                                STORE_LOC_CD LIKE '%{0}%' OR 
                //                                                ORDER_PROCESS_CLS LIKE '%{0}%' OR 
                //                                                ORDER_LOC_CD LIKE '%{0}%' OR 
                //                                                STORE_LOC_CD LIKE '%{0}%' OR 
                //                                                
                //                                                CONSUMTION_CLS LIKE '%{0}%'
                //
                //                                                ", keyFilter);

                //                    //INV_UM_RATE LIKE '%{0}%' OR 
                //                    //ORDER_UM_RATE LIKE '%{0}%' OR 
                //                    //PACK_SIZE LIKE '%{0}%' OR 

                //                    //get only the rows you want
                //                    DataRow[] results = dt.Select(filterString);

                //                    //populate new destination table
                //                    foreach (DataRow dr in results)
                //                        dtView.ImportRow(dr);
                //                }
                //else
                //{
                //    foreach (DataRow dr in dt.Rows)
                //        dtView.ImportRow(dr);
                //}
                //fpItemView.DataSource = dtView;
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusiness(this, ex.Message);
            }

        }
        //private void MapSpreadData()
        //{
        //    string[] names = Enum.GetNames(typeof(eColView));

        //    // check if data field and columns count is not equal
        //    if (names.Length != shtItemView.Columns.Count) return;

        //    for (int i = 0; i < names.Length; i++)
        //    {
        //        shtItemView.Columns[i].DataField = names[i];
        //        shtItemView.Columns[i].Locked = true;
        //    }
        //}
        #endregion

        #region Form event
        private void ItemFindDialog_Load(object sender, EventArgs e)
        {
            InitialScreen();
        }
        #endregion

        #region Control event
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            FindDataFromMemory();
        }
        DataTable m_dtAllData;
        private void FindDataFromMemory()
        {
            shtItemView.DataSource = FilterData(m_dtAllData, txtSearch.Text);
            CtrlUtil.SpreadUpdateColumnSorting(shtItemView);
        }

        private DataTable FilterData(DataTable dtView, string filterText)
        {
            if (filterText.Trim() == String.Empty)
                return dtView;

            string[] colNames = Enum.GetNames(typeof(eColView));
            string filterString = string.Empty;

            //for (int i = 0; i < colNames.Length; i++)
            //{
            //    filterString += string.Format(@"CONVERT({0},'System.String') LIKE '%{1}%' ", colNames[i], filterText);
            //    if (i != colNames.Length - 1)
            //        filterString += " OR ";
            //}

            filterString = FilterStringUtil.GetFilterstring(typeof(eColView), filterText);

            //get only the rows you want
            DataRow[] results = m_dtAllData.Select(filterString);
            DataTable dtFilter = dtView.Clone();

            //populate new destination table
            foreach (DataRow dr in results)
                dtFilter.ImportRow(dr);

            return dtFilter;
        }
        private void fpItemView_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            //EditItem();
            if (shtItemView.Rows.Count == 0) return;
            if (shtItemView.ActiveRowIndex < 0) return;

            int activeRow = shtItemView.ActiveRowIndex;

            IsSelected = true;

            int rowModel = shtItemView.GetModelRowFromViewRow(activeRow);
            if (shtItemView.DataSource != null)
            {
                DataTable dt = (DataTable)shtItemView.DataSource;
                SelectedItem = DTOUtility.ConvertDataRowToDTO<ItemUIDM>(dt.Rows[rowModel]);
            }

            //SelectedItem.ITEM_CD.Value = shtItemView.Cells[activeRow, (int)eColView.ITEM_CD].Text;
            //SelectedItem.ITEM_DESC.Value = shtItemView.Cells[activeRow, (int)eColView.ITEM_DESC].Text;
            //SelectedItem.ITEM_TYPE.Value = shtItemView.Cells[activeRow, (int)eColView.ITEM_CLS].Value;
            //SelectedItem.LOT_CONTROL_CLS.Value = shtItemView.Cells[activeRow, (int)eColView.LOT_CONTROL_CLS].Value;
            //SelectedItem.ORDER_LOC_CD.Value = shtItemView.Cells[activeRow, (int)eColView.ORDER_LOC_CD].Text;
            //SelectedItem.STORE_LOC_CD.Value = shtItemView.Cells[activeRow, (int)eColView.STORE_LOC_CD].Text;

            this.Close();
            //SelectedItem.CRT_BY.Value = shtItemView.Cells[activeRow, (int)eColView.CRT_BY].Text;
            //SelectedItem.CRT_DATE.Value = shtItemView.Cells[activeRow, (int)eColView.CRT_DATE].Text;
            //SelectedItem.CRT_MACHINE.Value = shtItemView.Cells[activeRow, (int)eColView.CRT_MACHINE].Text;
            //SelectedItem.UPD_BY.Value = shtItemView.Cells[activeRow, (int)eColView.UPD_BY].Text;
            //SelectedItem.UPD_DATE.Value = shtItemView.Cells[activeRow, (int)eColView.UPD_DATE].Text;
            //SelectedItem.UPD_MACHINE.Value = shtItemView.Cells[activeRow, (int)eColView.UPD_MACHINE].Text;
        }
        #endregion

        #region Static ShowDialog method
        public static ItemFindDialog ShowDialogWithOperator(eSqlOperator sqlOperator, eItemType[] eItemTypes)
        {
            return ShowDialogWithOperator(null, sqlOperator, eItemTypes);
        }
        public static ItemFindDialog ShowDialogWithOperator(IWin32Window window, eSqlOperator sqlOperator, eItemType[] eItemTypes)
        {
            ItemFindDialog dialog = new ItemFindDialog(sqlOperator, eItemTypes);
            dialog.m_loadType = eLoadType.WithOperator;

            dialog.ShowDialog(window);
            return dialog;
        }

        public static ItemFindDialog ShowDialogWithOperator(eSqlOperator sqlOperator, eItemType[] eItemTypes, NZString argDealingCode, DataDefine.eDealingType argDealingType)
        {
            return ShowDialogWithOperator(null, sqlOperator, eItemTypes, argDealingCode, argDealingType);
        }

        public static ItemFindDialog ShowDialogWithOperator(IWin32Window window, eSqlOperator sqlOperator, eItemType[] eItemTypes, NZString argDealingCode, DataDefine.eDealingType argDealingType)
        {
            ItemFindDialog dialog = new ItemFindDialog(sqlOperator, eItemTypes, argDealingCode, argDealingType);
            dialog.m_loadType = eLoadType.WithOperator;

            dialog.ShowDialog(window);
            return dialog;
        }

        public static ItemFindDialog ShowDialogConsumptionListOfItem(NZString itemCode)
        {
            return ShowDialogConsumptionListOfItem(null, itemCode);
        }
        public static ItemFindDialog ShowDialogConsumptionListOfItem(IWin32Window window, NZString itemCode)
        {
            ItemFindDialog dialog = new ItemFindDialog(eSqlOperator.In, null);

            dialog.m_loadType = eLoadType.WithConsumptionList;
            dialog.m_itemCode = itemCode;

            dialog.ShowDialog(window);
            return dialog;
        }
        #endregion

        private void fpItemView_KeyDown(object sender, KeyEventArgs e)
        {
            CtrlUtil.FilterShortCut(e);
        }

    }
}
