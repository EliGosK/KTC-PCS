using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Rubik.Report;
using Rubik.Forms.Forms.Inventory;

namespace Rubik.Inventory
{
    public partial class INV031 : SystemMaintenance.Forms.CustomizeBaseForm
    {
        //public enum eTAGCardType
        //{
        //    FG,WIP,RM
        //}
        private DataTable m_dt;
        private DataDefine.eTAGCardType m_tagCardType = DataDefine.eTAGCardType.FG;

        public INV031(DataTable ReportData,DataDefine.eTAGCardType tagCardType)
        {
            InitializeComponent();
            m_dt = ReportData;
            m_tagCardType = tagCardType;
        }

        private void INV031_Load(object sender, EventArgs e)
        {
            Rubik.Forms.Forms._3_Inventory.INV030_TAG_Card_Printing.TAG_Card_FG rpt = new Rubik.Forms.Forms._3_Inventory.INV030_TAG_Card_Printing.TAG_Card_FG();
            
            switch (m_tagCardType)
            {
                case DataDefine.eTAGCardType.FG:
                    rpt.FileName = Path.Combine(Application.StartupPath, @"Report\\TAG_Card_FG.rpt");
                    break;
                case DataDefine.eTAGCardType.WIP:
                    rpt.FileName = Path.Combine(Application.StartupPath, @"Report\\TAG_Card_WIP.rpt" );
                    break;
                case DataDefine.eTAGCardType.RM:
                    rpt.FileName = Path.Combine(Application.StartupPath, @"Report\\TAG_Card_RM.rpt");
                    break;
               
            }
          
            rpt.SetDataSource(m_dt);
            rptViewer.ReportSource = rpt;
            //this.AddParameter(rpt, "P_DATEFORMAT", C_APP.DateTimeFormat.ToString());
        }
    }
}
