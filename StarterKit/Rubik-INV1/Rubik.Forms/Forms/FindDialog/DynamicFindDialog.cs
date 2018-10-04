using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using EVOFramework;
using EVOFramework.Windows.Forms;
using EVOFramework.Data;
using CommonLib;
using FarPoint.Win.Spread;
using FarPoint.Win.Spread.Model;
using Rubik.BIZ;
using EVOFramework.Database;

using Rubik.DTO;

namespace Rubik.Forms.FindDialog
{
    /// <summary>
    /// สำหรับ Multi lang จะต้องใส่เองใน TZ_SCREEN_DETAIL_DYNAMIC_DLG_LANG_MS
    /// COLTROL_CD = 0,1, 2, 3,...  สำหรับ index column ของ spread
    /// CONTROL_CD = Title สำหรับ title
    /// LANG_CD ตาม lang
    /// SCREEN_CD = ชื่อ store ที่ใช้เรียกข้อมูล
    /// </summary>

    [Screen("DLG030", "Dynamic find dialog", eShowAction.Normal, eScreenType.Screen, "Dynamic find dialog")]
    public partial class DynamicFindDialog : SystemMaintenance.Forms.CustomizeBaseForm
    {
        #region Enum

        #endregion

        #region Constants

        private const int AUTO_COMPLETE_DELAY = 500;
        private const string DEFAULT_TITLE = "Search";
        private const bool DEFAULT_SHOW_OPTION = false;
        private const bool DEFAULT_CASE_SENSITIVE = false;
        private const bool DEFAULT_SHOW_MATCH_ITEMS_ONLY = true;
        private const FormStartPosition DEFAULT_START_POSITION = FormStartPosition.CenterScreen;
        private const int MINIMUM_SCREEN_SIZE = 300;
        private const int MAXIMUM_SCREEN_SIZE = 800;
        private const int SPACE_FOR_SCOLLBAR = 50;

        private const string DB_TITLE_NAME = "TITLE";

        DataTable dtData;
        DataTable dtSearchResult;
        #endregion

        #region Variables


        private bool m_blnCloseByUser;
        private Size m_originalSize;


        #endregion

        #region Constructor

        public DynamicFindDialog() { InitializeComponent(); }

        //public DynamicFindDialog(string argStoreProcName, string strTitle, SqlParameterCollection sqlCriteria)
        //    : this(argStoreProcName, strTitle, null, sqlCriteria)
        //{
        //    // Call another constructor only
        //}

        //public DynamicFindDialog(string argStoreProcName, string strTitle, object locationControl, SqlParameterCollection sqlCriteria)
        //{
        //    try
        //    {
        //        InitializeComponent();

        //        // Initiallize screen
        //        this.ShowInTaskbar = false;
        //        this.KeyPreview = true;
        //        this.StartPosition = FormStartPosition.Manual;
        //        this.Location = new Point(-this.Width, -this.Height);
        //        this.lblTitle.Text = DEFAULT_TITLE;
        //        this.tmrAutoComplete.Interval = AUTO_COMPLETE_DELAY;

        //        // Clear data
        //        txtSearch.Text = string.Empty;
        //        //dgvData.Rows.Clear();

        //        // Initialize object members
        //        m_blnCloseByUser = false;
        //        m_blnIsSelectItem = false;
        //        m_SelectedRow = null;
        //        m_SelectedKey = "";
        //        m_startLocationControl = null;
        //        m_originalSize = this.Size;
        //        m_strColumnName_Key = string.Empty;
        //        m_strColumnName_Value = string.Empty;
        //        this.Title = strTitle;
        //        this.m_StoredProcedureName = argStoreProcName;


        //        if (locationControl != null && locationControl is Control)
        //            m_startLocationControl = (Control)locationControl;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}


        public DynamicFindDialog(string argStoreProcName, string strTitle)
            : this(argStoreProcName, strTitle, null)
        {
            // Call another constructor only
        }

