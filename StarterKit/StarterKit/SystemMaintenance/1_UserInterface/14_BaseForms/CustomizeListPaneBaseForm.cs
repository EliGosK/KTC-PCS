using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FarPoint.Win.Spread;

namespace SystemMaintenance.Forms
{
    public partial class CustomizeListPaneBaseForm : CustomizeBaseForm
    {
        public CustomizeListPaneBaseForm()
        {
            InitializeComponent();

        }

        #region Protected methods
        /// <summary>
        /// Hide screen pane.
        /// </summary>
        protected void HidePane()
        {
            InternalVariable.MenuFrame_Instance.HideScreenPane();
        }

        /// <summary>
        /// Show screen pane.
        /// </summary>
        protected void ShowPane()
        {
            InternalVariable.MenuFrame_Instance.ShowScreenPane();
        }

        protected void ShowMultiSortDialog(SheetView spreadSheet)
        {
            MultiColumnSorting mcs = new MultiColumnSorting(spreadSheet);
            DialogResult dr = mcs.ShowDialog();

            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                spreadSheet.SortRows(0, spreadSheet.RowCount, mcs.SortingInfo);
            }
        }

        protected void ShowAdvanceSearchDialog(SheetView spreadSheet, Type enumType, DataTable data)
        {
            AdvanceSearchDialog ads = new AdvanceSearchDialog(spreadSheet, enumType, data);
            DialogResult dr = ads.ShowDialog();

            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                
            }
        }

        #endregion

        #region Permission Control
        public virtual void PermissionControl()
        {
            if (!DesignMode)
            {
                //CommonLib.CtrlUtil.EnabledControl(UserPermission.Edit, tsbExport);
                CommonLib.CtrlUtil.EnabledControl(ActivePermission.Add, tsbNew);
            }

        }
        #endregion

        virtual public void OnRefresh()
        {

        }
        virtual public void OnShowAll()
        {

        }
        virtual public void OnAddNew()
        {

        }
        virtual public void OnExport()
        {
            if (fpExport != null)
            {
                ExportDialog frmExport = new ExportDialog(fpExport);

                frmExport.ShowDialog(this);
            }

        }
        virtual public void OnExit()
        {
            HidePane();
        }

        virtual public void OnSorting()
        {

        }

        virtual public void OnSaveFormat()
        {

        }

        virtual public void OnResetFormat()
        {

        }

        virtual public void OnAdvanceSearch()
        {

        }

        private void CustomizeListPaneBaseForm_Shown(object sender, EventArgs e)
        {
            PermissionControl();
        }

        private void tsbRefresh_Click(object sender, EventArgs e)
        {
            OnRefresh();
        }

        private void tsbShowAll_Click(object sender, EventArgs e)
        {
            OnShowAll();
        }

        private void tsbNew_Click(object sender, EventArgs e)
        {
            OnAddNew();
        }

        private void tsbExport_Click(object sender, EventArgs e)
        {
            OnExport();
        }

        private void tsbExit_Click(object sender, EventArgs e)
        {
            OnExit();
        }

        private void tspSorting_Click(object sender, EventArgs e)
        {
            OnSorting();
        }

        FarPoint.Win.Spread.FpSpread fpExport;
        /// <summary>
        /// Get or set raw value.
        /// </summary>
        [Browsable(true)]
        public FarPoint.Win.Spread.FpSpread ExportObject
        {
            get
            {
                return fpExport;
            }
            set
            {
                fpExport = value == null ? null : value;
            }
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
