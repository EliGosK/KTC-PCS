using System;
using System.Windows.Forms;
using SystemMaintenance.Forms;
using EVOFramework;
using EVOFramework.Windows.Forms;
using Rubik.UIDataModel;
using Rubik.Controller;
using CommonLib;
using Rubik.Validators;
using EVOFramework.Data;
using Rubik.BIZ;
using Rubik.DTO;

namespace Rubik.Master
{
    //[Screen("MAS052", "Change Item", eShowAction.Normal, eScreenType.Dialog, "Change Item to BOM Setup")]
    public partial class MAS052_ChangeItem : MAS051_RegisterBOM
    {
        #region Variables

        private readonly BOMSetupViewDTO m_data = null;
        #endregion

        #region Constructor
        public MAS052_ChangeItem()
        {
            InitializeComponent();

            tsbAdd.Text = "Change";
        }              

        public MAS052_ChangeItem(BOMSetupViewDTO data) : base(data.UPPER_ITEM_CD.StrongValue) {
            InitializeComponent();

            tsbAdd.Text = "Change";

            m_data = data;
        }
        #endregion

        #region Form event
        private void MAS052_ChangeItem_Load(object sender, EventArgs e)
        {
            CtrlUtil.EnabledControl(false, txtItemCode, btnItemCode);

            txtItemCode.Text = m_data.LOWER_ITEM_CD.StrongValue;
            txtItemDesc.Text = m_data.LOWER_ITEM_DESC.StrongValue;
            txtUpperQty.PathValue = m_data.UPPER_QTY.NVL(1);
            txtLowerQty.PathValue = m_data.LOWER_QTY.NVL(1);
            //chkChildOrderLoc.Checked =  (Convert.ToString(m_data.CHILD_ORDER_LOC_CD.Value) == string.Empty);
            //if(!chkChildOrderLoc.Checked)
            //    cboOrderLoc.SelectedValue = m_data.CHILD_ORDER_LOC_CD.Value;
            //chkMRPFlag.Checked = (Convert.ToString(m_data.MRP_FLAG.Value) == string.Empty);
            //if(!chkMRPFlag.Checked)
            //    cboMRPFlag.SelectedValue = m_data.MRP_FLAG.Value;

            chkChildOrderLoc_CheckedChanged(this, null);
            chkMRPFlag_CheckedChanged(this, null);
        }

        private void MAS052_ChangeItem_Shown(object sender, EventArgs e)
        {
            CtrlUtil.FocusControl(txtUpperQty);
        }
        #endregion
    }
}
