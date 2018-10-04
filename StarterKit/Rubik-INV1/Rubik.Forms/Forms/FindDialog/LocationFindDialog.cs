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
using Rubik.Data;
using EVOFramework.Data;

namespace Rubik.Forms.FindDialog
{

    public partial class LocationFindDialog : SystemMaintenance.Forms.CustomizeBaseForm
    {
        #region Enum

        public enum eSearchType
        {
            All
        } ;

        private enum eColFilter
        {
            LOC_CD,
            LOC_DESC,
            LOC_CLS,
        }
        private enum eColView
        {
            CRT_BY,
            CRT_DATE,
            CRT_MACHINE,
            UPD_BY,
            UPD_DATE,
            UPD_MACHINE,

            LOC_CD,
            LOC_DESC,
            LOC_CLS,

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

            ALLOW_NEGATIVE,
            //OLD_DATA,
            //ORDER_SEQ,
            //TIME_STAMP,
        }
        #endregion

        #region Variables

        //private eSearchType m_searchType = eSearchType.All;
        private NZString[] m_LocationType;
        DataTable m_dtAllData;
        public DealingDTO SelectedItem { get; set; }
        public bool IsSelected { get; set; }

        #endregion

        #region Constructor

        public LocationFindDialog()
        {
            InitializeComponent();
        }
        public LocationFindDialog(NZString[] LocationType)
            : this()
        {

            m_LocationType = LocationType;
        }

        #endregion

        #region InitializeScreen
        private void InitializeScreen()
        {
            shtView.ActiveSkin = Common.ACTIVE_SKIN;

            CtrlUtil.MappingDataFieldWithEnum(shtView, typeof(eColView));

            txtSearch.KeyPress += CtrlUtil.SetNextControl;

            //------------ Location --------------------//           
            LookupDataBIZ m_bizLookupData = new LookupDataBIZ();
            //LookupData locationData = m_bizLookupData.LoadLookupLocation(null, null);
            LookupData locationData = m_bizLookupData.LoadLookupClassType(DataDefine.LOCATION_CLS.ToNZString());
            shtView.Columns[(int)eColView.LOC_CLS].CellType = CtrlUtil.CreateReadOnlyPairCellType(locationData);

            LoadItemData(txtSearch.Text);

            IsSelected = false;
        }
        #endregion

        #region Private method
        private void LoadItemData(string keyFilter)
        {
            //set ให้ show column ทั้งหมด
            //shtView.Columns[0, shtView.Columns.Count - 1].Visible = true;

            DealingBIZ biz = new DealingBIZ();
            DealingDTO dto = new DealingDTO();

            //DataTable dt = null;

            if (m_LocationType != null && m_LocationType.Length > 0)
            {
                m_dtAllData = biz.LoadByLocationType(m_LocationType);
            }
            else
            {
                m_dtAllData = DTOUtility.ConvertListToDataTable<DealingDTO>(biz.LoadAllLocations(false));
            }

            FindDataFromMemory();

            //shtView.Columns[(int)eColView.CRT_BY].Visible = false;
            //shtView.Columns[(int)eColView.CRT_DATE].Visible = false;
            //shtView.Columns[(int)eColView.CRT_MACHINE].Visible = false;                
            //shtView.Columns[(int)eColView.UPD_BY].Visible = false;
            //shtView.Columns[(int)eColView.UPD_DATE].Visible = false;
            //shtView.Columns[(int)eColView.UPD_MACHINE].Visible = false;
            //shtView.Columns[(int)eColView.ALLOW_NEGATIVE].Visible = false;
            //shtView.Columns[(int)eColView.MRP_LOCATION].Visible = false;            

            //DataTable dtView = dt.Clone();

            //if (keyFilter != string.Empty)
            //{
            //    string [] colNames = Enum.GetNames(typeof(eColView));
            //    string filterString = string.Empty;

            //    for (int i = 0; i < colNames.Length; i++) {
            //        filterString += string.Format(@"CONVERT({0},'System.String') LIKE '%{1}%' ", colNames[i], keyFilter);
            //        if (i != colNames.Length - 1)
            //            filterString += " OR ";
            //    }

            //    //get only the rows you want
            //    DataRow [] results = dt.Select(filterString);

            //    //populate new destination table
            //    foreach (DataRow dr in results)
            //        dtView.ImportRow(dr);
            //}
            //else
            //{
            //    foreach (DataRow dr in dt.Rows)
            //        dtView.ImportRow(dr);
            //}
            //fpView.DataSource = dtView;
        }
        private void FindDataFromMemory()
        {
            shtView.DataSource = FilterData(m_dtAllData, txtSearch.Text);
            CtrlUtil.SpreadUpdateColumnSorting(shtView);
        }

        private DataTable FilterData(DataTable dtView, string filterText)
        {
            if (filterText.Trim() == String.Empty)
                return dtView;

            //string[] colNames = Enum.GetNames(typeof(eColView));
            string[] colNames = Enum.GetNames(typeof(eColFilter));
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

        #endregion

        #region Form event
        private void CustomerFindDialog_Load(object sender, EventArgs e)
        {
            InitializeScreen();
        }

        private void CustomerFindDialog_Shown(object sender, EventArgs e)
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

            int rowModel = shtView.GetModelRowFromViewRow(activeRow);
            if (shtView.DataSource != null)
            {
                DataTable dt = (DataTable)shtView.DataSource;
                SelectedItem = DTOUtility.ConvertDataRowToDTO<DealingDTO>(dt.Rows[rowModel]);
            }

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

                int rowModel = shtView.GetModelRowFromViewRow(activeRow);
                if (shtView.DataSource != null)
                {
                    DataTable dt = (DataTable)shtView.DataSource;
                    SelectedItem = DTOUtility.ConvertDataRowToDTO<DealingDTO>(dt.Rows[rowModel]);
                }

                Close();
            }
        }
        #endregion

        private void fpView_KeyDown(object sender, KeyEventArgs e)
        {
            CtrlUtil.FilterShortCut(e);
        }


    }
}
