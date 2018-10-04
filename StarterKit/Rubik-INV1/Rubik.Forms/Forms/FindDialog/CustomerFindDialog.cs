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

    public partial class CustomerFindDialog : SystemMaintenance.Forms.CustomizeBaseForm
    {
        #region Enum

        public enum eSearchType
        {
            All
        } ;

        private enum eColView
        {
            CRT_BY,
            CRT_DATE,
            CRT_MACHINE,
            UPD_BY,
            UPD_DATE,
            UPD_MACHINE,
            IS_ACTIVE,
            CUSTOMER_CODE,
            CUSTOMER_NAME,
            CUSTOMER_TYPE,
            ADDRESS,
            PHONE_NO,
            FAX,
            REMARK,
            DELIVERY_LT
        }
        #endregion

        #region Variables
        private eSearchType m_searchType = eSearchType.All;

        public CustomerDTO SelectedItem { get; set; }
        public bool IsSelected { get; set; }

        #endregion

        #region Constructor
        /// <summary>
        /// Load all lot no within current period.
        /// </summary>
        public CustomerFindDialog()
        {
            InitializeComponent();
        }
        
        #endregion

        #region InitializeScreen
        private void InitializeScreen()
        {
            shtView.ActiveSkin = Common.ACTIVE_SKIN;
            CtrlUtil.MappingDataFieldWithEnum(shtView, typeof(eColView));

            txtSearch.KeyPress += CtrlUtil.SetNextControl;

            LoadItemData(txtSearch.Text);

            IsSelected = false;
        }
        #endregion

        #region Private method
        private void LoadItemData(string keyFilter)
        {
            //set ให้ show column ทั้งหมด
            shtView.Columns[0, shtView.Columns.Count - 1].Visible = true;

            CustomerBIZ biz = new CustomerBIZ();
            CustomerDTO dto = new CustomerDTO();

            DataTable dt = null;
            if (m_searchType == eSearchType.All) {
                dt = biz.LoadCustomerAll();
                shtView.Columns[(int)eColView.CRT_BY].Visible = false;
                shtView.Columns[(int)eColView.CRT_DATE].Visible = false;
                shtView.Columns[(int)eColView.CRT_MACHINE].Visible = false;
                shtView.Columns[(int)eColView.DELIVERY_LT].Visible = false;
                shtView.Columns[(int)eColView.UPD_BY].Visible = false;
                shtView.Columns[(int)eColView.UPD_DATE].Visible = false;
                shtView.Columns[(int)eColView.UPD_MACHINE].Visible = false;
                shtView.Columns[(int)eColView.CUSTOMER_TYPE].Visible = false;
                shtView.Columns[(int)eColView.REMARK].Visible = false;
                shtView.Columns[(int)eColView.IS_ACTIVE].Visible = false;
            }            

            DataTable dtView = dt.Clone();

            if (keyFilter != string.Empty)
            {
                string [] colNames = Enum.GetNames(typeof(eColView));
                string filterString = string.Empty;

                for (int i = 0; i < colNames.Length; i++) {
                    filterString += string.Format(@"CONVERT({0},'System.String') LIKE '%{1}%' ", colNames[i], keyFilter);
                    if (i != colNames.Length - 1)
                        filterString += " OR ";
                }

                //get only the rows you want
                DataRow [] results = dt.Select(filterString);

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
            if (shtView.DataSource != null) {
                DataTable dt = (DataTable)shtView.DataSource;
                SelectedItem = DTOUtility.ConvertDataRowToDTO<CustomerDTO>(dt.Rows[rowModel]);                
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
                if (shtView.DataSource != null) {
                    DataTable dt = (DataTable)shtView.DataSource;
                    SelectedItem = DTOUtility.ConvertDataRowToDTO<CustomerDTO>(dt.Rows[rowModel]);      
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