        public DynamicFindDialog(string argStoreProcName, string strTitle, object locationControl)
        {
            try
            {
                InitializeComponent();

                // Initiallize screen
                this.ShowInTaskbar = true;
                this.KeyPreview = true;
                this.StartPosition = FormStartPosition.CenterScreen;
                //this.Location = new Point(-this.Width, -this.Height);

                if (strTitle != null && "".Equals(strTitle))
                {
                    this.lblTitle.Text = strTitle;
                }
                else
                {
                    this.lblTitle.Text = DEFAULT_TITLE;
                }

                this.tmrAutoComplete.Interval = AUTO_COMPLETE_DELAY;

                // Clear data
                txtSearch.Text = string.Empty;
                //dgvData.Rows.Clear();

                // Initialize object members
                m_blnCloseByUser = false;
                m_blnIsSelectItem = false;
                m_SelectedRow = null;
                m_SelectedKey = "";
                m_startLocationControl = null;
                m_originalSize = this.Size;
                m_strColumnName_Key = string.Empty;
                m_strColumnName_Value = string.Empty;
                this.Title = strTitle;
                this.m_StoredProcedureName = argStoreProcName;


                if (locationControl != null && locationControl is Control)
                    m_startLocationControl = (Control)locationControl;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        private string m_strAdditionFilter;


        #endregion

        #region Initialize Screen

        #endregion


        #region Properties

        private ParameterCollection m_Parameters;
        public ParameterCollection Parameters
        {
            get { return m_Parameters; }
            set { m_Parameters = value; }
        }

        private string m_strColumnName_Key;
        public string ColumnName_Key
        {
            get
            {
                return m_strColumnName_Key;
            }
            set
            {
                m_strColumnName_Key = value;
            }
        }

        private string m_strColumnName_Value;
        public string ColumnName_Value
        {
            get
            {
                return m_strColumnName_Value;
            }
            set
            {
                m_strColumnName_Value = value;
            }
        }

        private Control m_startLocationControl;
        public Control LocationControl
        {
            get
            {
                return m_startLocationControl;
            }
            set
            {
                m_startLocationControl = value;
            }
        }

        private DataRow m_SelectedRow;
        public DataRow SelectedRow
        {
            get { return m_SelectedRow; }
        }

        private string m_SelectedKey;
        public string SelectedKey
        {
            get
            {
                if (m_SelectedKey == null)
                    m_SelectedKey = "";

                return m_SelectedKey;
            }
        }


        private bool m_blnIsSelectItem;
        public bool IsSelectItem
        {
            get
            {
                return m_blnIsSelectItem;
            }
        }

        public string Title
        {
            get
            {
                return lblTitle.Text;
            }
            set
            {
                if (value == null)
                    value = string.Empty;

                lblTitle.Text = value;
            }
        }

        private string m_StoredProcedureName;

        #endregion

        #region Handles and Overrides

        public string AdditionFilter
        {
            set { m_strAdditionFilter = value; }
            get { return m_strAdditionFilter; }
        }

        private void DynamicFindDialog_Load(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.SuspendLayout();

                shtData.ActiveSkin = CommonLib.Common.ACTIVE_SKIN;

                BindData();


                UpdateColumnText();
                //CalculateScreenSize();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.ResumeLayout();
                this.Cursor = Cursors.Default;
            }
        }

        private void DynamicFindDialog_Activated(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.SuspendLayout();

                m_blnCloseByUser = false;
                m_blnIsSelectItem = false;
                m_SelectedRow = null;
                m_SelectedKey = "";

                UpdateControls();
                //SetLocation(true);
                // AutoComplete();

                txtSearch.Focus();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.ResumeLayout();
                this.Cursor = Cursors.Default;
            }
        }

