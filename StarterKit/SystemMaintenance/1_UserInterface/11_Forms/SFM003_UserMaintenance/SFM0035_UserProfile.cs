using System;
using EVOFramework.Data;
using EVOFramework.Windows.Forms;
using SystemMaintenance.BIZ;
using CommonLib;
using SystemMaintenance.Controller;
using SystemMaintenance.UIDataModel;
using EVOFramework;

namespace SystemMaintenance.Forms
{
    [Screen("SFM0035", "User Profile", eShowAction.Normal, eScreenType.Screen, "User Profile")]
    public partial class SFM0035_UserProfile : CustomizeBaseForm
    {

        private readonly UserProfileController m_prcUserProfile = new UserProfileController();

        public SFM0035_UserProfile()
        {
            InitializeComponent();

            InitializeScreen();
        }

        private void InitializeScreen() {
            // Load lookup combobox data.
            LookupData();

            // Binding event to control.
            txtUserAccount.KeyPress += CtrlUtil.SetNextControl;
            txtUsername.KeyPress += CtrlUtil.SetNextControl;
            cboDefaultDateFormat.KeyPress += CtrlUtil.SetNextControl;
            cboDefaultLang.KeyPress += CtrlUtil.SetNextControl;
            txtCurrentPassword.KeyPress += CtrlUtil.SetNextControl;
            txtNewPassword.KeyPress += CtrlUtil.SetNextControl;
            txtConfirmNewPassword.KeyPress += CtrlUtil.SetNextControl;


            // Binding Model
            dmcUserProfile.AddRangeControl(
                txtUserAccount,
                txtUsername,
                txtNewPassword,
                txtConfirmNewPassword,
                cboDefaultDateFormat,
                cboDefaultLang,
                txtCurrentPassword
                );

            Map<string, object> mapData = m_prcUserProfile.LoadUserProfile(Common.CurrentUserInfomation.UserCD);
            UserProfileUIDM dataModel = mapData.ExtractValue<UserProfileUIDM>(UserProfileController.C_VAL_MODEL);
            dmcUserProfile.LoadData(dataModel);

            // Startup Enable/Disable control.
            CtrlUtil.EnabledControl(false, txtUserAccount);
            CtrlUtil.EnabledControl(true, txtUsername, txtNewPassword, txtConfirmNewPassword, cboDefaultDateFormat, cboDefaultLang, txtCurrentPassword);
        }

        private void LookupData() {
            // Lookup Lang
            LangBIZ bizLang = new LangBIZ();
            LookupData lookupLangData = bizLang.LoadLookup(true);
            cboDefaultLang.LoadLookupData(lookupLangData);

            // Lookup Date Format
            ClassListBIZ bizClassDTL = new ClassListBIZ();
            LookupData lookupDateFormat = bizClassDTL.LoadLookupClassType(DataDefine.DATE_FORMAT.ToNZString());
            cboDefaultDateFormat.LoadLookupData(lookupDateFormat);
        }        

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            UserProfileUIDM model = new UserProfileUIDM();
            model = dmcUserProfile.SaveData(model);

            try
            {
                m_prcUserProfile.SaveUserProfile(model);

                MessageDialog.ShowInformation(this, null, "UserProfile has updated.");
                Close();
            }
            catch (ValidateException err) {
                MessageDialog.ShowBusiness(this, err.ErrorResults[0].Message);
            }
            catch (BusinessException err) {
                MessageDialog.ShowBusiness(this, err.Error.Message);
            }
            catch (Exception err)
            {
                MessageDialog.ShowBusiness(this, err.Message);
            }
        }
    }
}
