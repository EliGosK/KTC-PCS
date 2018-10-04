using System;
using SystemMaintenance.Controller;
using System.Data;
using CommonLib;

namespace SystemMaintenance.Forms
{
    public partial class CustomizeListPaneForm : CustomizeListPaneBaseForm
    {

        public CustomizeListPaneForm()
        {
            InitializeComponent();

        }

        #region Virtual operation.
        ///// <summary>
        ///// Overriden this method for AddNew operation.
        ///// </summary>
        //public virtual void OnAdd() { }

        ///// <summary>
        ///// Override this method to close this form.
        ///// </summary>
        //public virtual void OnExit()
        //{
        //    this.Close();
        //    HidePane();
        //}

        public virtual void PermissionControl()
        {
            //if (!UserPermission.View)
            //{
            //    EVOFramework.Windows.Forms.MessageDialog.ShowInformation(this, "Permissionn Control"
            //        , EVOFramework.Message.LoadMessage(Messages.eInformation.INF9004.ToString()).MessageDescription);
            //    OnExit();
            //    return;
            //}

            tsbNew.Enabled = ActivePermission.Add;
           // if (!UserPermission.View)
            //    OnExit();
            //  if (!UserPermission.Add)
            
        }
        #endregion

        #region Control events
        
        //private void tsbAdd_Click(object sender, EventArgs e)
        //{
        //    OnAdd();
        //}
        //private void tsbExit_Click(object sender, EventArgs e)
        //{
        //    OnExit();
        //}
        #endregion

        private void CustomizeListPaneForm_Shown(object sender, EventArgs e)
        {
            PermissionControl();
        }
    }


}
