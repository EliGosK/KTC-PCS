using System;
using System.Windows.Forms;
using EVOFramework;
using EVOFramework.Data;
using EVOFramework.Windows.Forms;
using SystemMaintenance.Controller;
using CommonLib;
using System.Data;

namespace SystemMaintenance.Forms
{
    [ScreenAttribute("SYS_LOGIN", "LOGIN", eShowAction.Normal, eScreenType.Dialog, "Login Screen")]
    public partial class LoginForm : CustomizeBaseForm
    {
        private readonly ConfigurationController m_prcConfiguration = new ConfigurationController();
        private readonly UserController m_prcUser = new UserController();

        public LoginForm()
        {
            InitializeComponent();

            //###################
            // Binding event to control (movenext).
            //###################
            txtUserAccount.KeyPress += CtrlUtil.SetNextControl;
            txtPassword.KeyPress += CtrlUtil.SetNextControl;

            DialogResult = DialogResult.Cancel;
        }

        #region Private Method
        /// <summary>
        /// Update label database account connection.
        /// </summary>
        private void UpdateDatabaseString()
        {
            Map<string, string> map = m_prcConfiguration.LoadConfiguration();
            if (map[ConfigurationController.S_KEY_USERNAME].Value == String.Empty &&
                map[ConfigurationController.S_KEY_SERVER_NAME].Value == String.Empty)
            {
                txtDatabase.Text = "-";
            }
            else
            {
                txtDatabase.Text = String.Format("{0}@{1}", map[ConfigurationController.S_KEY_USERNAME].Value, map[ConfigurationController.S_KEY_SERVER_NAME].Value);
            }
        }
        #endregion

        #region Form events
        private void LoginForm_Load(object sender, EventArgs e)
        {
            txtUserAccount.Text = m_prcUser.LoadUserLastLogin();
            txtPassword.Text = string.Empty;


            btnOK.Select();
            UpdateDatabaseString();

            SetRubiksUser();

        }

        private void SetRubiksUser()
        {

            string user = System.Environment.GetEnvironmentVariable("RUBIKSUSER", EnvironmentVariableTarget.User);
            string pw = System.Environment.GetEnvironmentVariable("RUBIKSPASS", EnvironmentVariableTarget.User);

            if (user != null)
                this.txtUserAccount.Text = user;

            if (pw != null)
                this.txtPassword.Text = pw;

        }

        private void LoginForm_Shown(object sender, EventArgs e)
        {
            if (txtUserAccount.Text.Trim() == string.Empty)
                txtUserAccount.Focus();
            else
            {
                txtPassword.Focus();
            }
        }
        #endregion

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            bool bLogin = false;

            NZString user = null;
            NZString pass = null;
            try
            {
                user = new NZString(txtUserAccount, txtUserAccount.Text.Trim());
                pass = new NZString(txtPassword, txtPassword.Text.Trim());

                bLogin = m_prcUser.Login(user, pass);


            }
            catch (ValidateException err)
            {

                for (int i = 0; i < err.ErrorResults.Count; i++)
                {
                    MessageDialog.ShowBusiness(this, err.ErrorResults[i].Message);
                    err.ErrorResults[i].ControlIdentify.FocusOnControl();
                }
            }
            catch (BusinessException err)
            {
                MessageDialog.ShowBusiness(this, err.Error.Message);
            }


            if (bLogin)
            {

                DataTable dtPermission = m_prcUser.LoadPermissionTable(user);
                Common.RegisterPermissionInformation(dtPermission);

                DialogResult = DialogResult.OK;
            }
        }

        private void btnConfig_Click(object sender, EventArgs e)
        {
            FormSetting form = new FormSetting();

            if (form.ShowDialog(this) == DialogResult.OK)
                UpdateDatabaseString();

            form.Dispose();
            form = null;
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                btnOK.PerformClick();
            }
        }

        private int iCountDoubleClick = 0;

        private void picLogin_DoubleClick(object sender, EventArgs e)
        {
            iCountDoubleClick++;

            if (iCountDoubleClick >= 3)
                btnConfig.Visible = true;
        }



    }
}
