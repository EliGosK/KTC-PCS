using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using EVOFramework;
using SystemMaintenance.Controller;
using SystemMaintenance.UIDataModel;
using EVOFramework.Data;
using SystemMaintenance.SystemScreen;
using EVOFramework.Windows.Forms;
using CommonLib;

namespace SystemMaintenance.Forms
{
    [Screen("SFM007", "Screen Detail Maintenance", eShowAction.Normal, eScreenType.Screen, "Screen Detail Maintenance")]
    public partial class SFM007_ScreenDetailMaintenance : CustomizeBaseForm
    {
        enum eColScreen
        {
            SCREEN_CD,
            ORIGINAL_TITLE,
            DISPLAY_TITLE,
            IMAGE_CD
        }
        enum eColScreenDetail
        {
            ORIGINAL_CAPTION,
            DISPLAY_CAPTION,
            CONTROL_CD
        }

        string m_OldTextScreen = string.Empty;
        int m_LastActiveRow = -1;

        public SFM007_ScreenDetailMaintenance()
        {
            InitializeComponent();
        }

        private void SFM007_ScreenDetailMaintenance_Load(object sender, EventArgs e)
        {
            InitialScreen();
        }

        private void InitialScreen()
        {
            //txtFindScreen.KeyPress += CommonLib.CtrlUtil.SetRestrictKeyInput;
            //txtFindScreen.KeyUp += CommonLib.CtrlUtil.FilterRestrictChar;

            //txtFindScreenDetail.KeyPress += CommonLib.CtrlUtil.SetRestrictKeyInput;

            // Lookup Lang
            SystemMaintenance.BIZ.LangBIZ bizLang = new SystemMaintenance.BIZ.LangBIZ();
            LookupData lookupLangData = bizLang.LoadLookup(true);
            cboLanguage.LoadLookupData(lookupLangData);

            cboLanguage.SelectedValue = Common.CurrentUserInfomation.LanguageCD.Value;

            shtScreenList.Columns[(int)eColScreen.SCREEN_CD].DataField = "SCREEN_CD";
            shtScreenList.Columns[(int)eColScreen.ORIGINAL_TITLE].DataField = "ORIGINAL_TITLE";
            shtScreenList.Columns[(int)eColScreen.DISPLAY_TITLE].DataField = "DISPLAY_TITLE";
            shtScreenList.Columns[(int)eColScreen.IMAGE_CD].DataField = "IMAGE_CD";
            shtScreenList.ActiveSkin = CommonLib.Common.ACTIVE_SKIN;
            LoadScreenList(CommonLib.Common.CurrentUserInfomation.LanguageCD.StrongValue, string.Empty);

            shtScreenDetailList.Columns[(int)eColScreenDetail.ORIGINAL_CAPTION].DataField = "ORIGINAL_TITLE";
            shtScreenDetailList.Columns[(int)eColScreenDetail.DISPLAY_CAPTION].DataField = "CONTROL_CAPTION";
            shtScreenDetailList.Columns[(int)eColScreenDetail.CONTROL_CD].DataField = "CONTROL_CD";
            shtScreenDetailList.ActiveSkin = CommonLib.Common.ACTIVE_SKIN;

            shtScreenDetailList.Columns[(int)eColScreenDetail.DISPLAY_CAPTION].ForeColor = Color.Blue;
            shtScreenList.Columns[(int)eColScreen.DISPLAY_TITLE].ForeColor = Color.Blue;
        }

        private void LoadScreenList(string LangCD, string keyFilter)
        {
            try
            {
                ScreenDetailMaintenanceController ctlScreenDetail = new ScreenDetailMaintenanceController();

                DataTable dt = (DataTable)ctlScreenDetail.LoadAllDatabyLangCD(LangCD);
                DataTable dtView = dt.Clone();

                if (keyFilter != string.Empty)
                {
                    //get only the rows you want
                    DataRow[] results = dt.Select(string.Format("SCREEN_CD LIKE '%{0}%' OR ORIGINAL_TITLE LIKE '%{0}%' OR DISPLAY_TITLE LIKE '%{0}%'", keyFilter));

                    //populate new destination table
                    foreach (DataRow dr in results)
                        dtView.ImportRow(dr);
                }
                else
                {
                    foreach (DataRow dr in dt.Rows)
                        dtView.ImportRow(dr);
                }
                fpScreenList.DataSource = dtView;

                shtScreenList.Columns[(int)eColScreen.SCREEN_CD].Locked = true;
                shtScreenList.Columns[(int)eColScreen.ORIGINAL_TITLE].Locked = true;
                shtScreenList.Columns[(int)eColScreen.DISPLAY_TITLE].Locked = false;
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
                MessageDialog.ShowBusiness(this, err.Error.Message.MessageDescription);
        
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusiness(this, ex.Message);
      
            }
        }

