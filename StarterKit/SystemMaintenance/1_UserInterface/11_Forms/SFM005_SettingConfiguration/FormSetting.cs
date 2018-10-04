using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EVOFramework.IO;
using EVOFramework.Windows.Forms;
using EVOFramework.Data;
using CommonLib;
using EVOFramework;
using SystemMaintenance.Controller;


namespace SystemMaintenance.Forms
{    
    internal partial class FormSetting : EVOForm
    {
        ConfigurationController m_process = new ConfigurationController();

        public FormSetting()
        {            
            InitializeComponent();

            DialogResult = DialogResult.Cancel;
        }

        private void FormSetting_Load(object sender, EventArgs e)
        {
            //LookupData lookupDateFormat= m_process.LoadLookupDateFormat();
            //ComboUtil.AssignLookup(cboDateFormat, lookupDateFormat);

            Map<string, string> map = m_process.LoadConfiguration();
            txtServiceName.Text = map[ConfigurationController.S_KEY_SERVER_NAME].Value;
            txtDatabasename.Text = map[ConfigurationController.S_KEY_DATABASE_NAME].Value;
            txtUsername.Text = map[ConfigurationController.S_KEY_USERNAME].Value;
            txtPassword.Text = map[ConfigurationController.S_KEY_PASSWORD].Value;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            m_process.SaveConfiguration(EVOFramework.Database.DatabaseProvider.SQLSERVER.ToString(), txtServiceName.Text, txtDatabasename.Text, txtUsername.Text, txtPassword.Text);

            DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnTestConnection_Click(object sender, EventArgs e)
        {
            ErrorItem errorItem = m_process.TestConnection(EVOFramework.Database.DatabaseProvider.SQLSERVER,txtServiceName.Text,txtDatabasename.Text, txtUsername.Text, txtPassword.Text);
            if (errorItem == null) {
                MessageBox.Show(this, "Test connection sucessful.");
            } else {
                MessageBox.Show(this, errorItem.Message.MessageDescription);
            }
        }
    }
}
