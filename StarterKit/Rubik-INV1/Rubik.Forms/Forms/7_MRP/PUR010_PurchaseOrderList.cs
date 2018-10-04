using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using EVOFramework;
using EVOFramework.Data;
using EVOFramework.Windows.Forms;
using FarPoint.Win.Spread.Model;
using Rubik.BIZ;
using CommonLib;
using Rubik.Controller;
using Rubik.DTO;
using SystemMaintenance;
using Message = EVOFramework.Message;
using Rubik.Validators;
using Rubik.Data;

namespace Rubik.MRP
{
    //[Screen("PUR010", "Purchase Order List", eShowAction.Normal, eScreenType.ScreenPane, "Purchase Order List")]
    public partial class PUR010_PurchaseOrderList : SystemMaintenance.Forms.CustomizeListPaneBaseForm
    {
        private void PUR010_Load(object sender, EventArgs e)
        {
            InventoryPeriodBIZ biz = new InventoryPeriodBIZ();
            InventoryPeriodDTO dto = biz.LoadCurrentPeriodWithQueryRange();
            dtPeriodBegin.NZValue = dto.PERIOD_BEGIN_DATE;
            dtPeriodEnd.NZValue = dto.PERIOD_END_DATE;
            dtPeriodBegin.Format = Common.CurrentUserInfomation.DateFormatString;
            dtPeriodEnd.Format = Common.CurrentUserInfomation.DateFormatString;

            shtView.Columns[(int)eColumn.DUE_DATE].CellType = CtrlUtil.CreateDateTimeCellType();
            shtView.Columns[(int)eColumn.PO_DATE].CellType = CtrlUtil.CreateDateTimeCellType();

            this.m_dtShown = m_BizPurchaseOrder.LoadPurchaseOrderDByPONo(Convert.ToDateTime(dtPeriodBegin.Value), Convert.ToDateTime(dtPeriodEnd.Value));
            ShowSheet(this.m_dtShown);

            SetSpreadBGColor();
            SetContextMenu();
        }

        #region Enum
        public enum eColumn
        {
            PO_LINE,
            CRT_BY,
            CRT_DATE,
            CRT_MACHINE,
            UPD_BY,
            UPD_DATE,
            UPD_MACHINE,         
            PO_NO,
            PO_TYPE,
            PO_DATE,
            SUPPLIER_CD,
            SUPPLIER_NAME,
            ADDRESS,
            DELIVERY_TO,
            CURRENCY,
            VAT_TYPE,
            VAT_RATE,
            TERM_OF_PAYMENT,
            IS_EXPORT,           
            REMARK,
            ITEM_CD,
            ITEM_DESC,
            DUE_DATE,
            UNIT_PRICE,
            PO_QTY,
            UNIT,
            AMOUNT,
            RECEIVE_QTY,
            STATUS,
            IS_ACTIVE,
        };
        #endregion

        #region Variables
        private PurchaseOrderBIZ m_BizPurchaseOrder;
        private DataTable m_dtShown;
        #endregion

        #region Constructor
        public PUR010_PurchaseOrderList()
        {
            InitializeComponent();
            InitialScreen();
            
            m_BizPurchaseOrder = new PurchaseOrderBIZ();
        }
        #endregion

        #region Event Handler
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (DataDefine.ENABLED_AUTO_SEARCH_WHEN_TEXT_CHANGED)
            {
                FindDataFromMemory();
            }
        }
        
