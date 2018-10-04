using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using SystemMaintenance.Controller;
using SystemMaintenance.UIDataModel;
using EVOFramework;
using EVOFramework.Data;
using EVOFramework.Windows.Forms;

namespace SystemMaintenance.Forms
{
    [Screen("SFM004", "Import Screen", eShowAction.Normal, eScreenType.Screen, "Import Screen")]
    public partial class SFM004_ImportScreen : CustomizeBaseForm
    {
        enum eColView
        {
            SEL,
            SCREEN_CD,
            SCREEN_NAME,
            SCREEN_TYPE,
            IMPORT_STATUS,
            ORIGINAL_TITLE
        }

        enum eImportStatus
        {
            Import,
            NotImport
        }

        //public enum eScreenType
        //{
        //    Screen = 0,
        //    Report = 1,
        //    Process = 2,
        //    Dialog = 3,
        //    FindDialog = 4,1
        //    Table = 99,
        //    SystemScreen = 100,
        //}  
        public SFM004_ImportScreen()
        {
            InitializeComponent();
        }
        private Map<string, ScreenDetail> GetScreenDetail(string ScreenCD)
        {
            //Hashtable hs = new Hashtable();
            InternalScreenCache internals = InternalScreenCache.GetInstance();
            InternalScreen screen = internals[ScreenCD];
            object obj = Activator.CreateInstance(screen.ClassType, null);
            EVOFramework.Windows.Forms.EVOForm form = (EVOFramework.Windows.Forms.EVOForm)obj;
            Map<string, ScreenDetail> mapControl = form.GetControlList();

            return mapControl;
        }
        private MessageDialogResult ShowConfirmMessage(Messages.eConfirm msgCD)
        {
            // show confirm message
            MessageDialogResult dr = MessageDialog.ShowConfirmation(this, new EVOFramework.Message(msgCD.ToString()).MessageDescription);
            return dr;
        }
        private void btnImportScreen_Click(object sender, EventArgs e)
        {
            try
            {
                // show confirm message
                switch (ShowConfirmMessage(Messages.eConfirm.CFM9004))
                {
                    case MessageDialogResult.Cancel:
                        return;

                    case MessageDialogResult.No:
                        return;

                    case MessageDialogResult.Yes:
                        break;

                }
                List<ScreenImportUIDM> UIDMList = new List<ScreenImportUIDM>();
                ScreenImportController SIC = new ScreenImportController();
                List<ScreenDetailUIDM> UIDMScreenDetailList = new List<ScreenDetailUIDM>();
                int row = shtScreenList.Rows.Count;
                for (int i = 0; i < row; i++)
                {
                    if (shtScreenList.Cells[i, (int)eColView.SEL].Text == "True")
                    {
                        ScreenImportUIDM uidm = new ScreenImportUIDM();
                        uidm.ScreenCD.Value = shtScreenList.Cells[i, (int)eColView.SCREEN_CD].Text;
                        uidm.ScreenName.Value = shtScreenList.Cells[i, (int)eColView.SCREEN_NAME].Text;
                        uidm.ScreenType.Value = (int)Enum.Parse(typeof(eScreenType), shtScreenList.Cells[i, (int)eColView.SCREEN_TYPE].Text, true);
                        uidm.ImportStatus.Value = shtScreenList.Cells[i, (int)eColView.IMPORT_STATUS].Text;
                        uidm.OriginalTitle.Value = shtScreenList.Cells[i, (int)eColView.SCREEN_NAME].Text;
                        UIDMList.Add(uidm);
                    }
                }

                foreach (ScreenImportUIDM screenUIDM in UIDMList)
                {
                    // get screen detail from screen cd
                    //Hashtable hshScreenDetails = GetScreenDetail(screenUIDM.ScreenCD.StrongValue);

                    Map<string, ScreenDetail> mapControl = GetScreenDetail(screenUIDM.ScreenCD.StrongValue);

                    for (int i = 0; i < mapControl.Count; i++)
                    {
                        ScreenDetail screendetail = mapControl[i].Value;
                        if (SIC.IsScreenDetailAlreadyExist(screenUIDM.ScreenCD.StrongValue, screendetail.Name))
                        {
                            continue;
                        }
                        ScreenDetailUIDM screenDetailUIDM = new ScreenDetailUIDM();
                        screenDetailUIDM.ScreenCD = screenUIDM.ScreenCD;
                        screenDetailUIDM.ControlType.Value = screendetail.Type;// control.GetType().Name;
                        screenDetailUIDM.ControlCD.Value = screendetail.Name;
                        screenDetailUIDM.ControlCaption.Value = screendetail.Text;
                        screenDetailUIDM.OriginalTitle.Value = screendetail.Text;
                        UIDMScreenDetailList.Add(screenDetailUIDM);
                    }
                }
                SIC.ImportData(UIDMList, UIDMScreenDetailList);
                MessageDialog.ShowInformation(this, "Information", new EVOFramework.Message(Messages.eInformation.INF9001.ToString()).MessageDescription);
                UpdateImportStatus(true);
            }
            catch (ValidateException err)
            {
                for (int i = 0; i < err.ErrorResults.Count; i++)
                {
                    MessageBox.Show(err.ErrorResults[i].Message.MessageDescription);
                    err.ErrorResults[i].FocusOnControl();
                }
                if (CommonLib.Common.CurrentDatabase.DBTransactionState == EVOFramework.Database.TransactionState.PROCESSING)
                    CommonLib.Common.CurrentDatabase.Rollback();
            }
            catch (BusinessException err)
            {
                MessageBox.Show(err.Error.Message.MessageDescription);
                if (CommonLib.Common.CurrentDatabase.DBTransactionState == EVOFramework.Database.TransactionState.PROCESSING)
                    CommonLib.Common.CurrentDatabase.Rollback();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                if (CommonLib.Common.CurrentDatabase.DBTransactionState == EVOFramework.Database.TransactionState.PROCESSING)
                    CommonLib.Common.CurrentDatabase.Rollback();
            }
        }
        private void UpdateImportStatus(bool isImport)
        {
            int row = shtScreenList.Rows.Count;
            for (int i = 0; i < row; i++)
            {
                if (shtScreenList.Cells[i, (int)eColView.SEL].Text == "True")
                {
                    shtScreenList.Cells[i, (int)eColView.SEL].Value = false;
                    if (isImport)
                    {
                        shtScreenList.Cells[i, (int)eColView.IMPORT_STATUS].BackColor = Color.PaleGreen;
                        shtScreenList.Cells[i, (int)eColView.IMPORT_STATUS].Text = eImportStatus.Import.ToString();
                    }
                    else
                    {
                        shtScreenList.Cells[i, (int)eColView.IMPORT_STATUS].BackColor = Color.Salmon;
                        shtScreenList.Cells[i, (int)eColView.IMPORT_STATUS].Text = eImportStatus.NotImport.ToString();
                    }
                }
            }
        }
        private void SFM004_ImportScreen_Load(object sender, EventArgs e)
        {
            LoadData(string.Empty);
            //txtFind.KeyPress += CommonLib.CtrlUtil.SetRestrictKeyInput;
            //txtFind.KeyUp += CommonLib.CtrlUtil.FilterRestrictChar;
        }