        private void DynamicFindDialog_Deactivate(object sender, EventArgs e)
        {
            try
            {
                if (!m_blnCloseByUser)
                {
                    //CloseForm(false);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void DynamicFindDialog_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Escape)
                {
                    CloseForm(false);
                }
                else if (e.KeyCode == Keys.Enter)
                {
                    if (this.ActiveControl == txtSearch)
                    {
                        AutoComplete();
                        fpData.Focus();
                    }
                    else if (this.ActiveControl == fpData)
                        if (shtData.ActiveRowIndex < 0)
                            txtSearch.Focus();
                        else
                            CloseForm(true);
                    else
                        txtSearch.Focus();
                }
                else if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
                {
                    if (this.ActiveControl == txtSearch)
                        fpData.Focus();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                tmrAutoComplete.Enabled = true;

                tmrAutoComplete.Stop();
                tmrAutoComplete.Start();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void tmrAutoComplete_Tick(object sender, EventArgs e)
        {
            try
            {
                AutoComplete();

                tmrAutoComplete.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusiness(this, ex.Message);
            }
        }

        protected void UpdateColumnText()
        {
            if (this.m_StoredProcedureName == string.Empty)
                return;

            ScreenDetailDynamicDialogLangBIZ bizScreenDetailLang = new ScreenDetailDynamicDialogLangBIZ();

            string langCD = CommonLib.Common.SystemLanguage.StrongValue;

            if (CommonLib.Common.CurrentUserInfomation != null)
                langCD = CommonLib.Common.CurrentUserInfomation.LanguageCD.StrongValue;

            // Load screen detail depend on language.
            List<ScreenDetailDynamicDialogLangDTO> listScreenDetailLang = bizScreenDetailLang.LoadScreenDetailByLangCD(this.m_StoredProcedureName, langCD);
            foreach (ScreenDetailDynamicDialogLangDTO objScreenLang in listScreenDetailLang)
            {
                int iColumnIndex = 0;

                if (Int32.TryParse(objScreenLang.CONTROL_CD, out iColumnIndex))
                {
                    if (shtData.Columns.Count > iColumnIndex)
                    {
                        if (objScreenLang.CONTROL_CAPTION != null)
                        {
                            shtData.Columns[iColumnIndex].Label = objScreenLang.CONTROL_CAPTION.NVL(" ");
                        }
                    }
                    else
                    {
                        //ถ้า column มากกว่า lang ที่ set ไว้ ก็ไม่ต้อง set อะไร
                    }
                }
                else if (DB_TITLE_NAME.Equals(objScreenLang.CONTROL_CD, StringComparison.CurrentCultureIgnoreCase))
                {
                    if (!objScreenLang.CONTROL_CAPTION.IsNull)
                    {
                        lblTitle.Text = objScreenLang.CONTROL_CAPTION.StrongValue;
                    }
                }
            }
        }



        #endregion

        #region User Defines

        private void UpdateControls()
        {
            try
            {

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void SetLocation(bool includeValidateLocation)
        {
            Point pntLocation;

            try
            {
                if (m_startLocationControl != null)
                    pntLocation = m_startLocationControl.PointToScreen(new Point(m_startLocationControl.Width, 0));
                else
                    pntLocation = Cursor.Position;

                //this.StartPosition = FormStartPosition.Manual;
                this.StartPosition = FormStartPosition.CenterScreen;


                this.Location = pntLocation;

                if (includeValidateLocation)
                    ValidateLocation();
            }
            catch (Exception ex)
            {
                this.StartPosition = DEFAULT_START_POSITION;
            }
        }

        private void ValidateLocation()
        {
            Point pntLocation;

            try
            {
                pntLocation = this.Location;

                if ((pntLocation.X + this.Width) > Screen.PrimaryScreen.WorkingArea.Width)
                    pntLocation.X = Screen.PrimaryScreen.WorkingArea.Width - this.Width;

                if ((pntLocation.Y + this.Height) > Screen.PrimaryScreen.WorkingArea.Height)
                    pntLocation.Y = Screen.PrimaryScreen.WorkingArea.Height - this.Height;

                this.StartPosition = FormStartPosition.CenterScreen;
                this.Location = pntLocation;
            }
            catch (Exception ex)
            {
                this.StartPosition = DEFAULT_START_POSITION;
            }
        }

        private void AutoComplete()
        {
            string strSearch;


            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.SuspendLayout();

                strSearch = txtSearch.Text.Trim();
                strSearch = strSearch.Replace("'", "''");

                shtData.ActiveColumnIndex = -1;
                shtData.ActiveRowIndex = -1;

                if (strSearch.Length > 0)
                {

                    string strCol1 = dtData.Columns[0].ColumnName;
                    string strCol2 = dtData.Columns[1].ColumnName;
                    DataTable dtTmpData = dtData.Copy();
                    DataView dv = dtTmpData.DefaultView;


                    dv.RowFilter = GetRowFilterString(dv, strSearch);
                    //dv.RowFilter = "[" + strCol1 + "] LIKE '%" + strSearch + "%' OR [" + strCol2 + "] LIKE '%" + strSearch + "%' ";

                    dtSearchResult = dv.ToTable();

                    fpData.DataSource = dtSearchResult;

                    //                   DefaultSheetDataModel model = new DefaultSheetDataModel( dv.ToTable());
                    //fpData.Sheets[0] = model 

                }
                else
                {
                    //ถ้าไม่ใส่ keyword ให้ไม่ต้อง filter
                    DataTable dtTmpData = dtData.Copy();
                    DataView dv = dtTmpData.DefaultView;
                    dv.RowFilter = "";

                    dtSearchResult = dv.ToTable();

                    fpData.DataSource = dtSearchResult;
                }
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusiness(this, ex.Message);
            }
            finally
            {
                this.ResumeLayout();
                this.Cursor = Cursors.Default;
            }
        }

        private void SetHeaderColumn(DataTable argDataTable)
        {
            fpData.DataSource = argDataTable;

            if (argDataTable != null)
            {
                //int iColCount = 0;
                //foreach (DataColumn dc in argDataTable.Columns)
                //{
                //    try
                //    {
                //        shtData.ColumnHeader.Columns[iColCount].Label = dc.ColumnName;
                //    }
                //    catch
                //    {
                //        shtData.ColumnHeader.Columns[iColCount].Label = "Col" + iColCount + 1;
                //    }

                //    iColCount++;

                //}

                //if (argDataTable.Columns.Count >= 2)
                //{
                //    dgvData.Columns[0].HeaderText = argDataTable.Columns[0].ColumnName;
                //    dgvData.Columns[1].HeaderText = argDataTable.Columns[1].ColumnName;

                //    argDataTable.Columns[0].ColumnName = "Col1";
                //    argDataTable.Columns[1].ColumnName = "Col2";

                //}
                //else if (argDataTable.Columns.Count >= 1)
                //{
                //    dgvData.Columns[0].HeaderText = argDataTable.Columns[0].ColumnName;

                //    argDataTable.Columns[0].ColumnName = "Col1";
                //}
            }


        }

        private void CloseForm(bool isSuccess)
        {
            try
            {


                if (isSuccess && shtData.RowCount > 0)
                {
                    m_blnIsSelectItem = true;
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    m_blnIsSelectItem = false;
                    this.DialogResult = DialogResult.Cancel;
                }

                if (shtData.ActiveRowIndex > -1 && shtData.RowCount > 0)
                {
                    m_SelectedRow = dtSearchResult.Rows[shtData.GetModelRowFromViewRow(shtData.ActiveRowIndex)];

                    if (m_SelectedRow[0].Equals(DBNull.Value))
                    {
                        m_SelectedKey = "";
                    }
                    else
                    {
                        m_SelectedKey = m_SelectedRow[0].ToString();
                    }
                }
                else
                {
                    m_SelectedRow = null;
                    m_SelectedKey = "";
                }

                m_blnCloseByUser = true;
                this.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string GetRowFilterString(DataView argDataView, string argKeyword)
        {
            StringBuilder sb = new StringBuilder();

            DataColumnCollection columns = argDataView.Table.Columns;

            foreach (DataColumn dc in columns)
            {
                sb.Append("[" + dc.ColumnName + "] LIKE '%" + argKeyword + "%' OR");
                //dv.RowFilter = "[" + strCol1 + "] LIKE '%" + strSearch + "%' OR [" + strCol2 + "] LIKE '%" + strSearch + "%' ";
            }

            if (sb.Length > 2)
            {
                sb.Remove(sb.Length - 2, 2);
            }


            return sb.ToString();
        }

        private void BindData()
        {
            SearchDialogBIZ biz = new SearchDialogBIZ();


            DataTable dt = biz.searchData(this.m_StoredProcedureName, m_Parameters);

            dtData = dt.Copy();

            DataView dv = dtData.DefaultView;
            dv.RowFilter = m_strAdditionFilter;

            dtData = dv.ToTable();
            dtSearchResult = dv.ToTable();

            fpData.DataSource = dtSearchResult;

            shtData.Columns[0].Visible = false;
            shtData.ActiveRowIndex = -1;
            shtData.ActiveColumnIndex = -1;

        }


        #endregion



        private void CalculateScreenSize()
        {
            decimal decTotalDataGridColumnSize = 0;

            for (int iCol = 0; iCol < this.shtData.ColumnHeader.Columns.Count; iCol++)
            {
                if (shtData.ColumnHeader.Columns[iCol].Visible)
                {
                    decTotalDataGridColumnSize += (decimal)shtData.ColumnHeader.Columns[iCol].Width;
                }

                //shtData.ColumnHeader.Columns[0].
                //if (col.Visible)
                //{
                //    decTotalDataGridColumnSize += col.Width;
                //}
            }



            if (decTotalDataGridColumnSize > MINIMUM_SCREEN_SIZE && decTotalDataGridColumnSize < MAXIMUM_SCREEN_SIZE)
            {
                this.Width = ((int)decTotalDataGridColumnSize) + SPACE_FOR_SCOLLBAR;
            }
            else if (decTotalDataGridColumnSize <= MINIMUM_SCREEN_SIZE)
            {
                this.Width = MINIMUM_SCREEN_SIZE + SPACE_FOR_SCOLLBAR;
            }
            else if (decTotalDataGridColumnSize >= MINIMUM_SCREEN_SIZE)
            {
                this.Width = MAXIMUM_SCREEN_SIZE + SPACE_FOR_SCOLLBAR;
            }
        }

        private void fpData_CellDoubleClick(object sender, CellClickEventArgs e)
        {
            try
            {
                if (shtData.Rows.Count == 0) return;
                if (shtData.ActiveRowIndex < 0) return;


                CloseForm(true);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void DynamicFindDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            //try
            //{
            //    CloseForm(false);
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
        }

        private void fpData_KeyDown(object sender, KeyEventArgs e)
        {
            CtrlUtil.FilterShortCut(e);
        }




    }
}
