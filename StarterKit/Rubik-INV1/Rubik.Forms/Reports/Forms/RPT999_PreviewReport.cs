//Create Date 12 Oct 2010
//Author: Bunyapat L.
//Object Name: Report Preview
//Description: To preview report 

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Rubik.Report;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Windows.Forms;

namespace Rubik.Report
{
    public partial class RPT999_PreviewReport : SystemMaintenance.Forms.CustomizeBaseForm
    {

        #region Constructor

        public RPT999_PreviewReport()
        {
            InitializeComponent();
        }

        public RPT999_PreviewReport(ReportDocument rpd)
            : this()
        {
            this.pv_ReportDoc = rpd;
        }

        public RPT999_PreviewReport(string ReportPath)
            : this()
        {
            this.pv_ReportDoc.Load(ReportPath);
        }

        #endregion

        #region Member

        private ReportDocument pv_ReportDoc = new ReportDocument();

        #endregion

        #region Property

        public ReportDocument ReportDoc
        {
            get { return pv_ReportDoc; }
            set { pv_ReportDoc = value; }
        }

        public CrystalReportViewer ReportViewer
        {
            get { return this.rptViewer; }
        }

        #endregion


        #region Method

        public void SetDataSource(DataSet DataSource)
        {
            this.pv_ReportDoc.SetDataSource(DataSource);
        }

        public void ShowPreview()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                rptViewer.ReportSource = this.pv_ReportDoc;
                rptViewer.Zoom(1);
                //this.WindowState = FormWindowState.Maximized;
                this.Show();


            }
            finally
            { this.Cursor = Cursors.Default; }
        }

        #endregion

    }
}
