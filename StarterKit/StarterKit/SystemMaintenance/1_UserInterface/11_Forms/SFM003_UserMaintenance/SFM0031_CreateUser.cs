using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using EVOFramework.Data;
using EVOFramework;
using EVOFramework.Windows.Forms;
using SystemMaintenance.BIZ;
using SystemMaintenance.DTO;
using SystemMaintenance.UIDataModel;
using SystemMaintenance.Controller;

namespace SystemMaintenance.Forms
{
    public partial class SFM0031_CreateUser : CustomizeBaseForm
    {
        eOperationMode m_eMode;
        string m_UserAccount;
        public enum eOperationMode
        {
            CREATE_ACCOUNT,
            PROPERTIES_SHOW
        }

        public SFM0031_CreateUser() { InitializeComponent(); }

        public SFM0031_CreateUser(eOperationMode eMode, string UserAccount)
        {
            InitializeComponent();
            m_eMode = eMode;
            m_UserAccount = UserAccount;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveData();
        }

        private MessageDialogResult ShowConfirmMessage(Messages.eConfirm msgCD)
        {
            // show confirm message
            MessageDialogResult dr = MessageDialog.ShowConfirmation(this, new EVOFramework.Message(msgCD.ToString()).MessageDescription);
            return dr;
        }

        private void SaveData()
        {
            try
            {
                switch (ShowConfirmMessage(Messages.eConfirm.CFM9001))
                {
                    case MessageDialogResult.Cancel:
                        return;

                    case MessageDialogResult.No:
                        this.Close();
                        return;

                    case MessageDialogResult.Yes:
                        break;

                }
                CreateUserDomain userDm = dmcCreateUserAccount.SaveData(new CreateUserDomain());
                UserMaintenanceController userCtrler = new UserMaintenanceController();
                if (m_eMode == eOperationMode.CREATE_ACCOUNT)
                {
                    userCtrler.CreateUserController(userDm);
                }
                else
                {
                    userCtrler.UpdateUserController(userDm);
                }
                this.Close();
            }
            catch (ValidateException err)
            {
                for (int i = 0; i < err.ErrorResults.Count; i++)
                {
                    MessageBox.Show(err.ErrorResults[i].Message.MessageDescription);
                    err.ErrorResults[i].FocusOnControl();
                }
            }
            catch (BusinessException err)
            {
                MessageBox.Show(err.Error.Message.MessageDescription);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void InitialScreen()
        {
            LookupComboboxData();

            // add domain controller
            dmcCreateUserAccount.AddControl(txtUserAccount);
            dmcCreateUserAccount.AddControl(txtUserName);
            dmcCreateUserAccount.AddControl(txtPassWord);
            dmcCreateUserAccount.AddControl(cboDefaultDateFormat);
            dmcCreateUserAccount.AddControl(cboDefaultLang);
            dmcCreateUserAccount.AddControl(cboGroupUser);
            dmcCreateUserAccount.AddControl(cboMenuSet);
            dmcCreateUserAccount.AddControl(chkIsActive);
            dmcCreateUserAccount.AddControl(chkIsResign);

            // add move next event
            txtUserAccount.KeyPress += new KeyPressEventHandler(CommonLib.CtrlUtil.SetNextControl);
            txtUserName.KeyPress += new KeyPressEventHandler(CommonLib.CtrlUtil.SetNextControl);
            txtPassWord.KeyPress += new KeyPressEventHandler(CommonLib.CtrlUtil.SetNextControl);
            cboDefaultDateFormat.KeyPress += new KeyPressEventHandler(CommonLib.CtrlUtil.SetNextControl);
            cboDefaultLang.KeyPress += new KeyPressEventHandler(CommonLib.CtrlUtil.SetNextControl);
            cboGroupUser.KeyPress += new KeyPressEventHandler(CommonLib.CtrlUtil.SetNextControl);
            cboMenuSet.KeyPress += new KeyPressEventHandler(CommonLib.CtrlUtil.SetNextControl);

        }

        private void LookupComboboxData()
        {
            // Lookup Lang
            LangBIZ bizLang = new LangBIZ();
            LookupData lookupLangData = bizLang.LoadLookup(true);
            cboDefaultLang.LoadLookupData(lookupLangData);

            // Lookup Date Format
            ClassListBIZ bizClassDTL = new ClassListBIZ();
            LookupData lookupDateFormat = bizClassDTL.LoadLookupClassType(DataDefine.DATE_FORMAT.ToNZString());
            cboDefaultDateFormat.LoadLookupData(lookupDateFormat);

            // Lookup Group
            UserGroupBIZ bizUserGroup = new UserGroupBIZ();
            LookupData lookupGroup = bizUserGroup.LoadLookup(true);
            cboGroupUser.LoadLookupData(lookupGroup);

            // Lookup MenuSet
            MenuSetMaintenanceBIZ bizMenuSet = new MenuSetMaintenanceBIZ();
            LookupData lookupMenuSet = bizMenuSet.LoadLookup(true);
            cboMenuSet.LoadLookupData(lookupMenuSet);
        }

        private void SFM0031_CreateUser_Load(object sender, EventArgs e)
        {
            InitialScreen();

            if (m_eMode == eOperationMode.PROPERTIES_SHOW)
            {
                CreateUserDomain userDm = new CreateUserDomain();

                UserMaintenanceController userCtrler = new UserMaintenanceController();
                userDm.UserAccount.Value = m_UserAccount;
                dmcCreateUserAccount.LoadData(userCtrler.LoadData(userDm));
                txtPassWord.Text = string.Empty;
                chkIsActive.Checked = true;
                // disable control
                CommonLib.CtrlUtil.EnabledControl(false, txtUserAccount);
            }
        }


    }


}
