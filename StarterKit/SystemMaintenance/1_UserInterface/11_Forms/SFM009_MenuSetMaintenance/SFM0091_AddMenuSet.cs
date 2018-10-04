using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using EVOFramework.Windows.Forms;
using SystemMaintenance.Controller;
using EVOFramework;
using SystemMaintenance.UIDataModel;

namespace SystemMaintenance.Forms
{
    public partial class SFM0091_AddMenuSet : CustomizeBaseForm
    {
        public SFM0091_AddMenuSet()
        {
            InitializeComponent();
        }

        private void txtMenuSetCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != (char)Keys.Return)
                return;

            CommonLib.CtrlUtil.SetNextControl(sender, e);
        }

        private void txtMenuSetDesc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != (char)Keys.Return)
                return;

            CommonLib.CtrlUtil.SetNextControl(sender, e);
        }

        private void btnSave_Click(object sender, EventArgs e)
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
               
                MenuSetMaintenanceController ctlMenuSet = new MenuSetMaintenanceController();
                MenuSetMaintenanceUIDM uidmMenuSet = dmcAddMenuSet.SaveData(new  MenuSetMaintenanceUIDM());
                ctlMenuSet.AddNewMenuSet(uidmMenuSet);

                
                this.Close();
            }
            catch (ValidateException err)
            {
                for (int i = 0; i < err.ErrorResults.Count; i++)
                {
                    MessageDialog.ShowBusiness(this,err.ErrorResults[i].Message.MessageDescription);
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SFM0091_AddMenuSet_Load(object sender, EventArgs e)
        {
            dmcAddMenuSet.AddControl(txtMenuSetCode);
            dmcAddMenuSet.AddControl(txtMenuSetDesc);
        }
    }
}