        private void LoadData(string keyFilter)
        {
            try
            {
                shtScreenList.Columns[(int)eColView.SEL].DataField = "";
                shtScreenList.Columns[(int)eColView.SCREEN_CD].DataField = "SCREEN_CD";
                shtScreenList.Columns[(int)eColView.SCREEN_NAME].DataField = "SCREEN_NAME";
                shtScreenList.Columns[(int)eColView.SCREEN_TYPE].DataField = "SCREEN_TYPE";
                shtScreenList.Columns[(int)eColView.IMPORT_STATUS].DataField = "IMPORT_STATUS";

                shtScreenList.ActiveSkin = CommonLib.Common.ACTIVE_SKIN;

                ScreenImportController SIC = new ScreenImportController();

                InternalScreenCache internals = InternalScreenCache.GetInstance();
                DataTable dt = new DataTable();
                dt.Columns.Add("SCREEN_CD");
                dt.Columns.Add("SCREEN_NAME");
                dt.Columns.Add("SCREEN_TYPE");
                dt.Columns.Add("IMPORT_STATUS");

                for (int i = 0; i < internals.InternalScreenList.Count; i++)
                {
                    InternalScreen internalscreen = internals.InternalScreenList[i];
                    dt.Rows.Add(internalscreen.ScreenAttribute.ScreenCD
                       , internalscreen.ScreenAttribute.ScreenName
                       , internalscreen.ScreenAttribute.ScreenType.ToString()
                       , SIC.IsScreenAlreadyExist(internalscreen.ScreenAttribute.ScreenCD) ? eImportStatus.Import.ToString() : eImportStatus.NotImport.ToString());

                }
                //dt.DefaultView.Sort = "SCREEN_CD";
                DataTable dtView = dt.Clone();
                if (keyFilter != string.Empty)
                {
                    //get only the rows you want
                    DataRow[] results = dt.Select(string.Format("SCREEN_CD LIKE '%{0}%' OR SCREEN_NAME LIKE '%{0}%'", keyFilter));

                    //populate new destination table
                    foreach (DataRow dr in results)
                        dtView.ImportRow(dr);
                }
                else
                {
                    foreach (DataRow dr in dt.Rows)
                        dtView.ImportRow(dr);
                }

                dtView.DefaultView.Sort = "SCREEN_CD ASC";
                fpScreenList.DataSource = dtView.DefaultView;
                int row = shtScreenList.Rows.Count;
                for (int i = 0; i < row; i++)
                {
                    if (shtScreenList.Cells[i, (int)eColView.IMPORT_STATUS].Text == eImportStatus.Import.ToString())
                    {
                        shtScreenList.Cells[i, (int)eColView.IMPORT_STATUS].BackColor = Color.PaleGreen;
                    }
                    else
                    {
                        shtScreenList.Cells[i, (int)eColView.IMPORT_STATUS].BackColor = Color.Salmon;
                    }
                }

                shtScreenList.Columns[(int)eColView.SEL].Locked = false;
                shtScreenList.Columns[(int)eColView.IMPORT_STATUS].Locked = true;
                shtScreenList.Columns[(int)eColView.SCREEN_CD].Locked = true;
                shtScreenList.Columns[(int)eColView.SCREEN_NAME].Locked = true;
                shtScreenList.Columns[(int)eColView.SCREEN_TYPE].Locked = true;
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
        private void txtFind_TextChanged(object sender, EventArgs e)
        {
            LoadData(txtFind.Text);
        }

        private void btnClearScreen_Click(object sender, EventArgs e)
        {
            try
            {
                // show confirm message
                switch (ShowConfirmMessage(Messages.eConfirm.CFM9005))
                {
                    case MessageDialogResult.Cancel:
                        return;

                    case MessageDialogResult.No:
                        return;

                    case MessageDialogResult.Yes:
                        break;

                }
                List<ScreenImportUIDM> UIDMList = new List<ScreenImportUIDM>();
                ScreenImportController SIC = new ScreenImportController();
                int row = shtScreenList.Rows.Count;
                for (int i = 0; i < row; i++)
                {
                    if (shtScreenList.Cells[i, (int)eColView.SEL].Text == "True")
                    {
                        ScreenImportUIDM uidm = new ScreenImportUIDM();
                        uidm.ScreenCD.Value = shtScreenList.Cells[i, (int)eColView.SCREEN_CD].Text;
                        uidm.ScreenName.Value = shtScreenList.Cells[i, (int)eColView.SCREEN_NAME].Text;
                        uidm.ScreenType.Value = shtScreenList.Cells[i, (int)eColView.SCREEN_TYPE].Value;
                        uidm.ImportStatus.Value = shtScreenList.Cells[i, (int)eColView.IMPORT_STATUS].Text;
                        UIDMList.Add(uidm);
                    }
                }
                SIC.ClearData(UIDMList);
                MessageDialog.ShowInformation(this, "Information", new EVOFramework.Message(Messages.eInformation.INF9002.ToString()).MessageDescription);
                UpdateImportStatus(false);
            }
            catch (ValidateException err)
            {
                for (int i = 0; i < err.ErrorResults.Count; i++)
                {
                    MessageBox.Show(err.ErrorResults[i].Message.MessageDescription);
                    err.ErrorResults[i].FocusOnControl();
                }
                CommonLib.Common.CurrentDatabase.Rollback();
            }
            catch (BusinessException err)
            {
                MessageBox.Show(err.Error.Message.MessageDescription);
                CommonLib.Common.CurrentDatabase.Rollback();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                CommonLib.Common.CurrentDatabase.Rollback();
            }
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int row = shtScreenList.Rows.Count;
            for (int i = 0; i < row; i++)
            {
                shtScreenList.Cells[i, (int)eColView.SEL].Value = true;
            }
        }

        private void selectNoneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int row = shtScreenList.Rows.Count;
            for (int i = 0; i < row; i++)
            {
                shtScreenList.Cells[i, (int)eColView.SEL].Value = false;
            }
        }

        private void invertSelectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int row = shtScreenList.Rows.Count;
            for (int i = 0; i < row; i++)
            {
                if (Convert.ToBoolean(shtScreenList.Cells[i, (int)eColView.SEL].Value) == true)
                    shtScreenList.Cells[i, (int)eColView.SEL].Value = false;
                else
                    shtScreenList.Cells[i, (int)eColView.SEL].Value = true;
            }
        }

