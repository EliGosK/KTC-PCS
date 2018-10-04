using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FarPoint.Win.Spread;

namespace SystemMaintenance.Forms
{
    public partial class CustomizeInquiryForm : CustomizeBaseForm
    {
        public CustomizeInquiryForm()
        {
            InitializeComponent();
        }

        private void tsbExport_Click(object sender, EventArgs e)
        {
            OnExport();
        }

        public virtual void OnExport() { }

        public virtual void OnSaveFormat() { }

        public virtual void OnResetFormat() { }

        public virtual void OnAdvanceSearch() { }

        protected void ShowAdvanceSearchDialog(SheetView spreadSheet, Type enumType, DataTable data)
        {
            AdvanceSearchDialog ads = new AdvanceSearchDialog(spreadSheet, enumType, data);
            DialogResult dr = ads.ShowDialog();

            if (dr == System.Windows.Forms.DialogResult.OK)
            {

            }
        }

        #region Permission Control
        public virtual void PermissionControl()
        {
            //if (!DesignMode) {
            //    if (!ActivePermission.Edit) {
            //        CommonLib.CtrlUtil.EnabledControl(false, Controls);
            //    }
            //}

            //tsbSaveAndClose.Enabled = UserPermission.Edit;
            //tsbSaveAndNew.Enabled = UserPermission.Edit;
        }
        #endregion



        private void CustomizeInquiryForm_Shown(object sender, EventArgs e)
        {
            PermissionControl();
        }

        private void tsbDefaultSize_Click(object sender, EventArgs e)
        {
            OnResetFormat();
        }

        private void tsbSaveFormat_Click(object sender, EventArgs e)
        {
            OnSaveFormat();
        }

        private void tsbAdvanceSearch_Click(object sender, EventArgs e)
        {
            OnAdvanceSearch();
        }
    }
}
