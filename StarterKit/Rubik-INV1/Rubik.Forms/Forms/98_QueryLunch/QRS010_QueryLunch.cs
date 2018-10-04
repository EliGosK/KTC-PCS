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
using System.IO;


namespace Rubik.QueryLunch
{

    [Screen("QRS010", "Query Lunch", eShowAction.Normal, eScreenType.ScreenPane, "Query Lunch")]
    public partial class QRS010_QueryLunch : SystemMaintenance.Forms.CustomizeListPaneBaseForm
    {

        #region Enum
        public enum eColQueryList
        {
            ID,
            Name
        }
        #endregion

        #region Variables

        private DataTable m_dtAllData;
        private DataTable m_dtQueryList;

        #endregion

        #region Constructor
        public QRS010_QueryLunch()
        {
            InitializeComponent();
            InitializeScreen();
        }
        #endregion

        #region InitializeScreen
        private void InitializeScreen()
        {
            InitializeSpread();
        }

        private void InitializeSpread()
        {
            shtView.ActiveSkin = Common.ACTIVE_SKIN;
        }
        #endregion

        #region Private method

        #endregion

        #region Form event

        #endregion

        #region Control event

        #region Screen control

        public override void OnRefresh()
        {
            base.OnRefresh();

            LoadData();
        }

        public override void OnExport()
        {
            if (shtQueryList.ActiveRowIndex == -1)
            {
                return;
            }

            if (m_dtAllData == null)
            {
                MessageBox.Show("ให้ทำการค้นหาข้อมูลก่อน export");
                return;
            }

            string strReportID = "";
            strReportID = shtQueryList.Cells[shtQueryList.ActiveRowIndex, (int)eColQueryList.ID].Text;



            string strFileName = GenerateFileName(strReportID);

            string strTemplateFileName = @"Report\" + this.txtTemplate.Text;
            string strTemplatePath = Path.Combine(Application.StartupPath, strTemplateFileName);

            string strExportPath = SaveDialogUtil.GetBrowseFileDialogForExport(strFileName);

            if (!"".Equals(strExportPath))
            {


                DataSet ds = new DataSet();
                ds.Tables.Add(this.m_dtAllData.Copy());

                //ExportUtil.Export(ds, @"c:\testExport0.xls");


                if (File.Exists(strTemplatePath))
                {
                    ExportUtil.Export(ds, strTemplatePath, strExportPath, ExportUtil.Format, Convert.ToInt32(txtStartColumn.Text), Convert.ToInt32(txtStartRow.Text));
                }
                else
                {
                    ExportUtil.Export(ds, strExportPath, ExportUtil.Format, Convert.ToInt32(txtStartColumn.Text), Convert.ToInt32(txtStartRow.Text));
                }

                MessageDialogResult mdr = MessageDialog.ShowConfirmation(this, "บันทึกเสร็จแล้ว ต้องการเปิดไฟล์หรือไม่", EVOFramework.Windows.Forms.MessageDialogButtons.YesNo);

                if (mdr == MessageDialogResult.Yes)
                {
                    System.Diagnostics.Process.Start(strExportPath);
                }
            }
        }


        #endregion



        #region Spread

        #endregion

        #endregion

        #region Operation

        #endregion

        public override void PermissionControl()
        {
            base.PermissionControl();
        }

        private void LoadData()
        {
            try
            {

                QueryLunchDTO dto = new QueryLunchDTO();
                dto.SQLCommand = this.txtSearch.Text.ToNZString();


                QueryLunchBiz biz = new QueryLunchBiz();
                DataSet dsResult = biz.ExecuteSQLCommand(dto);

                this.m_dtAllData = null;
                this.shtView.DataSource = null;
                this.shtView.RowCount = 0;
                this.shtView.ColumnCount = 0;

                if (dsResult.Tables.Count > 0)
                {
                    if (dsResult.Tables[0].Rows.Count > 0)
                    {

                        this.m_dtAllData = dsResult.Tables[0];

                        this.shtView.DataSource = m_dtAllData;
                    }
                    else
                    {

                        MessageBox.Show("หาไม่เจอเว้ยยยยยยยย");
                    }
                }
                else
                {
                    MessageBox.Show("query ภาษาอะไรวะ");
                }
            }
            catch (DataAccessException ex)
            {
                MessageBox.Show("ไปเรียน Query ใหม่ซะไป๊");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void QRS010_QueryLunch_Load(object sender, EventArgs e)
        {
            this.tsbNew.Visible = false;
            this.tsSeperator1.Visible = false;
            this.tsbRefresh.Text = "Query";


            this.shtQueryList.ActiveSkin = Common.ACTIVE_SKIN;
            this.shtView.ActiveSkin = Common.ACTIVE_SKIN;

            CtrlUtil.MappingDataFieldWithEnum(shtQueryList, typeof(eColQueryList));


            QueryLunchBiz biz = new QueryLunchBiz();
            DataTable dt = biz.GetQueryList();

            m_dtQueryList = dt;
            this.shtQueryList.DataSource = dt;

        }

        private void fpQueryList_SelectionChanged(object sender, FarPoint.Win.Spread.SelectionChangedEventArgs e)
        {
            this.shtView.DataSource = null;
            this.shtView.RowCount = 0;
            this.shtView.ColumnCount = 0;
            this.m_dtAllData = null;

            if (m_dtQueryList != null)
            {
                object o = shtQueryList.Cells[e.Range.Row, (int)eColQueryList.ID].Value;

                if (o != null)
                {
                    string strID = Convert.ToString(o);

                    DataRow[] dr = m_dtQueryList.Select(eColQueryList.ID.ToString() + "='" + strID + "'");

                    //DataView dv = m_dtQueryList.DefaultView;
                    //dv.RowFilter = eColQueryList.ID.ToString() + "='" + strID + "'";

                    if (dr.Length > 0)
                    {

                        QueryLunchDTO dto = DTOUtility.ConvertDataRowToDTO<QueryLunchDTO>(dr[0]);


                        this.txtSearch.Text = dto.SQLCommand;
                        this.txtStartRow.Text = Convert.ToString(dto.StartRow);
                        this.txtStartColumn.Text = Convert.ToString(dto.StartColumn);
                        this.txtTemplate.Text = dto.ExcelTemplate;

                        //this.txtSearch.Text = dr[0]["SQLCommand"].ToString();//dto.SQLCommand;
                        //this.txtStartRow.Text = dr[0]["StartRow"].ToString();//Convert.ToString(dto.StartRow);
                        //this.txtStartColumn.Text = dr[0]["StartColumn"].ToString();//Convert.ToString(dto.StartColumn);
                        //this.txtTemplate.Text = dr[0]["ExcelTemplate"].ToString();//dto.ExcelTemplate;

                    }

                }
            }
        }

        private string GenerateFileName(string strReportID)
        {
            string strFilename = "";

            strFilename = "Export-" + strReportID + "_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".xls";

            return strFilename;
        }

        private void fpQueryList_KeyDown(object sender, KeyEventArgs e)
        {
            CtrlUtil.FilterShortCut(e);
        }

        private void fpView_KeyDown(object sender, KeyEventArgs e)
        {
            CtrlUtil.FilterShortCut(e);
        }

    }
}