        private void cboLanguage_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cboLanguage.SelectedValue != null)
            {
                string LangCD = cboLanguage.SelectedValue != null ? cboLanguage.SelectedValue.ToString() : CommonLib.Common.CurrentUserInfomation.LanguageCD.StrongValue;
                LoadScreenList(LangCD, txtFindScreen.Text);
                if (shtScreenList.Rows.Count == 0)
                    return;
                if (shtScreenList.ActiveRowIndex < 0)
                    return;

                string ScreenCD = shtScreenList.Cells[shtScreenList.ActiveRowIndex, (int)eColScreen.SCREEN_CD].Text;
                LoadScreenDetailList(ScreenCD, LangCD, txtFindScreenDetail.Text);
            }
        }

        private void fpScreenList_EditModeOff(object sender, EventArgs e)
        {
            int activeRow = shtScreenList.ActiveRowIndex;
            string ScreenCD = shtScreenList.Cells[activeRow, (int)eColScreen.SCREEN_CD].Text;
            string LangCD = cboLanguage.SelectedValue != null ? cboLanguage.SelectedValue.ToString() : CommonLib.Common.CurrentUserInfomation.LanguageCD.StrongValue;
            string DisplayTitle = shtScreenList.Cells[activeRow, (int)eColScreen.DISPLAY_TITLE].Text;
            if (m_OldTextScreen != DisplayTitle)
                SaveScreenDisplayText(ScreenCD, LangCD, DisplayTitle);
        }

        private void SaveScreenDisplayText(string ScreenCD, string LangCD, string DisplayTitle)
        {
            try
            {
                // call controller
                ScreenDetailMaintenanceController ctlScreen = new ScreenDetailMaintenanceController();

                ctlScreen.SaveScreenDisplayText(ScreenCD, LangCD, DisplayTitle);
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
                MessageDialog.ShowBusiness(this, err.Error.Message.MessageDescription);
       
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusiness(this, ex.Message);

            }

        }

        private void txtFindScreen_TextChanged(object sender, EventArgs e)
        {
            string LangCD = cboLanguage.SelectedValue != null ? cboLanguage.SelectedValue.ToString() : CommonLib.Common.CurrentUserInfomation.LanguageCD.StrongValue;
            LoadScreenList(LangCD, txtFindScreen.Text);
            shtScreenDetailList.Rows.Count = 0;
        }

        private void txtFindScreenDetail_TextChanged(object sender, EventArgs e)
        {
            if (shtScreenList.Rows.Count == 0)
                return;
            if (shtScreenList.ActiveRowIndex < 0)
                return;
            string ScreenCD = shtScreenList.Cells[shtScreenList.ActiveRowIndex, (int)eColScreen.SCREEN_CD].Text;
            string LangCD = cboLanguage.SelectedValue != null ? cboLanguage.SelectedValue.ToString() : CommonLib.Common.CurrentUserInfomation.LanguageCD.StrongValue;
            LoadScreenDetailList(ScreenCD, LangCD, txtFindScreenDetail.Text);
        }

        private void fpScreenList_EditModeOn(object sender, EventArgs e)
        {
            m_OldTextScreen = shtScreenList.Cells[shtScreenList.ActiveRowIndex, (int)eColScreen.DISPLAY_TITLE].Text;
        }

        private void fpScreenList_SelectionChanged(object sender, FarPoint.Win.Spread.SelectionChangedEventArgs e)
        {
            try
            {
                if (shtScreenList.Rows.Count == 0)
                    return;
                int activeRow = shtScreenList.ActiveRowIndex;
                if (activeRow == m_LastActiveRow)
                    return;
                string screenCD = shtScreenList.Cells[activeRow, (int)eColScreen.SCREEN_CD].Text;
                string langCD = (cboLanguage.SelectedValue != null) ? cboLanguage.SelectedValue.ToString() : CommonLib.Common.CurrentUserInfomation.LanguageCD.StrongValue;
                string keyFilter = txtFindScreenDetail.Text;
                string imageCD = shtScreenList.Cells[shtScreenList.ActiveRowIndex, (int)eColScreen.IMAGE_CD].Text;

                ImageItem imageItem = ImageCache.GetInstance().Get(imageCD);
                if (imageItem == null)
                    picIconDisplay.Image = null;
                else
                    picIconDisplay.Image = imageItem.ImageBin;

                LoadScreenDetailList(screenCD, langCD, keyFilter);
                m_LastActiveRow = shtScreenList.ActiveRowIndex;
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusiness(this, ex.Message);
   
            }

        }

        private void LoadScreenDetailList(string screenCD, string langCD, string keyFilter)
        {
            try
            {
                ScreenDetailMaintenanceController ctlScreenDetail = new ScreenDetailMaintenanceController();
                //ScreenDetailMaintenanceUIDM uidmScreenDetail = new ScreenDetailMaintenanceUIDM();

                DataTable dt = ctlScreenDetail.LoadScreenDetailWithOriginalCaptionByLangCD(screenCD, langCD);
                DataTable dtView = dt.Clone();

                if (keyFilter != string.Empty)
                {
                    //get only the rows you want
                    DataRow[] results = dt.Select(string.Format("CONTROL_CAPTION LIKE '%{0}%'", keyFilter));

                    //populate new destination table
                    foreach (DataRow dr in results)
                        dtView.ImportRow(dr);
                }
                else
                {
                    foreach (DataRow dr in dt.Rows)
                        dtView.ImportRow(dr);
                }
                fpScreenDetailList.DataSource = dtView;

                shtScreenDetailList.Columns[(int)eColScreenDetail.ORIGINAL_CAPTION].Locked = true;
                shtScreenDetailList.Columns[(int)eColScreenDetail.DISPLAY_CAPTION].Locked = false;
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
                MessageDialog.ShowBusiness(this, err.Error.Message.MessageDescription);
     
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusiness(this, ex.Message);
     
            }
        }

        string m_OldTextScreenDetail = string.Empty;
        private void fpScreenDetailList_EditModeOn(object sender, EventArgs e)
        {
            m_OldTextScreenDetail = shtScreenDetailList.Cells[shtScreenDetailList.ActiveRowIndex, (int)eColScreenDetail.DISPLAY_CAPTION].Text;
        }

        private void fpScreenDetailList_EditModeOff(object sender, EventArgs e)
        {
            int activeRow = shtScreenDetailList.ActiveRowIndex;
            string ScreenCD = shtScreenList.Cells[shtScreenList.ActiveRowIndex, (int)eColScreen.SCREEN_CD].Text;
            string LangCD = cboLanguage.SelectedValue != null ? cboLanguage.SelectedValue.ToString() : CommonLib.Common.CurrentUserInfomation.LanguageCD.StrongValue;
            string DisplayTitle = shtScreenDetailList.Cells[activeRow, (int)eColScreenDetail.DISPLAY_CAPTION].Text;
            string ControlCD = shtScreenDetailList.Cells[activeRow, (int)eColScreenDetail.CONTROL_CD].Text;
            if (m_OldTextScreenDetail != DisplayTitle)
                SaveScreenDetailDisplayText(ScreenCD, ControlCD, LangCD, DisplayTitle);
        }

        private void SaveScreenDetailDisplayText(string ScreenCD, string ControlCD, string LangCD, string DisplayTitle)
        {
            try
            {
                // call controller
                ScreenDetailMaintenanceController ctlScreen = new ScreenDetailMaintenanceController();

                ctlScreen.SaveScreenDetailDisplayText(ScreenCD, ControlCD, LangCD, DisplayTitle);
            }
            catch (ValidateException err)
            {
                for (int i = 0; i < err.ErrorResults.Count; i++)
                {
                    MessageDialog.ShowBusiness(this, err.ErrorResults[i].Message.MessageDescription);
                    err.ErrorResults[i].FocusOnControl();
                }
            
            }
            catch (BusinessException err)
            {
                MessageDialog.ShowBusiness(this, err.Error.Message.MessageDescription);
  
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusiness(this, ex.Message);

            }
        }

        private void btnChangeIcon_Click(object sender, EventArgs e)
        {
            if (shtScreenList.Rows.Count == 0)
                return;
            if (shtScreenList.ActiveRowIndex < 0)
                return;
            string imageCD = shtScreenList.Cells[shtScreenList.ActiveRowIndex, (int)eColScreen.IMAGE_CD].Text;
            string screenCD = shtScreenList.Cells[shtScreenList.ActiveRowIndex, (int)eColScreen.SCREEN_CD].Text;

            ScreenImageList imList = new ScreenImageList(imageCD);
            if (imList.ShowDialog(this) == DialogResult.OK) {
                if (imList.SelectedImage == null)
                    return;

                shtScreenList.Cells[shtScreenList.ActiveRowIndex, (int) eColScreen.IMAGE_CD].Text = imList.SelectedImageCode;
                picIconDisplay.Image = imList.SelectedImage;
                
                SaveChangeImage(screenCD, imList.SelectedImageCode);
            }
        }

        private void SaveChangeImage(string screenCD, string imageCD)
        {
            try
            {
                // call controller
                ScreenDetailMaintenanceController ctlScreen = new ScreenDetailMaintenanceController();

                ctlScreen.SaveChangeImage(screenCD, imageCD);
            }
            catch (ValidateException err)
            {
                for (int i = 0; i < err.ErrorResults.Count; i++)
                {
                    MessageDialog.ShowBusiness(this, err.ErrorResults[i].Message.MessageDescription);
                    err.ErrorResults[i].FocusOnControl();
                }
            
            }
            catch (BusinessException err)
            {
                MessageDialog.ShowBusiness(this, err.Error.Message.MessageDescription);
          
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusiness(this, ex.Message);
     
            }
        }

        private void removeImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (shtScreenList.Rows.Count == 0)
                return;
            if (shtScreenList.ActiveRowIndex < 0)
                return;
            string screenCD = shtScreenList.Cells[shtScreenList.ActiveRowIndex, (int)eColScreen.SCREEN_CD].Text;

            SaveChangeImage( screenCD, null);
            picIconDisplay.Image = null;
            shtScreenList.Cells[shtScreenList.ActiveRowIndex, (int)eColScreen.IMAGE_CD].Text = string.Empty;
        }

    }
}
