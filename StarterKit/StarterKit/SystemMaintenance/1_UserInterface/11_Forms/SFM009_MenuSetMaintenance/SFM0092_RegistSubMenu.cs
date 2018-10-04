using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using EVOFramework;
using EVOFramework.Windows.Forms;
using SystemMaintenance.Controller;

namespace SystemMaintenance.Forms
{
    public partial class SFM0092_RegistSubMenu : CustomizeBaseForm
    {
        enum eColMenuSub
        {
            SEL,
            MENU_SUB_CD,
            MENU_SUB_NAME
        }
        string m_MenuSetCD;
        public SFM0092_RegistSubMenu(string menuSetCD)
        {
            InitializeComponent();
            m_MenuSetCD = menuSetCD;
        }

        private void SFM0092_RegistSubMenu_Load(object sender, EventArgs e)
        {
            InitialScreen();
        }

        private void InitialScreen()
        {
            //txtFind.KeyPress += CommonLib.CtrlUtil.SetRestrictKeyInput;
            //txtFind.KeyUp += CommonLib.CtrlUtil.FilterRestrictChar;
            shtMenuSub.ActiveSkin = CommonLib.Common.ACTIVE_SKIN;

            shtMenuSub.Columns[(int)eColMenuSub.MENU_SUB_CD].DataField = "MENU_SUB_CD";
            shtMenuSub.Columns[(int)eColMenuSub.MENU_SUB_NAME].DataField = "MENU_SUB_NAME";

            LoadData(m_MenuSetCD, string.Empty);
        }

        private void LoadData(string menuSetCD, string keyFilter)
        {
            try
            {
                MenuSetMaintenanceController ctlMenuSet = new MenuSetMaintenanceController();
                DataTable dtMenuSub = ctlMenuSet.LoadAllMenuSubNotInMenuSet(menuSetCD);
                DataTable dtView = dtMenuSub.Clone();

                if (keyFilter != string.Empty)
                {
                    //get only the rows you want
                    DataRow[] results = dtMenuSub.Select(string.Format("MENU_SUB_CD LIKE '%{0}%' OR MENU_SUB_NAME LIKE '%{0}%' ", keyFilter));

                    //populate new destination table
                    foreach (DataRow dr in results)
                        dtView.ImportRow(dr);
                }
                else
                {
                    foreach (DataRow dr in dtMenuSub.Rows)
                        dtView.ImportRow(dr);
                }

                shtMenuSub.DataSource = dtView;

            }
            catch (ValidateException err)
            {
                for (int i = 0; i < err.ErrorResults.Count; i++)
                {
                    MessageDialog.ShowBusiness(this, err.ErrorResults[i].Message.MessageDescription);
                    err.ErrorResults[i].FocusOnControl();
                }
                if (CommonLib.Common.CurrentDatabase.DBTransactionState == EVOFramework.Database.TransactionState.PROCESSING)
                    CommonLib.Common.CurrentDatabase.Rollback();
            }
            catch (BusinessException err)
            {
                MessageDialog.ShowBusiness(this, err.Error.Message.MessageDescription);
                if (CommonLib.Common.CurrentDatabase.DBTransactionState == EVOFramework.Database.TransactionState.PROCESSING)
                    CommonLib.Common.CurrentDatabase.Rollback();
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusiness(this, ex.Message);
                if (CommonLib.Common.CurrentDatabase.DBTransactionState == EVOFramework.Database.TransactionState.PROCESSING)
                    CommonLib.Common.CurrentDatabase.Rollback();
            }
        }

        private void txtFind_TextChanged(object sender, EventArgs e)
        {
            LoadData(m_MenuSetCD, txtFind.Text.Trim());
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private MessageDialogResult ShowConfirmMessage(Messages.eConfirm msgCD)
        {
            // show confirm message
            MessageDialogResult dr = MessageDialog.ShowConfirmation(this, new EVOFramework.Message(msgCD.ToString()).MessageDescription);
            return dr;
        }
        private void btnRegist_Click(object sender, EventArgs e)
        {
            int row = shtMenuSub.Rows.Count;
            //int activeRow=shtMenuSub.ActiveRowIndex;
            bool isRowSelected = false;
            for (int i = 0; i < row; i++)
            {
                if (shtMenuSub.Cells[i, (int)eColMenuSub.SEL].Text == "True")
                {
                    isRowSelected = true;
                    break;
                }
            }

            if (!isRowSelected) return;

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
            try
            {
                MenuSetMaintenanceController ctlMenuSet = new MenuSetMaintenanceController();
                for (int i = 0; i < row; i++)
                {
                    if (shtMenuSub.Cells[i, (int)eColMenuSub.SEL].Text == "True")
                    {
                        string MenuSubCD = shtMenuSub.Cells[i, (int)eColMenuSub.MENU_SUB_CD].Text;
                        ctlMenuSet.AddMenuSetDetail(m_MenuSetCD, MenuSubCD);
                    }
                }
                this.Close();
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

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int row = shtMenuSub.Rows.Count;
            for (int i = 0; i < row; i++)
            {
                shtMenuSub.Cells[i, (int)eColMenuSub.SEL].Value = true;
            }
        }

        private void selectNoneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int row = shtMenuSub.Rows.Count;
            for (int i = 0; i < row; i++)
            {
                shtMenuSub.Cells[i, (int)eColMenuSub.SEL].Value = false;
            }
        }

        private void invertSelectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int row = shtMenuSub.Rows.Count;
            for (int i = 0; i < row; i++)
            {
                if (Convert.ToBoolean(shtMenuSub.Cells[i, (int)eColMenuSub.SEL].Value) == true)
                    shtMenuSub.Cells[i, (int)eColMenuSub.SEL].Value = false;
                else
                    shtMenuSub.Cells[i, (int)eColMenuSub.SEL].Value = true;
            }
        }
    }
}
