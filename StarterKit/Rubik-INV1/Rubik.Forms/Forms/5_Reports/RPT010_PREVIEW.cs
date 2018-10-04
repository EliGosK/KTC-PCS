using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Rubik.Report;
using EVOFramework;
using Rubik.Forms.Forms.Reports;
using Rubik.Forms.Reports.Report;

namespace Rubik.Report
{
    public partial class RPT010_PREVIEW : SystemMaintenance.Forms.CustomizeBaseForm
    {

        private DataTable m_dt;
        private NZDateTime m_BeginDate;
        private NZDateTime m_EndDate;

        public RPT010_PREVIEW(DataTable ReportData, NZDateTime BeginDate, NZDateTime EndDate)
        {
            InitializeComponent();
            m_dt = ReportData;
            m_BeginDate = BeginDate;
            m_EndDate = EndDate;
        }

        private void RPT010_PREVIEW_Load(object sender, EventArgs e)
        {
            RPT010_RPT rpt = new RPT010_RPT();
            rpt.FileName = System.IO.Path.Combine(Application.StartupPath, @"Report\\RPT010_RPT.rpt");
            
            rpt.SetDataSource(m_dt);
            rpt.SetParameterValue("BeginDate", m_BeginDate.StrongValue.Date);
            rpt.SetParameterValue("EndDate", m_EndDate.IsNull ? m_BeginDate.StrongValue.Date : m_EndDate.StrongValue.Date);

            rptViewer.ReportSource = rpt;
        }
    }
}
