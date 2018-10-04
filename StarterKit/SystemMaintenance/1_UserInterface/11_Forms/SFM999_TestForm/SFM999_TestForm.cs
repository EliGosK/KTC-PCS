using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EVOFramework.Windows.Forms;
using EVOFramework.Data;
using Message=EVOFramework.Message;
using EVOFramework.Database;
using EVOFramework;

namespace SystemMaintenance.Forms
{
    //[Screen("SFM999", "Test Screen Panel", eShowAction.Normal, eScreenType.ScreenPane, "Test Screen Panel")]
    public partial class SFM999_TestForm : CustomizeListPaneForm
    {        
        public SFM999_TestForm()
        {
            InitializeComponent();
        }

        private void SFM999_TestForm_Load(object sender, EventArgs e)
        {                                    
        }

        private void evoButton1_Click(object sender, EventArgs e)
        {
            DatabaseCredential credential = new DatabaseCredential();
            credential.ServerName = "teerayut0si0nb";
            credential.DatabaseName = "test";
            credential.Username = "sa";
            credential.Password = "1234";
            credential.Provider = DatabaseProvider.SQLSERVER;

            Database sqlDB = DatabaseManager.CreateDatabase(credential);
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("SELECT * FROM TB_TORO WHERE NAME=:NAME");

            DataRequest req = new DataRequest(sb.ToString());
            req.Parameters.Add("NAME", DataType.NVarChar, "TORO");
            DataTable dt = sqlDB.ExecuteQuery(req);
                        
            evoTextBox1.Clear();
            for (int i=0; i<dt.Rows.Count; i++) {
                evoTextBox1.Text += dt.Rows[i][0] + "\r\n";
            }
        }
           
    }
}
