using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using EVOFramework;
using CommonLib;
using Rubik.BIZ;
using Rubik.DTO;
using EVOFramework.Windows.Forms;

namespace Rubik.Forms.FindDialog
{
    [Screen("DLG020", "Lot No find dialog", eShowAction.Normal, eScreenType.Screen, "Lot No find dialog")]
    public partial class LotNoFindDialog : SystemMaintenance.Forms.CustomizeBaseForm
    {
        #region Enum

        public enum eSearchType
        {
            All,
            DependOnItemAndLocation,
        } ;
        private enum eColView
        {
            PACK_NO,
            FG_NO,
            LOT_NO,
            EXTERNAL_LOT_NO,
            ON_HAND_QTY,
        }
        #endregion

        #region Variables
        private eSearchType m_searchType = eSearchType.All;

        private NZString m_itemCode = null;
        private NZString m_locationCode = null;

        public NZString SelectedLotNo { get; set; }
        public NZString SelectedPackNo { get; set; }
        public NZString SelectedFGNo { get; set; }
        public NZString SelectedExternalLotNo { get; set; }        
        public bool IsSelected { get; set; }
        #endregion

        #region Constructor
        /// <summary>
        /// Load all lot no within current period.
        /// </summary>
        public LotNoFindDialog()
        {
            InitializeComponent();
        }

        public LotNoFindDialog(NZString itemCode, NZString locationCode)
            : this()
        {
            m_searchType = eSearchType.DependOnItemAndLocation;

            m_itemCode = itemCode;
            m_locationCode = locationCode;
        }

        public LotNoFindDialog(NZString itemCode, NZString locationCode, eSearchType searchType)
            : this()
        {
            m_searchType = searchType;

            m_itemCode = itemCode;
            m_locationCode = locationCode;
        }
        #endregion

        #region InitializeScreen
        private void InitializeScreen()
        {
            shtView.ActiveSkin = Common.ACTIVE_SKIN;
            CtrlUtil.MappingDataFieldWithEnum(shtView, typeof(eColView));

            txtSearch.KeyPress += CtrlUtil.SetNextControl;

            LoadItemData(txtSearch.Text.Trim());

            IsSelected = false;
        }
        #endregion

        #region Private method
        private void LoadItemData(string keyFilter)
        {
            //set ให้ show column ทั้งหมด
            shtView.Columns[0, shtView.Columns.Count - 1].Visible = true;


            InventoryPeriodBIZ inventoryPeriodBIZ = new InventoryPeriodBIZ();
            InventoryPeriodDTO inventoryPeriodDTO = inventoryPeriodBIZ.LoadCurrentPeriod();

            DataTable dt = null;
            InventoryBIZ inventoryBIZ = new InventoryBIZ();
            if (m_searchType == eSearchType.All)
            {
                dt = inventoryBIZ.LoadAllLotNo(inventoryPeriodDTO.YEAR_MONTH);
                shtView.Columns[(int)eColView.ON_HAND_QTY].Visible = false;
            }
            else if (m_searchType == eSearchType.DependOnItemAndLocation)
            {
                dt = inventoryBIZ.LoadAllLotNoByItemAndLocation(inventoryPeriodDTO.YEAR_MONTH, m_itemCode, m_locationCode);
            }
            else
            {
                dt = inventoryBIZ.LoadAllLotNo(inventoryPeriodDTO.YEAR_MONTH);
                shtView.Columns[(int)eColView.ON_HAND_QTY].Visible = false;
            }

            DataTable dtView = dt.Clone();

            if (keyFilter != string.Empty)
            {
                //                string filterString = string.Format(@"
                //                                                {1} LIKE '%{0}%'
                //                                                OR {2} LIKE '%{0}%'
                //                                                ", keyFilter, eColView.LOT_NO, eColView.PACK_NO);

                string filterString = FilterStringUtil.GetFilterstring(dtView, keyFilter);

                //get only the rows you want
                DataRow[] results = dt.Select(filterString);

                //populate new destination table
                foreach (DataRow dr in results)
                    dtView.ImportRow(dr);
            }
            else
            {
                foreach (DataRow dr in dt.Rows)
                    dtView.ImportRow(dr);
            }
            fpView.DataSource = dtView;
        }
        #endregion

        #region Form event
        private void LotNoFindDialog_Load(object sender, EventArgs e)
        {
            InitializeScreen();
        }

        private void LotNoFindDialog_Shown(object sender, EventArgs e)
        {
            CtrlUtil.FocusControl(txtSearch);
        }
        #endregion

        #region Control event
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadItemData(txtSearch.Text.Trim());
        }

        private void fpView_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            if (shtView.Rows.Count == 0) return;
            if (shtView.ActiveRowIndex < 0) return;

            int activeRow = shtView.ActiveRowIndex;

            IsSelected = true;

            SelectedLotNo = new NZString();
            SelectedLotNo.Value = shtView.Cells[activeRow, (int)eColView.LOT_NO].Value;

            SelectedPackNo = new NZString();
            SelectedPackNo.Value = shtView.Cells[activeRow, (int)eColView.PACK_NO].Value;

            SelectedFGNo = new NZString();
            SelectedFGNo.Value = shtView.Cells[activeRow, (int)eColView.FG_NO].Value;

            SelectedExternalLotNo = new NZString();
            SelectedExternalLotNo.Value = shtView.Cells[activeRow, (int)eColView.EXTERNAL_LOT_NO].Value;

            Close();
        }



        private void fpView_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                if (shtView.Rows.Count == 0) return;
                if (shtView.ActiveRowIndex < 0) return;

                int activeRow = shtView.ActiveRowIndex;

                IsSelected = true;

                SelectedLotNo = new NZString();
                SelectedLotNo.Value = shtView.Cells[activeRow, (int)eColView.LOT_NO].Value;

                SelectedFGNo = new NZString();
                SelectedFGNo.Value = shtView.Cells[activeRow, (int)eColView.FG_NO].Value;

                SelectedPackNo = new NZString();
                SelectedPackNo.Value = shtView.Cells[activeRow, (int)eColView.PACK_NO].Value;

                SelectedExternalLotNo = new NZString();
                SelectedExternalLotNo.Value = shtView.Cells[activeRow, (int)eColView.EXTERNAL_LOT_NO].Value;

                Close();
            }
        }
        #endregion

        private void chkShowReserveLot_CheckedChanged(object sender, EventArgs e)
        {
            LoadItemData(txtSearch.Text.Trim());
        }

        private void fpView_KeyDown(object sender, KeyEventArgs e)
        {
            CtrlUtil.FilterShortCut(e);
        }


    }
}
