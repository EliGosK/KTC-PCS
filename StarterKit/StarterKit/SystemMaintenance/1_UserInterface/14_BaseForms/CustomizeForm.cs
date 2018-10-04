using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EVOFramework.Windows.Forms;

namespace SystemMaintenance.Forms
{
    public partial class CustomizeForm : CustomizeBaseForm
    {
        #region Constructor
        public CustomizeForm()
        {
            InitializeComponent();
        }
        #endregion

        #region Button Click
        private void tsbSaveAndNew_Click(object sender, EventArgs e)
        {
            OnSaveAndNew();
        }
        private void tsbSaveAndClose_Click(object sender, EventArgs e)
        {
            OnSaveAndClose();
        }
        #endregion

        #region Raise event onclick of ToolBar button
        public virtual void OnSaveAndNew() { }
        public virtual void OnSaveAndClose() { }

        virtual public void OnSaveFormat()
        {

        }

        virtual public void OnResetFormat()
        {

        }
        #endregion

        // Add by Pongthorn S. @ 2012-05-09
        #region Raise event for screen
        virtual public void ClearScreen() { }
        virtual public void ValidateBeforeAdd() { }
        virtual public void ValidateBeforeEdit() { }
        virtual public void ClearScreenAfterSave() { }
        virtual public void SetScreenMode() { }
        // End Add.
        #endregion

        #region Raise event for initial event
        virtual public void InitialComboBox() { }
        virtual public void InitialSpread() { }
        virtual public void InitialFormat() { }
        #endregion
        #region Permission Control
        public virtual void PermissionControl()
        {
            if (!DesignMode)
            {
                if (!(ActivePermission.Edit || ActivePermission.Add))
                {
                    CommonLib.CtrlUtil.EnabledControl(false, Controls);
                }
                tsbSaveAndClose.Enabled = ActivePermission.Edit || ActivePermission.Add;
                tsbSaveAndNew.Enabled = ActivePermission.Edit || ActivePermission.Add;
            }

        }
        #endregion



        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);

            if (e.Control && e.Shift && e.KeyCode == Keys.Enter)
            {
                OnSaveAndClose();
            }
            else if (e.Control && e.KeyCode == Keys.Enter)
            {
                OnSaveAndNew();
            }
        }
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
        }
        protected override void OnKeyUp(KeyEventArgs e)
        {
            base.OnKeyUp(e);
        }

        private void CustomizeForm_Shown(object sender, EventArgs e)
        {
            PermissionControl();
        }

        private void CustomizeForm_Load(object sender, EventArgs e)
        {

        }

        private void tsbDefaultSize_Click(object sender, EventArgs e)
        {
            OnResetFormat();
        }

        private void tsbSaveFormat_Click(object sender, EventArgs e)
        {
            OnSaveFormat();
        }
    }
}