        private void fpView_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            OpenPurchaseOrderEntry(GeneratePurchaseOrderHDTO());     
        }
        private void fpView_EnterCell(object sender, FarPoint.Win.Spread.EnterCellEventArgs e)
        {
            if (ctxMenu.Items.Count > 1)
            {
                ctxMenu.Items[1].Enabled = Convert.ToBoolean(shtView.Cells[e.Row, (int)eColumn.IS_ACTIVE].Value);
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenPurchaseOrderEntry(GeneratePurchaseOrderHDTO());
        }
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            switch (MessageDialog.ShowConfirmation(this, new EVOFramework.Message(Messages.eConfirm.CFM9002.ToString()).MessageDescription))
            {
                case MessageDialogResult.Cancel:
                    return;
                case MessageDialogResult.No:
                    return;
                case MessageDialogResult.Yes:                   
                    break;
            }
            try
            {
                DeletePO();
            }
            catch (BusinessException err)
            {
                MessageDialog.ShowBusiness(this, err.Error.Message);
                err.Error.FocusOnControl();
            }
            catch (ValidateException err)
            {
                MessageDialog.ShowBusiness(this, err.ErrorResults[0].Message);
                err.ErrorResults[0].FocusOnControl();
            }
        }
        #endregion

        #region Override Method
        public override void OnRefresh()
        {
            // ค้นหา PO ตามเงื่อนไข           
            DateTime dtmBegin = Convert.ToDateTime(dtPeriodBegin.Value);
            DateTime dtmEnd = Convert.ToDateTime(dtPeriodEnd.Value);
            bool bIncludeCancelPO = chkIncludeCancel.Checked;

            DataTable dtSearchData = m_BizPurchaseOrder.LoadPurchaseOrderDByPONoWithCriteria(dtmBegin, dtmEnd, bIncludeCancelPO);
            m_dtShown = dtSearchData;

            shtView.RowCount = 0;
            // Filter ข้อมูลตาม textbox
            shtView.DataSource = FilterData(m_dtShown, txtSearch.Text);
            CtrlUtil.SpreadUpdateColumnSorting(shtView);

            SetSpreadBGColor();
            SetContextMenu();
        }
        public override void OnAddNew()
        {
            //MRP040_PurchaseOrderEntry dialog = new MRP040_PurchaseOrderEntry();
            //dialog.ShowDialog(this );
            OpenPurchaseOrderEntry(null);
        }
        #endregion

        #region Private Method
        private void InitialScreen()
        {
            #region set hidden column to spsheet
            shtView.ActiveSkin = Common.ACTIVE_SKIN;
            int[] iHideIndex = {
                                   (int)eColumn.PO_LINE,
                                   (int)eColumn.CRT_BY,
                                   (int)eColumn.CRT_DATE,
                                   (int)eColumn.CRT_MACHINE,
                                   (int)eColumn.UPD_BY,
                                   (int)eColumn.UPD_DATE,
                                   (int)eColumn.UPD_MACHINE,
                                   //(int)eColumn.STATUS,
                                   (int)eColumn.PO_TYPE,
                                   (int)eColumn.ADDRESS,
                                   (int)eColumn.VAT_TYPE,
                                   (int)eColumn.VAT_RATE,
                                   (int)eColumn.TERM_OF_PAYMENT,
                                   (int)eColumn.REMARK,
                                   (int)eColumn.IS_EXPORT,
                               };
            for (int iRow = 0; iRow < iHideIndex.Length; iRow++)
                shtView.Columns[iHideIndex[iRow]].Visible = false;
            #endregion

            CtrlUtil.MappingDataFieldWithEnum(shtView, typeof(eColumn));

     
            dtPeriodEnd.KeyPress += CtrlUtil.SetNextControl;
            dtPeriodBegin.KeyPress += CtrlUtil.SetNextControl;
            chkIncludeCancel.KeyPress += CtrlUtil.SetNextControl;
        }
        private DataTable FilterData(DataTable dtView, string filterText)
        {
            try
            {
                if (filterText.Trim() == String.Empty)
                    return dtView;

                string[] colNames = Enum.GetNames(typeof(eColumn));
                string filterString = string.Empty;

                for (int i = 0; i < colNames.Length; i++)
                {
                    filterString += string.Format(@"CONVERT({0},'System.String') LIKE '%{1}%' ", colNames[i], filterText);
                    if (i != colNames.Length - 1)
                        filterString += " OR ";
                }

                //get only the rows you want
                DataRow[] results = this.m_dtShown.Select(filterString);
                DataTable dtFilter = dtView.Clone();

                //populate new destination table
                foreach (DataRow dr in results)
                    dtFilter.ImportRow(dr);

                return dtFilter;
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusiness(this, ex.Message);
            }
            return null;
        }
        private void ShowSheet(DataTable dtShown)
        {
            try
            {
                shtView.Rows.Count = 0;
                DataTable dtbPurchaseOrder = dtShown;
                if (dtbPurchaseOrder.Rows.Count > 0)
                {
                    shtView.DataSource = dtbPurchaseOrder;
                }
            }
            catch (BusinessException err)
            {
                MessageDialog.ShowBusiness(this, err.Error.Message);
                err.Error.FocusOnControl();
            }
            catch (ValidateException err)
            {
                MessageDialog.ShowBusiness(this, err.ErrorResults[0].Message);
                err.ErrorResults[0].FocusOnControl();
            }
        }
        private void SetSpreadBGColor()
        {
            for (int iRow = 0; iRow < shtView.RowCount; iRow++)
            {
                if (!Convert.ToBoolean(shtView.Cells[iRow, (int)eColumn.IS_ACTIVE].Value))
                    shtView.Rows[iRow].BackColor = System.Drawing.Color.Gray;
            }
        }
        private void SetContextMenu()
        {
            if (shtView.RowCount > 0 && ctxMenu.Items.Count < 2)
            {
                ctxMenu.Items.Add("Edit");
                ctxMenu.Items.Add("Delete");
                ctxMenu.Items[0].Click += new EventHandler(editToolStripMenuItem_Click);
                ctxMenu.Items[1].Click += new EventHandler(deleteToolStripMenuItem_Click);
            }
            if (shtView.RowCount == 0)
                ctxMenu.Items.Clear();
        }
        private void OpenPurchaseOrderEntry(PurchaseOrderHDTO dtoPurchaseOrder)
        {
            PUR020_PurchaseOrderEntry dialog = new PUR020_PurchaseOrderEntry(dtoPurchaseOrder);
            
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                OnRefresh();
            }
        }
        private void DeletePO()
        {
            int iActive = shtView.ActiveRowIndex;
            List<PurchaseOrderDDTO> dDTOPurchaseOrderList = new List<PurchaseOrderDDTO>();

            ValidateException.ThrowErrorItem(
                PurchaseOrderEntryValidation.CheckEmptyString(
                (NZString)Convert.ToString(shtView.Cells[iActive, (int)eColumn.PO_LINE].Value),
                Messages.eValidate.VLM0142));

            dDTOPurchaseOrderList.Add(new PurchaseOrderDDTO
            {
                PO_NO = (NZString)Convert.ToString(shtView.Cells[iActive, (int)eColumn.PO_NO].Value),

                PO_LINE = (NZDecimal)Convert.ToDecimal(shtView.Cells[iActive, (int)eColumn.PO_LINE].Value),

                RECEIVE_QTY = (NZDecimal)Convert.ToDecimal(shtView.Cells[iActive, (int)eColumn.RECEIVE_QTY].Value),
                ITEM_CD = (NZString)Convert.ToString(shtView.Cells[iActive, (int)eColumn.ITEM_CD].Value),
                DUE_DATE = (NZDateTime)Convert.ToDateTime(shtView.Cells[iActive, (int)eColumn.DUE_DATE].Value)
            });
            new PurchaseOrderBIZ().DeletePOLine(GeneratePurchaseOrderHDTO(), dDTOPurchaseOrderList);

            MessageDialog.ShowInformation(this, "Information", new EVOFramework.Message(Messages.eInformation.INF9003.ToString()).MessageDescription);
            OnRefresh();
        }
        private PurchaseOrderHDTO GeneratePurchaseOrderHDTO()
        {
            int iActive = shtView.ActiveRowIndex;
            return new PurchaseOrderHDTO
            {
                CRT_BY = (NZString)Convert.ToString(shtView.Cells[iActive, (int)eColumn.CRT_BY].Value),
                CRT_DATE = (NZDateTime)Convert.ToDateTime(shtView.Cells[iActive, (int)eColumn.CRT_DATE].Value),
                CRT_MACHINE = (NZString)Convert.ToString(shtView.Cells[iActive, (int)eColumn.CRT_MACHINE].Value),
                UPD_BY = (NZString)Convert.ToString(shtView.Cells[iActive, (int)eColumn.UPD_BY].Value),
                UPD_DATE = (NZDateTime)Convert.ToDateTime(shtView.Cells[iActive, (int)eColumn.UPD_DATE].Value),
                UPD_MACHINE = (NZString)Convert.ToString(shtView.Cells[iActive, (int)eColumn.UPD_MACHINE].Value),
                IS_ACTIVE = (NZBoolean)Convert.ToBoolean(shtView.Cells[iActive, (int)eColumn.IS_ACTIVE].Value),
                PO_NO = (NZString)Convert.ToString(shtView.Cells[iActive, (int)eColumn.PO_NO].Value),
                PO_TYPE = (NZString)Convert.ToString(shtView.Cells[iActive, (int)eColumn.PO_TYPE].Value),
                PO_DATE = (NZDateTime)Convert.ToDateTime(shtView.Cells[iActive, (int)eColumn.PO_DATE].Value),
                SUPPLIER_CD = (NZString)Convert.ToString(shtView.Cells[iActive, (int)eColumn.SUPPLIER_CD].Value),
                SUPPLIER_NAME = (NZString)Convert.ToString(shtView.Cells[iActive, (int)eColumn.SUPPLIER_NAME].Value),
                ADDRESS = (NZString)Convert.ToString(shtView.Cells[iActive, (int)eColumn.ADDRESS].Value),
                DELIVERY_TO = (NZString)Convert.ToString(shtView.Cells[iActive, (int)eColumn.DELIVERY_TO].Value),
                CURRENCY = (NZString)Convert.ToString(shtView.Cells[iActive, (int)eColumn.CURRENCY].Value),
                VAT_TYPE = (NZString)Convert.ToString(shtView.Cells[iActive, (int)eColumn.VAT_TYPE].Value),
                VAT_RATE = (NZDecimal)Convert.ToDecimal(shtView.Cells[iActive, (int)eColumn.VAT_RATE].Value),
                TERM_OF_PAYMENT = (NZString)Convert.ToString(shtView.Cells[iActive, (int)eColumn.TERM_OF_PAYMENT].Value),
                IS_EXPORT = (NZBoolean)Convert.ToBoolean(shtView.Cells[iActive, (int)eColumn.IS_EXPORT].Value),
                STATUS = (NZString)Convert.ToString(shtView.Cells[iActive, (int)eColumn.STATUS].Value),
                REMARK = (NZString)Convert.ToString(shtView.Cells[iActive, (int)eColumn.REMARK].Value)
            };
        }
        #endregion             

        private void fpView_KeyDown(object sender, KeyEventArgs e)
        {
            CtrlUtil.FilterShortCut(e);
        }

        private void FindDataFromMemory()
        {
            shtView.DataSource = FilterData(m_dtShown, txtSearch.Text);
            CtrlUtil.SpreadUpdateColumnSorting(shtView);

            SetSpreadBGColor();
            SetContextMenu();
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (DataDefine.ENABLED_AUTO_SEARCH_WHEN_PRESS_ENTER_KEY && e.KeyCode == Keys.Enter)
                FindDataFromMemory();
        }
    }
}