        private void btnReImport_Click(object sender, EventArgs e)
        {

            // Import ข้อมูลใหม่เข้าทุกตัว
            // set Is_used เพื่อดูว่าตัวไหนไม่ได้ใช้
            // ถ้ามีข้อมูลอยู่แล้วจะไม่ update ใน db (ยกเว้น default language จะ update ให้เท่ากับหน้า design

            try
            {
                // show confirm message
                switch (ShowConfirmMessage(Messages.eConfirm.CFM9004))
                {
                    case MessageDialogResult.Cancel:
                        return;

                    case MessageDialogResult.No:
                        return;

                    case MessageDialogResult.Yes:
                        break;

                }
                List<ScreenImportUIDM> UIDMList = new List<ScreenImportUIDM>();
                ScreenImportController SIC = new ScreenImportController();
                List<ScreenDetailUIDM> UIDMScreenDetailList = new List<ScreenDetailUIDM>();
                int row = shtScreenList.Rows.Count;
                for (int i = 0; i < row; i++)
                {

                    ScreenImportUIDM uidm = new ScreenImportUIDM();
                    uidm.ScreenCD.Value = shtScreenList.Cells[i, (int)eColView.SCREEN_CD].Text;
                    uidm.ScreenName.Value = shtScreenList.Cells[i, (int)eColView.SCREEN_NAME].Text;
                    uidm.ScreenType.Value = (int)Enum.Parse(typeof(eScreenType), shtScreenList.Cells[i, (int)eColView.SCREEN_TYPE].Text, true);
                    uidm.ImportStatus.Value = shtScreenList.Cells[i, (int)eColView.IMPORT_STATUS].Text;
                    uidm.OriginalTitle.Value = shtScreenList.Cells[i, (int)eColView.SCREEN_NAME].Text;
                    UIDMList.Add(uidm);
                }

                foreach (ScreenImportUIDM screenUIDM in UIDMList)
                {
                    // get screen detail from screen cd
                    //Hashtable hshScreenDetails = GetScreenDetail(screenUIDM.ScreenCD.StrongValue);

                    //if (screenUIDM.ScreenCD.StrongValue == "INV040")
                    //{
                    //    string s = "";
                    //}
                    
                    Map<string, ScreenDetail> mapControl = GetScreenDetail(screenUIDM.ScreenCD.StrongValue);


                    for (int i = 0; i < mapControl.Count; i++)
                    {
                        ScreenDetail screendetail = mapControl[i].Value;
                        //if (SIC.IsScreenDetailAlreadyExist(screenUIDM.ScreenCD.StrongValue, screendetail.Name))
                        //{
                        //    continue;
                        //}
                        ScreenDetailUIDM screenDetailUIDM = new ScreenDetailUIDM();
                        screenDetailUIDM.ScreenCD = screenUIDM.ScreenCD;
                        screenDetailUIDM.ControlType.Value = screendetail.Type;// control.GetType().Name;
                        screenDetailUIDM.ControlCD.Value = screendetail.Name;
                        screenDetailUIDM.ControlCaption.Value = screendetail.Text;
                        screenDetailUIDM.OriginalTitle.Value = screendetail.Text;
                        UIDMScreenDetailList.Add(screenDetailUIDM);
                    }
                }
                SIC.ReImportData(UIDMList, UIDMScreenDetailList);
                MessageDialog.ShowInformation(this, "Information", new EVOFramework.Message(Messages.eInformation.INF9001.ToString()).MessageDescription);
                UpdateImportStatus(true);
            }
            catch (ValidateException err)
            {
                for (int i = 0; i < err.ErrorResults.Count; i++)
                {
                    MessageBox.Show(err.ErrorResults[i].Message.MessageDescription);
                    err.ErrorResults[i].FocusOnControl();
                }
                if (CommonLib.Common.CurrentDatabase.DBTransactionState == EVOFramework.Database.TransactionState.PROCESSING)
                    CommonLib.Common.CurrentDatabase.Rollback();
            }
            catch (BusinessException err)
            {
                MessageBox.Show(err.Error.Message.MessageDescription);
                if (CommonLib.Common.CurrentDatabase.DBTransactionState == EVOFramework.Database.TransactionState.PROCESSING)
                    CommonLib.Common.CurrentDatabase.Rollback();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                if (CommonLib.Common.CurrentDatabase.DBTransactionState == EVOFramework.Database.TransactionState.PROCESSING)
                    CommonLib.Common.CurrentDatabase.Rollback();
            }
        }
    }
}
