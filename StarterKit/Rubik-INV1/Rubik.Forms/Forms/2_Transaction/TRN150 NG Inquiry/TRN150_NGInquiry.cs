using System;
using System.Collections.Generic;
using System.Data;
using SystemMaintenance.Forms;
using CommonLib;
using EVOFramework.Windows.Forms;
using Rubik.BIZ;
using Rubik.Controller;
using EVOFramework;
using Rubik.DTO;
using System.Windows.Forms;
using EVOFramework.Data;
using Rubik.Validators;

namespace Rubik.Inventory
{
    //[Screen("TRN150", "NG Inquiry", eShowAction.Normal, eScreenType.Screen, "NG Inquiry")]
    public partial class TRN150_NGInquiry : CustomizeInquiryForm
    {
        #region Enum
        public enum eColumns
        {
            ITEM_CD,
            ITEM_DESC,
            SHORT_NAME,
            LOT_NO,
            TRANS_DATE,
            SHIFT_CLS,
            NG_QTY,
            NG_REASON,
            WO_NO,
            REMARK,
            TRAN_SUB_CLS
        }
        #endregion

        #region Variable
        private DataTable m_dtAllData;
        #endregion

        #region Constructor

        public TRN150_NGInquiry()
        {
            InitializeComponent();
        }

        #endregion

        #region Overriden Method

        public override void OnExport()
        {
            base.OnExport();
            ExportDialog frmExport = new ExportDialog(fpView);

            frmExport.ShowDialog(this);
        }

        #endregion

        #region From Load

        private void TRN150_NGInquiry_Load(object sender, EventArgs e)
        {

            dtPeriodBegin.Format = Common.CurrentUserInfomation.DateFormatString;
            dtPeriodEnd.Format = Common.CurrentUserInfomation.DateFormatString;

            InitialSpread();

            LoadDefaultPeriod();
            RefreshSpreadColumn();
        }

        private void InitialSpread()
        {
            shtView.ActiveSkin = Common.ACTIVE_SKIN;
            LookupDataBIZ biz = new LookupDataBIZ();
            LookupData shiftLookupData = biz.LoadLookupClassType(DataDefine.SHIFT_CLS.ToNZString());
            shtView.Columns[(int)eColumns.SHIFT_CLS].CellType = CtrlUtil.CreateReadOnlyPairCellType(shiftLookupData);
            LookupData workresultLookupData = biz.LoadLookupClassType(DataDefine.TRAN_SUB_CLS.ToNZString());
            shtView.Columns[(int)eColumns.TRAN_SUB_CLS].CellType = CtrlUtil.CreateReadOnlyPairCellType(workresultLookupData);

            shtView.Columns[(int)eColumns.TRANS_DATE].CellType = CtrlUtil.CreateDateTimeCellType();
        }
        #endregion

        #region Botton Click
        private void btlFind_Click(object sender, EventArgs e)
        {

            LoadData(dtPeriodBegin.NZValue, dtPeriodEnd.NZValue, txtItemFrom.ToNZString(), txtItemTo.ToNZString(), txtLotNumber.ToNZString());
        }
        #endregion

        #region LoadData
        private void LoadData(NZDateTime FromPeriod, NZDateTime ToPeriod, NZString ItemFrom, NZString ItemTo, NZString LotNo)
        {
            try
            {
                if (ItemFrom == "")
                    ItemFrom = null;
                if (ItemTo == "")
                    ItemTo = null;

                bool GroupByItem = rdoGroupItem.Checked;

                NGInquiryController ctlInvent = new NGInquiryController();
                List<NGInquiryViewDTO> dto = ctlInvent.LoadNGInquiry(FromPeriod, ToPeriod, ItemFrom, ItemTo, GroupByItem, LotNo);
                if (dto.Count == 0)
                {
                    MessageDialog.ShowBusiness(this, new EVOFramework.Message(TKPMessages.eInformation.INF0001.ToString()));
                    return;
                }

                m_dtAllData = DTOUtility.ConvertListToDataTable(dto);
                DataTable dtView = m_dtAllData.Clone();
                foreach (DataRow dr in m_dtAllData.Rows)
                {
                    dtView.ImportRow(dr);
                }

                //Hide Column When ByGroupItem
                RefreshSpreadColumn();

                fpView.DataSource = dtView;
                CtrlUtil.MappingDataFieldWithEnum(shtView, typeof(eColumns));

            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusiness(this, ex.Message);
            }
        }
        private void LoadDefaultPeriod()
        {
            InventoryPeriodBIZ biz = new InventoryPeriodBIZ();
            InventoryPeriodDTO dto = biz.LoadCurrentPeriodWithQueryRange();
            dtPeriodBegin.NZValue = dto.PERIOD_BEGIN_DATE;
            dtPeriodEnd.NZValue = dto.PERIOD_END_DATE;
        }

        private void RefreshSpreadColumn()
        {
            if (rdoGroupItem.Checked == true)
            {
                shtView.Columns[(int)eColumns.LOT_NO].Visible = false;
                shtView.Columns[(int)eColumns.TRANS_DATE].Visible = false;
                shtView.Columns[(int)eColumns.SHIFT_CLS].Visible = false;
                shtView.Columns[(int)eColumns.WO_NO].Visible = false;
                shtView.Columns[(int)eColumns.REMARK].Visible = false;
                shtView.Columns[(int)eColumns.NG_REASON].Visible = false;
                shtView.Columns[(int)eColumns.TRAN_SUB_CLS].Visible = false;

            }
            else
            {
                shtView.Columns[(int)eColumns.LOT_NO].Visible = true;
                shtView.Columns[(int)eColumns.TRANS_DATE].Visible = true;
                shtView.Columns[(int)eColumns.SHIFT_CLS].Visible = true;
                shtView.Columns[(int)eColumns.WO_NO].Visible = true;
                shtView.Columns[(int)eColumns.REMARK].Visible = true;
                shtView.Columns[(int)eColumns.NG_REASON].Visible = true;
                shtView.Columns[(int)eColumns.TRAN_SUB_CLS].Visible = true;
            }
        }

        #endregion

        private void rdoGroupItem_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void fpView_KeyDown(object sender, KeyEventArgs e)
        {
            CtrlUtil.FilterShortCut(e);
        }
    }
}